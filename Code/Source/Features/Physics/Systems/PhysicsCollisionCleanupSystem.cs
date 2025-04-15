using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Collisions;

namespace Sandbox.Source.Features.Physics.Systems;

public class PhysicsCollisionCleanupSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<CollisionComponent>()
		.With<CalculatedTag>();

	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<CalculatedTag>();
			entity.RemoveComponent<OnCollisionStart>();
			entity.RemoveComponent<OnCollisionUpdate>();
			entity.RemoveComponent<OnCollisionStop>();
		}
	}
}
