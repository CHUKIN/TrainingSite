using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSite.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
		public virtual List<Position> PositionsList { get; set; }
	}
}