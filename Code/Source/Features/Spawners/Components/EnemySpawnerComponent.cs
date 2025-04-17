namespace Sandbox.Source.Features.Enemy.Components;

public struct EnemySpawnerComponent 
{
	[Property] public int SpawnCount { get; set; }
	[Property] public float SpawnRadius { get; set; }
	[Property] public float SpawnDelay { get; set; }
	[Property] public GameObject SpawnPosition { get; set; }
	[Property] public string EnemyId { get; set; }
	
	public TimeSince SpawnTimer { get; set; }
}
