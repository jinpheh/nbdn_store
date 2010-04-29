using System.Web;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_a_request_from(HttpContext http_context)
        {
            if (http_context.Request.Url.ToString().Contains("SubDepartment"))
                return new ViewSubDepartmentRequest(DepartmentNameParser.parse(http_context.Request.Url.ToString()));
            return new StubRequest();
        }

        public class StubRequest : Request
        {
            public string parameter
            {
                get; set;
            }
        }
    }

    public class ViewSubDepartmentRequest : Request
    {
        public ViewSubDepartmentRequest(string s)
        {
            parameter = s;
        }

        public string parameter
        {
            get; set;
        }
    }
}