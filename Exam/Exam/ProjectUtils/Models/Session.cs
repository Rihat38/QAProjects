namespace Exam.ProjectUtils.Models
{
    public partial class Session
    {
        public Session()
        {
            Tests = new HashSet<Test>();
        }

        public long Id { get; set; }
        public string SessionKey { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public long BuildNumber { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
