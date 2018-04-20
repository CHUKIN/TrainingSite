using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSite.Models
{
	public class Theory
	{
		[Key]
		[ForeignKey("Step")]
		public int Id { get; set; }
		public virtual Step Step { get; set; }
		
		public string Text { get; set; }
	}
}