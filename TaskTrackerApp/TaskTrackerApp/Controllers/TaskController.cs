using Microsoft.AspNetCore.Mvc;
using TaskTrackerApp.Models;

namespace TaskTrackerApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public TaskController(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        private string ApiUrl => _configuration["ApiSettings:BaseUrl"];

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}/api/Tasks");
            if (response.IsSuccessStatusCode)
            {
                var tasks = await response.Content.ReadFromJsonAsync<List<Models.TaskDto>>();
                return View(tasks);
            }
            return View(new List<Models.TaskDto>());
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskDto task)
        {
            if(ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}/api/Tasks", task);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(task);
        }
        // PUT: Task/Edit GET
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}/api/Tasks/{id}");
            if (response.IsSuccessStatusCode)
            {
                var task = await response.Content.ReadFromJsonAsync<TaskDto>();
                return View(task);
            }
            return RedirectToAction(nameof(Index));
        }
        // PUT: Task/Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskDto task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/api/Tasks/{id}", task);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(task);
        }

        // DELETE: Task/Delete GET
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}/api/Tasks/{id}");
            if (response.IsSuccessStatusCode)
            {
                var task = await response.Content.ReadFromJsonAsync<TaskDto>();
                return View(task);
            }
            return RedirectToAction(nameof(Index));
        }

        // DELETE: Task/Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/api/Tasks/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
