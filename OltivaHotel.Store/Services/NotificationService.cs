using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using OltivaHotel.PCL.Model;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OltivaHotel.Store.Services
{
    public class NotificationService : INotificationService
    {
        public void Notify(string message)
        {
            var messageDialog = new MessageDialog(message);
            messageDialog.ShowAsync();
        }

        public async Task<bool> NotifyOkCancel(string message, string caption = "")
        {
            string dResult = null;
            IUICommand dialogResult;
            var messageDialog = new MessageDialog(message, caption);

            messageDialog.Commands.Add(new UICommand("Cancel"));
            messageDialog.Commands.Add(new UICommand("Ok"));

            messageDialog.DefaultCommandIndex = 1;

            var dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            dialogResult = await messageDialog.ShowAsync();
            string returnValue = dialogResult.Label;
            return returnValue == "Ok";
        }
    }
}
