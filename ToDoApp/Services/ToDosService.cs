using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Services
{
    public class ToDosService : IToDosService
    {
        private readonly AppDbContext _dbContext;
        public ToDosService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Todo> ChangeStatus(int todoId, bool status)
        {
            var todo = await _dbContext.Todos.FirstOrDefaultAsync(t => t.Id == todoId);
            if(todo != null)
            {
                throw new Exception("Todo not found");
            }
            todo.Status = status;
            await _dbContext.SaveChangesAsync();
            return todo;

        }

        public async Task<Todo> Create(Todo todo)
        {
            _dbContext.Todos.Add(todo);
            await _dbContext.SaveChangesAsync();
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetAll(int userId)
        {
            return await _dbContext.Todos.Where(u=> u.UserId == userId).ToListAsync();
        }
    }
}
