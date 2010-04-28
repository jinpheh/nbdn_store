using System.Web;

namespace nothinbutdotnetstore.hello.web
{
    public class DisplayTheName : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Server.Transfer("Welcome.aspx",true);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}