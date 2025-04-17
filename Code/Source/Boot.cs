using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Common;
using Sandbox.Source.Features.Common.Storages;
using Sandbox.Source.Features.Enemy;
using Sandbox.Source.Features.Projectiles;
using Sandbox.Source.Features.Slots;
using Sandbox.Source.Features.Spawners;
using Sandbox.Source.Features.Turrets;
using Sandbox.Source.Features.Waves;

namespace Sandbox.Source;

public class Boot : InitializerBase
{
	[Property] private List<GameResource> _resources { get; set; } = new List<GameResource>();
	
	protected override void OnAwake()
	{
		var container = new DlContainer()
			.Register<TestStorage>();

		foreach ( var resource in _resources )
		{
			container.Register( resource );
		}
		
		// AddFeature( new CommonFeature( container ) );
		// // AddFeature( new PhysicsFeature( container ) );
		//
		// AddFeature( new SpawnerFeature( container ) );
		// AddFeature( new SlotsFeature( container ) );
		// AddFeature( new TurretFeature( container ) );
		// AddFeature( new ProjectileFeature( container ) );
		// AddFeature( new EnemyFeature( container ) );
		// AddFeature( new WaveFeature( container ) );

		base.OnAwake();
	}
}
