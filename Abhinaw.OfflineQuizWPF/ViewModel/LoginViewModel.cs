using System.Windows.Input;

namespace Abhinaw.OfflineQuizWPF.ViewModel
{
	/// <summary>
	/// View model for gettting user name
	/// </summary>
	/// <seealso cref="Abhinaw.OfflineQuizWPF.ViewModel.BaseViewModel" />
	public class LoginViewModel : BaseViewModel
	{
		#region Private Variables
		private readonly RelayCommand _loginCommand;
		private string _userName;

		#endregion
		#region Public Properties
		/// <summary>
		/// Gets the login command.
		/// </summary>
		/// <value>
		/// The login command.
		/// </value>
		public ICommand LoginCommand
		{
			get
			{
				return _loginCommand;
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
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}


		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="LoginViewModel"/> class.
		/// </summary>
		public LoginViewModel()
		{
			_loginCommand = new RelayCommand(GoNext, CanGoNext);
		}

		#region private methods 

		/// <summary>
		/// Determines whether user can go to next view.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns>
		///   <c>true</c> if  user can go to next view; otherwise, <c>false</c>.
		/// </returns>
		private bool CanGoNext(object obj)
		{
			return !string.IsNullOrEmpty(UserName);
		}
		/// <summary>
		/// Goes the next view
		/// </summary>
		/// <param name="obj">The object.</param>
		private void GoNext(object obj)
		{
			MainWindow.Instance.ViewModel.UserName = UserName;
			MainWindow.Instance.ViewModel.ChangeView(ApplicationPagesEnum.Instruction);
		} 
		#endregion
	}
}
