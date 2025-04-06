using Sandbox.k.ECS.Core;

namespace Sandbox.k.ECS.Extensions.Utils;

public static class EntityExtensions
{
	public static void AddComponent<T>(this int entity)
	{
		World.Default.AddComponent<T>(entity, default);
	}
	
	public static void RemoveComponent<T>(this int entity)
	{
		World.Default.RemoveComponent<T>(entity);
	}
	
	public static ref T GetComponent<T>(this int entity)
	{
		return ref World.Default.GetComponentRef<T>(entity);
	}
	
	public static bool TryGetComponent<T>(this int entity, out T component)
	{
		if (World.Default.HasComponent<T>(entity))
		{
			component = World.Default.GetComponent<T>(entity);
			return true;
		}
		
		component = default;
		return component != null;
	}
}
