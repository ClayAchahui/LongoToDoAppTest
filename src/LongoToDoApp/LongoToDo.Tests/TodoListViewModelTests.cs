using System;
using Xunit;
using System.Linq;
using LongoToDo.Core.ViewModels;
using LongoToDo.Tests.Mocks;
using LongoToDo.Core.Models;
using System.Collections.ObjectModel;

namespace LongoToDo.Tests
{
    public class TodoListViewModelTests
    {
        [Fact]
        public void WhenTodoListPageAppear_TodoItemsIsSet()
        {
            var sut = new TodoListViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());

            sut.OnNavigatedTo(null);

            Assert.NotNull(sut.TodoItems);
        }

        [Fact]
        public void WhenRefreshCommandIsInvoked_IsRefreshingPropertyChangedIsRaised()
        {
            var sut = new TodoListViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());

            Assert.PropertyChanged(sut, "IsRefreshing", () => sut.RefreshCommand.Execute(null));
        }

        [Fact]
        public void WhenRefreshCommandIsInvoked_TodoItemsPropertyIsRaised()
        {
            var sut = new TodoListViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());

            Assert.PropertyChanged(sut, "TodoItems", () => sut.RefreshCommand.Execute(null));
            Assert.NotNull(sut.TodoItems);
        }

        [Fact]
        public void WhenSeletedItemIsSetWithIsCompletePropertyFalse_TodoItemIsCompletedPropertyIsTrue()
        {
            var sut = new TodoListViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());
            var newItem = new TodoItem { Key = Guid.NewGuid().ToString(), Name = "new todo item" };
            sut.TodoItems = new ObservableCollection<TodoItem> { newItem };

            sut.SelectedItem = newItem;

            Assert.True(sut.SelectedItem.IsComplete);
            Assert.PropertyChanged(sut, "TodoItems", () => sut.SelectedItem = newItem);
        }

        [Fact]
        public void WhenSelectedItemIsSetWithIsCompletePropertyTrue_TodoItemIsCompletePropertyIsFalse()
        {
            var sut = new TodoListViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());
            var newItem = new TodoItem { Key = Guid.NewGuid().ToString(), Name = "new todo item", IsComplete = true };
            sut.TodoItems = new ObservableCollection<TodoItem> { newItem };

            sut.SelectedItem = newItem;

            Assert.False(sut.SelectedItem.IsComplete);
            Assert.PropertyChanged(sut, "TodoItems", () => sut.SelectedItem = newItem);
        }

        [Fact]
        public void WhenDeleteCommandIsInvoked_TodoItemsPropertyChangedIsRaised()
        {
            var todoService = new TodoServiceMock();
            var sut = new TodoListViewModel(new NavigationServiceMock(), todoService, new DialogServiceMock());
            var newTodo = new TodoItem { Key = Guid.NewGuid().ToString(), Name = "new todo"};
            todoService.Add(newTodo);

            Assert.PropertyChanged(sut, "TodoItems", () => sut.DeleteTodoCommand.Execute(newTodo));
        }
    }
}

