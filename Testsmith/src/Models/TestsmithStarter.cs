using Testsmith.Enums;

namespace Testsmith.Models
{
    /// <summary>
    /// Entry point voor de Testsmith applicatie vanuit de Frontend.
    /// </summary>
    public class TestsmithStarter
    {
        public string ProjectName { get; set; } = string.Empty;
        public Framework Framework { get; set; }
        public Language Language { get; set; }
        public List<Dependency> Dependencies { get; set; } = new List<Dependency>();
        public bool UITesting { get; set; } = false;
        public bool ApiTesting { get; set; } = false;
        public bool DataDriven { get; set; } = false;
        public bool EndToEndTesting { get; set; } = false;
        public bool PerformanceTesting { get; set; } = false;
        public bool MobileTesting { get; set; } = false;
        public bool CICDIntegration { get; set; } = false;
        public bool ReportingDashboard { get; set; } = false;
    }

    public class Dependency
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Environment { get; set; } = string.Empty;
    }
}
