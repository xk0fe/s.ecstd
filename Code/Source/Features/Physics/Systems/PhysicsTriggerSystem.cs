using System;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Physics.Common;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Triggers;
using Sandbox.Source.Features.Physics.Enums;

namespace Sandbox.Source.Features.Physics.Systems;

public class PhysicsTriggerSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<TriggerComponent>()
		.With<RecalculateTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<RecalculateTag>();
			ref var component = ref entity.GetComponent<TriggerComponent>();
			if ( component.Triggers == null ) continue;
			foreach ( var trigger in component.Triggers )
			{
				switch ( trigger.State )
				{
					case TriggerChangeState.Enter:
						OnTriggerStart( entity, trigger );
						break;
					case TriggerChangeState.Exit:
						OnTriggerExit( entity, trigger );
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			entity.SetComponent( new CalculatedTag() );
		}
	}

	private void OnTriggerStart( int entity, TriggerData data )
	{
		if ( entity.HasComponent<OnTriggerEnterComponent>() )
		{
			ref var triggerStart = ref entity.GetComponent<OnTriggerEnterComponent>();
			triggerStart.Triggers ??= new Queue<Collider>();
			triggerStart.Triggers.Enqueue( data.Other );
			return;
		}

		entity.SetComponent( new OnTriggerEnterComponent { Triggers = new Queue<Collider>( new[] { data.Other } ) } );
	}

	private void OnTriggerExit( int entity, TriggerData data )
	{
		if ( entity.HasComponent<OnTriggerExitComponent>() )
		{
			ref var triggerExit = ref entity.GetComponent<OnTriggerExitComponent>();
			triggerExit.Triggers ??= new Queue<Collider>();
			triggerExit.Triggers.Enqueue( data.Other );
			return;
		}

		entity.SetComponent( new OnTriggerExitComponent { Triggers = new Queue<Collider>( new[] { data.Other } ) } );
	}
}
