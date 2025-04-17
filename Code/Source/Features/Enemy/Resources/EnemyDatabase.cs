using Sandbox.Source.Features.Enemy.Configs;

namespace Sandbox.Source.Features.Enemy.Resources;

[GameResource("Enemy Database", "npcdb", "Database of enemies duh", Category = "Game", Icon = "sports_baseball")]
public class EnemyDatabase : GameResource
{
	[Property, InlineEditor] public EnemyModel[] Enemies { get; set; }

	public bool TryGetEnemyPrefab( string enemyId, out GameObject prefab )
	{
		prefab = null;
		foreach ( var enemy in Enemies )
		{
			if ( enemy.Id == enemyId )
			{
				prefab = enemy.Prefab;
				return prefab.IsValid();
			}
		}
		
		Log.Warning( $"Enemy with ID {enemyId} not found in the database." );
		return false;
	}
}
