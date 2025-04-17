using Sandbox.k.StateMachine.Interfaces;

namespace Sandbox.k.StateMachine.Common;

public abstract class TimedConditionalState : IConditionalState
{
	private TimeSince _timeSinceEntered;
	private float _duration;
	
	public TimedConditionalState(float duration)
	{
		_duration = duration;
	}

	public virtual void OnEnter()
	{
		_timeSinceEntered = 0;
	}

	public abstract void OnUpdate();

	public abstract void OnExit();

	public virtual bool ShouldTransition()
	{
		return _timeSinceEntered >= _duration;
	}

	public abstract IConditionalState GetNextState();
}
