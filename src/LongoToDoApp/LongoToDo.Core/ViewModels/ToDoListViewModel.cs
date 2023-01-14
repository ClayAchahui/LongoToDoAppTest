using System;
namespace LongoToDo.Core.ViewModels
{
	public class ToDoListViewModel : BaseViewModel
	{
		private string _title;
		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		public ToDoListViewModel()
		{
			Title = "Titulo de prueba";
		}
	}
}

