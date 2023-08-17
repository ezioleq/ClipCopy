using Android.Content;

namespace ClipCopy.Activities;

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
    protected override void OnStart()
    {
        base.OnStart();

        if (Intent?.Action != Intent.ActionSend)
            return;

        var text = Intent?.GetStringExtra(Intent.ExtraText) ?? "NOTHING";

        var clipboardService = (ClipboardManager)Application.Context.GetSystemService(ClipboardService)!;
        var clipData = ClipData.NewPlainText("clip", text);
        clipboardService.PrimaryClip = clipData;

        Toast.MakeText(this, $"Copied {text}", ToastLength.Short)!.Show();

        Finish();
    }
}
