using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening.Extensions;

public static class TweenerExtensions
{
	public static Tween Scale( this GameObject target, float duration, Vector3 from, Vector3 to,
		EasingType easing = EasingType.Linear, float delay = 0f, LoopType loopType = LoopType.None,
		int loopCount = -1 )
	{
		return Tweener.Scale( target, duration, from, to, easing, delay, loopType, loopCount );
	}
	
	public static Tween Position( this GameObject target, float duration, Vector3 from, Vector3 to,
		EasingType easing = EasingType.Linear, float delay = 0f, LoopType loopType = LoopType.None,
		int loopCount = -1 )
	{
		return Tweener.Position( target, duration, from, to, easing, delay, loopType, loopCount );
	}
	
	public static Tween LocalPosition( this GameObject target, float duration, Vector3 from, Vector3 to,
		EasingType easing = EasingType.Linear, float delay = 0f, LoopType loopType = LoopType.None,
		int loopCount = -1 )
	{
		return Tweener.LocalPosition( target, duration, from, to, easing, delay, loopType, loopCount );
	}
	
	public static Tween ShakePosition( this GameObject target, float duration, float power,
		EasingType easing = EasingType.Linear, float delay = 0f, LoopType loopType = LoopType.None,
		int loopCount = -1 )
	{
		return Tweener.ShakePosition( target, duration, power, easing, delay, loopType, loopCount );
	}
	
	public static Tween PunchScale( this GameObject target, float duration, Vector3 punch, int vibrato, float elasticity,
		EasingType easing = EasingType.Linear, float delay = 0f, LoopType loopType = LoopType.None,
		int loopCount = -1 )
	{
		return Tweener.PunchScale( target, duration, punch, vibrato, elasticity, easing, delay, loopType, loopCount );
	}
}
