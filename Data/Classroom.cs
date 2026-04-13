using System.ComponentModel.DataAnnotations.Schema;

namespace GTest.Data
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("HomeroomTeacherId")]
        public int? HomeroomTeacherId { get; set; }
        public Teacher HomeroomTeacher { get; set; }
    }
}