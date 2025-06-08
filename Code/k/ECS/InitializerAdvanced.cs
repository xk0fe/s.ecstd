using Sandbox.k.DependencyLocator;

namespace Sandbox.k;

public class InitializerAdvanced : Component
{
	private readonly List<StorageFeatureBase> _features = new List<StorageFeatureBase>();
	
	private DlContainer _container;
	
	protected void BindContainer( DlContainer container )
	{
		foreach ( var feature in _features )
		{
			feature.RegisterStorages( container );
		}

		foreach ( var feature in _features )
		{
			feature.RegisterSystems( container );
		}
		
		OnContainerBind( container );
	}
	
	// can i make a better name really
	protected virtual void OnContainerBind( DlContainer container )
	{
	}
	
	protected void AddFeature( StorageFeatureBase featureBase )
	{
		_features.Add( featureBase );
	}

	protected virtual void OnRegister( DlContainer container )
	{
	}
	
	protected override void OnAwake()
	{
		base.OnAwake();
		var container = new DlContainer();
		OnRegister( container );
		BindContainer( container );
		
		foreach ( var feature in _features )
		{
			if ( !feature.IsEnabled ) continue;
			feature.Initialize();
		}
	}
	
	protected override void OnUpdate()
	{
		base.OnUpdate();
		var deltaTime = Time.Delta;
		foreach ( var feature in _features )
		{
			feature.Update( deltaTime );
		}
	}
}
