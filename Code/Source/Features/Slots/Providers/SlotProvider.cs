using Sandbox.k.Common.Extensions;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;
using Sandbox.Source.Features.Physics.Components.Triggers;
using Sandbox.Source.Features.Slots.Components;

namespace Sandbox.Source.Features.Slots.Providers;

public class SlotProvider : EntityProvider<SlotComponent>, Component.ITriggerListener
{
	public void OnTriggerEnter( GameObject other )
	{
		if ( !other.IsPlayer() ) return;
		var entity = GetEntity();
		if ( entity == -1 ) return;
		entity.SetComponent( new SlotActiveTag() );
	}

	public void OnTriggerExit( GameObject other )
	{
		if ( !other.IsPlayer() ) return;
		var entity = GetEntity();
		if ( entity == -1 ) return;
		entity.RemoveComponent<SlotActiveTag>();
	}

	protected override void OnEntityCreated( int entityId )
	{
		base.OnEntityCreated( entityId );
		entityId.SetComponent( new SlotUpdateTag() );
	}
}
