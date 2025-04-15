using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Projectiles.Components;

namespace Sandbox.Source.Features.Projectiles.Systems;

public class ProjectileViewSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<ProjectileComponent>()
		.With<ProjectileViewComponent>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var projectileViewComponent = ref entity.GetComponent<ProjectileViewComponent>();
			var view = projectileViewComponent.View;
			if ( !view.IsValid() )
			{
				World.Default.DestroyEntity( entity );
				continue;
			}

			ref var projectileComponent = ref entity.GetComponent<ProjectileComponent>();

			view.WorldPosition = projectileComponent.Position;
		}
	}
}
