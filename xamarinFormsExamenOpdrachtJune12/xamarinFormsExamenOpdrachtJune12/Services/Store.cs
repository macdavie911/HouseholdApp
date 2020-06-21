using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using xamarinFormsExamenOpdrachtJune12.Models;
using xamarinFormsExamenOpdrachtJune12.Static;

namespace xamarinFormsExamenOpdrachtJune12.Services
{
    public class Store : IStore<TodoList, Todo>
    {
        private List<TodoList> todoLists;

        public List<TodoList> TodoLists
        {
            get { return todoLists; }
            set { todoLists = value; }
        }


        public Store()
        {
            // Replaced by API Call - See method below
            /*
            TodoLists = new List<TodoList>()
            {
                new TodoList {
                    Id = Guid.NewGuid().ToString(),
                    Title = "1.TodoList",
                    Todos = new List<Todo>()
                    {
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "1.Todo", Description = "This is an item description." },
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "2.Todo", Description = "This is an item description." },
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "3.Todo", Description = "This is an item description." },
                    }
                },
                new TodoList {
                    Id = Guid.NewGuid().ToString(),
                    Title = "2.TodoList",
                    Todos = new List<Todo>()
                    {
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "1.Todo", Description = "This is an item description." },
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "2.Todo", Description = "This is an item description." },
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "3.Todo", Description = "This is an item description." },
                    }
                },
                new TodoList {
                    Id = Guid.NewGuid().ToString(),
                    Title = "3.TodoList",
                    Todos = new List<Todo>()
                    {
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "1.Todo", Description = "This is an item description." },
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "2.Todo", Description = "This is an item description." },
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "3.Todo", Description = "This is an item description." },
                    }
                }
            };
            */
        }


       
        // TodoLists
        public async Task<IEnumerable<TodoList>> GetTodoListsAsync(bool forceRefresh = false)
        {
            TodoLists = await API.GetTodoListsAsync();

            return await Task.FromResult(TodoLists);
        }

        // TodoList
        public async Task<bool> AddTodoListAsync(TodoList todoList)
        {
            todoLists.Add(todoList);

            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteTodoListAsync(string id)
        {
            var oldTodoList = todoLists.Where((TodoList arg) => arg.Id == id).FirstOrDefault();
            todoLists.Remove(oldTodoList);

            return await Task.FromResult(true);
        }
        public Task<TodoList> GetTodoListAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateTodoListAsync(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        // Todo
        public async Task<bool> AddTodoAsync(string todoListId, Todo todo)
        {
            var todoList = todoLists.Where((TodoList arg) => arg.Id == todoListId).FirstOrDefault();

            todoList.Todos.Add(todo);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTodoAsync(string todoListId, Todo todo)
        {
            var todoList = todoLists.Where((TodoList arg) => arg.Id == todoListId).FirstOrDefault();

            todoList.Todos.Remove(todo);

            return await Task.FromResult(true);
        }

        
        public async Task<bool> ToggleTodoDoneAsync(string todoListId, string todoId)
        {
            
            //var todoList = todoLists.Where((TodoList arg) => arg.Id == todoListId).FirstOrDefault();

            //var todo = todoList.Todos.Where((Todo arg) => arg.Id == todoId).FirstOrDefault();

            // todo.Done = !todo.Done; ObservableList in TodoListVM and Store reference the same objects in memory.
            // switching it again brings it back to default false
            
            return await Task.FromResult(true);
        }
        


        // Todos
        public async Task<IEnumerable<Todo>> GetTodosAsync(string todoListId, bool forceRefresh = false)
        {
            var todoList = todoLists.Where((TodoList arg) => arg.Id == todoListId).FirstOrDefault();

            return await Task.FromResult(todoList.Todos);
        }
    }
}
