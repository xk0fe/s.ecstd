namespace Sandbox.k.DI;

public class GameResourceContainer : Component
{
	[Property] public GameResource[] Resources { get; set; }

	// protected override void OnAwake()
	// {
	// 	base.OnAwake();
	// 	var container = new InjectionContainer();
	// 	foreach (var resource in Resources)
	// 	{
	// 		if (resource == null) continue;
	// 		if (resource.IsSingleton)
	// 		{
	// 			container.RegisterSingleton(resource.Type, resource.GetInstance());
	// 		}
	// 		else
	// 		{
	// 			container.Register(resource.Type, resource.GetInstance);
	// 		}
	// 	}
	// }
}
