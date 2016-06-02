using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPIntellisenseDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string send;
            StandardPopup.IsOpen = true;
            RichBox.Document.GetText(Windows.UI.Text.TextGetOptions.None, out send);
            RichBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, send + "哈哈");
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private void RichEditOwnBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string receiveString;
            RichBox.Document.GetText(Windows.UI.Text.TextGetOptions.None, out receiveString);
            if (receiveString == "@\r" || receiveString.EndsWith("@\r"))
            {
                ResetLocation();
                ConnectorsView.UpdateSourceView(ConnectorViewModel.listViews);
                StandardPopup.IsOpen = true;
            }
            else if(receiveString.Contains("@"))
            {
                string[] splitGroup = receiveString.Split(new char[] { '@','\r' }, StringSplitOptions.RemoveEmptyEntries);
                string identifyName = splitGroup.Last();
                ObservableCollection<Connector> newObserve = ConnectorViewModel.UpdateSource(identifyName);
                if (newObserve.Count != 0)
                {
                    ConnectorsView.UpdateSourceView(newObserve);
                    StandardPopup.IsOpen = true;
                }
                else
                {
                    StandardPopup.IsOpen = false;
                }
            }
            else if (string.IsNullOrEmpty(receiveString))
            {
                StandardPopup.IsOpen = false;
            }
        }

        private void RichEditOwnBox_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            //如果是Enter键的话,则选择当前StandardPopup中选中的一个,并且将popup消失
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
            }
        }

        private void ResetLocation()
        {
            double[] leftAndTop = RichBox.ResetPopupLocation();
            StandardPopup.VerticalOffset = leftAndTop[1];
            StandardPopup.HorizontalOffset = leftAndTop[0];
        }
    }
}
