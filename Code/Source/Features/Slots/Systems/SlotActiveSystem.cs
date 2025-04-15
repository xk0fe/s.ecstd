using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Slots.Components;

namespace Sandbox.Source.Features.Slots.Systems;

public class SlotActiveSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<SlotComponent>().With<SlotActiveTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			Log.Info( "taking money" );
		}
	}
}
