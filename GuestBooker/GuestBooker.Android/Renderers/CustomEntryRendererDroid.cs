using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GuestBooker.Controls;
using GuestBooker.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRendererDroid))]
namespace GuestBooker.Droid.Renderers
{
    public class CustomEntryRendererDroid : EntryRenderer
    {
        public CustomEntryRendererDroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var nativeControl = Control;

            if (e.NewElement != null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(25f);
                gradientDrawable.SetColor(global::Android.Graphics.Color.ParseColor("#30000000"));
                gradientDrawable.SetStroke(1, Android.Graphics.Color.White);

                Control.SetBackground(gradientDrawable);
                Control.SetPadding(25, 4, 0, 0);
                Control.Gravity = GravityFlags.CenterVertical;
                //Control.TextAlignment = Android.Views.TextAlignment.Center;
            }
        }
    }
}