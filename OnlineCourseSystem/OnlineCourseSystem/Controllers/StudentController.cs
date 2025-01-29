using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Models.Student;

namespace OnlineCourseSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        /// <summary>
        /// Adds new student
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentFormModel model)
        {
            await studentService.AddAsync(model);
            return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "added", "student") });
        }

        /// <summary>
        /// Retrieves a list of all students
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await studentService.GetAllStudentsAsync());
        }

        /// <summary>
        /// Deletes an existing student
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await studentService.DeleteAsync(id);

                return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "deleted", "student") });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing student
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] StudentFormModel model)
        {
            try
            {
                await studentService.EditAsync(model);

                return Ok(new { Message = string.Format(Messages.SuccessfulOperation, "edited", "student") });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an existing student by identifier
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var model = await studentService.GetByIdAsync(id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
