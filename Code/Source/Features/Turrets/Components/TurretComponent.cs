using Sandbox.Source.Features.Projectiles.Common;
using Sandbox.Source.Features.Turrets.Common;

namespace Sandbox.Source.Features.Turrets.Components;

public struct TurretComponent
{
	[Property] public GameObject TurretView { get; set; }
	[Property] public Vector3 ShootPoint { get; set; }
	[Property] public ProjectileResource Projectile { get; set; }
	[Property] public TurretResource Turret { get; set; }
	[Property, Tag] public string[] EnemyTags { get; set; }
}
