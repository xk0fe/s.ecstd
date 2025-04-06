using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Common.Systems;

namespace Sandbox.Source.Features.Common;

public class CommonFeature : FeatureBase
{
	public CommonFeature()
	{
		AddSystem( new GameObjectPositionSystem() );
	}
}
