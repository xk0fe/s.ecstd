using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Common.Systems;

namespace Sandbox.Source.Features.Common;

public class CommonFeature : StorageFeatureBase
{
	public override void RegisterStorages( DlContainer container )
	{
	}

	public override void RegisterSystems( DlContainer container )
	{
		AddSystem( new GameObjectPositionSystem() );
		AddSystem( new DelayedDestroySystem() );
	}
}
