using System;
using Prism.Commands;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using LongoToDo.Core.Services;
using LongoToDo.Core.Models;
using LongoToDo.Core.Utils;

namespace LongoToDo.Core.ViewModels
{
    public class NewTodoViewModel : BaseViewModel
    {
        private string _todoText;
        public string TodoText
        {
            get { return _todoText; }
            set { SetProperty(ref _todoText, value); }
        }

        public NewTodoViewModel(
            INavigationService navigationService,
            ITodoService todoService,
            IDialogService dialogService)
            : base(navigationService,todoService,dialogService)
        {

        }

        private async void CreateTodo()
        {
            try
            {
                var response = await _todoService.Add(new TodoItem { Name = TodoText, IsComplete = false });

                if (response != null)
                {
                    TodoText = string.Empty;
                    await _navigationService.GoBackAsync();
                }
                else
                {
                    await _dialogService.DisplayAlert(Constants.Messages.NullResult, Constants.Messages.TitleMessage, Constants.Messages.OK);
                }
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlert(ex.Message, Constants.Messages.TitleMessage, Constants.Messages.OK);
                //TODO: Track the error 
            }

        }

        private bool ValidateTodoText()
        {
            return !string.IsNullOrWhiteSpace(TodoText);
        }

        public ICommand CreateTodoCommand => new DelegateCommand(CreateTodo, ValidateTodoText).ObservesProperty(() => TodoText);
    }
}

