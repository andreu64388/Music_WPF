using System;
using System.Windows.Input;

namespace Music.Model;

internal class RelayCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	private readonly Action<object> action;

	public RelayCommand(Action<object> action)
	{
		this.action += action;
	}

	public bool CanExecute(object? parameter)
	{
		return true;
	}

	public void Execute(object? parameter = null)
	{
		action?.Invoke(parameter);
	}
}