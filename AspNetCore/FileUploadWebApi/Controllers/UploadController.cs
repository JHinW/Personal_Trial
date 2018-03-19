

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FileUploadWebApi.Source;

using Microsoft.AspNetCore.Mvc;

namespace FileUploadWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Upload(FileUploadViewModel model)
        {

            var file = model.File;

            if (file.Length > 0)
            {
                string path = Directory.GetCurrentDirectory();
                using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                model.source = $"/uploadFiles{file.FileName}";
                model.Extension = Path.GetExtension(file.FileName).Substring(1);
            }
            return BadRequest();
        }
    }
}
