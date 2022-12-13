namespace TaskAPI.Endpoints
{
    public static class TaskEndpoints
    {
        public static void ConfigureTaskEndpoints(this WebApplication app)
        {
            app.MapGet("/api/task",GetAllTask);

            app.MapGet("/api/task/{id:int}",GetTask);

            app.MapPost("/api/task",CreateTask);

            app.MapPut("/api/task/{id:int}",UpdateTask);

            app.MapDelete("/api/task/{id:int}",DeleteTask); 
        }

        private async static Task<IResult> GetAllTask()
        {
            return Results.Ok();
        }

        private async static Task<IResult> GetTask(int id)
        {
            return Results.Ok(id);
        }


        private async static Task<IResult> CreateTask()
        {
            return Results.Ok();
        }

        private async static Task<IResult> UpdateTask(int id)
        { 
            return Results.Ok(id);
        }

        private async static Task<IResult> DeleteTask()
        { 
            return Results.Ok();
        }

    }
}
