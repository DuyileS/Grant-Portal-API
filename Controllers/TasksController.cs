using AutoMapper;
using GMP.API.CustomActionFilters;
using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = GMP.API.Models.Domain.Task;

namespace GMP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;

        public TasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskDomain = await taskRepository.GetAllAsync();
            var taskDto = mapper.Map<TaskDto>(taskDomain);
            return Ok(taskDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var taskDomain = await taskRepository.GetById(id);
            
            if(taskDomain == null) 
            {
                return NotFound();
            }

            var taskDto = mapper.Map<TaskDto>(taskDomain);
            return Ok(taskDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddTaskRequestDto addTaskRequestDto)
        {
            var taskDomain = mapper.Map<Task>(addTaskRequestDto);

            taskDomain = await taskRepository.CreateAsync(taskDomain);

            var taskDto = mapper.Map<TaskDto>(taskDomain);
            return CreatedAtAction(nameof(GetById), new { id = taskDto.TaskId }, taskDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskRequestDto updateTaskRequestDto)
        {
            var taskDomain = mapper.Map<Task>(updateTaskRequestDto);

            taskDomain = await taskRepository.UpdateAsync(id, taskDomain);


            if (taskDomain == null)
            {
                return NotFound();
            }

            var taskDto = mapper.Map<TaskDto>(taskDomain);
            return Ok(taskDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var taskDomain = await taskRepository.DeleteAsync(id);

            if (taskDomain == null)
            {
                return NotFound();
            }

            var taskDto = mapper.Map<TaskDto>(taskDomain);
            return Ok(taskDto);
        }
    }
}
