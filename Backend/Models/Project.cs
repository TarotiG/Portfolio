namespace Backend.Models
{
    /// <summary>
    /// Dit is het model voor projecten
    /// </summary>
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Function { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Technology> Technologies { get; set; }
        public bool PersonalProject { get; set; }

        public Project()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            Function = string.Empty;
            PersonalProject = false;
            Technologies = new List<Technology>();
        }
    }

    public class Technology
    {
        public Guid Id { get; set; }

        public Guid? ProjectId { get; set; }
        public Project? Project { get; set; }

        public string TechnologyName { get; set; } = default!;

        public Technology()
        {
            Id = Guid.NewGuid();
            TechnologyName = string.Empty;
        }
    }
}
