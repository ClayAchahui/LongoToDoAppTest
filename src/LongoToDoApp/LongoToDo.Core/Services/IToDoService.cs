using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LongoToDo.Core.Models;

namespace LongoToDo.Core.Services
{
	public interface IToDoService
	{
		Task<List<TodoItem>> GetAllAsync();
	}
}

