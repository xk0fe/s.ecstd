using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Waves.Systems;

namespace Sandbox.Source.Features.Waves;

public class WaveFeature : StorageFeatureBase
{
	public WaveFeature( DlContainer container )
	{
		AddSystem( new WaveSpawnSystem( container ) );
	}

	public override void RegisterStorages( DlContainer container )
	{
	}

	public override void RegisterSystems( DlContainer container )
	{
	}
}
