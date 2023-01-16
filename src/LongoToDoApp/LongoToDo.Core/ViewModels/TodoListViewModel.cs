using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LongoToDo.Core.Models;
using LongoToDo.Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;

namespace LongoToDo.Core.ViewModels
{
	public class TodoListViewModel : BindableBase, INavigatedAware
    {
		private INavigationService _navigationService;
		private ITodoService _todoService;
		private IDialogService _dialogService;

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy;  }
			set { SetProperty(ref _isBusy, value); }
		}

		private ObservableCollection<TodoItem> _todoItems;
		public ObservableCollection<TodoItem> TodoItems
		{
			get { return _todoItems; }
			set { SetProperty(ref _todoItems, value); }
		}

		public TodoListViewModel(INavigationService navigationService ,ITodoService todoService, IDialogService dialogService)
		{
			_navigationService = navigationService;
			_todoService = todoService;
			_dialogService = dialogService;
			Title = "Test";
		}

		private async Task GetAllTodos()
		{
			IsBusy = true;
			TodoItems = new ObservableCollection<TodoItem>(await _todoService.GetAll());
			IsBusy = false;
		}

		private async Task GoToCreateTodo()
		{
 			await _navigationService.NavigateAsync("NewTodoPage");
		}

		private async void DeleteTodo(TodoItem todo)
		{
			await _todoService.Delete(todo.Key);
			await GetAllTodos();
			_dialogService.ShowDialog("Message", new DialogParameters($"ToDo item {todo.Name} has been deleted correctly"));
		}

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetAllTodos();
        }

        public ICommand CreateTodoCommand => new DelegateCommand(async () =>await GoToCreateTodo());
        public DelegateCommand<TodoItem> DeleteTodoCommand => new DelegateCommand<TodoItem>(DeleteTodo);
    }
}

