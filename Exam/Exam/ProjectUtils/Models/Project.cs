namespace Exam.ProjectUtils.Models
{
    public partial class Project
    {
        public Project()
        {
            Tests = new HashSet<Test>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Test> Tests { get; set; }
    }
}
