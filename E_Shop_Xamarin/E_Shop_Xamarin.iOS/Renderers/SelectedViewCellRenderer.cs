using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E_Shop_Xamarin.iOS.Renderers;
using E_Shop_Xamarin.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SelectedViewCell), typeof(SelectedViewCellRenderer))]
namespace E_Shop_Xamarin.iOS.Renderers
{
    public class SelectedViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as SelectedViewCell;
            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = view.SelectedBackgroundColor.ToUIColor(),
            };

            return cell;
        }
    }
}