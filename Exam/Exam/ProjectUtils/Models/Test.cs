using System.Reflection;

namespace Exam.ProjectUtils.Models
{
    public partial class Test
    {
        public Test()
        {
        }

        public long Id { get; set; }
        public string? Name { get; set; } = null!;
        public int? StatusId { get; set; }
        public string MethodName { get; set; } = null!;
        public long ProjectId { get; set; }
        public long SessionId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string Env { get; set; } = null!;
        public string? Browser { get; set; }
        public long? AuthorId { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Project Project { get; set; } = null!;
        public virtual Session Session { get; set; } = null!;
        public virtual Status? Status { get; set; }
        public virtual ICollection<Log> Logs { get; set; }

        public List<Variance> DetailedCompare(Test anotherTest)
        {
            var variances = new List<Variance>();
            var fi = anotherTest.GetType().GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var f in fi)
            {
                var v = new Variance();
                v.Prop = f.Name[1..^16];
                v.valA = f.GetValue(this);
                v.valB = f.GetValue(anotherTest);
                if (!Equals(v.valA, v.valB))
                    variances.Add(v);
            }

            variances.RemoveAt(variances.Count - 1);
            return variances;
        }
    }
}
