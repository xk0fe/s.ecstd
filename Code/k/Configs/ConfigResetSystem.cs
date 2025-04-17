namespace Sandbox.k.Configs;

public class ConfigResetSystem : GameObjectSystem
{
	public ConfigResetSystem(Scene scene) : base(scene)
	{
		Config.ClearCache();
	}
}
