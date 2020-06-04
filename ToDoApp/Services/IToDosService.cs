using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public interface IToDosService
    {
        public Task<IEnumerable<Todo>> GetAll(int userId);

        public Task<Todo> Create(Todo todo);

        public Task<Todo> ChangeStatus(int todoId, bool status);
    }
}
