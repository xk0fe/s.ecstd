using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy.Systems;

namespace Sandbox.Source.Features.Enemy;

public class EnemyFeature : Feature
{
	public EnemyFeature()
	{
		AddSystem( new EnemySpawnerSystem() );
	}
}
