using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Projectiles.Components;

namespace Sandbox.Source.Features.Projectiles.Systems;

public class ProjectileMovementSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<ProjectileComponent>();
	
	private const float GRAVITY = -980f;

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var projectileComponent = ref entity.GetComponent<ProjectileComponent>();

			projectileComponent.Velocity.z += GRAVITY * deltaTime;
			projectileComponent.Position += projectileComponent.Velocity * deltaTime;
		}
	}
}
