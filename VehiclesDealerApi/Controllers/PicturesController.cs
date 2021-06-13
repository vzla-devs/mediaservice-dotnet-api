using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace VehiclesDealerApi.Controllers
{
    [Route("api/pictures")]
    [ApiController]
    public class PicturesController : ControllerBase {
        [HttpGet]
        public OkResult Get() {
            return Ok();
        }

        [HttpPost]
        public OkResult Post([FromBody] List<IFormFile> pictures) {
            pictures.ForEach(async pic => {
                var filePath = Path.GetFullPath("public/uploads");
                var fileName = Path.GetTempFileName();
                var fullPath = Path.Combine(filePath, fileName);
                using FileStream stream = System.IO.File.Create(fullPath);
                await pic.CopyToAsync(stream);
            });
            return Ok();
        }
    }
}
