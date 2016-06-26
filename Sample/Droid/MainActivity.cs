using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace FABSample.Droid
{
    [Activity(Label = "FABSample.Droid", MainLauncher = true)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var app = new FABSample.App();

            this.LoadApplication(app);
        }
    }
}