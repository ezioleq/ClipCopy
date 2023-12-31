using Android.App;
using Android.Content;
using Android.Util;
using Android.Widget;
using ClipCopy.Database;
using ClipCopy.Database.Models;
using ClipCopy.Resources.Localizations;
using Microsoft.EntityFrameworkCore;

namespace ClipCopy.Platforms.Android.Activities;

/// <summary>
/// Activity for receiving strings from other applications.
/// </summary>
[Activity(
    Label = "@string/clipboard",
    Name = $"com.ezioleq.{nameof(ReceiveTextActivity)}",
    Theme = "@style/Theme.Transparent",
    Exported = true
)]
[IntentFilter(
    new[]
    {
        Intent.ActionSend
    }, Categories = new[]
    {
        Intent.CategoryDefault
    },
    DataMimeType = Constants.SupportedMimeType
)]
public class ReceiveTextActivity : Activity
{
    private const string Tag = nameof(ReceiveTextActivity);
    private const string ClipboardLabel = "ClipCopy";

    protected override void OnStart()
    {
        base.OnStart();

        HandleIncomingIntent();
        Finish();
    }

    /// <summary>
    /// Handle the caller's incoming intent.
    /// </summary>
    private void HandleIncomingIntent()
    {
        if (Intent?.Action != Intent.ActionSend)
            return;

        var receivedText = GetReceivedIntentText();
        var clipboardSet = SetClipboardContent(receivedText);

        if (!clipboardSet)
            return;

        var toastMessage = string.Format(Localization.clipboard_copied, receivedText);
        ShowToast(toastMessage);

        Task.Run(async () => await RegisterClip(receivedText));
    }

    /// <summary>
    /// Get <see cref="Intent.ExtraText"/> value from the caller intent.
    /// </summary>
    /// <returns>Received text on success or <see cref="string.Empty"/> otherwise.</returns>
    private string GetReceivedIntentText()
    {
        if (Intent is null)
            return string.Empty;

        var text = Intent.GetStringExtra(Intent.ExtraText);

        if (string.IsNullOrEmpty(text))
            return string.Empty;

        return text;
    }

    /// <summary>
    /// Sets the clipboard content to the provided text.
    /// </summary>
    /// <param name="content">Text content to set as the primary clip content.</param>
    /// <returns>Whether the operation finished successfully.</returns>
    private bool SetClipboardContent(string content)
    {
        if (string.IsNullOrEmpty(content))
        {
            Log.Error(Tag, "Clipboard content string cannot be empty!");
            return false;
        }

        var clipboardService = (ClipboardManager?)global::Android.App.Application.Context.GetSystemService(ClipboardService);

        if (clipboardService is null)
        {
            ShowToast(Localization.clipboard_service_failed);

            Log.Error(Tag, "Failed to get ClipboardService");
            return false;
        }

        var clipData = ClipData.NewPlainText(ClipboardLabel, content);
        clipboardService.PrimaryClip = clipData;

        return true;
    }

    /// <summary>
    /// Show short toast with provided message content.
    /// </summary>
    /// <param name="message">Message to show on toast.</param>
    private void ShowToast(string message)
    {
        var toast = Toast.MakeText(this, message, ToastLength.Short);

        if (toast is null)
            Log.Error(Tag, $"Failed create toast message with content '{message}'");

        toast?.Show();
    }

    /// <summary>
    /// Register clip text in the database.
    /// </summary>
    /// <param name="clipText">Clipboard text to save.</param>
    private static async Task RegisterClip(string clipText)
    {
        var connectionString = DependencyService.Get<IConnectionString>();
        await using var dbContext = new DatabaseContext(connectionString);

        var previousEntry = await dbContext.ClipEntries.FirstOrDefaultAsync(entry => entry.TextContent == clipText);

        if (previousEntry is not null)
        {
            previousEntry.ModificationTimeUtc = DateTime.UtcNow;

            dbContext.Update(previousEntry);
            await dbContext.SaveChangesAsync();

            return;
        }

        var entry = new ClipEntry()
        {
            Id = new Guid(),
            TextContent = clipText,
            IsPinned = false,
            CreationTimeUtc = DateTime.UtcNow,
            ModificationTimeUtc = DateTime.UtcNow
        };

        await dbContext.AddAsync(entry);
        await dbContext.SaveChangesAsync();
    }
}
