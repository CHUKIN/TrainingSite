using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace TrainingSite.Models
{
	public class Competence
	{
        [Key, Column(Order = 0)]
        [ForeignKey("Position")]
		public int PositionId { get; set; }
		public virtual Position Position { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Course")]
		public int CourseId { get; set; }
		public virtual Course Course { get; set; }
		
		public string Description { get; set; }
		public bool IsRequired { get; set; }
	}
}