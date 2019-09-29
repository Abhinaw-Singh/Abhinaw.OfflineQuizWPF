using System;
using Abhinaw.OfflineQuizWPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abhinaw.OfflineQuizWPF.Test
{
	[TestClass]
	public class LoginViewModelTest
	{
		private LoginViewModel _loginViewModel;

		public LoginViewModelTest()
		{
			_loginViewModel = new LoginViewModel();
		}
		[TestMethod]
		public void LoginWithOutUserNameFailed()
		{
			Assert.IsFalse(_loginViewModel.LoginCommand.CanExecute(null));
		}

		[TestMethod]
		public void LoginWithUserNameSuccess()
		{
			_loginViewModel.UserName = "Abhinaw Kumar";
			Assert.IsTrue(_loginViewModel.LoginCommand.CanExecute(null));
		}
	}
}
