namespace Exam.ProjectUtils.Models
{
    public partial class Author
    {
        public Author()
        {
            Tests = new HashSet<Test>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Login { get; set; } = null!;
        public string? Email { get; set; } = null!;

        public virtual ICollection<Test> Tests { get; set; }
    }
}
