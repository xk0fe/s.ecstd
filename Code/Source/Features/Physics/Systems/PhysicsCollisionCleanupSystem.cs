using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Collisions;
using Sandbox.Source.Features.Physics.Common;

namespace Sandbox.Source.Features.Physics.Systems;

public class PhysicsCollisionCleanupSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<CollisionComponent>()
		.With<CalculatedTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<CalculatedTag>();
			
			// Clear and remove OnCollisionStart
			if (entity.HasComponent<OnCollisionStart>())
			{
				entity.RemoveComponent<OnCollisionStart>();
			}
			
			// Clear and remove OnCollisionUpdate
			if (entity.HasComponent<OnCollisionUpdate>())
			{
				entity.RemoveComponent<OnCollisionUpdate>();
			}
			
			// Clear and remove OnCollisionStop
			if (entity.HasComponent<OnCollisionStop>())
			{
				entity.RemoveComponent<OnCollisionStop>();
			}

			// Clear storage data for this entity
			PhysicsStorage.ClearEntityData(entity);
		}
	}
}
