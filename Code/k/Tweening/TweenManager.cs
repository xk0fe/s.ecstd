namespace Sandbox.k.Tweening;

public class TweenManager
{
	private static readonly Dictionary<string, TweenBase> _tweensById = new();
	private static readonly Dictionary<GameObject, List<TweenBase>> _tweensByTarget = new();

	public static void Register( TweenBase tween )
	{
		if ( !string.IsNullOrEmpty( tween.Id ) )
			_tweensById[tween.Id] = tween;

		if ( !_tweensByTarget.TryGetValue( tween.Target, out var list ) )
			_tweensByTarget[tween.Target] = list = new List<TweenBase>();

		list.Add( tween );
	}

	public static void KillById( string id, bool complete = false )
	{
		if ( !_tweensById.TryGetValue( id, out var tween ) ) return;
		KillTween( tween, complete );
		_tweensById.Remove( id );
	}

	public static void KillByGameObject( GameObject obj, bool complete = false )
	{
		if ( !_tweensByTarget.TryGetValue( obj, out var list ) ) return;
		foreach ( var tween in list )
		{
			KillTween( tween, complete );
			_tweensById.Remove( tween.Id );
		}

		_tweensByTarget.Remove( obj );
	}

	private static void KillTween( TweenBase tween, bool complete = false )
	{
		tween.OnComplete = null; // Optional: skip callback
		if ( !complete ) return;
		tween.Complete(); // Finalize tween
	}
}
