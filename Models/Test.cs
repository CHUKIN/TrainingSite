using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSite.Models
{
	public class Test
	{
		[Key]
        [ForeignKey("Step")]
		public int Id { get; set; }
		public int? StepId { get; set; }
		public virtual Step Step { get; set; }
		public virtual List<Variant> VariantsList { get; set; }
	}
}