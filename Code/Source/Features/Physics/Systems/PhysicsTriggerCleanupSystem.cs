using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Triggers;
using Sandbox.Source.Features.Physics.Common;

namespace Sandbox.Source.Features.Physics.Systems;

public class PhysicsTriggerCleanupSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<TriggerComponent>()
		.With<CalculatedTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<CalculatedTag>();
			
			// Clear and remove OnTriggerEnterComponent
			if (entity.HasComponent<OnTriggerEnterComponent>())
			{
				entity.RemoveComponent<OnTriggerEnterComponent>();
			}
			
			// Clear and remove OnTriggerExitComponent
			if (entity.HasComponent<OnTriggerExitComponent>())
			{
				entity.RemoveComponent<OnTriggerExitComponent>();
			}

			// Clear storage data for this entity
			PhysicsStorage.ClearEntityData(entity);
		}
	}
}
