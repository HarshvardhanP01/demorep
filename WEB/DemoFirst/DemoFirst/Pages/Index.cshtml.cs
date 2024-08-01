using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DemoFirst.BizLayer.Contracts;
namespace DemoFirst.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMyService _myService; // we actually regitration
        public IndexModel(ILogger<IndexModel> logger, IMyService myService) // for registraton we add here i.e. Dependency Injection
        {
            _logger = logger;
            _myService = myService;
        }

        public void OnGet()
        {
            ViewData.Add("Greet",_myService.GetData("Harshvardhan"));// Calling and mapping with key and value pair
        }
    }
}
