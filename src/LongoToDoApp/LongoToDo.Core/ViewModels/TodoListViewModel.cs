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

namespace LongoToDo.Core.ViewModels
{
	public class TodoListViewModel : BindableBase, INavigatedAware
    {
		private INavigationService _navigationService;
		private ITodoService _todoService;
		private IDialogService _dialogService;

		public TodoListViewModel(INavigationService navigationService ,ITodoService todoService, IDialogService dialogService)
		{
			_navigationService = navigationService;
			_todoService = todoService;
			_dialogService = dialogService;
		}

		private TodoItem _selectedItem;
		public TodoItem SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				SetProperty(ref _selectedItem, value);

				if (value != null)
					MarkAsCompleted();
			}
		}

		private bool _isRefreshing;
		public bool IsRefreshing
		{
			get { return _isRefreshing; }
			set { SetProperty(ref _isRefreshing, value); }
		}

		private ObservableCollection<TodoItem> _todoItems;
		public ObservableCollection<TodoItem> TodoItems
		{
			get { return _todoItems; }
			set { SetProperty(ref _todoItems, value); }
		}

		private async Task GetAllTodos()
		{
			IsRefreshing = true;
			TodoItems = new ObservableCollection<TodoItem>(await _todoService.GetAll());
			IsRefreshing = false;
		}

		private async Task GoToCreateTodo()
		{
 			await _navigationService.NavigateAsync("NewTodoPage");
		}

		private async void DeleteTodo(TodoItem todo)
		{
			await _todoService.Delete(todo.Key);
			await GetAllTodos();
			await _dialogService.DisplayAlert($"ToDo item {todo.Name} has been deleted correctly", "Message", "Ok");
		}

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetAllTodos();
        }

		private async void MarkAsCompleted()
		{
			SelectedItem.IsComplete = !SelectedItem.IsComplete;
			await _todoService.Update(SelectedItem);
			await GetAllTodos();
		}

		private async void Refresh()
		{
			await GetAllTodos();
		}

        public ICommand CreateTodoCommand => new DelegateCommand(async () =>await GoToCreateTodo());

        public DelegateCommand<TodoItem> DeleteTodoCommand => new DelegateCommand<TodoItem>(DeleteTodo);

        public ICommand RefreshCommand => new DelegateCommand(Refresh);
    }
}

