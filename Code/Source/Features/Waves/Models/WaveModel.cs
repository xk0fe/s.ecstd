namespace Sandbox.Source.Features.Waves.Models;

public class WaveModel
{
	[Property] public float Duration { get; set; }
	[Property, InlineEditor] public SpawnModel[] Spawns { get; set; }
}
