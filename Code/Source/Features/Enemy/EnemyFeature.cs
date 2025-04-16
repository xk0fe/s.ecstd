using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy.Systems;

namespace Sandbox.Source.Features.Enemy;

public class EnemyFeature : FeatureBase
{
	public EnemyFeature( DlContainer container )
	{
		AddSystem( new EnemyDeathAnimationSystem() );
		AddSystem( new EnemySpawnerSystem() );
		AddSystem( new EnemySpawnAnimationSystem() );
		AddSystem( new EnemyMovementSystem() );
		AddSystem( new EnemySpawnerOverTimeSystem() );
		AddSystem( new EnemyCleanupSystem() );
	}
}
