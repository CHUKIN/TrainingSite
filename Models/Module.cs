using System.Collections.Generic;

namespace TrainingSite.Models
{
	public class Module
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual Course Course { get; set; }
		public virtual List<Step> StepsList { get; set; }
	}
}