using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening.Player.Parameters;

public class TweenShakePositionParameter : TweenParameter
{
	[Property] public float Power;
	public override Tween CreateTween(GameObject target, float duration, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1)
	{
		return Tweener.ShakePosition( target, duration, Power, easing, delay, loopType, loopCount );
	}
}
