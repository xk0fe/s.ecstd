using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Common.Storages;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemySpawnerSystem : SystemBase
{
	private readonly TestStorage _storage;

	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<EnemySpawnerComponent>()
		.With<InvokeComponent>()
		.With<EnemySpawnerActiveTag>();

	public EnemySpawnerSystem( DlContainer container )
	{
		_storage = container.Get<TestStorage>();
	}

	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<InvokeComponent>();
			var spawner = entity.GetComponent<EnemySpawnerComponent>();
			
			var spawnPosition = spawner.SpawnPosition;
			if ( !spawnPosition.IsValid() || !spawner.SpawnPrefab.IsValid() ) continue;
			var position = spawnPosition.WorldPosition;
			// var spawnRadius = spawner.SpawnRadius;
			for ( var i = 0; i < spawner.SpawnCount; i++ )
			{
				// var spawnOffset = Random.Shared.Float( -spawnRadius, spawnRadius );
				// var spawnPos = position + spawnOffset;
				SpawnEnemy( spawner.SpawnPrefab, position );
			}
			Log.Info( "Spawning enemy!" );
		}
	}

	private void SpawnEnemy(GameObject prefab, Vector3 position)
	{
		var instance = prefab.Clone();
		var enemy = World.Default.CreateEntity();
		enemy.SetComponent(new GameObjectComponent {Value = instance});
		enemy.SetComponent(new PositionComponent {Value = position});
		enemy.AddComponent<SyncPositionToGameObjectTag>();
		enemy.AddComponent<EnemyComponent>();
	}
}
