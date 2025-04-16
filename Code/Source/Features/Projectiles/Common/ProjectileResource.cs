namespace Sandbox.Source.Features.Projectiles.Common;

[GameResource("Projectile Definition", "prjtl", "Projectile moment", Category = "Game", Icon = "sports_baseball")]
public class ProjectileResource : GameResource
{
	[Property] public GameObject Prefab { get; set; }
	[Property] public float Mass { get; set; }
	[Property] public float Radius { get; set; }
	[Property] public float Damage { get; set; }
	/// <summary>
	/// Normal value is 1
	/// Going higher will make the projectile fly lesser distance
	/// Going lower will make the projectile fly longer distance
	/// </summary>
	[Property] public float Deviation { get; set; }
}
