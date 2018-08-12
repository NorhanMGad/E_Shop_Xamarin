using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using E_Shop_Xamarin.iOS.Renderers;
using E_Shop_Xamarin.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineLabelRenderer))]
namespace E_Shop_Xamarin.iOS.Renderers
{
    class UnderlineLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element != null)
            {
                var attrString = new NSMutableAttributedString(Control.Text);
                attrString.AddAttribute(UIStringAttributeKey.UnderlineStyle,
                                    NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                                    new NSRange(0, attrString.Length));

                Control.AttributedText = attrString;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null && Element != null)
            {
                var attrString = new NSMutableAttributedString(Control.Text);
                attrString.AddAttribute(UIStringAttributeKey.UnderlineStyle,
                                    NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                                    new NSRange(0, attrString.Length));

                Control.AttributedText = attrString;
            }
        }
    }
}