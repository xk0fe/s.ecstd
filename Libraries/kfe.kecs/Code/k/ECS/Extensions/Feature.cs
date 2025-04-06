using System.Collections.Generic;

namespace Sandbox.k.ECS.Extensions;

public class Feature
{
	public bool IsEnabled { get; set; } = true;
	
	private readonly List<System> _systems = new List<System>();
	private bool _isInitialized;
	
	public void AddSystem( System system )
	{
		_systems.Add( system );
	}
	
	public virtual void Initialize()
	{
		foreach ( var system in _systems )
		{
			system.Initialize();
		}
		_isInitialized = true;
	}

	public virtual void Update( float deltaTime )
	{
		if ( !_isInitialized || !IsEnabled ) return;
		foreach ( var system in _systems )
		{
			system.Update( deltaTime );
		}
	}
}
