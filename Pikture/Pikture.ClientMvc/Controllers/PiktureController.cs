using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pikture.ClientMvc.Models;

namespace Pikture.ClientMvc.Controllers
{
  public class PiktureController : Controller
  {
    private static HttpClient _http = new HttpClient();
    
    public async Task<IActionResult> Index()
    {
      var response = await _http.GetAsync("http://localhost:5000/api/image");
      var imageViewModel = new ImageViewModel() { ImageUrl = await response.Content.ReadAsStringAsync() };

      return View(imageViewModel);
    }
  }
}
