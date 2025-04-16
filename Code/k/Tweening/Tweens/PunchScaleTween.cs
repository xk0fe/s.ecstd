using System;
using System.Threading.Tasks;
using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening.Tweens;

public class PunchScaleTween : TweenBase
{
	private Vector3 _punch;
	private int _vibrato;
	private float _elasticity;
	private Vector3 _initialScale;
	
	public PunchScaleTween( GameObject target, float duration, Vector3 punch, int vibrato, float elasticity,
		EasingType easing, float delay, LoopType loopType, int loopCount, string id = null)
		: base( target, duration, easing, delay, loopType, loopCount, id )
	{
		_punch = punch;
		_vibrato = vibrato;
		_elasticity = elasticity;
	}


	protected override async Task Play(bool forward)
	{
		TimeSince timeSince = 0;
		_initialScale = _target.WorldScale;

		var oscillations = _vibrato;
		var decay = _elasticity;
		var duration = _duration;

		while (timeSince < duration)
		{
			if (_token.IsCancellationRequested || !Game.IsPlaying)
				break;

			var t = timeSince / duration;

			// Damped oscillation curve
			// Amplitude falls off over time
			var decayFactor = MathF.Pow(1 - t, decay * 5f); // Adjust strength falloff
			var angle = t * oscillations * MathF.PI * 2; // Vibrations
			var offset = _punch * decayFactor * MathF.Sin(angle);

			_target.WorldScale = _initialScale + offset;

			await GameTask.Yield();
		}

		_target.WorldScale = _initialScale;
	}

	protected override void Complete(bool forward)
	{
		_target.WorldScale = _initialScale;
	}
}
