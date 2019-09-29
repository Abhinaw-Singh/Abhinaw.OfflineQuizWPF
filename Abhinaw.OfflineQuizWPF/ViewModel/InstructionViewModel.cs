using System.Windows.Input;

namespace Abhinaw.OfflineQuizWPF.ViewModel
{
	/// <summary>
	/// View model for instruction view
	/// </summary>
	/// <seealso cref="Abhinaw.OfflineQuizWPF.ViewModel.BaseViewModel" />
	public class InstructionViewModel : BaseViewModel
	{


		#region Public Property
		/// <summary>
		/// Gets or sets the start quiz command.
		/// </summary>
		/// <value>
		/// The start quiz command.
		/// </value>
		public ICommand StartQuizCommand { get; set; }
		/// <summary>
		/// Gets the project requirement.
		/// </summary>
		/// <value>
		/// The project requirement.
		/// </value>
		public string ProjectRequirement
		{
			get
			{
				return
@"
		

1. The application shall maintain a list of questions on any topic(General Knowledge, Science etc), out of which 10 questions shall be randomly selected for any test cycle to be attempted by the user (Questions can be stored in memory collections)
2. The system should allow the user to provide basic details before attempting the quiz
User Name
3. The system should allow the user to answer one question at a time
4. The user should complete the quiz within a certain time limit, the timer should be clearly displayed through out the quiz
5. The user should be able to skip any question(s) to be attempted later
6. The user should be able to review the skipped question before submitting the quiz
7. The system should prompt the user if any question(s) is skipped on/before submitting.
8. The system should clearly indicate visually the progress during the test.
9. The system should show the result of the test after submitting
	9.1 Date of examiniation taken
	9.2 Pass or failed";
			}
		}
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="InstructionViewModel"/> class.
		/// </summary>
		public InstructionViewModel()
		{
			StartQuizCommand = new RelayCommand(StartQuiz);
		}

		void StartQuiz(object param)
		{
			MainWindow.Instance.ViewModel.StartQuiz();
		}
		
	}
}
