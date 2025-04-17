namespace Sandbox.k.StateMachine.Interfaces;

public interface IConditionalState : IState
{
	bool ShouldTransition();
	IConditionalState GetNextState();
}
