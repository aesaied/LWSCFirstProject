using EmptyProject.Models;

namespace EmptyProject.Services
{
    public class EmployeeService : IEmployeeService
    {


        public List<EmployeeViewModel> GetAll()
        {
            //
            return new List<EmployeeViewModel>() {
                new EmployeeViewModel() { Id=1, Name="Atallah", Salary=5000 } ,
                new EmployeeViewModel() { Id=2, Name="Hamza", Salary=5500 } ,
                new EmployeeViewModel() { Id=3, Name="Basil", Salary=5800 } ,

            };



        }

    }
}
