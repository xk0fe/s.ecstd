using System;

namespace Sandbox.k.ECS.Game.Components;

[Category( "k.ECS" )]
public class EntityProvider<T> : Component 
{
	protected override void OnAwake()
	{
		base.OnAwake();
		Initialize();
	}

	private void Initialize()
	{
		if (this is not T component)
		{
			throw new InvalidOperationException(
				$"{GetType().Name} must inherit EntityProvider<{GetType().Name}> properly.");
		}

		var identifier = GetOrAddEntityIdentifier();
		identifier.InitializeEntity();
		identifier.LinkComponent(component);
	}
	
	public int GetEntity()
	{
		var identifier = GetOrAddEntityIdentifier();
		identifier.InitializeEntity();
		return identifier.EntityId;
	}

	private SandboxEntityIdentifier GetOrAddEntityIdentifier()
	{
		var entityIdentifier = GetComponent<SandboxEntityIdentifier>();
		if ( !entityIdentifier.IsValid() )
		{
			entityIdentifier = AddComponent<SandboxEntityIdentifier>();
		}

		return entityIdentifier;
	}
}
