namespace GTest.Models.Student
{
    public class StudentForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SchoolYear { get; set; }
        public string BirthDate { get; set; }
        public int? ClassroomId { get; set; }

        public List<Data.Classroom> Classrooms { get; set; }
    }
}
