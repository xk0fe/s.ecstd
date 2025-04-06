using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Common;
using Sandbox.Source.Features.Enemy;

namespace Sandbox.Source;

public class Boot : InitializerBase
{
	protected override void OnAwake()
	{
		AddFeature( new CommonFeature() );
		AddFeature( new EnemyFeatureBase() );
		base.OnAwake();
	}
}
