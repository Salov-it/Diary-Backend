using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskListServices.Application.CQRS.Command.Create;
using TaskListServices.Application.CQRS.Command.Delete;
using TaskListServices.Application.CQRS.Command.GetAll;
using TaskListServices.Application.CQRS.Command.Update;
using TaskListServices.Application.CQRS.Command.Upgate;
using TaskListServices.Application.Interface;

namespace TaskListServices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTaskListServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<ICreateTaskList, CreateTaskList>();

            services.AddScoped<CreateTaskListCommand>();
            services.AddScoped<CreateTaskListHandler>();

            services.AddScoped<IGetTaskList,GetTaskList>();
            services.AddScoped<TaskListCommand>();
            services.AddScoped<TaskListHandler>();

            services.AddScoped<IDeletTaskList, DeletTaskList>();
            services.AddScoped<DeleteTaskListDtoCommand>();
            services.AddScoped<DeleteTaskListDtoHandler>();

            services.AddScoped<IUpdateTaskList, UpdateTaskList>();
            services.AddScoped<UpdateTaskListCommand>();
            services.AddScoped<UpdateTaskListHandler>();

            return services;
        }
    }
}
