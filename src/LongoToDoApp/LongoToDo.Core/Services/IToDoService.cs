using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LongoToDo.Core.Models;

namespace LongoToDo.Core.Services
{
	public interface ITodoService
	{
		Task<List<TodoItem>> GetAll();

		Task<TodoItem> Add(TodoItem todo);

		Task<bool> Delete(string id);

		Task<bool> Update(TodoItem todo);
    }
}

