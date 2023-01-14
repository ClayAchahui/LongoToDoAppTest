using System;
using LongoToDo.Forms.Utils;
using LongoToDo.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LongoToDo.Forms
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            ViewModelLocator.RegisterDependencies();

            MainPage = new ToDoListPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

