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
	public string Id { get; private set; }
	public GameObject Target => _target;
	
	protected readonly GameObject _target;
	protected readonly float _duration;
	protected readonly EasingType _easing;
	protected readonly float _delay;
	protected readonly LoopType _loopType;
	protected readonly int _loopCount;
	protected CancellationToken _token;

	private bool _lastDirection;

	protected TweenBase( GameObject target, float duration, EasingType easing,
		float delay, LoopType loopType, int loopCount, string id = null )
	{
		_target = target;
		_duration = duration;
		_easing = easing;
		_delay = delay;
		_loopType = loopType;
		_loopCount = loopCount;
		Id = id ?? Guid.NewGuid().ToString();
		TweenManager.Register( this );
	}

	public async Task Run()
	{
		if ( _delay > 0 ) await GameTask.DelaySeconds( _delay, _token );

		// true by default, false if reversed
		_lastDirection = _loopType != LoopType.Reverse;
		if ( _duration == 0 )
		{
			Complete( forward: _lastDirection );
			OnComplete?.Invoke();
			return;
		}

		var currentLoop = 0;

		while ( _loopCount < 0 || currentLoop < _loopCount )
		{
			if ( !Game.IsPlaying ) break;
			if ( _token.IsCancellationRequested )
				break;

			await Play( forward: _lastDirection );
			Complete( forward: _lastDirection );

			if ( _token.IsCancellationRequested )
				break;

			if ( _loopType == LoopType.None )
				break;

			if ( _loopType == LoopType.PingPong )
				_lastDirection = !_lastDirection;

			currentLoop++;
		}

		OnComplete?.Invoke();
	}

	public void Complete()
	{
		Complete( forward: _lastDirection );
		OnComplete?.Invoke();
	}
	
	public void SetCancellationToken( CancellationToken token )
	{
		_token = token;
	}

	protected abstract Task Play( bool forward );

	protected abstract void Complete( bool forward );
}
