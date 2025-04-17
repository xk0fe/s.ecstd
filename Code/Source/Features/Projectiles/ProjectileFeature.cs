using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Projectiles.Systems;

namespace Sandbox.Source.Features.Projectiles;

public class ProjectileFeature : StorageFeatureBase
{
	public ProjectileFeature( DlContainer container )
	{
		AddSystem( new ProjectileMovementSystem() );
		AddSystem( new ProjectileCollisionSystem() );
		AddSystem( new ProjectileViewSystem() );
		AddSystem( new ProjectileLifeTimeSystem() );
		AddSystem( new ProjectileCleanupSystem() );
	}

	public override void RegisterStorages( DlContainer container )
	{
	}

	public override void RegisterSystems( DlContainer container )
	{
	}
}
