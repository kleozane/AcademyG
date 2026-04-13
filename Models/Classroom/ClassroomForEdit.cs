namespace GTest.Models.Classroom
{
    public class ClassroomForEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? HomeroomTeacherId { get; set; }
        public List<Data.Teacher> Teachers { get; set; }
    }
}
