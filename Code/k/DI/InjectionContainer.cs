using System;
using System.Reflection;
using Sandbox.Source.Features.Common.Systems;

namespace Sandbox.k.DI;

public class InjectionContainer
{
	private readonly Dictionary<Type, Func<object>> _registry = new();

	public void Register<T>(Func<object> factory) => _registry[typeof(T)] = factory;
	public void Register<T>() where T : new() => _registry[typeof(T)] = () => new T();
	public void RegisterSingleton<T>(T instance) => _registry[typeof(T)] = () => instance;
	
	public T Resolve<T>() where T : new()
	{
		// if (_registry.TryGetValue(typeof(T), out var factory))
			// return factory();

		return new T();
		// Try to instantiate manually without reflection
		// throw new Exception($"Can't resolve type: {type}");
	}
}
