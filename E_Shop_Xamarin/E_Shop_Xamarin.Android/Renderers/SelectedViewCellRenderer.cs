using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using E_Shop_Xamarin.Droid.Renderers;
using E_Shop_Xamarin.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SelectedViewCell), typeof(SelectedViewCellRenderer))]
namespace E_Shop_Xamarin.Droid.Renderers
{
    public class SelectedViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _cellCore;
        private Drawable _unselectedBackground;
        private bool _selected;

        protected override Android.Views.View GetCellCore(Cell item,
                                                          Android.Views.View convertView,
                                                          ViewGroup parent,
                                                          Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);

            _selected = false;
            _unselectedBackground = _cellCore.Background;

            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnCellPropertyChanged(sender, e);
                if (e.PropertyName == "IsSelected")
                {
                    _selected = !_selected;

                    if (_selected)
                    {
                        var extendedViewCell = sender as SelectedViewCell;
                        _cellCore.SetBackgroundColor(extendedViewCell.SelectedBackgroundColor.ToAndroid());
                    }
                    else
                    {
                        _cellCore.SetBackground(_unselectedBackground);
                    }
                }
            }
            catch
            {

            }
        }
        
    }
}