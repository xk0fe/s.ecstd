using System.Text.Json.Serialization;

namespace Sandbox.Source.Features.Turrets.Configs;

public class StatModifiers
{
	[JsonPropertyName("range")] public float Range { get; set; }
	[JsonPropertyName("damage")] public float Damage { get; set; }
	[JsonPropertyName("speed")] public float Speed { get; set; }
}
