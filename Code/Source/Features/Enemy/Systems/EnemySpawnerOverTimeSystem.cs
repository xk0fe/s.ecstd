using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Enemy.Systems;

public class EnemySpawnerOverTimeSystem : SystemBase
{
	private EntityFilter _filter;

	public override void Initialize()
	{
		base.Initialize();
		_filter = new EntityFilter( World.Default )
			.With<EnemySpawnerComponent>()
			.With<EnemySpawnerActiveTag>()
			.Without<InvokeComponent>();
	}
	
	public override void Update( float deltaTime )
	{
		foreach ( var entity in _filter )
		{
			var spawner = entity.GetComponent<EnemySpawnerComponent>();

			if ( spawner.SpawnTimer < spawner.SpawnDelay ) continue;

			spawner.SpawnTimer = 0f;
			entity.AddComponent<InvokeComponent>();
		}
	}
}
