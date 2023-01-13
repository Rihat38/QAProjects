namespace WorkingWithDB.Models
{
    public partial class Author
    {
        public Author()
        {
            Test = new HashSet<Test>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Test> Test { get; set; }
    }
}
