using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSite.Models
{
	public class Story
	{
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public int UserId { get; set; }
		public virtual User User { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Step")]
        public int StepId { get; set; }
        public virtual Step Step { get; set; }
		
		public bool IsOpen { get; set; }
		public bool IsSuccessful { get; set; }
		public bool IsWrong { get; set; }
	}
}