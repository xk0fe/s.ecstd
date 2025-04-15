using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Common;
using Sandbox.Source.Features.Common.Storages;
using Sandbox.Source.Features.Enemy;
using Sandbox.Source.Features.Physics;
using Sandbox.Source.Features.Slots;

namespace Sandbox.Source;

public class Boot : InitializerBase
{
	protected override void OnAwake()
	{
		var container = new DlContainer()
			.Register<TestStorage>();
		AddFeature( new CommonFeature( container ) );
		AddFeature( new PhysicsFeature( container ) );
		
		AddFeature( new SlotsFeature( container ) );
		AddFeature( new EnemyFeature( container ) );

		base.OnAwake();
	}
}
