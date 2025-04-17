using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.ECS.Game.Components;
using Sandbox.Source.Features.Enemy.Components;

namespace Sandbox.Source.Features.Enemy.Providers;

public class EnemySpawnerProvider : EntityProvider<EnemySpawnerComponent>
{
	[Button]
	private void Spawn()
	{
		GetEntity().AddComponent<InvokeComponent>();
	}
	
	protected override void DrawGizmos()
	{
		base.DrawGizmos();
		var spawnPosition = _component.SpawnPosition;
		if ( !spawnPosition.IsValid() ) return;
		
		var position = spawnPosition.WorldPosition;
		Gizmo.Draw.LineCircle( position - WorldPosition, Vector3.Up, _component.SpawnRadius );
	}
}
