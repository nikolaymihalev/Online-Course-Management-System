using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Models.Course;

namespace OnlineCourseSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController( ICourseService _courseService)
        {
            courseService = _courseService;
        }

        /// <summary>
        /// Retrieves a list of all available courses
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await courseService.GetCoursesAsync());
        }

        /// <summary>
        /// Adds a new course
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseFormModel model)
        {
            await courseService.AddAsync(model);
            return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "added", "course") });
        }

        /// <summary>
        /// Retrieves a course by its ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var model = await courseService.GetByIdAsync(id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing course
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CourseFormModel model)
        {
            try
            {
                await courseService.EditAsync(model);
                return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "edited", "course") });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a course
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await courseService.DeleteAsync(id);
                return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "deleted", "course") });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
