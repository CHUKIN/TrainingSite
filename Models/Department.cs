using System.Collections.Generic;

namespace TrainingSite.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public User HeadOfDepartment { get; set; }
		public virtual List<Position> PositionsList { get; set; }
	}
}