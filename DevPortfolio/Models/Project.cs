namespace DevPortfolio.Models
{
    /// <summary>
    /// Dit is het model voor projecten
    /// </summary>
    public class Project
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Function { get; set; } = default!;
        public string Period { get; set; } = default!;
        public string Technology { get; set; } = default!;
        public bool PersonalProject { get; set; }
    }
}
