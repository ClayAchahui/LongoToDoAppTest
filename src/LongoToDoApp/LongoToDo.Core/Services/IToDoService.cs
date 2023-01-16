using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LongoToDo.Core.Models;

namespace LongoToDo.Core.Services
{
	public interface ITodoService
	{
		Task<List<TodoItem>> GetAll();

		Task Add(TodoItem todo);

		Task Delete(string id);

		Task Update(TodoItem todo);
    }
}

