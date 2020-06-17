using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xamarinFormsExamenOpdrachtJune12.Services
{
    public interface IStore<T, T2>
    {
        // TodoList
        Task<bool> AddTodoListAsync(T todoList);
        Task<bool> UpdateTodoListAsync(T todoList);
        Task<bool> DeleteTodoListAsync(string id);
        Task<T> GetTodoListAsync(string id);

        // TodoLists
        Task<IEnumerable<T>> GetTodoListsAsync(bool forceRefresh = false);

        // Todo
        Task<bool> AddTodoAsync(string todoListId, T2 todo);
        Task<bool> DeleteTodoAsync(string todoListId, T2 todo);
        Task<bool> ToggleTodoDoneAsync(string todoListId, string todoId);

        // Todos
        Task<IEnumerable<T2>> GetTodosAsync(string todoListId, bool forceRefresh = false);
        
    }
}
