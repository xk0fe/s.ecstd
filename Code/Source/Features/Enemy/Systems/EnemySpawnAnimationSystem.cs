using System;
using System.Threading.Tasks;
using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Enemy.Components;
using Sandbox.Utility;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemySpawnAnimationSystem : SystemBase
{
	private EntityFilter _filter;

	public override void Initialize()
	{
		base.Initialize();
		_filter = new EntityFilter( World.Default )
			.With<EnemyComponent>()
			.With<GameObjectComponent>()
			.Without<EnemyAnimatedTag>();
	}

	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			var gameObjectComponent = entity.GetComponent<GameObjectComponent>();
			var gameObject = gameObjectComponent.Value;
			LerpSize( gameObject, .5f, Vector3.One * .1f, Vector3.One, Easing.QuadraticOut );
			entity.SetComponent( new EnemyAnimatedTag() );
		}
	}
	
	private async Task LerpSize( GameObject target, float seconds, Vector3 from, Vector3 to, Easing.Function easer )
	{
		TimeSince timeSince = 0;
		while ( timeSince < seconds )
		{
			var size = Vector3.Lerp( from, to, easer( timeSince / seconds ) );
			target.WorldScale = size;
			await Task.Yield();
		}
		target.WorldScale = to;
	}

	private float EaseOutCubic(float t)
	{
		t = Math.Clamp(t, 0, 1);
		return 1 - MathF.Pow(1 - t, 3);
	}
}
