using System;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening;

public abstract class TweenBase
{
	/// <summary>
	/// Called when the tween or tween loop is complete.
	/// </summary>
	public Action OnComplete;

	protected readonly GameObject _target;
	protected readonly float _duration;
	protected readonly EasingType _easing;
	protected readonly float _delay;
	protected readonly LoopType _loopType;
	protected readonly int _loopCount;
	protected readonly CancellationToken _token;

	protected TweenBase( GameObject target, float duration, EasingType easing,
		float delay, LoopType loopType, int loopCount,
		CancellationToken token )
	{
		_target = target;
		_duration = duration;
		_easing = easing;
		_delay = delay;
		_loopType = loopType;
		_loopCount = loopCount;
		_token = token;
	}

	public async Task Run()
	{
		if ( _delay > 0 ) await GameTask.DelaySeconds( _delay, _token );

		// true by default, false if reversed
		var direction = _loopType != LoopType.Reverse;
		if ( _duration == 0 )
		{
			Complete( forward: direction );
			OnComplete?.Invoke();
			return;
		}

		var currentLoop = 0;

		while ( _loopCount < 0 || currentLoop < _loopCount )
		{
			if ( !Game.IsPlaying ) break;
			if ( _token.IsCancellationRequested )
				break;

			await Play( forward: direction );
			Complete( forward: direction );

			if ( _token.IsCancellationRequested )
				break;

			if ( _loopType == LoopType.None )
				break;

			if ( _loopType == LoopType.PingPong )
				direction = !direction;

			currentLoop++;
		}

		OnComplete?.Invoke();
	}

	protected abstract Task Play( bool forward );
	protected abstract void Complete( bool forward );
}
