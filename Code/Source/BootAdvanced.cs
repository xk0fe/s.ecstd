using Sandbox.k;
using Sandbox.k.DependencyLocator;
using Sandbox.Source.Features.Common;
using Sandbox.Source.Features.Economy;
using Sandbox.Source.Features.Enemy;
using Sandbox.Source.Features.Projectiles;
using Sandbox.Source.Features.Slots;
using Sandbox.Source.Features.Spawners;
using Sandbox.Source.Features.Turrets;
using Sandbox.Source.Features.Waves;

namespace Sandbox.Source;

public class BootAdvanced : InitializerAdvanced
{
	[Property] private GameResource[] _resources { get; set; }
	[Property] private InjectablePanelComponent[] _panels { get; set; }
	
	protected override void OnRegister( DlContainer container )
	{
		base.OnRegister( container );
		foreach ( var resource in _resources )
		{
			container.Register( resource );
		}
		
		RegisterFeatures();
	}

	private void RegisterFeatures()
	{
		AddFeature( new CommonFeature() );
		AddFeature( new EconomyFeature() );
		// AddFeature( new PhysicsFeature( container ) );

		AddFeature( new SpawnerFeature() );
		AddFeature( new SlotsFeature() );
		AddFeature( new TurretFeature() );
		AddFeature( new ProjectileFeature() );
		AddFeature( new EnemyFeature() );
		AddFeature( new WaveFeature() );
	}

	protected override void OnContainerBind( DlContainer container )
	{
		base.OnContainerBind( container );
		
		// register ui panels after resources, storages and systems
		// it is important, so that panels can access resources and storages
		foreach ( var panel in _panels )
		{
			panel.InjectContainer( container );
		}
	}
}
