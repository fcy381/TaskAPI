using Microsoft.Extensions.Options;
using TaskAPI.Entities;
using TaskAPI.Repository;

namespace TaskAPI.Endpoints
{
    public static class TaskEndpoints
    {
        

        public static void ConfigureTaskEndpoints(this WebApplication app)
        {            
            app.MapGet("/api/task", GetAllTaskAsync);

            app.MapGet("/api/task/{id:Guid}", GetTaskAsync); 

            app.MapPost("/api/task", CreateTaskAsync);

            app.MapPut("/api/task/{id:Guid}", UpdateTaskAsync);

            app.MapDelete("/api/task/{id:Guid}", DeleteTaskAsync); 
        }

        private async static Task<List<Entities.Tarea>> GetAllTaskAsync(TaskRepository _taskRepository)
        {
            return await _taskRepository.GetAllAsync();
        }

        private async static Task<Entities.Tarea> GetTaskAsync(Guid id, TaskRepository _taskRepository)
        {
            return await _taskRepository.GetAsync(id);
        }

        private async static Task<IResult> CreateTaskAsync(Entities.Tarea task, TaskRepository _taskRepository)
        {
            await _taskRepository.CreateAsync(task);
            
            return Results.Ok(task);
        }

        private async static Task<IResult> UpdateTaskAsync(Guid id, Entities.Tarea task, TaskRepository _taskRepository)
        { 
            await _taskRepository.UpdateAsync(id, task);
            
            return Results.Ok();
        }

        private async static Task<IResult> DeleteTaskAsync(Guid id, TaskRepository _taskRepository)
        {
            await _taskRepository.RemoveAsync(id);

            return Results.Ok();
        }

    }
}
