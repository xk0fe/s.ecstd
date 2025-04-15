using System;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Physics.Common;
using Sandbox.Source.Features.Physics.Components;
using Sandbox.Source.Features.Physics.Components.Collisions;
using Sandbox.Source.Features.Physics.Enums;

namespace Sandbox.Source.Features.Physics.Systems;

public class PhysicsCollisionSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<CollisionComponent>()
		.With<RecalculateTag>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			entity.RemoveComponent<RecalculateTag>();
			ref var component = ref entity.GetComponent<CollisionComponent>();
			if ( component.Collisions == null ) continue;
			foreach ( var collision in component.Collisions )
			{
				switch ( collision.State )
				{
					case CollisionChangeState.Start:
						OnCollisionStart( entity, collision );
						break;
					case CollisionChangeState.Update:
						OnCollisionUpdate( entity, collision );
						break;
					case CollisionChangeState.Stop:
						OnCollisionStop( entity, collision );
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			entity.SetComponent( new CalculatedTag() );
		}
	}

	private void OnCollisionStart( int entity, CollisionData data )
	{
		if ( entity.HasComponent<OnCollisionStart>() )
		{
			ref var collisionStart = ref entity.GetComponent<OnCollisionStart>();
			collisionStart.Collisions ??= new Queue<Collision>();
			collisionStart.Collisions.Enqueue( data.Other );
			return;
		}

		entity.SetComponent( new OnCollisionStart { Collisions = new Queue<Collision>( new[] { data.Other } ) } );
	}

	private void OnCollisionUpdate( int entity, CollisionData data )
	{
		if ( entity.HasComponent<OnCollisionUpdate>() )
		{
			ref var collisionUpdate = ref entity.GetComponent<OnCollisionUpdate>();
			collisionUpdate.Collisions ??= new Queue<Collision>();
			collisionUpdate.Collisions.Enqueue( data.Other );
			return;
		}

		entity.SetComponent( new OnCollisionUpdate { Collisions = new Queue<Collision>( new[] { data.Other } ) } );
	}

	private void OnCollisionStop( int entity, CollisionData data )
	{
		var stopCollision = data.Stop;
		var collision = new Collision( stopCollision.Self, stopCollision.Other, default );
		if ( entity.HasComponent<OnCollisionStop>() )
		{
			ref var collisionStop = ref entity.GetComponent<OnCollisionStop>();
			collisionStop.Collisions ??= new Queue<Collision>();
			collisionStop.Collisions.Enqueue( collision );
			return;
		}

		entity.SetComponent( new OnCollisionStop { Collisions = new Queue<Collision>( new[] { collision } ) } );
	}
}
