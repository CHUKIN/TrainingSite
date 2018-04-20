using System.Collections.Generic;

namespace TrainingSite.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int? UserId { get; set; }
		public User Creator { get; set; }
		public int? LanguageId { get; set; }
		public Language Language { get; set; }
		public virtual List<Competence> CompetencesList { get; set; }
		public virtual List<Module> ModulesList { get; set; }
	}
}