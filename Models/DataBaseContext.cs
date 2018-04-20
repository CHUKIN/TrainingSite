using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TrainingSite.Models
{
	public class DataBaseContext: DbContext
	{
//		static DataBaseContext()
//		{
//			Database.SetInitializer<DataBaseContext>(new MyContextInitializer());
//		}
		
		public DbSet<Competence> CompetencesList { get; set; }
		public DbSet<Course> CoursesList { get; set; }
		public DbSet<Department> DepartmentsList { get; set; }
		public DbSet<Group> GroupsList { get; set; }
		public DbSet<Module> ModulesList { get; set; }
		public DbSet<Position> PositionsList { get; set; }
		public DbSet<Step> StepsList { get; set; }
		public DbSet<Story> StoriesList { get; set; }
		public DbSet<Test> TestsList { get; set; }
		public DbSet<Theory> TheoriesList { get; set; }
		public DbSet<User> UsersList { get; set; }
		public DbSet<Variant> VariantsList { get; set; }
		public DbSet<Video> VideoList { get; set; }
		public DbSet<Language> LanguagesList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

//	internal class MyContextInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
//	{
//		protected override void Seed(DataBaseContext db)
//		{
//		}
//	}
}