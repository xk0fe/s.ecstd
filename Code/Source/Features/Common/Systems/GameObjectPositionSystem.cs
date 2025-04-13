using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Common.Components;

namespace Sandbox.Source.Features.Common.Systems;

public class GameObjectPositionSystem : SystemBase
{
	private EntityFilter _filter = new EntityFilter( World.Default )
			.With<GameObjectComponent>()
			.With<PositionComponent>()
			.With<SyncPositionToGameObjectTag>();

	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			var gameObjectComponent = entity.GetComponent<GameObjectComponent>();
			var positionComponent = entity.GetComponent<PositionComponent>();
			
			var gameObject = gameObjectComponent.Value;
			
			if ( !gameObject.IsValid() ) continue;
			gameObject.WorldPosition = positionComponent.Value;
		}
	}
}
