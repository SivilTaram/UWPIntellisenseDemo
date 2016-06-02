using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace UWPIntellisenseDemo
{
    public sealed class RichEditOwnBox : RichEditBox
    {
        public RichEditOwnBox()
        {
        }

        public double[] ResetPopupLocation()
        {
            Point point = new Point();
            this.Document.Selection.GetPoint(HorizontalCharacterAlignment.Left, VerticalCharacterAlignment.Top, PointOptions.None, out point);
            double defalutleft = Window.Current.CoreWindow.Bounds.Left;
            double defaluttop = Window.Current.CoreWindow.Bounds.Top;
            double left = point.X - defalutleft;
            double top = point.Y - defaluttop + this.FontSize + this.Padding.Top + 5;
            System.Diagnostics.Debug.Write("left:" + left + "top:" + top);
            return new double[] { left, top };
        }

    }
}
