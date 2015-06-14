using System.Web.Http;
using WeHome.BLL;

namespace WeHome.Web.Api
{
    public class BaseController : ApiController
    {
        protected UnitOfWork Work;

        public BaseController()
        {
            Work = new UnitOfWork();
        }
    }
}
