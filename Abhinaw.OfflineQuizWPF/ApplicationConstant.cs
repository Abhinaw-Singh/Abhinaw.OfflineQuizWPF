using System;
using System.Configuration;

namespace Abhinaw.OfflineQuizWPF
{
	public class ApplicationConstant
	{
		public static readonly int QUIZ_TIME_EXPIRE_IN_MINUTE;
		public static readonly int NO_OF_QUESTION;

		static ApplicationConstant()
		{
			QUIZ_TIME_EXPIRE_IN_MINUTE = Convert.ToInt32(ConfigurationManager.AppSettings["quizTimeExpireInMinute"]);
			NO_OF_QUESTION = Convert.ToInt32(ConfigurationManager.AppSettings["noOfQuestion"]);
		}
	}
}
