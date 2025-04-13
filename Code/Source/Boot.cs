using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Common;
using Sandbox.Source.Features.Common.Storages;
using Sandbox.Source.Features.Enemy;

namespace Sandbox.Source;

public class Boot : InitializerBase
{
	protected override void OnAwake()
	{
		var container = new DlContainer()
			.Register<TestStorage>();
		AddFeature( new CommonFeature( container ) );
		AddFeature( new EnemyFeatureBase( container ) );

		base.OnAwake();
	}
}
