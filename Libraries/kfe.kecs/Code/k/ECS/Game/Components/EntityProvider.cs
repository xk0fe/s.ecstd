using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions.Utils;

namespace Sandbox.k.ECS.Game.Components;

[Category( "k.ECS" )]
public class EntityProvider<T> : Component where T : struct
{
	[Property, InlineEditor] protected T _component { get; set; }
	public int EntityId { get; set; }
	
	private bool _isInitialized;
	
	protected override void OnAwake()
	{
		base.OnAwake();
		Initialize();
	}
	

	public int CreateEntity()
	{
		if (_isInitialized) return -1;
		var world = World.Default;
		EntityId = world.CreateEntity();
		Log.Info($"ECS - Entity created with ID: {EntityId}");
		_isInitialized = true;
		return EntityId;
	}

	private void Initialize()
	{
		var entity = CreateEntity();
		Log.Info($"ECS - Linking component {typeof(T)} to entity {EntityId}");
		entity.SetComponent( _component );
	}

	public int GetEntity()
	{
		return _isInitialized ? EntityId : -1;
	}
}
