using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.Tweening;
using Sandbox.k.Tweening.Enums;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemySpawnAnimationSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<EnemyTag>()
		.With<GameObjectComponent>()
		.Without<EnemyAnimatedTag>();

	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			entity.SetComponent( new EnemyAnimatedTag() );
			var gameObjectComponent = entity.GetComponent<GameObjectComponent>();
			var gameObject = gameObjectComponent.Value;
			Tweener.Scale( gameObject, .25f, Vector3.One * .25f, Vector3.One, EasingType.QuadraticOut );
			if ( gameObject.Children.Count == 0 ) return;
			var child = gameObject.Children[0];
			if ( !child.IsValid() ) return;
			Tweener.LocalPosition( child, .75f, child.LocalPosition + Vector3.Up * 5f,
				child.LocalPosition, EasingType.QuadraticInOut, loopType: LoopType.PingPong );
		}
	}
}
