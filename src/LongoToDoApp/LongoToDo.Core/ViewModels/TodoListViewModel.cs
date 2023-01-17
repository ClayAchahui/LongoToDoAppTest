using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LongoToDo.Core.Models;
using LongoToDo.Core.Services;
using LongoToDo.Core.Utils;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace LongoToDo.Core.ViewModels
{
	public class TodoListViewModel : BaseViewModel, INavigatedAware
    {
		public TodoListViewModel(
			INavigationService navigationService ,
			ITodoService todoService,
			IDialogService dialogService)
			: base(navigationService, todoService, dialogService)
		{
		}

        #region Properties

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

        #endregion Properties

        #region Commands

        public ICommand CreateTodoCommand => new DelegateCommand(async () => await GoToCreateTodo());

        public DelegateCommand<TodoItem> DeleteTodoCommand => new DelegateCommand<TodoItem>(DeleteTodo);

        public ICommand RefreshCommand => new DelegateCommand(Refresh);

        #endregion Commands

        #region Methods

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetAllTodos();
        }

        private async Task GetAllTodos()
		{
			IsRefreshing = true;

			try
			{
				var response = await _todoService.GetAll();
				if (response == null)
				{
					await _dialogService.DisplayAlert(Constants.Messages.NullResult, Constants.Messages.TitleMessage, Constants.Messages.OK);
					return;
				}

				TodoItems = new ObservableCollection<TodoItem>(await _todoService.GetAll());
			}
			catch (Exception ex)
			{
				await _dialogService.DisplayAlert(ex.Message, Constants.Messages.TitleMessage, Constants.Messages.OK);
				//TODO: Track the error 
			}
			finally
			{
				IsRefreshing = false;
			}
		}

		private async Task GoToCreateTodo()
		{
 			await _navigationService.NavigateAsync(Constants.Navigation.CreateTodo);
		}

		private async void DeleteTodo(TodoItem todo)
		{
			try
			{
				var response = await _todoService.Delete(todo.Key);

				if (response)
				{
					await GetAllTodos();
					await _dialogService.DisplayAlert($"ToDo item {todo.Name} has been deleted correctly", "Message", "Ok");
				}
				else
				{
					await _dialogService.DisplayAlert(Constants.Messages.NullResult, Constants.Messages.TitleMessage, Constants.Messages.OK);
					return;
				}
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlert(ex.Message, Constants.Messages.TitleMessage, Constants.Messages.OK);
                //TODO: Track the error 
            }
        }

		private async void MarkAsCompleted()
		{
			try
			{
				SelectedItem.IsComplete = !SelectedItem.IsComplete;
				var response = await _todoService.Update(SelectedItem);
				if (response)
				{
					await GetAllTodos();
				}
				else
				{
					await _dialogService.DisplayAlert(Constants.Messages.NullResult, Constants.Messages.TitleMessage, Constants.Messages.OK);
					return;
				}
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlert(ex.Message, Constants.Messages.TitleMessage, Constants.Messages.OK);
                //TODO: Track the error 
            }
        }

		private async void Refresh()
		{
			await GetAllTodos();
		}

        #endregion Methods
    }
}

