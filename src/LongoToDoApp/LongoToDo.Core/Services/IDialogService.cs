using System;
using System.Threading.Tasks;

namespace LongoToDo.Core.Services
{
	public interface IDialogService
	{
        Task DisplayAlert(string message, string title = null, string accept = null);
    }
}

