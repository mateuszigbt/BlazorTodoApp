using BlazorTodoApp.Shared;
using System.Net.Http.Json;

namespace BlazorTodoApp.Client.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TodoItem>> GetAllTodoItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TodoItem>>("https://localhost:7051/api/todo/GetList") ?? new();
        }

        public async Task AddTodoItemAsync(TodoItem item)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7051/api/todo/CreateItem", item);
        }

        public async Task UpdateTodoItemAsync(TodoItem item)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7051/api/todo/UpdateItem/{item.Id}", item);
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7051/api/todo/DeleteItem/{id}");
        }
    }
}
