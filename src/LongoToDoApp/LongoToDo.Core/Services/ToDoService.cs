using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LongoToDo.Core.Models;
using LongoToDo.Core.Utils;
using Newtonsoft.Json;

namespace LongoToDo.Core.Services
{
	public class TodoService : ITodoService
	{

        public async Task<List<TodoItem>> GetAll()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(Constants.ApiUrl);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<TodoItem>>(json);
                return list;
            }

            return null;
        }

        public async Task<TodoItem> Add(TodoItem todo)
        {
            var httpClient = new HttpClient();
            var body = JsonConvert.SerializeObject(todo);
            StringContent content = new StringContent(body);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(Constants.ApiUrl, content);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                var newTodo = JsonConvert.DeserializeObject<TodoItem>(json);
            }

            return null;
        }

        public async Task<bool> Delete(string id)
        {
            var uri = $"{Constants.ApiUrl}/{id}";
            var httpClient = new HttpClient();
            var result = await httpClient.DeleteAsync(uri);

            if (result.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<bool> Update(TodoItem todo)
        {
            var uri = $"{Constants.ApiUrl}/{todo.Key}";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(todo);
            StringContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PutAsync(uri, content);

            if (result.IsSuccessStatusCode)
                return true;

            return false;
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

        public async Task<TodoItem> Add(TodoItem todo)
        {
            await Task.Delay(500);
            todo.Key = Guid.NewGuid().ToString();
            _items.Add(todo);
            return todo;
        }

        public async Task<bool> Delete(string id)
        {
            await Task.Delay(500);

            var item = _items.Where(x => x.Key.Equals(id)).FirstOrDefault();
            _items.Remove(item);
            return true;
        }

        public async Task<bool> Update(TodoItem todo)
        {
            await Task.Delay(500);

            _items.ForEach(x =>
            {
                if (x.Key.Equals(todo.Key))
                    x.IsComplete = todo.IsComplete;
            });

            return true;
        }
    }
}

