namespace Sandbox.k.Configs;

/// <summary>
/// Represents functionality for loading and managing configuration files of different types.
/// </summary>
public class Config
{
	private static Dictionary<string, object> _configs = new();

	/// <summary>
	/// Loads a configuration file of the specified type from the given file path.
	/// </summary>
	/// <typeparam name="T">The type of the configuration file to load.</typeparam>
	/// <param name="path">The file path of the configuration file to load.</param>
	/// <returns>Returns the configuration object of type <c>T</c>. If loading fails, returns the default value of <c>T</c>.</returns>
	public static T GetFromPath<T>( string path )
	{
		return LoadConfig<T>( path );
	}

	/// <summary>
	/// Loads a configuration file of the specified type from the default configuration directory using the given file name.
	/// </summary>
	/// <typeparam name="T">The type of the configuration to load.</typeparam>
	/// <param name="fileName">The name of the configuration file to load, located in the default configuration directory.</param>
	/// <returns>Returns the configuration object of type <c>T</c>. If loading fails, returns the default value of <c>T</c>.</returns>
	public static T Get<T>( string fileName )
	{
		return LoadConfig<T>( ConfigSettings.CONFIGS_PATH + fileName );
	}

	/// <summary>
	/// Loads a configuration file of the specified type from the given file path.
	/// </summary>
	/// <typeparam name="T">The type of the configuration file to load.</typeparam>
	/// <param name="path">The file path of the configuration file to load.</param>
	/// <returns>Returns the configuration object of type <c>T</c>. If the file cannot be loaded, returns the default value of <c>T</c>.</returns>
	private static T LoadConfig<T>( string path )
	{
		if ( _configs.TryGetValue( path, out var config ) )
		{
			return (T)config;
		}

		var read = FileSystem.Mounted.ReadJson<T>( path );
		if ( read == null )
		{
			Log.Error( $"Failed to load config: {path}" );
			return default;
		}

		_configs[path] = read;

		return read;
	}
	
	/// <summary>
	/// As we use hot reload for configs, we need to clear the cache.
	/// </summary>
	public static void ClearCache()
	{
		_configs.Clear();
	}
}
