using System;
using System.Collections.Generic;
using Sandbox.k.ECS.Core.Interfaces;

namespace Sandbox.k.ECS.Core;

public class ComponentStorageContainer
{
	private Dictionary<Type, IComponentStorage> _storages;
	
	public ComponentStorageContainer()
	{
		_storages = new Dictionary<Type, IComponentStorage>();
	}
	
	public void AddStorage<T>(ComponentStorage<T> storage)
	{
		_storages.Add( typeof(T), storage );
	}
	
	public void SetStorage<T>(ComponentStorage<T> storage)
	{
		_storages[typeof(T)] = storage;
	}
	
	public ComponentStorage<T> GetStorage<T>()
	{
		return (ComponentStorage<T>)_storages[typeof(T)];
	}
	
	public bool HasStorage<T>()
	{
		return _storages.ContainsKey( typeof(T) );
	}
	
	public IEnumerable<KeyValuePair<Type, IComponentStorage>> Values => _storages;

	public bool TryGetValue( Type type, out IComponentStorage storage )
	{
		return _storages.TryGetValue( type, out storage );
	}
}
