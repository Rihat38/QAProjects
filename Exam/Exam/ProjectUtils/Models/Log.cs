namespace Exam.ProjectUtils.Models
{
    public partial class Log
    {
        public long Id { get; set; }
        public string Content { get; set; } = null!;
        public bool IsException { get; set; }
        public long TestId { get; set; }

        public virtual Test Test { get; set; } = null!;
    }
}
