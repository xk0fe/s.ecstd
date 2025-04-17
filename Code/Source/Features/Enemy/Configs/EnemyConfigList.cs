using System.Text.Json.Serialization;

namespace Sandbox.Source.Features.Enemy.Configs;

public class EnemyConfigList
{
	[JsonPropertyName( "enemies" )] public List<EnemyConfig> Enemies { get; set; }
}
