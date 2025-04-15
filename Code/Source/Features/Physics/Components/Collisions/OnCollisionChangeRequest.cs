using Sandbox.Source.Features.Physics.Enums;

namespace Sandbox.Source.Features.Physics.Components.Collisions;

public struct OnCollisionChangeRequest
{
	public CollisionChangeState State;
	public Collision Other;
	public CollisionStop OtherStop;
}
