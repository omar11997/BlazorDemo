using Microsoft.AspNetCore.Components;
using SharedLibrary;
using System.Net.Http.Json;
using WASM.App.Services;


namespace WASM.App.Pages
{
    public partial class EmployeeDetails
    {
        [Parameter]
        public int Id { get; set; }

        public Employee? CurEmp { get; set; }
        //List<Employee>? Employees;
        //List<Country> Countries;
        /// <summary>
        /// using httpClient
        /// </summary>
        //[Inject]
        //public HttpClient HttpClient { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    Employees = await HttpClient.GetFromJsonAsync<List<Employee>>("https://localhost:7201/api/Employee");
        //    CurEmp = Employees.FirstOrDefault(e => e.Id == Id);

        //}

        /// <summary>
        /// using httpClientFactory
        /// </summary>
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            CurEmp = await EmployeeDataService.GetById(Id);
        }
    }
}
