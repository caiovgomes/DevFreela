using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descrição do Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha descrição do Projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha descrição do Projeto 3", 1, 1, 30000),
            };

            Users = new List<User>
            {
                new User("Caio Vitor", "caio@gmail.com", new DateTime(2001, 10, 11)),
                new User("Fabio", "fabio@gmail.com", new DateTime(1966, 11, 03)),
                new User("Solange", "solange@gmail.com", new DateTime(1975, 05, 01)),
            };

            Skills = new List<Skill>
            {
                new Skill(1,".Net Core"),
                new Skill(2,"C#"),
                new Skill(3,"SQL"),
            };

        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
