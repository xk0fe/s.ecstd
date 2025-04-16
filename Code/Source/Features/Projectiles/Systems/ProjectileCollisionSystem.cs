using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;
using Sandbox.k.Tweening;
using Sandbox.k.Tweening.Extensions;
using Sandbox.Source.Features.Common.Components;
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
				entity.SetComponent( new DestroyTag() );
				continue;
			}
			
			var startPos = projectileComponent.Position;
			var endPos = projectileComponent.Position + projectileComponent.Velocity * 2.5f * deltaTime;
			var radius = projectileComponent.Radius;
			
			// Gizmo.Draw.Line( startPos, endPos );
			var tr = scene.Trace
				.WithAnyTags( projectileComponent.AllowedTags )
				.Sphere( radius, startPos, endPos )
				.Run();

			if ( !tr.Hit ) continue;

			var target = tr.GameObject;
			TweenManager.KillByGameObject( target, true );
			target.PunchScale( .25f, Vector3.One, 1, 1 );
			var entityProvider = target.GetComponent<EntityProviderLink>();
			if ( entityProvider.IsValid() )
			{
				entityProvider.EntityId.SetComponent( new DelayedDestroyComponent
				{
					TimeSince = 0,
					Delay = 1.5f,
				} );
			}
			entity.SetComponent( new DestroyTag() );
		}
	}
}
