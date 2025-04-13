using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening.Player.Parameters;

public class TweenScaleParameter : TweenParameter
{
	[Property] public Vector3 From { get; set; } = new Vector3( 1f, 1f, 1f );
	[Property] public Vector3 To { get; set; } = new Vector3( 1f, 1f, 1f );
	
	public override Tween CreateTween(GameObject target, float duration, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1)
	{
		return TweenFactory.Scale( target, duration, From, To, easing, delay, loopType, loopCount );
	}
}
