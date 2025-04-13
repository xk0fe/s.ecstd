using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy.Systems;

namespace Sandbox.Source.Features.Enemy;

public class EnemyFeatureBase : FeatureBase
{
	public EnemyFeatureBase( DlContainer container )
	{
		AddSystem( new EnemySpawnerSystem( container ) );
		AddSystem( new EnemySpawnAnimationSystem() );
		AddSystem( new EnemyMovementSystem() );
		AddSystem( new EnemySpawnerOverTimeSystem() );
	}
}
