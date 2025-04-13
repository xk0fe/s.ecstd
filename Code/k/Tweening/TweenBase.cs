using System.Threading;
using System.Threading.Tasks;
using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening;

public abstract class TweenBase
{
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
		int currentLoop = 0;

		while (_loopCount < 0 || currentLoop < _loopCount)
		{
			if (_token.IsCancellationRequested)
				break;

			if (_delay > 0) await GameTask.DelaySeconds(_delay, _token);

			await Play(forward: true);

			if (_token.IsCancellationRequested)
				break;

			switch ( _loopType )
			{
				case LoopType.None:
					return;
				case LoopType.Reverse:
				case LoopType.PingPong:
					await Play( forward: false );
					break;
			}

			currentLoop++;
		}
	}

	protected abstract Task Play(bool forward);
}
