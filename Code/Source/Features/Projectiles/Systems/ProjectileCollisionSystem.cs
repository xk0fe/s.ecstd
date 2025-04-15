using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Projectiles.Components;

namespace Sandbox.Source.Features.Projectiles.Systems;

public class ProjectileCollisionSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<ProjectileComponent>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var projectileComponent = ref entity.GetComponent<ProjectileComponent>();

			var scene = projectileComponent.Scene;
			if ( !scene.IsValid() )
			{
				World.Default.DestroyEntity( entity );
				continue;
			}
			
			var startPos = projectileComponent.Position;
			var endPos = projectileComponent.Position + projectileComponent.Velocity * projectileComponent.Impulse * deltaTime;
			var radius = projectileComponent.Radius;
			
			var tr = scene.Trace
				.Sphere( radius, startPos, endPos )
				.Run();

			if ( tr.Hit )
			{
				Log.Info( $"Hit {entity} with {tr.GameObject.Name}" );
			}
		}
	}
}
