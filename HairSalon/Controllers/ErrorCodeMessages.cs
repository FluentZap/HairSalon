using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrillinStyles.Controllers
{
	public static class ErrorCodeMessages
	{
		public static string FromCode(int code)
		{			
			switch (code)
			{
				case 1:
					return "User name already exists";
				default:
					break;
			}
			return "";
		}

	}
}
