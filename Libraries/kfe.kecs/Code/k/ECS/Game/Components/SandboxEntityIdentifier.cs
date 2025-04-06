using Sandbox.k.ECS.Core;

namespace Sandbox.k.ECS.Game.Components;

public class SandboxEntityIdentifier : Component
{
	[Property, ReadOnly] public int EntityId { get; set; }
	
	private bool _isInitialized;

	public void InitializeEntity()
	{
		if (_isInitialized) return;
		var world = World.Default;
		EntityId = world.CreateEntity();
		Log.Info($"ECS - Entity created with ID: {EntityId}");
		world.AddComponent(EntityId, this);
		_isInitialized = true;
	}
	
	public void LinkComponent<T>(T component)
	{
		var world = World.Default;
		Log.Info($"ECS - Linking component {component.GetType().Name} to entity {EntityId}");
		world.AddComponent(EntityId, component);
	}
}
