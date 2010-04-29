using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.application.mappers
{
    public class DepartmentMapper : Mapper<NameValueCollection, Department>
    {
        public Department map(NameValueCollection input)
        {
            return new Department
                   {
                       name = PayloadKeys.department.name.map_from(input),
                       active_in_store_since = PayloadKeys.department.active_in_store_since.map_from(input),
                       is_special = PayloadKeys.department.is_active.map_from(input)
                   };
        }

    }
}
