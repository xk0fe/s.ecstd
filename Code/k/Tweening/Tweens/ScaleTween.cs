﻿using System.Threading.Tasks;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Extensions;

namespace Sandbox.k.Tweening.Tweens;

public class ScaleTween : TweenBase
{
	private readonly Vector3 _from;
	private readonly Vector3 _to;

	public ScaleTween(GameObject target, float duration, Vector3 from, Vector3 to, EasingType easing,
		float delay, LoopType loopType, int loopCount, string id = null)
		: base(target, duration, easing, delay, loopType, loopCount, id)
	{
		_from = from;
		_to = to;
	}

	protected override async Task Play(bool forward)
	{
		TimeSince timeSince = 0;
		var easingFunc = TweenExtensions.EasingFunction( _easing );

		var start = forward ? _from : _to;
		var end = forward ? _to : _from;

		while (timeSince < _duration)
		{
			if (_token.IsCancellationRequested)
				break;

			var progress = timeSince / _duration;
			_target.WorldScale = Vector3.Lerp(start, end, easingFunc(progress));
			await GameTask.Yield();
		}
	}
	
	protected override void Complete( bool forward )
	{
		var end = forward ? _to : _from;
		_target.WorldScale = end;
	}
}
