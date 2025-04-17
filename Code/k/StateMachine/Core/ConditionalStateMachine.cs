using Sandbox.k.StateMachine.Interfaces;

namespace Sandbox.k.StateMachine.Core;

public class ConditionalStateMachine : StateMachine<IConditionalState>
{
	public ConditionalStateMachine( IConditionalState initialState ) : base( initialState )
	{
	}

	public override void Update()
	{
		if ( _currentState == null ) return;

		_currentState.OnUpdate();
		if ( !_currentState.ShouldTransition() ) return;

		var newState = _currentState.GetNextState();
		if ( newState != null ) ChangeState( newState );
	}
}
