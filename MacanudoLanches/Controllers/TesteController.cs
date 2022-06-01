using Microsoft.AspNetCore.Mvc;

namespace MacanudoLanches.Controllers
{
    public class TesteController : Controller
    {
        public string Index()
        {
            return $"Testando o método Index de TesteController : {DateTime.Now}";
        }
    }
}
