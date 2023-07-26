using EmptyProject.Models;

namespace EmptyProject.Services
{
    public interface IEmployeeService
    {
        List<EmployeeViewModel> GetAll();
    }
}