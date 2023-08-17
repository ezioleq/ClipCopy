using Android.Content;

namespace ClipCopy.Activities;

[Activity(Name = $"com.ezioleq.{nameof(ReceiveTextActivity)}", Exported = true, Theme = "@style/Theme.Transparent")]
[IntentFilter(new[]
{
    Intent.ActionSend
}, Categories = new[]
{
    Intent.CategoryDefault
}, DataMimeType = "text/*")]
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
