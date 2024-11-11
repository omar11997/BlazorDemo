using Microsoft.AspNetCore.Components;
using SharedLibrary;
using WASM.App.Services;

namespace WASM.App.Pages
{
    public partial class EditEmployeeForm
    {
        [Parameter]
        public int Id { get; set; }
        public Employee CurEmp { get; set; }
        //IEnumerable<Employee> Employees;
        IEnumerable<Country> Countries;
        protected bool Saved = false;
        //public string Name { get; set; }
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            CurEmp = await EmployeeDataService.GetById(Id);
            Countries = await CountryDataService.GetAll();
            if(CurEmp == null)
                CurEmp = new Employee {CountryId = 1 ,BirthDate = DateTime.Now,JoinedDate = DateTime.Now };
            
        }
        protected async void HandelValidSubmit()
        {
            Saved = false;
            if(CurEmp.Id == 0)
            {
               await EmployeeDataService.AddEmployee(CurEmp);
                 
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Id, CurEmp);
               
                //emptoEdit.FirstName = CurEmp.FirstName;
                //emptoEdit.LastName = CurEmp.LastName;
                //emptoEdit.MaritalStatus = CurEmp.MaritalStatus;

                
            }
            Saved = true;
        }
        
        private void Nav()
        {
            NavigationManager.NavigateTo("/employeeoverview");
            
        }
    }
}
