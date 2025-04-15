using Sandbox.Source.Features.Projectiles.Common;

namespace Sandbox.Source.Features.Turrets.Components;

public struct TurretComponent
{
	[Property] public GameObject TurretView { get; set; }
	[Property] public Vector3 ShootPoint { get; set; }
	[Property] public GameObject BulletSpawnPoint { get; set; }
	[Property] public ProjectileResource Projectile { get; set; }
}
