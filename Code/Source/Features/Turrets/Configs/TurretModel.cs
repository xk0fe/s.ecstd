using System.Text.Json.Serialization;

namespace Sandbox.Source.Features.Turrets.Configs;

public class TurretModel
{
	[JsonPropertyName( "id" )] public string Id { get; set; }
	[JsonPropertyName( "name" )] public string Name { get; set; }
	[JsonPropertyName( "baseCost" )] public int BaseCost { get; set; }
	[JsonPropertyName( "description" )] public string Description { get; set; }
	[JsonPropertyName( "stats" )] public TurretStats Stats { get; set; }
	[JsonPropertyName( "upgrades" )] public List<TurretUpgrade> Upgrades { get; set; }
}
