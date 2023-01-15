using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LongoToDo.Core.Models;
using LongoToDo.Core.Services;
using Prism.Mvvm;
using Prism.Navigation;

namespace LongoToDo.Core.ViewModels
{
	public class TodoListViewModel : BindableBase, IInitialize
    {
		private INavigationService _navigationService;
		private ITodoService _todoService;

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

		private IEnumerable<TodoItem> _todoItems;
		public IEnumerable<TodoItem> TodoItems
		{
			get { return _todoItems; }
			set { SetProperty(ref _todoItems, value); }
		}

		public TodoListViewModel(INavigationService navigationService ,ITodoService todoService)
		{
			_navigationService = navigationService;
			_todoService = todoService;
			Title = "Test";
		}

        public async void Initialize(INavigationParameters parameters)
        {
			await GetAllTodos();
        }

		private async Task GetAllTodos()
		{
			IsBusy = true;
			TodoItems = await _todoService.GetAll();
			IsBusy = false;
		}
    }
}

