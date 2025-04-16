using System;
using System.Threading.Tasks;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Extensions;

namespace Sandbox.k.Tweening.Tweens;

public class ShakePositionTween : TweenBase
{
	private readonly float _power;

	public ShakePositionTween(GameObject target, float duration, float power, EasingType easing,
		float delay, LoopType loopType, int loopCount, string id = null)
		: base(target, duration, easing, delay, loopType, loopCount, id )
	{
		_power = power;
	}

	protected override async Task Play(bool forward)
	{
		TimeSince timeSince = 0;
		var easingFunc = TweenExtensions.EasingFunction(_easing);
		var duration = _duration;
		var originalPosition = _target.WorldPosition;

		while (timeSince < duration)
		{
			if (_token.IsCancellationRequested || !Game.IsPlaying)
				break;

			var t = timeSince / duration;
			var dampenedPower = _power * (1f - easingFunc(t)); // shake fades over time
			var offset = new Vector3(
				Random.Shared.Float(-dampenedPower, dampenedPower),
				Random.Shared.Float(-dampenedPower, dampenedPower),
				Random.Shared.Float(-dampenedPower, dampenedPower)
			);

			_target.WorldPosition = originalPosition + offset;

			await GameTask.Yield();
		}

		_target.WorldPosition = originalPosition; // restore original position at the end
	}

	protected override void Complete(bool forward)
	{
		// Ensure final position is reset
		_target.WorldPosition = _target.WorldPosition;
	}
}
