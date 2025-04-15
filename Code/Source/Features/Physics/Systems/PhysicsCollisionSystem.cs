using System;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
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
		PhysicsStorage.GetCollisionStartQueue(entity).Enqueue(data.Other);
		entity.SetComponent( new OnCollisionStart() );
	}

	private void OnCollisionUpdate( int entity, CollisionData data )
	{
		PhysicsStorage.GetCollisionUpdateQueue(entity).Enqueue(data.Other);
		entity.SetComponent( new OnCollisionUpdate() );
	}

	private void OnCollisionStop( int entity, CollisionData data )
	{
		var collision = new Collision( data.Stop.Self, data.Stop.Other, default );
		PhysicsStorage.GetCollisionStopQueue(entity).Enqueue(collision);
		entity.SetComponent( new OnCollisionStop() );
	}
}
