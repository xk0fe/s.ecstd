using System.Threading;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Tweens;

namespace Sandbox.k.Tweening;

public class TweenFactory
{
	public static Tween Scale(GameObject target, float duration, Vector3 from, Vector3 to, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1)
	{
		var cts = new CancellationTokenSource();
		var tween = new ScaleTween(target, duration, from, to, easing, delay, loopType, loopCount, cts.Token);
		return new Tween(tween, cts).Start();
	}
	
	public static Tween Position(GameObject target, float duration, Vector3 from, Vector3 to, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1)
	{
		var cts = new CancellationTokenSource();
		var tween = new PositionTween(target, duration, from, to, easing, delay, loopType, loopCount, cts.Token);
		return new Tween(tween, cts).Start();
	}
	
	public static Tween LocalPosition(GameObject target, float duration, Vector3 from, Vector3 to, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1)
	{
		var cts = new CancellationTokenSource();
		var tween = new LocalPositionTween(target, duration, from, to, easing, delay, loopType, loopCount, cts.Token);
		return new Tween(tween, cts).Start();
	}
}
