using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemyMovementSystem : SystemBase
{
	private EntityFilter _entityFilter = new EntityFilter( World.Default )
		.With<EnemyComponent>()
		.With<PositionComponent>();

	private const float MOVEMENT_SPEED = 5f;

	public override void Update( float deltaTime )
	{
		foreach ( var entity in _entityFilter )
		{
			ref var position = ref entity.GetComponent<PositionComponent>();
			
			position.Value += MOVEMENT_SPEED * deltaTime;
		}
	}
}
