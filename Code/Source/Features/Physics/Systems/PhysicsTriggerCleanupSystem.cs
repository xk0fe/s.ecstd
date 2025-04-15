using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Triggers;

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
			entity.RemoveComponent<OnTriggerEnterComponent>();
			entity.RemoveComponent<OnTriggerExitComponent>();
		}
	}
}
