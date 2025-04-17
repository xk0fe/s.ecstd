using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.Source.Features.Waves.Systems;

namespace Sandbox.Source.Features.Waves;

public class WaveFeature : StorageFeatureBase
{
	public override void RegisterStorages( DlContainer container )
	{
	}

	public override void RegisterSystems( DlContainer container )
	{
		AddSystem( new WaveSpawnSystem( container ) );
	}
}
