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
	}
	
	protected void AddFeature( StorageFeatureBase featureBase )
	{
		_features.Add( featureBase );
	}

	protected virtual void Register( DlContainer container )
	{
	}
	
	protected override void OnAwake()
	{
		base.OnAwake();
		var container = new DlContainer();
		Register( container );
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
