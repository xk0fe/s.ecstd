using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;

namespace Sandbox.Source.Features.Common.Systems;

public class DelayedDestroySystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
		.With<DelayedDestroyComponent>();

	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		foreach ( var entity in _filter )
		{
			ref var delayedDestroyComponent = ref entity.GetComponent<DelayedDestroyComponent>();
			if ( delayedDestroyComponent.TimeSince > delayedDestroyComponent.Delay )
			{
				entity.RemoveComponent<DelayedDestroyComponent>();
				entity.SetComponent( new DestroyTag() );
			}
		}
	}
}
