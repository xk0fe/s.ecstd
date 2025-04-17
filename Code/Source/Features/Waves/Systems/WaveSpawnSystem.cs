using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Enemy.Components;
using Sandbox.Source.Features.Enemy.Resources;
using Sandbox.Source.Features.Spawners;
using Sandbox.Source.Features.Waves.Common;
using Sandbox.Source.Features.Waves.Resources;

namespace Sandbox.Source.Features.Waves.Systems;

public class WaveSpawnSystem : SystemBase
{
	private EntityFilter _requestFilter = Filter.Default().With<SpawnCurrentWave>();
	private EntityFilter _spawnFilter = Filter.Default()
		.With<SpawnerComponent>().With<SpawnGameObject>();
	
	private WaveDatabase _waveDatabase;
	private EnemyDatabase _enemyDatabase;

	private int DEBUG_CURRENT_WAVE = 1;

	public WaveSpawnSystem( DlContainer container )
	{
		_waveDatabase = container.Get<WaveDatabase>();
		_enemyDatabase = container.Get<EnemyDatabase>();
	}

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var requestEntity in _requestFilter )
		{
			requestEntity.RemoveComponent<SpawnCurrentWave>();

			var spawner = new Spawner(); // todo
			var currentWave = _waveDatabase.GetWave( DEBUG_CURRENT_WAVE );
			foreach ( var spawn in currentWave.Spawns )
			{
				for ( var i = 0; i < spawn.SpawnCount; i++ )
				{
					if ( !_enemyDatabase.TryGetEnemyPrefab( spawn.EnemyId, out var prefab ) ) continue;
					spawner.Spawn( prefab, instance =>
					{
						var entity = World.Default.CreateEntity();
						entity.SetComponent( new GameObjectComponent { Value = instance, } );
						entity.SetComponent( new EnemyTag() );
						entity.SetComponent( new EnemyFollowPathTag() );
					} );
				}
			}
		}
	}
}
