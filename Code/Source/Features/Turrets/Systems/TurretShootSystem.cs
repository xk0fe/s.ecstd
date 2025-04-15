using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Extensions;
using Sandbox.Source.Features.Projectiles.Components;
using Sandbox.Source.Features.Turrets.Components;

namespace Sandbox.Source.Features.Turrets.Systems;

public class TurretShootSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<TurretComponent>()
		.Without<TurretCooldown>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var turretComponent = ref entity.GetComponent<TurretComponent>();

			var view = turretComponent.TurretView;
			if ( view.IsValid() )
			{
				view.ShakePosition( .5f, 5 );
				view.Scale( .25f, Vector3.One * .5f, Vector3.One * .65f, EasingType.QuadraticOut );
			}

			SpawnProjectile( turretComponent );
			entity.SetComponent( new TurretCooldown { Cooldown = 2.5f, } );
		}
	}

	private void SpawnProjectile( TurretComponent turret )
	{
		var projectile = turret.Projectile;
		var spawnPosition = turret.ShootPoint;
		var view = projectile.Prefab.Clone( spawnPosition );

		var originalScale = view.WorldScale;
		view.Scale( .1f, originalScale * .75f, originalScale ); 
		
		var direction = turret.BulletSpawnPoint.WorldRotation.Forward;
		
		var entity = World.Default.CreateEntity();
		entity.SetComponent( new ProjectileComponent
		{
			Position = spawnPosition + turret.TurretView.WorldPosition,
			Velocity = direction * (projectile.ImpulseForce / projectile.Deviation),
			Radius = projectile.Radius,
			Damage = projectile.Damage,
			Impulse = projectile.ImpulseForce,
			Scene = view.Scene,
		} );
		entity.SetComponent( new ProjectileViewComponent { View = view, } );
	}
}
