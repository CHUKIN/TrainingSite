namespace TrainingSite.Models
{
	public class Variant
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public bool IsCorrected { get; set; }
		public int? TestId { get; set; }
		public virtual Test Test { get; set; }
	}
}