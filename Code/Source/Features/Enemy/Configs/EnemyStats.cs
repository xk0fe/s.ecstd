using System.Text.Json.Serialization;

namespace Sandbox.Source.Features.Enemy.Configs;

public class EnemyStats
{
	[JsonPropertyName( "range" )] public float Range { get; set; }
	[JsonPropertyName( "damage" )] public float Damage { get; set; }
	[JsonPropertyName( "fireRate" )] public float FireRate { get; set; }
}
