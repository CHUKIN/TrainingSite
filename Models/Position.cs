using System.Collections.Generic;
using System.Configuration;

namespace TrainingSite.Models
{
	public class Position
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual Department Department { get; set; }
		public virtual List<User> UserList { get; set; }
		public virtual List<Competence> CompetencesList { get; set; }
	}
}