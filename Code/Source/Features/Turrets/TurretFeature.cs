using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Turrets.Systems;

namespace Sandbox.Source.Features.Turrets;

public class TurretFeature : StorageFeatureBase
{
	public override void RegisterStorages( DlContainer container )
	{
	}

	public override void RegisterSystems( DlContainer container )
	{
		AddSystem( new TurretCooldownSystem() );
		AddSystem( new TurretShootSystem() );
		AddSystem( new TurretInactiveSystem() );
	}
}
