﻿using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Projectiles.Components;

namespace Sandbox.Source.Features.Projectiles.Systems;

public class ProjectileViewSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<ProjectileComponent>()
		.With<GameObjectComponent>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var viewComponent = ref entity.GetComponent<GameObjectComponent>();
			var view = viewComponent.Value;
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
