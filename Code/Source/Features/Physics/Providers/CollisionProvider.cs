using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;
using Sandbox.Source.Features.Physics.Common;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Collisions;
using Sandbox.Source.Features.Physics.Enums;

namespace Sandbox.Source.Features.Physics.Providers;

public class CollisionProvider : EntityProvider<CollisionComponent>, Component.ICollisionListener
{
	public void OnCollisionStart( Collision other )
	{
		UpdateCollision( CollisionChangeState.Start, other, default );
	}

	public void OnCollisionUpdate( Collision other )
	{
		UpdateCollision( CollisionChangeState.Update, other, default );
	}

	public void OnCollisionStop( CollisionStop other )
	{
		UpdateCollision( CollisionChangeState.Stop, default, other );
	}

	private void UpdateCollision(CollisionChangeState state, Collision other, CollisionStop stop)
	{
		var entity = GetEntity();
		if ( entity == -1 ) return;
		var collisionData = new CollisionData { State = state, Other = other, Stop = stop };
		if ( entity.HasComponent<CollisionComponent>() )
		{
			ref var component = ref entity.GetComponent<CollisionComponent>();
			component.Collisions ??= new Queue<CollisionData>();
			component.Collisions.Enqueue( collisionData );
		}
		else
		{
			entity.SetComponent( new CollisionComponent
			{
				Collisions = new Queue<CollisionData>( new[] { collisionData } )
			} );
		}
		entity.SetComponent( new RecalculateTag() );
	}
}
