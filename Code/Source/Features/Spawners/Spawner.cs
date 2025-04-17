using System;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Spawners;

public class Spawner
{
	private Queue<SpawnerData> spawnerQueue = new Queue<SpawnerData>();

	private EntityFilter spawnerFilter = Filter.Default()
		.With<SpawnerComponent>()
		.Without<SpawnCooldownActive>();

	public void Spawn( GameObject prefab, Action<GameObject> onSpawn )
	{
		spawnerQueue.Enqueue( new SpawnerData( prefab, onSpawn ) );
	}

	public void OnUpdate()
	{
		if ( spawnerQueue.Count == 0 ) return;
		foreach ( var entity in spawnerFilter )
		{
			var spawnerData = spawnerQueue.Dequeue();
			entity.SetComponent( new SpawnGameObject() );
			if ( spawnerQueue.Count == 0 ) break;
		}
	}
}

public struct SpawnerData
{
	public GameObject Prefab;
	public Action<GameObject> OnSpawned;

	public SpawnerData( GameObject prefab, Action<GameObject> onSpawned )
	{
		Prefab = prefab;
		OnSpawned = onSpawned;
	}
}
