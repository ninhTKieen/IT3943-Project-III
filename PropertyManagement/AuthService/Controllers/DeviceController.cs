using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

public class DeviceController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}