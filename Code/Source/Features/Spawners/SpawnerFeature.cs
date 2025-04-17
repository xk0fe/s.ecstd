using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy.Providers;
using Sandbox.Source.Features.Enemy.Systems;

namespace Sandbox.Source.Features.Spawners;

public class SpawnerFeature : StorageFeatureBase
{
	private void Test()
	{
		var spawner = new Spawner();
		var prefab = new GameObject();
		
		spawner.Spawn( prefab, (go) =>
		{
			go.AddComponent<EnemyProvider>();
		} );
	}

	public override void RegisterStorages( DlContainer container )
	{
		container.Register<Spawner>();
	}

	public override void RegisterSystems( DlContainer container )
	{
		// AddSystem( new EnemySpawnerSystem( container ) );
	}
}
