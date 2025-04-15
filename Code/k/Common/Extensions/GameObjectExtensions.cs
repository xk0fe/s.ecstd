namespace Sandbox.k.Common.Extensions;

public static class GameObjectExtensions
{
	public static bool IsPlayer( this GameObject gameObject )
	{
		return gameObject.Tags.Contains( "player" );
	}
}
