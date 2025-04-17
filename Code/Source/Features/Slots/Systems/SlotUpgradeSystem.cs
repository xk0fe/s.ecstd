using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Slots.Components;

namespace Sandbox.Source.Features.Slots.Systems;

public class SlotUpgradeSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<SlotComponent>()
		.With<SlotCompleteTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<SlotCompleteTag>();
			ref var component = ref entity.GetComponent<SlotComponent>();
			component.CurrentMoney = 200000;
			var enabledState = int.MinValue;
			for ( var i = 0; i < component.States.Length; i++ )
			{
				var state = component.States[i];
				if ( state.IsActive )
				{
					enabledState = i;
					state.SetActive( false, component.Collider );
				}
				else if ( enabledState + 1 == i )
				{
					state.SetActive( true, component.Collider );
				}
			}
		}
	}
}
