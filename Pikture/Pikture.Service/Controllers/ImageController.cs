using System;
using Microsoft.AspNetCore.Mvc;

namespace Pikture.Service.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ImageController : ControllerBase
  {
    [HttpGet]
    public IActionResult Get()
    {
      // return Ok("http://placecorgi.com/300");
      return Ok(new JsonResult("http://placecorgi.com/300"));
    }

    [HttpGet("{width}/{height?}")] //image/200/
    public IActionResult Get(int width, int height)
    {
      return Ok($"http://placecorgi.com/{width}/{height}");
    }
  }
}

// localhost/image/200/100 - GET -> getBySize
// localhost/image - GET -> get
// localhost/image/200/0 - GET - getBySize
// localhost/image/200/ - GET - ?????, 404

// OBJECT -> CONTROLLERBASE -> CONTROLLER(RENDERING)
