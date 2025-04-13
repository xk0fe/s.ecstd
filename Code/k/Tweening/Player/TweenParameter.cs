using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening.Player;

public class TweenParameter : Component
{
	public virtual Tween CreateTween( GameObject target, float duration, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1 )
	{
		return null;
	}
}
