using System.Text.Json.Serialization;

namespace Sandbox.Source.Features.Enemy.Configs;

public class EnemyConfig
{
	[JsonPropertyName( "id" )] public string Id { get; set; }
	[JsonPropertyName( "name" )] public string Name { get; set; }
	[JsonPropertyName( "speed" )] public float Speed { get; set; }
	[JsonPropertyName( "stats" )] public EnemyStats Stats { get; set; }
}
