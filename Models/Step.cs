using System.Collections.Generic;
using System.Web.WebPages;

namespace TrainingSite.Models
{
	public class Step
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual Theory Theory { get; set; }
		public virtual Test Test { get; set; }
		public virtual Video Video { get; set; }
		public virtual List<Story> StoriesList { get; set; }
	}
}