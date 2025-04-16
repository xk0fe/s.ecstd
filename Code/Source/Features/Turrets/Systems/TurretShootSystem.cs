using System;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.Tweening;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Extensions;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Projectiles.Components;
using Sandbox.Source.Features.Turrets.Components;

namespace Sandbox.Source.Features.Turrets.Systems;

public class TurretShootSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<TurretComponent>()
		.Without<TurretCooldown>()
		.Without<TurretInactive>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var turretComponent = ref entity.GetComponent<TurretComponent>();

			var view = turretComponent.TurretView;
			if ( view.IsValid() )
			{
				TweenManager.KillByGameObject( view );
				var randomShake = Random.Shared.Float( 1f, 5f );
				view.ShakePosition( .25f, randomShake );
				var originalScale = view.WorldScale;
				view.Scale( .25f, originalScale * .75f, originalScale, EasingType.QuadraticOut );
			}

			SpawnProjectile( turretComponent );
			entity.SetComponent( new TurretCooldown { Cooldown = 2.5f, } );
		}
	}

	private void SpawnProjectile( TurretComponent component )
	{
		var projectile = component.Projectile;
		var turret = component.Turret;
		var spawnPosition = component.ShootPoint;
		var view = projectile.Prefab.Clone( spawnPosition );

		var originalScale = view.WorldScale;
		view.Scale( .1f, originalScale * .75f, originalScale ); 
		
		var direction = component.TurretView.WorldRotation.Forward;
		
		var entity = World.Default.CreateEntity();
		entity.SetComponent( new ProjectileComponent
		{
			Position = spawnPosition + component.TurretView.WorldPosition,
			Velocity = direction * (turret.ImpulseForce / projectile.Deviation),
			Radius = projectile.Radius,
			Damage = projectile.Damage,
			Impulse = turret.ImpulseForce,
			Scene = view.Scene,
			AllowedTags = component.EnemyTags,
		} );
		entity.SetComponent( new GameObjectComponent() { Value = view, } );
	}
}
