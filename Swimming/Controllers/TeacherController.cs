using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Swimming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }

    
        // GET: api/<TeacherController>
        [HttpGet]
        public List<Teacher> Get()
        {
            return _context.TeacherList;
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult< Teacher> Get(int id)
        {

            var t = _context.TeacherList.Find(x => x.id == id);
            if(t == null)   
                return NotFound();  
            return t;
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult Post([FromBody] Teacher t)
        {
            var t1 = _context.TeacherList.Find(x => x.id == t.id);
            if (t1 == null)
                return NotFound();
            if (t.id.ToString().Length != 9)
                return BadRequest();
            _context.TeacherList.Add(new Teacher { id = t.id, name = t.name });
            return Ok();    

        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Teacher t)
        {
         
            var t2 = _context.TeacherList.Find(e => e.id == id); 
            if (t2 == null)
                return NotFound();
            if (t. id.ToString().Length != 9)
                return BadRequest();

            t2.id=t.id; 
            t2.name = t.name;
            return Ok();

        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t2 = _context.TeacherList.Find(e => e.id == id);
            if (t2 == null)
                return NotFound();
            _context.TeacherList.Remove(t2);
            return Ok();
        }
    }
}
