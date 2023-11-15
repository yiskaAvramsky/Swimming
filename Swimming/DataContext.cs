namespace Swimming
{
    public class DataContext
    {
        public List<Course> CoursesList { get; set; }
        public int CourseCount { get; set; }


        public List<Student> StudentList { get; set; }
      


        public List<Teacher> TeacherList { get; set; }
        




        public DataContext()
        {
            CoursesList = new List<Course>();
            CoursesList.Add(new Course{ id = 1, name = "back", teacherId = 113456789 });
            CoursesList.Add(new Course { id = 2, name = "breast", teacherId = 113456789 }) ;
            CoursesList.Add(new Course{ id = 3, name = "side", teacherId = 113456789 });
            CourseCount = 4;

           
            StudentList = new List<Student>();
            StudentList.Add(new Student { id = 123456789, name = "tamar", age = 13, courseId = 1 });
            StudentList.Add(new Student { id = 213456789, name = "lali", age = 16, courseId = 1 }) ;
            StudentList.Add(new Student { id = 312456789, name = "rachel", age = 16, courseId = 1 });
           

  
            TeacherList = new List<Teacher>();
            TeacherList.Add(new Teacher { id = 113456789, name = "SARA" });
            TeacherList.Add(new Teacher { id = 223456789, name = "SHOSHI" });
            TeacherList.Add(new Teacher { id = 331456789, name = "TOVA" });
            
        }
      
    }
}
