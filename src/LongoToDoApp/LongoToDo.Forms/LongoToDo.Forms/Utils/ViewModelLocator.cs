using System;
using Autofac;
using LongoToDo.Core.Services;

namespace LongoToDo.Forms.Utils
{
    public static class ViewModelLocator
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ToDoService>().As<IToDoService>();

            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

