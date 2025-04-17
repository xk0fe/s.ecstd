using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Slots.Components;

namespace Sandbox.Source.Features.Slots.Systems;

public class SlotActiveSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<SlotComponent>()
		.With<SlotActiveTag>()
		.Without<SlotCompleteTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var component = ref entity.GetComponent<SlotComponent>();

			entity.SetComponent( new SlotUpdateTag() );
			if (component.CurrentMoney <= 0)
			{
				entity.RemoveComponent<SlotActiveTag>();
				entity.SetComponent( new SlotCompleteTag() );
				continue;
			}
			component.CurrentMoney--;
			component.TextRenderer.Text = "$ " + component.CurrentMoney;
		}
	}
}
