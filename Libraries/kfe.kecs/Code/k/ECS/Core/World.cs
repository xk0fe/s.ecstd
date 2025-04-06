using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.k.ECS.Core;

public class World
{
	private EntityManager _entityManager = new EntityManager();
    private ComponentStorageContainer _componentStorages = new ComponentStorageContainer();

    private static World _default;
    
    public ComponentStorageContainer ComponentStorages => _componentStorages;
    public EntityManager EntityManager => _entityManager;
    public static World Default => _default ??= new World();
    
    public static void ResetDefault() => _default = new World();
	
    // Entity management
    public int CreateEntity() => _entityManager.CreateEntity();
    
    public void DestroyEntity(int entity)
    {
        if (!_entityManager.IsAlive(entity)) return;

        foreach ( var (_, storage) in _componentStorages.Values )
        {
	        storage.Remove( entity );
        }
        
        _entityManager.DestroyEntity(entity);
    }
    
    // Component management
    public void AddComponent<T>(int entity, T component)
    {
        var storage = GetOrCreateStorage<T>();
        if ( storage == null )
        {
	        Log.Error( $"Could not create storage for component {typeof(T).Name}" );
	        return;
        }
	    storage.Add(entity, component);
    }
    
    public void RemoveComponent<T>(int entity)
    {
        if (HasComponent<T>(entity))
            GetStorage<T>().Remove(entity);
    }
    
    public bool HasComponent(Type type, int entity)
    {
	    if (!_componentStorages.TryGetValue(type, out var storage))
		    return false;
            
	    return storage.Has(entity);
    }
    
    public bool HasComponent<T>(int entity)
    {
        if (!_componentStorages.TryGetValue(typeof(T), out var storage))
            return false;
            
        return storage.Has(entity);
    }
    
    public T GetComponent<T>(int entity)
    {
        return GetStorage<T>().Get(entity);
    }
    
    public ref T GetComponentRef<T>(int entity)
	{
		return ref GetStorage<T>().GetRef(entity);
	}
    
    // Storage management
    private ComponentStorage<T> GetStorage<T>()
    {
        if (!_componentStorages.TryGetValue(typeof(T), out var storage))
            throw new KeyNotFoundException($"Trying to get component {typeof(T).Name} that does not exist on the entity");
            
        return (ComponentStorage<T>)storage;
    }
    
    private ComponentStorage<T> GetOrCreateStorage<T>()
    {
        if (!_componentStorages.TryGetValue(typeof(T), out var storage))
        {
	        var instance = new ComponentStorage<T>();
	        storage = instance;
            _componentStorages.AddStorage( instance );
        }
        
        return (ComponentStorage<T>)storage;
    }
    
    // Systems query shortcuts
    public IEnumerable<int> GetEntitiesWith<T>()
    {
        if (!_componentStorages.TryGetValue(typeof(T), out var storage))
            return Enumerable.Empty<int>();
            
        return ((ComponentStorage<T>)storage).GetAllEntities();
    }
    
    public IEnumerable<int> GetEntitiesWithout<T>()
	{
		var entities = new HashSet<int>();
		foreach ( var (key, storage) in _componentStorages.Values )
		{
			if ( key == typeof(T) ) continue;
			var loopEntities = storage.GetAllEntities();
			foreach ( var entity in loopEntities )
			{
				entities.Add( entity );
			}
		}
		
		return entities;
	}
    
    public IEnumerable<int> GetEntitiesWith<T1, T2>()
    {
        return GetEntitiesWith<T1>().Intersect(GetEntitiesWith<T2>());
    }
    
    public IEnumerable<int> GetFilter(IEnumerable<int> withFilter, IEnumerable<int> withoutFilter)
    {
	    return withFilter.Except(withoutFilter);
    }
}
