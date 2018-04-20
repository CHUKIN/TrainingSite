using System.ComponentModel.DataAnnotations;

namespace TrainingSite.VIewModel
{
	public class RegisterModel
	{
		[Required]
		public string Login { get; set; }
 
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
 
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage="Пароли не совпадают")]
		public string ConfirmPassword { get; set; }
	}
}