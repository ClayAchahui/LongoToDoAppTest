using System;
using System.Threading.Tasks;
using LongoToDo.Core.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LongoToDo.Forms.Services
{
    public class DialogService : IDialogService
    {
        public async Task DisplayAlert(string message, string title = null, string accept = null)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(title, message, accept);
            });

            await taskCompletionSource.Task;
        }
    }
}

