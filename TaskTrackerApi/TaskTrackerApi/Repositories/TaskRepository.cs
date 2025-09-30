using TaskTrackerApi.Data;
using TaskTrackerApi.Models;

namespace TaskTrackerApi.Repositories
{
    public class TaskRepository
    {
        private readonly TaskDbContext _db;
        public TaskRepository(TaskDbContext db)
        {
            _db = db;
        }
        public List<TaskItem> GetAllTasks()
        {
            return _db.TaskItems.ToList();
        }
        public TaskItem? GetTaskById(int id)
        {
            return _db.TaskItems.Find(id);
        }
        public void AddTask(TaskItem task)
        {
            _db.TaskItems.Add(task);
            _db.SaveChanges();
        }
        public TaskItem? UpdateTask(int id,TaskItem task)
        {
            TaskItem? existingTask = _db.TaskItems.Find(id);
            if (existingTask == null) return null;
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            _db.SaveChanges();
            return existingTask;
        }
        public bool DeleteTask(int id)
        {
            TaskItem? task = _db.TaskItems.Find(id);
            if (task == null) return false;
            _db.TaskItems.Remove(task);
            _db.SaveChanges();
            return true;
        }
    }
}
