using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Economy;
using Sandbox.Source.Features.Slots.Components;

namespace Sandbox.Source.Features.Slots.Systems;

public class SlotActiveSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<SlotComponent>()
		.With<SlotActiveTag>()
		.Without<SlotCompleteTag>();
	
	private Wallet _wallet;
	
	public SlotActiveSystem( DlContainer container )
	{
		_wallet = container.Get<Wallet>();
	}

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

			var DEBUG_PRICE = 1;
			
			if ( !_wallet.TrySpendCurrency( DEBUG_PRICE ) )
			{
				entity.RemoveComponent<SlotActiveTag>();
				continue;
			}
			component.CurrentMoney--;
			component.TextRenderer.Text = "$ " + component.CurrentMoney;
		}
	}
}
