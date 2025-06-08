using Sandbox.k;
using Sandbox.k.DependencyLocator;

namespace Sandbox.Source.Features.Economy;

public class EconomyFeature : StorageFeatureBase
{
	private const int STARTING_CURRENCY = 100;
	
	public override void RegisterStorages( DlContainer container )
	{
		var wallet = new Wallet(STARTING_CURRENCY); // use constructor before registering
		container.Register(wallet);
	}

	public override void RegisterSystems( DlContainer container )
	{
	}
}
