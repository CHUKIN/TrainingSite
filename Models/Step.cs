using System.Collections.Generic;
using System.Web.WebPages;

namespace TrainingSite.Models
{
	public class Step
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public int? Order { get; set; }
		public int? TheoryId { get; set; }
		public virtual Theory Theory { get; set; }
		public int? TestId { get; set; }
		public virtual Test Test { get; set; }
		public int? VideoId { get; set; }
		public virtual Video Video { get; set; }
		public virtual List<Story> StoriesList { get; set; }
	}
}