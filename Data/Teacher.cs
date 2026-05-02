using System.ComponentModel.DataAnnotations.Schema;

namespace GTest.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("ClassroomId")]
        public int? ClassroomId { get; set; }
        public Classroom Classroom { get; set; }


        public List<TeacherSubject> TeacherSubjects { get; set; }
    }
}
