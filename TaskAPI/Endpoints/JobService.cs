using AutoMapper;
using JobAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TaskAPI.Entities;
using TaskAPI.Repository;

namespace TaskAPI.Endpoints
{
    public static class JobService
    {
        public static void ConfigureJobService(this WebApplication app)
        {            
            app.MapGet("/api/job", GetAllJobsAsync);

            app.MapGet("/api/job/{id:Guid}", GetJobAsync); 

            app.MapPost("/api/job", CreateJobAsync);

            app.MapPut("/api/job/{id:Guid}", UpdateJobAsync);

            app.MapDelete("/api/job/{id:Guid}", DeleteJobAsync); 
        }

        private async static Task<List<Job>> GetAllJobsAsync(JobRepository _jobRepository)
        {
            return await _jobRepository.GetAllAsync();
        }

        private async static Task<Job> GetJobAsync(Guid id, JobRepository _jobRepository)
        {
            return await _jobRepository.GetAsync(id);
        }

        private async static Task<IResult> CreateJobAsync([FromBody] JobCreateDTO jobCreateDTO, 
                                                           JobRepository _jobRepository,
                                                           Mapper _mapper)
        {
            Job job = new Job();
            //Job job = new()
            //{
            //    Title = jobCreateDTO.Title,
            //    Description = jobCreateDTO.Description,
            //    Creation = DateTime.Now.ToString(),
            //    Update = DateTime.Now.ToString(),
            //    Author = jobCreateDTO.Author,
            //    Condition= jobCreateDTO.Condition
            //};

            job = _mapper.Map<Job>(jobCreateDTO);

            job.Creation = DateTime.Now.ToString();
            job.Update = DateTime.Now.ToString();   

            await _jobRepository.CreateAsync(job);

            return Results.CreatedAtRoute("GetJobAsync", new { id = job.Id }, job);
        }

        private async static Task<IResult> UpdateJobAsync(Guid id, Job job, JobRepository _jobRepository)
        { 
            await _jobRepository.UpdateAsync(id, job);
            
            return Results.Ok();
        }

        private async static Task<IResult> DeleteJobAsync(Guid id, JobRepository _jobRepository)
        {
            await _jobRepository.RemoveAsync(id);

            return Results.Ok();
        }

    }
}
