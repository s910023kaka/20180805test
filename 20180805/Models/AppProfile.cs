using System;
namespace Application.Models
{
    public enum AppType
    {
        Factory, Tools, DepartmentA, DepartmentB
    }

    public class AppProfile
    {
        public int AppProfileID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AppType? Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Version { get; set; }
        public string Owner { get; set; }
        public string VSTS { get; set; }
        public string SqlServer { get; set; }

        public int ServerID { get; set; }
        public Server Server { get; set; }
    }
}