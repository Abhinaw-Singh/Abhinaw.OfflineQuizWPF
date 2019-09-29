using Abhinaw.OfflineQuizWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Abhinaw.OfflineQuizWPF.ViewModel
{
	/// <summary>
	/// view model for displaying results
	/// </summary>
	/// <seealso cref="Abhinaw.OfflineQuizWPF.ViewModel.BaseViewModel" />
	public class ResultViewModel : BaseViewModel
	{
		#region Private Members
		private readonly List<Question> _quizQuestions;
		private DateTime _quizStartedOn;
		private int _numberOfAttemptedQuestions;
		private int _totalQuestion;
		private int _rightAnswer;
		private DateTime _quizcompletedOn;
		private bool _isPassed;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="ResultViewModel"/> class.
		/// </summary>
		/// <param name="quizQuestions">The quiz questions.</param>
		/// <param name="quizStartedOn">The quiz started on.</param>
		public ResultViewModel(List<Question> quizQuestions,DateTime quizStartedOn)
		{
			_quizQuestions = quizQuestions;
			_quizStartedOn = quizStartedOn;
			FindResult();
		}

		#region Public Propertiees
		/// <summary>
		/// Gets or sets the number of attempted questions.
		/// </summary>
		/// <value>
		/// The number of attempted questions.
		/// </value>
		public int NumberOfAttemptedQuestions
		{
			get
			{
				return _numberOfAttemptedQuestions;
			}
			set
			{
				_numberOfAttemptedQuestions = value;
				OnPropertyChanged(nameof(NumberOfAttemptedQuestions));
			}
		}
		/// <summary>
		/// Gets or sets the total question.
		/// </summary>
		/// <value>
		/// The total question.
		/// </value>
		public int TotalQuestion
		{
			get
			{
				return _totalQuestion;
			}
			set
			{
				_totalQuestion = value;
				OnPropertyChanged(nameof(TotalQuestion));
			}
		}
		/// <summary>
		/// Gets or sets the right answer.
		/// </summary>
		/// <value>
		/// The right answer.
		/// </value>
		public int RightAnswer
		{
			get
			{
				return _rightAnswer;
			}
			set
			{
				_rightAnswer = value;
				OnPropertyChanged(nameof(RightAnswer));
			}
		}
		/// <summary>
		/// Gets or sets the quiz completed on.
		/// </summary>
		/// <value>
		/// The quiz completed on.
		/// </value>
		public DateTime QuizCompletedOn
		{
			get
			{
				return _quizcompletedOn;
			}
			set
			{
				_quizcompletedOn = value;
				OnPropertyChanged(nameof(QuizCompletedOn));
			}
		}
		/// <summary>
		/// Gets or sets the quiz started on.
		/// </summary>
		/// <value>
		/// The quiz started on.
		/// </value>
		public DateTime QuizStartedOn
		{
			get
			{
				return _quizStartedOn;
			}
			set
			{
				_quizStartedOn = value;
				OnPropertyChanged(nameof(QuizStartedOn));
			}
		}

		/// <summary>
		/// Gets or sets a value indicating quiz result is passed or failed
		/// </summary>
		/// <value>
		///   <c>true</c> if quiz is passed; otherwise, <c>false</c>.
		/// </value>
		public bool IsPassed
		{
			get
			{
				return _isPassed;
			}
			set
			{
				_isPassed = value;
				OnPropertyChanged(nameof(IsPassed));
			}
		}

		#endregion
		#region Private Methods
		/// <summary>
		/// Finds the result.
		/// </summary>
		private void FindResult()
		{
			TotalQuestion = _quizQuestions.Count;
			NumberOfAttemptedQuestions = _quizQuestions.Count(x => x.Options.Any(y => y.IsSelected));
			RightAnswer = _quizQuestions.Count(x => x.Options.Any(y => y.IsSelected && y.IsCorrect));
			QuizCompletedOn = DateTime.Now;
			IsPassed = ((decimal)RightAnswer / TotalQuestion) * 100 > 60;
		} 
		#endregion
	}
}
