using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Projectiles.Components;

namespace Sandbox.Source.Features.Projectiles.Systems;

public class ProjectileCleanupSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<ProjectileComponent>()
		.With<DestroyTag>();

	private EntityFilter _viewFilter = new EntityFilter( World.Default )
		.With<GameObjectComponent>()
		.With<DestroyTag>();
	
	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );

		foreach ( var entity in _viewFilter )
		{
			ref var viewComponent = ref entity.GetComponent<GameObjectComponent>();
			if ( viewComponent.Value.IsValid() )
			{
				viewComponent.Value.Destroy();
			}
		}
		
		foreach ( var entity in _filter )
		{
			World.Default.DestroyEntity( entity );
		}
	}
}
