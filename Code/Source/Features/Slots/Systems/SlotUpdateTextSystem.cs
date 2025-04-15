using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Slots.Components;

namespace Sandbox.Source.Features.Slots.Systems;

public class SlotUpdateTextSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<SlotComponent>()
		.With<SlotUpdateTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var component = ref entity.GetComponent<SlotComponent>();
			component.TextRenderer.Text = "$ " + component.CurrentMoney;
		}
	}
}
