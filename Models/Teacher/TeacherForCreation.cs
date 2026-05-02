namespace GTest.Models.Teacher
{
    public class TeacherForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int? ClassroomId { get; set; }

        public List<Data.Subject> Subjects { get; set; }

        public List<int?> SubjectIds { get; set; }
    }
}
