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

        public async Task Delete(string id)
        {
            var uri = $"{Url}/{id}";

            var httpClient = new HttpClient();

            await httpClient.DeleteAsync(uri);
        }

        public async Task Update(TodoItem todo)
        {
            var uri = $"{Url}/{todo.Key}";
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(todo);

            StringContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(uri, content);
        }

    }

    public class FakeTodoService : ITodoService
    {
        private List<TodoItem> _items;

        public FakeTodoService()
        {
            _items = new List<TodoItem>
            {
                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Call to mom", IsComplete = false },

                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Buy eggs", IsComplete = false },

                new TodoItem { Key = Guid.NewGuid().ToString(), Name = "Throw trash", IsComplete = false }
            };
        }

        public async Task<List<TodoItem>> GetAll()
        {
            await Task.Delay(500);

            return _items;
        }

        public async Task Add(TodoItem todo)
        {
            await Task.Delay(500);
            todo.Key = Guid.NewGuid().ToString();
            _items.Add(todo);
        }

        public async Task Delete(string id)
        {
            await Task.Delay(500);

            var item = _items.Where(x => x.Key.Equals(id)).FirstOrDefault();

            _items.Remove(item);
        }

        public async Task Update(TodoItem todo)
        {
            await Task.Delay(500);

            _items.ForEach(x =>
            {
                if (x.Key.Equals(todo.Key))
                    x.IsComplete = todo.IsComplete;
            });
        }
    }
}

