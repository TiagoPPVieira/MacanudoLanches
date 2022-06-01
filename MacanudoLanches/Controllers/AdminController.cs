using Microsoft.AspNetCore.Mvc;

namespace MacanudoLanches.Controllers
{
    public class AdminController : Controller
    {
        public string Index()
        {
            return $"Testando o método Index de AdminController : {DateTime.Now}";
        }
        public string Demo()
        {
            return $"Testando o método Demo de AdminController : {DateTime.Now}";
        }
    }
}