using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Swimming.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;
        public CourseController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public List<Course> Get()
        {
            return _context.CoursesList;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult< Course> Get(int id)
        {           
            var c2 = _context.CoursesList.Find(x => x.id == id);
            if (c2 == null)
                return NotFound();
            return c2;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] Course c )
        {
            //בדיקה למורה האם קיימת במאגר
            var t = _context.TeacherList.Find(x => x.id == c.teacherId);
            if (t == null)
                return NotFound();
            _context.CoursesList.Add(new Course { id = _context.CourseCount++, name =c.name, teacherId = c.teacherId });
            return Ok();


        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course c)
        {
            //בבדיקה למורה האם קיימת במאגר
            var t = _context.TeacherList.Find(x => x.id == c.teacherId);
            if (t == null)
                return NotFound();
            var c2= _context.CoursesList.Find(x => x.id == id);
            c2.name=c.name; 
            c2.teacherId=c.teacherId;
            return Ok();    
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var c = _context.CoursesList.Find(x => x.id == id);
            if (c == null)
                return NotFound();
            _context.CoursesList.Remove(c);
            return Ok();

        }
    }
}
