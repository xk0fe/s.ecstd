using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Turrets.Components;

namespace Sandbox.Source.Features.Turrets.Systems;

public class TurretInactiveSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<TurretInactive>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var turretInactive = ref entity.GetComponent<TurretInactive>();
			turretInactive.Since += deltaTime;
			if ( turretInactive.Since > turretInactive.Delay )
			{
				entity.RemoveComponent<TurretInactive>();
			}
		}
	}
}
