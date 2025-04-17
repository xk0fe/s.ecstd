using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy.Systems;

namespace Sandbox.Source.Features.Enemy;

public class EnemyFeature : StorageFeatureBase
{
	public override void RegisterStorages( DlContainer container )
	{
	}

	public override void RegisterSystems( DlContainer container )
	{
		AddSystem( new EnemyDeathAnimationSystem() );
		AddSystem( new EnemySpawnerSystem( container ) );
		AddSystem( new EnemySpawnAnimationSystem() );
		AddSystem( new EnemyMovementSystem() );
		AddSystem( new EnemySpawnerOverTimeSystem() );
		AddSystem( new EnemyCleanupSystem() );
	}
}
