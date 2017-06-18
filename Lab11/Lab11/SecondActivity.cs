using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab11
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnCreate");
            base.OnCreate(bundle);
        }

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnResume");
            base.OnStart();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnPause");
            base.OnStart();
        }

        protected override void OnStop()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnStop");
            base.OnStart();
        }

        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnDestroy");
            base.OnStart();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnRestart");
            base.OnStart();
        }
    }
}