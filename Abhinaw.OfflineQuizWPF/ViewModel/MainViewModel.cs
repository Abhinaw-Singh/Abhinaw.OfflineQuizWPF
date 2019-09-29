using Abhinaw.OfflineQuizWPF.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace Abhinaw.OfflineQuizWPF.ViewModel
{
	/// <summary>
	/// View model for main window, this handles navigation, user and timer
	/// </summary>
	/// <seealso cref="Abhinaw.OfflineQuizWPF.ViewModel.BaseViewModel" />
	public class MainViewModel : BaseViewModel
	{
		#region Private members
		private readonly Dictionary<ApplicationPagesEnum, Type> _applicationPages;
		private BaseViewModel _currentPage;
		private string _userName;
		private TimeSpan _remainingTime;
		DispatcherTimer _timer;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="MainViewModel"/> class.
		/// </summary>
		public MainViewModel()
		{
			_applicationPages = new Dictionary<ApplicationPagesEnum, Type>
			{
				{ApplicationPagesEnum.Login,typeof(LoginViewModel) },
				{ApplicationPagesEnum.Instruction,typeof(InstructionViewModel) },
				{ApplicationPagesEnum.Quiz,typeof(QuizViewModel) },
				{ApplicationPagesEnum.Result,typeof(ResultViewModel) },
			};
			_remainingTime = TimeSpan.FromMinutes(ApplicationConstant.QUIZ_TIME_EXPIRE_IN_MINUTE);
		}

		#region Public Properties
		/// <summary>
		/// Gets or sets the remaining time.
		/// </summary>
		/// <value>
		/// The remaining time.
		/// </value>
		public TimeSpan RemainingTime
		{
			get
			{
				return _remainingTime;
			}
			set
			{
				_remainingTime = value;
				OnPropertyChanged(nameof(RemainingTime));
			}
		}
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = $"Hello {value}!";
				OnPropertyChanged(nameof(UserName));
			}
		}

		/// <summary>
		/// Gets or sets the current page.
		/// </summary>
		/// <value>
		/// The current page.
		/// </value>
		public BaseViewModel CurrentPage
		{
			get
			{
				return _currentPage;
			}
			set
			{
				_currentPage = value;
				OnPropertyChanged(nameof(CurrentPage));
			}
		}

		#endregion
		
		#region Public Methods
		/// <summary>
		/// Starts the quiz.
		/// </summary>
		public void StartQuiz()
		{
			ChangeView(ApplicationPagesEnum.Quiz);
			StartTimer();
		}
		/// <summary>
		/// Changes the view.
		/// </summary>
		/// <param name="page">The page.</param>
		public void ChangeView(ApplicationPagesEnum page)
		{
			if (!_applicationPages.ContainsKey(page))
				return;

			CurrentPage = (BaseViewModel)Activator.CreateInstance(_applicationPages[page]);
		}

		/// <summary>
		/// Shows the result view
		/// </summary>
		/// <param name="quizQuestions">The quiz questions.</param>
		/// <param name="quizStartedOn">The quiz started on.</param>
		public void ShowResult(List<Question> quizQuestions, DateTime quizStartedOn)
		{
			CurrentPage = (BaseViewModel)Activator.CreateInstance(_applicationPages[ApplicationPagesEnum.Result], quizQuestions, quizStartedOn);
			_timer.Stop();
		}

		#endregion

		#region Private Methods
		/// <summary>
		/// Starts the timer.
		/// </summary>
		private void StartTimer()
		{
			_timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.DataBind, delegate
			{

				if (_remainingTime == TimeSpan.Zero)
				{
					_timer.Stop();
					MainWindow.Instance.TimerExpire();
					((QuizViewModel)CurrentPage).GotoResultView();
				}
				RemainingTime = RemainingTime.Add(TimeSpan.FromSeconds(-1));
			}, Application.Current.Dispatcher);

			_timer.Start();
		}

		#endregion
	}
}
