using System;
using LongoToDo.Core.ViewModels;
using LongoToDo.Tests.Mocks;
using Xunit;

namespace LongoToDo.Tests
{
	public class NewTodoViewModelTests
	{
        [Fact]
        public void WhenTodoTextHasValue_CanExecuteIsTrue()
        {
            var sut = new NewTodoViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());

            sut.TodoText = "new todo";

            Assert.True(sut.CreateTodoCommand.CanExecute(null));
        }

        [Fact]
        public void WhenTodoTextIsNull_CanExecuteIsFalse()
        {
            var sut = new NewTodoViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());

            Assert.False(sut.CreateTodoCommand.CanExecute(null));
        }

        [Fact]
        public void WhenCreateCommandIsInvoked_TodoTextPropertyChangedIsRaised()
        {
            var sut = new NewTodoViewModel(new NavigationServiceMock(), new TodoServiceMock(), new DialogServiceMock());

            sut.TodoText = "new todo";

            Assert.PropertyChanged(sut, "TodoText", () => sut.CreateTodoCommand.Execute(null));
        }

    }
}

