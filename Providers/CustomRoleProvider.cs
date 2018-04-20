using System;
using System.Linq;
using System.Web.Security;
using TrainingSite.Models;

namespace TrainingSite.Providers
{
	public class CustomRoleProvider : RoleProvider
	{
		private readonly DataBaseContext _db = new DataBaseContext();

		public override string[] GetRolesForUser(string username)
		{
			var roles = new string[] { };

			var user = _db.UsersList.FirstOrDefault(u => u.Login == username);
			if (user?.Group != null)
			{
				// получаем роль
				roles = new string[] {user.Group.Name};
			}

			return roles;
		}

		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			// Получаем пользователя
			var user = _db.UsersList.FirstOrDefault(u => u.Login == username);

			return user?.Group != null && user.Group.Name == roleName;
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}
	}
}