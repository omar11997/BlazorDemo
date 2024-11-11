using SharedLibrary;

using System.Text;
using System.Text.Json;

namespace WASM.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        public EmployeeDataService(HttpClient httpClient) {
            _httpClient = httpClient;
        
        }
        

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                (await _httpClient.GetStreamAsync("/api/Employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("https://localhost:7201/api/Employee",
            //new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

        public async Task<Employee> GetById(int id)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync("/api/Employee/"+id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task AddEmployee(Employee employee)
        {
            var empObjSer = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/api/Employee/", empObjSer);
        }

        public async Task UpdateEmployee(int id,Employee employee)
        {

            var empObjSer = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("/api/Employee/" + employee.Id, empObjSer);
        }
        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
