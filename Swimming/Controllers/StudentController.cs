using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Swimming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DataContext _context;
        public StudentController(DataContext context)
        {
            _context = context;
        }
    
        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Get()
        {
            return _context.StudentList;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult< Student> Get(int id)
        {
            var s = _context.StudentList.Find(x => x.id == id);
            if (s == null)
                return NotFound();
            return s;
            
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] Student s)
        {
            //בדיקה האם הקורס קיים במאגר
            var t = _context.CoursesList.Find(x => x.id == s.courseId);
            if (t == null)
                return NotFound();
            if (s.id.ToString().Length != 9)
                return BadRequest();
            _context.StudentList.Add(new Student { id = s.id, name = s.name, age = s.age,courseId=s.courseId });
            return Ok();

        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student s)
        {
            var t = _context.CoursesList.Find(x => x.id == s.courseId);
            if (t == null)
                return NotFound();
            if (s.id.ToString().Length != 9)
                return BadRequest();
           
            var s2 = _context.StudentList.Find(e => e.id == id);
            if (s2 == null)
                return NotFound();
            s2.id = id;
            s2.name = s.name;
            s2.age = s.age;
            s2.courseId = s.courseId;
            return Ok();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var s = _context.StudentList.Find(e => e.id == id);
            if (s == null)
                return NotFound();
            _context.StudentList.Remove(s);
            return Ok();
        }
    }
}
