using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<Department> get_all_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_all_sub_departments_in_department(string department)
        {
            if (department.Contains("100"))
                return Enumerable.Range(100, 10).Select(x => new Department { name = x.ToString(department + ", SubDepartment 0 " ) });

            return Enumerable.Range(200, 1).Select(x => new Department { name = x.ToString("SubDepartment 0 of " + department) });
        }
    }
}