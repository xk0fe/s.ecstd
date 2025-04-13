using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Common.Systems;

namespace Sandbox.Source.Features.Common;

public class CommonFeature : FeatureBase
{
	public CommonFeature( DlContainer container )
	{
		AddSystem( new GameObjectPositionSystem() );
	}
}
