﻿using DatabasePostgres.Persistance.Interface;
using DatabasePostgres.Persistance.SqlRequest.TaskListSqlRequest;
using Npgsql;
using TaskListServices.Dto;

namespace DatabasePostgres.Persistance.Repository
{
    public class TaskListRepositoryPostgres : UserRepositoryPostgres, ITaskListRepositoryPostgres
    {
        TaskListSqlRequest _TaskSql = new TaskListSqlRequest();
        public async Task<string> Add(PostTaskListDto taskListDto)
        {
            await using var conn = new NpgsqlConnection(_Connect);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_TaskSql.Add,conn)
            {
                Parameters =
                {
                    new() { Value = taskListDto.Login },
                    new() { Value = taskListDto.Text },
                    new() { Value = taskListDto.StatusTasks },
                    new() { Value = taskListDto.Created }
                } 
            };
            await cmd.ExecuteNonQueryAsync();
            return "Выполнено";
        }

        public async Task<string> CreateTable()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_TaskSql.CreateTasksTable))
            {
                await cmd.ExecuteNonQueryAsync();
            }
            return "Таблица Tasks создана успешно";
        }

        public async Task<string> Delete(DeleteTaskListDto deleteTaskListDto)
        {
            await using var conn = new NpgsqlConnection(_Connect);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_TaskSql.Delete, conn)
            {
                Parameters =
                {
                    new() { Value = deleteTaskListDto.id },
                  
                }
            };
            await cmd.ExecuteNonQueryAsync();
            return "Выполнено";
        }

        public GetAllTaskListDto TaskListDto = new GetAllTaskListDto();
        public List<GetAllTaskListDto> Result = new List<GetAllTaskListDto>();
        public async Task<List<GetAllTaskListDto>> GetAll(GetTaskListLoginDto getTaskListLoginDto)
        {
            await using var conn = new NpgsqlConnection(_Connect);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_TaskSql.GetTasksInfo, conn)
            {
                Parameters =
                {
                    new() { Value = getTaskListLoginDto.Login },

                }
            };
            
                await using (var reader = await cmd.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt16(0);
                        var Login = reader.GetString(1);
                        var text = reader.GetString(2);
                        var StatusTasks = reader.GetBoolean(3);
                        var Created = reader.GetDateTime(4);

                        TaskListDto = new GetAllTaskListDto
                        {
                            id = id,
                            Login = Login,
                            Text = text,
                            StatusTasks = StatusTasks,
                            Created = Created
                        };
                        Result.Add(TaskListDto);
                    }
                }
            
            return Result;
        }

        public UpdateTaskListDto updateTaskListDto = new UpdateTaskListDto();
        public async Task<UpdateTaskListDto> Update(UpdateTaskListDto updateTaskListDto)
        {
            await using var conn = new NpgsqlConnection(_Connect);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_TaskSql.Update, conn)
            {
                Parameters =
                {
                    new() { Value = updateTaskListDto.id },
                    new() { Value = updateTaskListDto.Text },
                    new() { Value = updateTaskListDto.StatusTasks }
                }
            };

            await using (var reader = await cmd.ExecuteReaderAsync())
            {

              while (await reader.ReadAsync())
              {
                 var id = reader.GetInt16(0);
                 var text = reader.GetString(1);
                 var StatusTasks = reader.GetBoolean(2);
                        
                 updateTaskListDto = new UpdateTaskListDto
                 {
                   id = id,
                   Text = text,
                   StatusTasks = StatusTasks
                 };
              }
            }
            return updateTaskListDto;
        }
    }
}
