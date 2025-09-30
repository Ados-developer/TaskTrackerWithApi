using TaskTrackerApi.Models;

namespace TaskTrackerApi.Services
{
    public class TaskService
    {
        private readonly Repositories.TaskRepository _repository;
        public TaskService(Repositories.TaskRepository repository)
        {
            _repository = repository;
        }
        public List<TaskItem> GetAllTasks()
        {
            return _repository.GetAllTasks();
        }
        public TaskItem? GetTaskById(int id)
        {
            return _repository.GetTaskById(id);
        }
        public void AddTask(TaskItem task)
        {
            _repository.AddTask(task);
        }
        public TaskItem? UpdateTask(int id, TaskItem task)
        {
            return _repository.UpdateTask(id, task);
        }
        public bool DeleteTask(int id)
        {
            return _repository.DeleteTask(id);
        }
    }
}
