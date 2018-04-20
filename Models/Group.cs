using System.Collections.Generic;

namespace TrainingSite.Models
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<User> UsersList { get; set; }
	}
}