using System;
namespace LongoToDo.Core.Utils
{
	public static class Constants
	{
		public const string ApiUrl = "https://localhost:8080/api/Todo";

		public struct Navigation
		{
			public const string CreateTodo = "NewTodoPage";
		}

		public struct Messages
		{
			public const string TitleMessage = "Message";
			public const string NullResult = "It's not you, it's me";
			public const string OK = "OK";
		}
	}
}

