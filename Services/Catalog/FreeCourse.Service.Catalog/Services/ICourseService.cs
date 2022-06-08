using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Service.Catalog.Dtos;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Service.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string UserId);
        
    }
}