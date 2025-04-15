using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;
using Sandbox.Source.Features.Physics.Common;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Triggers;
using Sandbox.Source.Features.Physics.Enums;

namespace Sandbox.Source.Features.Physics.Providers;

public class TriggerProvider : EntityProvider<TriggerComponent>, Component.ITriggerListener
{
	public void OnTriggerEnter( Collider other )
	{
		UpdateTrigger( TriggerChangeState.Enter, other );
	}

	public void OnTriggerExit( Collider other )
	{
		UpdateTrigger( TriggerChangeState.Exit, other );
	}
	
	private void UpdateTrigger(TriggerChangeState state, Collider other)
	{
		var entity = GetEntity();
		if ( entity == -1 ) return;
		var triggerData = new TriggerData { State = state, Other = other };
		if ( entity.HasComponent<TriggerComponent>() )
		{
			ref var component = ref entity.GetComponent<TriggerComponent>();
			component.Triggers ??= new Queue<TriggerData>();
			component.Triggers.Enqueue( triggerData );
		}
		else
		{
			entity.SetComponent( new TriggerComponent
			{
				Triggers = new Queue<TriggerData>( new[] { triggerData } )
			} );
		}
		entity.SetComponent( new RecalculateTag() );
	}
}
