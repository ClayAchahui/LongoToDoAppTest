using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LongoToDo.Core.Models;
using Newtonsoft.Json;

namespace LongoToDo.Core.Services
{
	public class ToDoService : IToDoService
	{
        private string Url = "http://localhost:8080/api/Todo";

        public async Task<List<TodoItem>> GetAllAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Url);

            var result = JsonConvert.DeserializeObject<List<TodoItem>>(json);

            return result;
        }
    }
}

