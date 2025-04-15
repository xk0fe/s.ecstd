using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Physics.Components.Triggers;
using Sandbox.Source.Features.Slots.Components;

namespace Sandbox.Source.Features.Slots.Systems;

public class OnSlotTriggerEnter : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<SlotComponent>().With<OnTriggerEnterComponent>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var component = ref entity.GetComponent<OnTriggerEnterComponent>();
			if (component.Triggers == null) continue;
			foreach ( var trigger in component.Triggers )
			{
				var isPlayer = trigger.GameObject.Components.TryGet<PlayerController>( out _);
				if ( !isPlayer && trigger.GameObject.Parent.IsValid() )
				{
					isPlayer = trigger.GameObject.Parent.Components.TryGet<PlayerController>( out _);
				}
				
				if ( isPlayer )
				{
					entity.SetComponent( new SlotActiveTag() );
				}
			}
		}
	}
}
