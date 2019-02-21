using System;
using CoreGraphics;
using GuestBooker.Controls;
using GuestBooker.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRendererIOS))]
namespace GuestBooker.iOS.Renderers
{
    public class CustomPickerRendererIOS : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Layer.CornerRadius = 14f;
                Control.Layer.ShadowRadius = 14f;
                Control.Layer.BorderWidth = 1f;
                Control.Layer.BorderColor = Color.White.ToCGColor();
                Control.Layer.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 50).CGColor;

                Control.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
                Control.TextColor = Color.White.ToUIColor();

                // Padding
                Control.LeftView = new UIView(new CGRect(0, 0, 10, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIView(new CGRect(0, 0, 10, 0));
                Control.RightViewMode = UITextFieldViewMode.Always;
            }
        }
    }
}
