using System;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemyDeathAnimationSystem : SystemBase
{
	private EntityFilter _pathFilter = new EntityFilter( World.Default )
		.With<EnemyFollowPathTag>()
		.With<DelayedDestroyComponent>();
	
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<EnemyTag>()
		.With<PositionComponent>()
		.With<DelayedDestroyComponent>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _pathFilter )
		{
			entity.RemoveComponent<EnemyFollowPathTag>();
		}
		
		foreach ( var entity in _filter )
		{
			ref var position = ref entity.GetComponent<PositionComponent>();
			var fallSpeed = 15f;
			var gravity = 20f;

			var wobble = MathF.Sin(Time.Now * 40f) * 0.25f;

			var targetPosition = position.Value;
			targetPosition.z -= fallSpeed * deltaTime + 0.5f * gravity * deltaTime * deltaTime;
			targetPosition.x += wobble * deltaTime;
			
			position.Value = targetPosition;
		}
	}
}
