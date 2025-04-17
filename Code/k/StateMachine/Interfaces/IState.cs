namespace Sandbox.k.StateMachine.Interfaces;

public interface IState
{
	void OnEnter();
	void OnUpdate();
	void OnExit();
}
