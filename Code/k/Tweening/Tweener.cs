using System.Threading;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Tweens;

namespace Sandbox.k.Tweening;

public class Tweener
{
	public static Tween Scale(GameObject target, float duration, Vector3 from, Vector3 to, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1, string id = null)
	{
		var cts = new CancellationTokenSource();
		var tween = new ScaleTween(target, duration, from, to, easing, delay, loopType, loopCount, id);
		tween.SetCancellationToken( cts.Token );
		return new Tween(tween, cts).Start();
	}
	
	public static Tween Position(GameObject target, float duration, Vector3 from, Vector3 to, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1, string id = null)
	{
		var cts = new CancellationTokenSource();
		var tween = new PositionTween(target, duration, from, to, easing, delay, loopType, loopCount, id );
		tween.SetCancellationToken( cts.Token );
		return new Tween(tween, cts).Start();
	}
	
	public static Tween LocalPosition(GameObject target, float duration, Vector3 from, Vector3 to, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1, string id = null)
	{
		var cts = new CancellationTokenSource();
		var tween = new LocalPositionTween(target, duration, from, to, easing, delay, loopType, loopCount, id );
		tween.SetCancellationToken( cts.Token );
		return new Tween(tween, cts).Start();
	}
	
	public static Tween ShakePosition(GameObject target, float duration, float power, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1, string id = null)
	{
		var cts = new CancellationTokenSource();
		var tween = new ShakePositionTween(target, duration, power, easing, delay, loopType, loopCount, id );
		tween.SetCancellationToken( cts.Token );
		return new Tween(tween, cts).Start();
	}
	
	public static Tween PunchScale(GameObject target, float duration, Vector3 punch, int vibrato, float elasticity,
		EasingType easing, float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1, string id = null)
	{
		var cts = new CancellationTokenSource();
		var tween = new PunchScaleTween(target, duration, punch, vibrato, elasticity, easing, delay, loopType,
			loopCount, id );
		tween.SetCancellationToken( cts.Token );
		return new Tween(tween, cts).Start();
	}
}
