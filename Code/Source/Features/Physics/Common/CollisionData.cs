using Sandbox.Source.Features.Physics.Enums;

namespace Sandbox.Source.Features.Physics.Common;

public struct CollisionData
{
	public CollisionChangeState State { get; set; }
	public Collision Other { get; set; }
	public CollisionStop Stop { get; set; }
}
