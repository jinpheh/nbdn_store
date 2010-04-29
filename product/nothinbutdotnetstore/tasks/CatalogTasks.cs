using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<Department> get_all_main_departments();
        IEnumerable<Department> get_all_sub_departments_in_department(Department department_name);
    	IEnumerable<Product> get_all_products_in_department(Department department);
    }
}