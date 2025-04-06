using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemySpawnerSystem : k.ECS.Extensions.System
{
	private Filter _filter;
	public override void Initialize()
	{
		_filter = new Filter( World.Default )
			.With<EnemySpawnerComponent>()
			.With<InvokeComponent>();
	}
	
	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			var spawner = entity.GetComponent<EnemySpawnerComponent>();
			if ( spawner.IsActive )
			{
				entity.RemoveComponent<InvokeComponent>();
				Log.Info( "Spawning enemy!" );
			}
		}
	}
}
