using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;

namespace Sandbox.k;

public abstract class StorageFeatureBase : FeatureBase
{
	/// <summary>
	/// Registers storage instances into the Dependency Locator container.
	/// Storages are registered before systems, allowing systems from any feature
	/// to retrieve and use shared storages during initialization or runtime.
	/// Example: container.Register( new YourStorage() );
	/// </summary>
	/// <param name="container">The dependency container where storages are registered.</param>
	public abstract void RegisterStorages( DlContainer container );
	
	/// <summary>
	/// Registers system instances into the Dependency Locator container.
	/// Systems can depend on previously registered storages or other services.
	/// Called after RegisterStorages to ensure all required dependencies are available.
	/// Example: AddSystem( container.Register( new YourSystem() ) );
	/// </summary>
	/// <param name="container">The dependency container where systems are registered.</param>

	public abstract void RegisterSystems( DlContainer container );
}
