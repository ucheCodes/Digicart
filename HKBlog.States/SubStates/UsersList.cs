using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
	public class UsersList
	{
		public IReadOnlyList<User> Data { get; }
		public UsersList(List<User> data)
		{
			Data = data;
		}
	}
}
