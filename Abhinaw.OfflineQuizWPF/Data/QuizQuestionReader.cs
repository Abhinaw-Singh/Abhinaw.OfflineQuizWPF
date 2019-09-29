using Abhinaw.OfflineQuizWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Abhinaw.OfflineQuizWPF.Data
{
	public class QuizQuestionReader
	{
		public static List<Question> GetRandomQuestions()
		{
			var qaJson = File.ReadAllText("qa.json");
			var questions = JsonConvert.DeserializeObject<List<Question>>(qaJson);
			return questions.OrderBy(x=> Guid.NewGuid()).Take(ApplicationConstant.NO_OF_QUESTION).ToList();
		}
	}
}
