using System;
using Prism.Commands;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using LongoToDo.Core.Services;
using LongoToDo.Core.Models;

namespace LongoToDo.Core.ViewModels
{
    public class NewTodoViewModel : BindableBase, IInitialize
    {
        private INavigationService _navigationService;
        private ITodoService _todoService;

        private string _todoText;
        public string TodoText
        {
            get { return _todoText; }
            set { SetProperty(ref _todoText, value); }
        }

        public NewTodoViewModel(INavigationService navigationService, ITodoService todoService)
        {
            _navigationService = navigationService;
            _todoService = todoService;
        }

        public void Initialize(INavigationParameters parameters)
        {
        }

        private async Task CreateTodo()
        {
            if (!ValidateTodoText())
                return;

            await _todoService.Add(new TodoItem { Name = TodoText, IsComplete = false });
            TodoText = string.Empty;
            await _navigationService.GoBackAsync();
        }

        private bool ValidateTodoText()
        {
            return !string.IsNullOrWhiteSpace(TodoText);
        }

        public ICommand CreateTodoCommand => new DelegateCommand(async () => await CreateTodo());
    }
}

