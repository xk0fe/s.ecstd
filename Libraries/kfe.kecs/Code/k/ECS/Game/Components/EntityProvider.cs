using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions.Utils;

namespace Sandbox.k.ECS.Game.Components;

[Category( "k.ECS" )]
public class EntityProvider<T> : Component where T : struct
{
	[Property, InlineEditor] protected T _component { get; set; }
	
	private int _entityId;
	private bool _isInitialized;

	protected override void OnAwake()
	{
		base.OnAwake();
		Initialize();
	}

	public int GetEntity()
	{
		return _isInitialized ? _entityId : -1;
	}

	private int CreateEntity()
	{
		if (_isInitialized) return _entityId;
		var entityLink = GetComponent<EntityProviderLink>();
		if (entityLink.IsValid())
		{
			_entityId = entityLink.EntityId;
			Log.Info($"ECS - Entity already created with ID: {_entityId}");
			_isInitialized = true;
			return _entityId;
		}

		entityLink = AddComponent<EntityProviderLink>();
		var world = World.Default;
		_entityId = world.CreateEntity();
		Log.Info($"ECS - Entity created with ID: {_entityId}");
		_isInitialized = true;
		entityLink.EntityId = _entityId;
		return _entityId;
	}

	private void Initialize()
	{
		var entity = CreateEntity();
		Log.Info($"ECS - Linking component {typeof(T).Name} to entity {_entityId}");
		entity.SetComponent(_component);
	}

	private void UpdateEntityComponent()
	{
		if (!_isInitialized) return;
		
		Log.Info($"ECS - Updating component {typeof(T).Name} for entity {_entityId}");
		_entityId.SetComponent(_component);
	}
}
