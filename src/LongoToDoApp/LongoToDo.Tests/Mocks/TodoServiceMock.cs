using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LongoToDo.Core.Models;
using LongoToDo.Core.Services;

namespace LongoToDo.Tests.Mocks
{
	public class TodoServiceMock : ITodoService
	{
        List<TodoItem> _items = new List<TodoItem>();

        public Task<List<TodoItem>> GetAll()
        {
            return Task.FromResult(_items.Where(x => !x.IsComplete).ToList());
        }

        public Task<TodoItem> Add(TodoItem todo)
        {
            var item = new TodoItem() { Key = Guid.NewGuid().ToString(), Name = todo.Name };
            _items.Add(item);
            return Task.FromResult(item);
        }

        public Task<bool> Update(TodoItem item)
        {
            var itemToUpdate = _items.Where(x => x.Key == item.Key).FirstOrDefault();
            if (itemToUpdate != null)
            {
                itemToUpdate.IsComplete = true;
            }

            return Task.FromResult(true);
        }

        public Task<bool> Delete(string id)
        {
            var item = _items.Where(x => x.Key.Equals(id)).FirstOrDefault();
            _items.Remove(item);
            return Task.FromResult(true);
        }

    }
}

