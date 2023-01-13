namespace Exam.ProjectUtils.Models
{
    public partial class Status
    {
        public Status()
        {
            Tests = new HashSet<Test>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Test> Tests { get; set; }
    }
}
