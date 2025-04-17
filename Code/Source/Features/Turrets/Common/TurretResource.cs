namespace Sandbox.Source.Features.Turrets.Common;

[GameResource("Turret Definition", "trrt", "Turret settings", Category = "Game", Icon = "sports_baseball")]
public class TurretResource : GameResource
{
	[Property] public float ImpulseForce { get; set; }
	[Property] public float Cooldown { get; set; }
}
