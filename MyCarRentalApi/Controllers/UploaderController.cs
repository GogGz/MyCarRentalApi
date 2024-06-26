﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCarRentalApi.Models.Models;
using System.Drawing;

namespace MyCarRentalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploaderController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadFile([FromForm] AddImageRequest image)
        {
            try
            {
                
                //  string path = Path.Combine($"C:/Users/gohar/Desktop/Images", image.FileName);
               

                string path = Path.Combine($"C:/Users/gohar/Desktop/Images");

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    image.File.CopyTo(stream);

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
