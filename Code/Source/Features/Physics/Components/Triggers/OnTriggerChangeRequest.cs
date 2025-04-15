using Sandbox.Source.Features.Physics.Enums;

namespace Sandbox.Source.Features.Physics.Components.Triggers;

public struct OnTriggerChangeRequest
{
	public TriggerChangeState State;
	public Collider Other;
}
