namespace Sandbox.k.Tweening.Player;

public class TweenPlayerManager : Component
{
	[Property] public bool _playOnEnable { get; set; }
	[RequireComponent] private TweenPlayerComponent _tweenPlayer { get; set; }

	protected override void OnEnabled()
	{
		base.OnEnabled();
		if ( _playOnEnable ) _tweenPlayer.Play();
	}
}
