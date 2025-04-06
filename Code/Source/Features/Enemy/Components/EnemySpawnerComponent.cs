using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;

namespace Sandbox.Source.Features.Enemy.Components;

public class EnemySpawnerComponent : EntityProvider<EnemySpawnerComponent>
{
	[Property] public int SpawnCount { get; set; }
	[Property] public float SpawnRadius { get; set; }
	[Property] public float SpawnDelay { get; set; }
	[Property] public bool IsActive { get; set; }
	[Property] public GameObject SpawnPosition { get; set; }
	[Property] public GameObject SpawnPrefab { get; set; }
	
	[Button]
	private void Spawn()
	{
		GetEntity().AddComponent<InvokeComponent>();
	}
}
