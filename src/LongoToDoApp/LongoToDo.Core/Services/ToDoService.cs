using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task Add(TodoItem todo)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(todo);

            StringContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await httpClient.PostAsync(Url, content);
        }
    }

    public class FakeTodoService : ITodoService
    {
        List<TodoItem> items;

        public FakeTodoService()
        {
            items = new List<TodoItem>
            {
                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Call to mom", IsComplete = false },

                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Buy eggs", IsComplete = false },

                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Throw trash", IsComplete = false }
            };
        }

        public async Task<List<TodoItem>> GetAll()
        {
            await Task.Delay(1000);

            return items;
        }

        public async Task Add(TodoItem todo)
        {
            await Task.Delay(1000);

            items.Add(todo);
        }
    }
}

