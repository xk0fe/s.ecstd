using System.Text.Json.Serialization;

namespace Sandbox.Source.Features.Turrets.Configs;

public class TurretConfig
{
	[JsonPropertyName("turrets")]
	public List<TurretModel> Turrets { get; set; }
}
