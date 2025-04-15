using System.Collections.Generic;

namespace Sandbox.Source.Features.Physics.Common;

public static class QueuePool<T>
{
    private static readonly Queue<Queue<T>> _pool = new();
    private static readonly object _lock = new();

    public static Queue<T> Get()
    {
        lock (_lock)
        {
            if (_pool.Count > 0)
            return _pool.Dequeue();
            return new Queue<T>();
        }
    }

    public static void Return(Queue<T> queue)
    {
        if (queue == null) return;
        
        lock (_lock)
        {
            queue.Clear();
            _pool.Enqueue(queue);
        }
    }
} 