using System;
using System.Windows.Input;

namespace Abhinaw.OfflineQuizWPF
{
	/// <summary>
	/// Relay Command
	/// </summary>
	/// <seealso cref="System.Windows.Input.ICommand" />
	public class RelayCommand : ICommand
	{


		#region Private Variables
		readonly Action<object> _execute;
		readonly Predicate<object> _canExecute; 
		#endregion


		/// <summary>
		/// Occurs when changes occur that affect whether or not the command should execute.
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand"/> class.
		/// </summary>
		/// <param name="execute">The execute.</param>
		public RelayCommand(Action<object> execute)
			: this(execute, null) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand"/> class.
		/// </summary>
		/// <param name="execute">The command that has to be execute.</param>
		/// <param name="canExecute">is command available to executed.</param>
		/// <exception cref="ArgumentNullException">execute</exception>
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException("execute");
			_canExecute = canExecute;
		}

		/// <summary>
		/// Defines the method that determines whether the command can execute in its current state.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
		/// </returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}


		/// <summary>
		/// Defines the method to be called when the command is invoked.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
}
