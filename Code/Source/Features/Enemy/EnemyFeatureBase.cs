using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy.Systems;

namespace Sandbox.Source.Features.Enemy;

public class EnemyFeatureBase : FeatureBase
{
	public EnemyFeatureBase()
	{
		AddSystem( new EnemySpawnerSystem() );
	}
}
