using System.Collections.Generic;

namespace Sandbox.k.DependencyLocator;

public class DlContainer
{
	private readonly Dictionary<string, object> _instances = new();
	
	public T Get<T>() where T : new()
	{
		var key = GetKey<T>();
		if (_instances.TryGetValue(key, out var instance))
		{
			return (T)instance;
		}
		return new T();
	}

	public DlContainer Register<T>() where T : new()
	{
		var key = GetKey<T>();
		_instances[key] = new T();
		return this;
	}
	
	/// <summary>
	/// Allows subclasses to be registered.
	/// </summary>
	public DlContainer Register<T>(T instance)
	{
		var key = instance.GetType().ToString();
		_instances[key] = instance;
		return this;
	}
	
	public DlContainer Register<T>(string key) where T : new()
	{
		_instances[key] = new T();
		return this;
	}
	
	public DlContainer Register<T>(string key, T instance)
	{
		_instances[key] = instance;
		return this;
	}
	
	private string GetKey<T>()
	{
		return typeof(T).ToString();
	}
}
