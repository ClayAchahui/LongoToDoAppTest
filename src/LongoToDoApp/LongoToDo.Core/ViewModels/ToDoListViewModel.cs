using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LongoToDo.Core.Models;
using LongoToDo.Core.Services;

namespace LongoToDo.Core.ViewModels
{
	public class ToDoListViewModel : BaseViewModel
	{

		private ObservableCollection<TodoItem> _todoList;
		public ToDoListViewModel()
		{
			Title = "Titulo de prueba";
		}

		public override async Task InitializeAsync(object navigationData)
		{
			await base.InitializeAsync(navigationData);

			//_todoList = new ObservableCollection<TodoItem>(await _toDoService.GetAllAsync());
		}
    }
}

