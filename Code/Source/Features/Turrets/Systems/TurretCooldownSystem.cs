using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Turrets.Components;

namespace Sandbox.Source.Features.Turrets.Systems;

public class TurretCooldownSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<TurretCooldown>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var turretCooldown = ref entity.GetComponent<TurretCooldown>();
			turretCooldown.Cooldown -= deltaTime;

			if ( turretCooldown.Cooldown <= 0f ) entity.RemoveComponent<TurretCooldown>();
		}
	}
}
