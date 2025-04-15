using System;
using System.Collections.Generic;

namespace Sandbox.k.DependencyLocator;

public class DlContainer
{
	private readonly Dictionary<Type, object> _instances = new();
	
	public T Get<T>() where T : new()
	{
		if (_instances.TryGetValue(typeof(T), out var instance))
		{
			return (T)instance;
		}
		return new T();
	}

	public DlContainer Register<T>() where T : new()
	{
		_instances[typeof(T)] = new T();
		return this;
	}
}
