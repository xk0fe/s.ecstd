using Sandbox.Source.Features.Waves.Models;

namespace Sandbox.Source.Features.Waves.Resources;

[GameResource("Wave Database", "wavdb", "Database of waves duh", Category = "Game", Icon = "sports_baseball")]
public class WaveDatabase : GameResource
{
	[Property] public WaveModel[] Waves { get; set; }
	
	public WaveModel GetWave( int index )
	{
		return Waves[index % Waves.Length];
	}
}
