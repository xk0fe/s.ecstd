using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Projectiles.Components;

namespace Sandbox.Source.Features.Projectiles.Systems;

public class ProjectileLifeTimeSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<ProjectileComponent>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var projectileComponent = ref entity.GetComponent<ProjectileComponent>();

			if ( projectileComponent.Position.z < -100 )
			{
				entity.SetComponent( new DestroyTag() );
			}
		}
	}
}
