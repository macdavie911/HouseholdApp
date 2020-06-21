using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xamarinFormsExamenOpdrachtJune12.Models;
using xamarinFormsExamenOpdrachtJune12.Static;

namespace xamarinFormsExamenOpdrachtJune12.Services
{
    public static class API
    {
        public static string UriTodoLists(string id = "")
        {
            return String.Format(Constants.URI, "todolists", id);
        }

        public async static Task<List<TodoList>> GetTodoListsAsync()
        {
            List<TodoList> todoLists;
            var uri = UriTodoLists();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();

                todoLists = JsonConvert.DeserializeObject<List<TodoList>>(json);
            }

            return todoLists;
        }
    }
}
