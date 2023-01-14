using System;
using System.Collections.Generic;
using LongoToDo.Core.ViewModels;
using Xamarin.Forms;

namespace LongoToDo.Forms.Views
{	
	public partial class ToDoListPage : ContentPage
	{	
		public ToDoListPage ()
		{
			InitializeComponent ();
			this.BindingContext = new ToDoListViewModel();
		}
	}
}

