namespace GTest.Models.Classroom
{
    public class ClassroomForCreation
    {
        public string Name { get; set; }

        public int HomeroomTeacherId { get; set; }
        public List<Data.Teacher> Teachers { get; set; }
    }
}