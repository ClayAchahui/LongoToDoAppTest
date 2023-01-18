using System;
using LongoToDo.Core.Services;
using Prism.Mvvm;
using Prism.Navigation;

namespace LongoToDo.Core.ViewModels
{
	public class BaseViewModel : BindableBase
    {
        protected INavigationService _navigationService;
        protected ITodoService _todoService;
        protected IDialogService _dialogService;

        public BaseViewModel(INavigationService navigationService, ITodoService todoService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _todoService = todoService;
            _dialogService = dialogService;
        }
    }
}

