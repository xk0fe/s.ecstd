using System.Text.Json.Serialization;

namespace Sandbox.Source.Features.Turrets.Configs;

public class TurretUpgrade
{
	[JsonPropertyName("id")] public string Id { get; set; }
	[JsonPropertyName("name")] public string Name { get; set; }
	[JsonPropertyName("cost")] public int Cost { get; set; }
	[JsonPropertyName("description")] public string Description { get; set; }
	[JsonPropertyName("modifiers")] public StatModifiers Modifiers { get; set; }
}
