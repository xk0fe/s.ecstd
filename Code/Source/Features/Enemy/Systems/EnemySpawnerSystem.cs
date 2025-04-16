using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Enemy.Components;
using Sandbox.Source.Features.Physics.Providers;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemySpawnerSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<EnemySpawnerComponent>()
		.With<InvokeComponent>()
		.With<EnemySpawnerActiveTag>();

	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<InvokeComponent>();
			var spawner = entity.GetComponent<EnemySpawnerComponent>();
			
			var spawnPosition = spawner.SpawnPosition;
			if ( !spawnPosition.IsValid() || !spawner.SpawnPrefab.IsValid() ) continue;
			var position = spawnPosition.WorldPosition;
			for ( var i = 0; i < spawner.SpawnCount; i++ )
			{
				SpawnEnemy( spawner.SpawnPrefab, position );
			}
		}
	}

	private void SpawnEnemy(GameObject prefab, Vector3 position)
	{
		var instance = prefab.Clone();
		var enemy = World.Default.CreateEntity();
		instance.AddComponent<EntityProviderLink>().EntityId = enemy;
		instance.AddComponent<CollisionProvider>();
		enemy.SetComponent(new GameObjectComponent {Value = instance});
		enemy.SetComponent(new PositionComponent {Value = position});
		enemy.AddComponent<SyncPositionToGameObjectTag>();
		enemy.AddComponent<EnemyTag>();
		enemy.AddComponent<EnemyFollowPathTag>();
	}
}
