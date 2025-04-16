using System.Numerics;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;
using Sandbox.Source.Features.Turrets.Components;

namespace Sandbox.Source.Features.Turrets.Providers;

public class TurretProvider : EntityProvider<TurretComponent>
{
	protected override void DrawGizmos()
	{
		base.DrawGizmos();
		if ( !_component.Projectile.IsValid() ) return;
		Gizmo.Transform = new Transform( Vector3.Zero, Quaternion.Identity, Vector3.One );
		Gizmo.Draw.SolidSphere( _component.ShootPoint + WorldPosition, _component.Projectile.Radius );
	}

	protected override void OnEntityCreated( int entityId )
	{
		base.OnEntityCreated( entityId );
		entityId.SetComponent( new TurretInactive
		{
			Since = 0,
			Delay = 5f,
		} );
	}
}
