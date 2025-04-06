using System.Collections.Generic;

namespace Sandbox.k.ECS.Core;

public class EntityManager
{
	public HashSet<int> Entities { get; private set; }
	
	private int _nextEntityId = 0;
    
	public EntityManager()
	{
		Entities = new HashSet<int>();
	}
	
	public int CreateEntity()
	{
		int entity = _nextEntityId++;
		Entities.Add(entity);
		return entity;
	}
    
	public void DestroyEntity(int entity)
	{
		Entities.Remove(entity);
		// We'll need to notify component systems to remove this entity
	}
    
	public bool IsAlive(int entity) => Entities.Contains(entity);
}
