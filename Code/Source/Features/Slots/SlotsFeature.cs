using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Slots.Systems;

namespace Sandbox.Source.Features.Slots;

public class SlotsFeature : FeatureBase
{
	public SlotsFeature( DlContainer container )
	{
		AddSystem( new SlotActiveSystem() );
		AddSystem( new SlotUpdateTextSystem() );
		AddSystem( new SlotUpgradeSystem() );
	}
}
