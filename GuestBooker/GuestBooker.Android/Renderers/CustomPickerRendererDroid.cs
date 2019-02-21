using System;
using Android.Content;
using Android.Graphics.Drawables;
using GuestBooker.Controls;
using GuestBooker.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRendererDroid))]
namespace GuestBooker.Droid.Renderers
{
    public class CustomPickerRendererDroid : PickerRenderer
    {
        public CustomPickerRendererDroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
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
                Control.SetPadding(20, 4, 0, 0);
            }
        }
    }
}
