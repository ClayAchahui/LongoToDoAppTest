using System;
using System.Threading.Tasks;
using LongoToDo.Core.Services;

namespace LongoToDo.Tests.Mocks
{
    public class DialogServiceMock : IDialogService
    {
        public Task DisplayAlert(string message, string title = null, string accept = null)
        {
            return Task.FromResult(true);
        }
    }
}

