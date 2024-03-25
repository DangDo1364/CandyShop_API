using CandyShop_API.Repositories;
using CandyShop_API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandyShop_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_imageRepository.GetAll());
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_imageRepository.GetByID(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ImageVM imageVM)
        {
            try
            {
                return Ok(_imageRepository.Add(imageVM));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ImageVM imageVM)
        {
            if (id != imageVM.idImg)
                return BadRequest();

            try
            {
                _imageRepository.Update(imageVM);
                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
