using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    [ApiController]
    [Route("api/student")]
    public class controller : ControllerBase
    {

        public static List<Student> Student { get; set; } = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name="Test",
            },

            new Student
            {
                Id = 2,
                Name="Test2",

            }
        };
        [HttpPost]
        public void Post(Student student)
        {

            Student.Add(student);


        }

        [HttpGet]

        public List<Student> GetUsers()
        {
            return Student;
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student updatedStudent)
        {
           
            var existingStudent = Student.FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound(); 
            }

         
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Id = updatedStudent.Id;

            return NoContent(); 
        }
        //[HttpPatch("{id}")]
        //public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Student> patchDoc)
        //{
        //    if (patchDoc == null)
        //        return BadRequest();

        //    var student = Student.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //        return NotFound();

        //    patchDoc.ApplyTo(student, ModelState);

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    return NoContent(); 
        //}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Student.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); 
            }

            Student.Remove(student); 

            return NoContent(); 
        }

    }
}

