using System;
using LongoToDo.Core.Services;
using LongoToDo.Forms.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LongoToDo.Forms
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        //public App ()
        //{
        //    InitializeComponent();

        //    MainPage = new ToDoListPage();
        //}

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ToDoListPage>();
            containerRegistry.Register<IToDoService, ToDoService>();
        }

        protected async override void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("ToDoListPage");
        }
    }
}

