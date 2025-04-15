using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Physics.Systems;

namespace Sandbox.Source.Features.Physics;

// wrapper for the s&box physics
// fuck this shit really
public class PhysicsFeature : FeatureBase
{
	public PhysicsFeature( DlContainer container )
	{
		// collisions
		AddSystem( new PhysicsCollisionCleanupSystem() );
		AddSystem( new PhysicsCollisionSystem() );
		
		// triggers
		AddSystem( new PhysicsTriggerCleanupSystem() );
		AddSystem( new PhysicsTriggerSystem() );
	}
}
