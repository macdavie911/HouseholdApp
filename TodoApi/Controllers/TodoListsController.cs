using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class TodoListsController : ApiController
    {
        /* Postman - PostBody JSON for testing
        {
            "Id": "6d758e2a-1cd1-4356-a8c3-67439a8ff723",
            "Title": "4.TodoLIst API",
            "Todos": [
                {
                    "Id": "6d758e2a-1cd1-4356-a8c3-67439a8ff726",
                    "Title": "asdf",
                    "Description": "ölkasdölkjsaf",
                    "Quantity": "5",
                    "Done": "true"
                }
            ]
        }
        */


        private static List<TodoList> _todoLists = new List<TodoList>()
        {
            new TodoList {
                Id = Guid.NewGuid().ToString(),
                Title = "1.TodoList API",
                Todos = new List<Todo>()
                {
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "1.Todo", Description = "This is an item description." },
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "2.Todo", Description = "This is an item description." },
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "3.Todo", Description = "This is an item description." },
                }
            },
            new TodoList {
                Id = "6d758e2a-1cd1-4356-a8c3-67439a8ff722",
                Title = "2.TodoList API",
                Todos = new List<Todo>()
                {
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "1.Todo", Description = "This is an item description." },
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "2.Todo", Description = "This is an item description." },
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "3.Todo", Description = "This is an item description." },
                }
            },
            new TodoList {
                Id = Guid.NewGuid().ToString(),
                Title = "3.TodoList API",
                Todos = new List<Todo>()
                {
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "1.Todo", Description = "This is an item description." },
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "2.Todo", Description = "This is an item description." },
                    new Todo { Id = Guid.NewGuid().ToString(), Title = "3.Todo", Description = "This is an item description." },
                }
            }
        };

        [HttpGet]
        [Route("api/todoLists/test/{id}")]
        public int Get(int id)
        {
            return id;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var todoLists = _todoLists;

            //return StatusCode(HttpStatusCode.OK); // 200 Ok
            return Ok(_todoLists); // Statuscode shortcut
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var todoList = _todoLists.Find((TodoList t) => t.Id == id);

            //IQueryable<TodoList> todolist2;




            return Ok(todoList); // Statuscode shortcut
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]TodoList todoList)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _todoLists.Add(todoList);
            //return StatusCode(HttpStatusCode.Created); // 201 Created
            return Ok("TodoList posted successfully");
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var idx = _todoLists.FindIndex(t => t.Id == id);

            if (idx == -1) return BadRequest("TodoList not found");

            var result = _todoLists.Find(t => t.Id == id);

            _todoLists.Remove(result);

            _todoLists.Insert(idx, todoList);

            return Ok("Todolist updated");
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var idx = _todoLists.FindIndex(t => t.Id == id);

            if (idx == -1) return BadRequest("TodoList not found");

            _todoLists.RemoveAt(idx);

            return Ok("TodoList deleted successfully");
        }
    }
}
