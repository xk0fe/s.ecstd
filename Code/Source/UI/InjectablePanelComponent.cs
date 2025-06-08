using System;
using Sandbox.k.DependencyLocator;

public abstract class InjectablePanelComponent : PanelComponent {
	protected DlContainer _container;
	
	public void InjectContainer( DlContainer container )
	{
		_container = container;
		if ( _container == null )
		{
			throw new ArgumentNullException(nameof(container), "Container cannot be null or invalid.");
		}
		
		OnInject(container);
	}

	/// <summary>
	/// Abstract method that is invoked when the dependency container is injected.
	/// This method should be overridden to handle container initialization and dependent object retrieval.
	/// </summary>
	/// <param name="container">The dependency injection container providing access to registered instances.</param>
	/// <example>
	/// <code>
	/// private MyClassExample _example;
	/// 
	/// public override void OnInject(DlContainer container)
	/// {
	///     _example = container.Get&lt;MyClassExample&gt;();
	/// }
	/// </code>
	/// </example>
	public abstract void OnInject( DlContainer container );
}
