using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Turrets.Systems;

namespace Sandbox.Source.Features.Turrets;

public class TurretFeature : FeatureBase
{
	public TurretFeature( DlContainer container )
	{
		AddSystem( new TurretCooldownSystem() );
		AddSystem( new TurretShootSystem() );
		AddSystem( new TurretInactiveSystem() );
	}
}
