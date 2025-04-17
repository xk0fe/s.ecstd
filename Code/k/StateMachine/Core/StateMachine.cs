using Sandbox.k.StateMachine.Interfaces;

namespace Sandbox.k.StateMachine.Core;

public class StateMachine<T> where T : IState
{
	protected T _currentState;

	public StateMachine( T initialState )
	{
		ChangeState( initialState );
	}

	public virtual void Update()
	{
		_currentState.OnUpdate();
	}

	public void ChangeState( T newState )
	{
		if ( _currentState != null ) _currentState.OnExit();

		_currentState = newState;
		if ( newState != null ) newState.OnEnter();
	}
}
