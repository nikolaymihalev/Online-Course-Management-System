using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Core.Contracts;

namespace OnlineCourseSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService studentCourseService;

        public StudentCourseController(IStudentCourseService _studentCourseService)
        {
            studentCourseService = _studentCourseService;
        }

        /// <summary>
        /// Retrieves a list of all registered courses for a student
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentsCourses(int id)
        {
            var model = await studentCourseService.GetStudentsCourses(id);
            return Ok(model);
        }

        /// <summary>
        /// Deletes a student registration for course
        /// </summary>
        [HttpDelete("leave")]
        public async Task<IActionResult> LeaveCourse(int courseId, int studentId)
        {
            try
            {
                await studentCourseService.LeaveCourse(courseId, studentId);

                return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "deleted", "student-course") });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registrate a student to course
        /// </summary>
        [HttpPost("join")]
        public async Task<IActionResult> RegistrateToCourse(int courseId, int studentId)
        {
            try
            {
                await studentCourseService.RegistrateToCourse(courseId, studentId);

                return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "registered", "student to course") });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates a progress for student in course
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateProgressStatus(int courseId, int studentId, string progress)
        {
            try
            {
                await studentCourseService.UpdateStudentCourseStatus(courseId, studentId, progress);

                return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "updated", "progress") });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
