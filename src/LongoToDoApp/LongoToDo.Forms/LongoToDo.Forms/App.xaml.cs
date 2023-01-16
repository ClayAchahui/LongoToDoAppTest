using System;
using LongoToDo.Core.Services;
using LongoToDo.Core.ViewModels;
using LongoToDo.Forms.Services;
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

        protected async override void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("TodoListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterViewModels(containerRegistry);
            RegisterServices(containerRegistry, isFake: true);
        }

        private void RegisterViewModels(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TodoListPage, TodoListViewModel>();
            containerRegistry.RegisterForNavigation<NewTodoPage, NewTodoViewModel>();
        }

        private void RegisterServices(IContainerRegistry containerRegistry, bool isFake)
        {
            if (isFake)
            {
                containerRegistry.RegisterSingleton<ITodoService, FakeTodoService>();
                containerRegistry.Register<IDialogService, DialogService>();
            }
            else
            {
                containerRegistry.Register<ITodoService, TodoService>();
                containerRegistry.Register<IDialogService, DialogService>();
            }

        }
    }
}

