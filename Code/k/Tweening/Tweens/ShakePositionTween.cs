using System;
using System.Threading.Tasks;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Extensions;

namespace Sandbox.k.Tweening.Tweens;

public class ShakePositionTween : TweenBase
{
	private readonly float _power;
	private readonly Vector3 _originalPosition;

	public ShakePositionTween(GameObject target, float duration, float power, EasingType easing,
		float delay, LoopType loopType, int loopCount, string id = null)
		: base(target, duration, easing, delay, loopType, loopCount, id )
	{
		_power = power;
		_originalPosition = target.WorldPosition;
	}

	protected override async Task Play(bool forward)
	{
		TimeSince timeSince = 0;
		var easingFunc = TweenExtensions.EasingFunction(_easing);
		var duration = _duration;

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

			_target.WorldPosition = _originalPosition + offset;

			await GameTask.Yield();
		}

		_target.WorldPosition = _originalPosition; // restore original position at the end
	}

	protected override void Complete(bool forward)
	{
		// Ensure final position is reset
		_target.WorldPosition = _originalPosition;
	}
}
