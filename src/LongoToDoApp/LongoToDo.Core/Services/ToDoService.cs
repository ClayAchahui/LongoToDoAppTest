using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using LongoToDo.Core.Models;
using Newtonsoft.Json;

namespace LongoToDo.Core.Services
{
	public class TodoService : ITodoService
	{
        private string Url = "https://localhost:8080/api/Todo";

        public async Task<List<TodoItem>> GetAll()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Url);

            var result = JsonConvert.DeserializeObject<List<TodoItem>>(json);

            return result;
        }
    }

    public class FakeTodoService : ITodoService
    {
        List<TodoItem> items;

        public async Task<List<TodoItem>> GetAll()
        {
            await Task.Delay(1000);

            items = new List<TodoItem>
            {
                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Call to mom", IsComplete = false },

                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Buy eggs", IsComplete = false },

                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Throw trash", IsComplete = false }
            };

            return items;
        }
    }
}

