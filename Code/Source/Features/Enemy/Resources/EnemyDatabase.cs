namespace Sandbox.Source.Features.Enemy.Resources;

[GameResource("Enemy Database", "npcdb", "Database of enemies duh", Category = "Game", Icon = "sports_baseball")]
public class EnemyDatabase : GameResource
{
	[Property] public string HelloWorld { get; set; } = "Hello World!";
}
