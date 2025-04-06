using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy;

namespace Sandbox.Source;

public class Boot : InitializerBase
{
	protected override void OnAwake()
	{
		AddFeature( new EnemyFeature() );
		base.OnAwake();
	}
}
