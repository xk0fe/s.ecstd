using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.Source.Features.Slots.Systems;

namespace Sandbox.Source.Features.Slots;

public class SlotsFeature : StorageFeatureBase
{
	public override void RegisterStorages( DlContainer container )
	{
	}

	public override void RegisterSystems( DlContainer container )
	{
		AddSystem( new SlotActiveSystem() );
		AddSystem( new SlotUpdateTextSystem() );
		AddSystem( new SlotUpgradeSystem() );
	}
}
