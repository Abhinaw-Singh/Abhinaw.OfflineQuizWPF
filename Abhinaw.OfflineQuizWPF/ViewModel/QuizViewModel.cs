using Abhinaw.OfflineQuizWPF.Data;
using Abhinaw.OfflineQuizWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Abhinaw.OfflineQuizWPF.ViewModel
{
	/// <summary>
	/// View model for handling Quiz, Next, Previous, Skip and Submit
	/// </summary>
	/// <seealso cref="Abhinaw.OfflineQuizWPF.ViewModel.BaseViewModel" />
	public class QuizViewModel : BaseViewModel
	{
		#region Private variables
		private List<Question> _quizQuestions;
		private Question _currentQuestion;
		int _currentQuestionNumber;
		DateTime _quizStartedOn; 
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="QuizViewModel"/> class.
		/// </summary>
		public QuizViewModel()
		{
			LoadRandomQuestions();
			GotoNextQuestionsCommand = new RelayCommand(GotoNextQuestions, CanGotoNext);
			SkipToNextQuestionsCommand = new RelayCommand(GotoNextQuestions);
			SubmitQuizCommand = new RelayCommand(ConfirmationBeforeSubmission);
			GotoPreviousQuestionsCommand = new RelayCommand(GotoPreviousQuestions);
			_quizStartedOn = DateTime.Now;
		}


		#region Public Properties

		/// <summary>
		/// Gets or sets the goto next questions command.
		/// </summary>
		/// <value>
		/// The goto next questions command.
		/// </value>
		public ICommand GotoNextQuestionsCommand { get; set; }
		/// <summary>
		/// Gets or sets the skip to next questions command.
		/// </summary>
		/// <value>
		/// The skip to next questions command.
		/// </value>
		public ICommand SkipToNextQuestionsCommand { get; set; }
		/// <summary>
		/// Gets or sets the submit quiz command.
		/// </summary>
		/// <value>
		/// The submit quiz command.
		/// </value>
		public ICommand SubmitQuizCommand { get; set; }
		/// <summary>
		/// Gets or sets the goto previous questions command.
		/// </summary>
		/// <value>
		/// The goto previous questions command.
		/// </value>
		public ICommand GotoPreviousQuestionsCommand { get; set; }

		//
		/// <summary>
		/// Gets or sets the current question number.
		/// </summary>
		/// <value>
		/// The current question number.
		/// </value>
		public int CurrentQuestionNumber
		{
			get
			{
				return _currentQuestionNumber;
			}
			set
			{
				_currentQuestionNumber = value;
				OnPropertyChanged(nameof(CurrentQuestionNumber));
			}
		}
		/// <summary>
		/// Gets or sets the quiz questions.
		/// </summary>
		/// <value>
		/// The quiz questions.
		/// </value>
		public List<Question> QuizQuestions
		{
			get
			{
				return _quizQuestions;
			}
			set
			{
				_quizQuestions = value;
				OnPropertyChanged(nameof(QuizQuestions));
			}
		}

		/// <summary>
		/// Gets or sets the current question.
		/// </summary>
		/// <value>
		/// The current question.
		/// </value>
		public Question CurrentQuestion
		{
			get
			{
				return _currentQuestion;
			}
			set
			{
				_currentQuestion = value;
				_currentQuestion.IsDisplayed = true;
				OnPropertyChanged(nameof(CurrentQuestion));
			}
		}

		#endregion


		#region Public Methods
		/// <summary>
		/// Goto the result view.
		/// </summary>
		public void GotoResultView()
		{
			MainWindow.Instance.ViewModel.ShowResult(_quizQuestions, _quizStartedOn);
		} 
		#endregion
		#region Private Methods
		/// <summary>
		/// Determines whether next button will be enable
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns>
		///   <c>true</c> if Determines whether next button will be enable; otherwise, <c>false</c>.
		/// </returns>
		private bool CanGotoNext(object obj)
		{
			return CurrentQuestion.Options.Any(x => x.IsSelected);
		}

		/// <summary>
		/// Confirmations the before submission.
		/// </summary>
		/// <param name="obj">The object.</param>
		private void ConfirmationBeforeSubmission(object obj)
		{

			var isAllAttempted = _quizQuestions.All(x => x.Options.Any(y => y.IsSelected));
			if (!isAllAttempted)
			{
				var skippedCount = _quizQuestions.Count(x => x.Options.All(y => !y.IsSelected));
				if (MainWindow.Instance.AskToReviewSkippedQuestions(skippedCount))
				{
					DisplaySkippedQuestions();
					return;
				}

				GotoResultView();
				return;
			}
			else
			{
				var result = MainWindow.Instance.AskBeforeSubmit();
				if (result)
					GotoResultView();
			}
		}


		/// <summary>
		/// Displays the skipped questions.
		/// </summary>
		private void DisplaySkippedQuestions()
		{
			_quizQuestions = _quizQuestions.OrderBy(x => x.Options.Any(y => y.IsSelected)).ToList();
			CurrentQuestion = _quizQuestions.FirstOrDefault(x => x.Options.All(y => !y.IsSelected));
			var index = _quizQuestions.IndexOf(CurrentQuestion);
			CurrentQuestionNumber = index;
		}

		/// <summary>
		/// Go to the previous questions.
		/// </summary>
		/// <param name="obj">The object.</param>
		private void GotoPreviousQuestions(object obj)
		{
			if (QuizQuestions.Count == CurrentQuestionNumber)
				--CurrentQuestionNumber;
			if (0 != CurrentQuestionNumber)
				--CurrentQuestionNumber;

			CurrentQuestion = _quizQuestions[CurrentQuestionNumber];
		}

		/// <summary>
		/// Goto the next questions.
		/// </summary>
		/// <param name="obj">The object.</param>
		private void GotoNextQuestions(object obj)
		{
			++CurrentQuestionNumber;
			if (QuizQuestions.Count - 1 >= CurrentQuestionNumber)
			{
				CurrentQuestion = _quizQuestions[CurrentQuestionNumber];
			}
			else
			{
				CurrentQuestionNumber = QuizQuestions.Count;
			}
		}
		/// <summary>
		/// Loads the random questions.
		/// </summary>
		private void LoadRandomQuestions()
		{
			QuizQuestions = QuizQuestionReader.GetRandomQuestions();
			CurrentQuestion = QuizQuestions[0];
		} 
		#endregion
	}
}
