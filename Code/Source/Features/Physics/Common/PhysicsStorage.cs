namespace Sandbox.Source.Features.Physics.Common;

public static class PhysicsStorage
{
	private static readonly Dictionary<int, Queue<Collision>> _collisionStartStorage = new();
	private static readonly Dictionary<int, Queue<Collision>> _collisionUpdateStorage = new();
	private static readonly Dictionary<int, Queue<Collision>> _collisionStopStorage = new();
	private static readonly Dictionary<int, Queue<Collider>> _triggerEnterStorage = new();
	private static readonly Dictionary<int, Queue<GameObject>> _triggerStayStorage = new();
	private static readonly Dictionary<int, Queue<Collider>> _triggerExitStorage = new();

	public static Queue<Collision> GetCollisionStartQueue( int entityId )
	{
		if ( !_collisionStartStorage.TryGetValue( entityId, out var queue ) )
			queue = _collisionStartStorage[entityId] = new Queue<Collision>();
		return queue;
	}

	public static Queue<Collision> GetCollisionUpdateQueue( int entityId )
	{
		if ( !_collisionUpdateStorage.TryGetValue( entityId, out var queue ) )
			queue = _collisionUpdateStorage[entityId] = new Queue<Collision>();
		return queue;
	}

	public static Queue<Collision> GetCollisionStopQueue( int entityId )
	{
		if ( !_collisionStopStorage.TryGetValue( entityId, out var queue ) )
			queue = _collisionStopStorage[entityId] = new Queue<Collision>();
		return queue;
	}

	public static Queue<Collider> GetTriggerEnterQueue( int entityId )
	{
		if ( !_triggerEnterStorage.TryGetValue( entityId, out var queue ) )
			queue = _triggerEnterStorage[entityId] = new Queue<Collider>();
		return queue;
	}

	public static Queue<Collider> GetTriggerExitQueue( int entityId )
	{
		if ( !_triggerExitStorage.TryGetValue( entityId, out var queue ) )
			queue = _triggerExitStorage[entityId] = new Queue<Collider>();
		return queue;
	}

	public static Queue<GameObject> GetTriggerStayQueue( int entityId )
	{
		if ( !_triggerStayStorage.TryGetValue( entityId, out var queue ) )
			queue = _triggerStayStorage[entityId] = new Queue<GameObject>();
		return queue;
	}

	public static void AddToTriggerStay( int entityId, GameObject gameObject )
	{
		var queue = GetTriggerStayQueue( entityId );
		queue.Enqueue( gameObject );
	}

	public static void RemoveFromTriggerStay( int entityId, GameObject gameObject )
	{
		if ( !_triggerStayStorage.TryGetValue( entityId, out var queue ) ) return;
		
		var tempQueue = new Queue<GameObject>();
		while ( queue.Count > 0 )
		{
			var obj = queue.Dequeue();
			if ( obj != gameObject )
			{
				tempQueue.Enqueue( obj );
			}
		}
		
		while ( tempQueue.Count > 0 )
		{
			queue.Enqueue( tempQueue.Dequeue() );
		}
	}

	public static void ClearEntityData( int entityId )
	{
		_collisionStartStorage.Remove( entityId );
		_collisionUpdateStorage.Remove( entityId );
		_collisionStopStorage.Remove( entityId );
		_triggerEnterStorage.Remove( entityId );
		_triggerExitStorage.Remove( entityId );
		_triggerStayStorage.Remove( entityId );
	}
}
