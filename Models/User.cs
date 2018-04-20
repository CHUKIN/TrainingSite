using System;
using System.Collections.Generic;

namespace TrainingSite.Models
{
 	public class User
 	{
 		public int Id { get; set; }
 		public string Name { get; set; }
 		public string Surname { get; set; }
 		public string Patronymic { get; set; }
 		public string Login { get; set; }
 		public string Password { get; set; }
 		public DateTime? DateOfBirthday { get; set; }
 		public DateTime? EmploymentDate { get; set; }
		public int? GroupId { get; set; }
 		public virtual Group Group { get; set; }
		public int? PositionId { get; set; }
 		public virtual Position Position { get; set; }
 		public virtual List<Story> StoriesList { get; set; }
 	}
 }