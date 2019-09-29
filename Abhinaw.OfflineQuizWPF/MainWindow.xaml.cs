using Abhinaw.OfflineQuizWPF.ViewModel;
using System;
using System.Windows;

namespace Abhinaw.OfflineQuizWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainViewModel ViewModel { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			ViewModel = new MainViewModel
			{
				CurrentPage = new LoginViewModel()
			};
			DataContext = ViewModel;
			Instance = this;
		}

		public static MainWindow Instance { get; private set; }

		public bool AskBeforeSubmit()
		{
			return MessageBox.Show("Are you sure want to submit?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
		}

		public bool AskToReviewSkippedQuestions(int skippedCount)
		{
			return MessageBox.Show($"There are {skippedCount} skipped question. Would you like to review them?", "Info", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
		}

		public void TimerExpire()
		{
			MessageBox.Show("Your time has been expire.");
		}
	}
}
