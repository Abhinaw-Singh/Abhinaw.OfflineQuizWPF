using System.ComponentModel;

namespace Abhinaw.OfflineQuizWPF.ViewModel
{
	/// <summary>
	/// Base for all view model
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class BaseViewModel: INotifyPropertyChanged
	{
		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Called when property changed.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
