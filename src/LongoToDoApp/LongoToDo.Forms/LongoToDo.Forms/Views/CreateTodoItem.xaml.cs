using System;
using System.Collections.Generic;
using LongoToDo.Core.ViewModels;
using Xamarin.Forms;

namespace LongoToDo.Forms.Views
{
    public partial class CreateTodoItem : ContentPage
    {
        public CreateTodoItem()
        {
            InitializeComponent();
            this.BindingContext = new CreateTodoItemViewModel();
        }
    }
}

