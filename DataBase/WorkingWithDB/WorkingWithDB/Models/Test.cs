namespace WorkingWithDB.Models
{
    public partial class Test
    {
        public Test()
        {
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public int? StatusId { get; set; }
        public string MethodName { get; set; }
        public long ProjectId { get; set; }
        public long SessionId { get; set; }
        public string Env { get; set; }
        public string? StartTime { get; set; }
        public string EndTime { get; set; }
        public string Browser { get; set; }
        public long? AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Project Project { get; set; }
        public virtual Session Session { get; set; }
        public virtual Status Status { get; set; }
    }
}
