using System.Web.Http;

namespace OwinWebApplication.Controllers
{
    public class DefaultController : ApiController
    {
        public string Get()
        {
            return User.Identity.Name;
        }
    }
}
