using System.Threading.Tasks;
using FreeCourse.Service.Catalog.Dtos;
using FreeCourse.Service.Catalog.Services;
using FreeCourse.Shared.CustomController;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Service.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        // [HttpGet("{userid}")]
        [HttpGet]
        [Route("api/[controller]/GetByUserId/{userid}")]
        public async Task<IActionResult> GetByUserId(string userid)
        {
            var response = await _courseService.GetAllByUserIdAsync(userid);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto createDto)
        {
            var response = await _courseService.CreateAsync(createDto);
            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto createDto)
        {
            var response = await _courseService.UpdateAsync(createDto);
            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);
            
            
            return CreateActionResultInstance(response);
        }
    }
}