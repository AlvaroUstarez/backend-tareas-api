using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_tareas_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        // GET: api/DefaultController
        public string Get()
        {
            return "Aplicación corriendo...";
        }

    }
}
