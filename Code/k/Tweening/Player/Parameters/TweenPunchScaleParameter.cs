using Sandbox.k.Tweening.Enums;

namespace Sandbox.k.Tweening.Player.Parameters;

public class TweenPunchScaleParameter : TweenParameter
{
	[Property] public Vector3 Punch;
	[Property] public int Vibrato;
	[Property] public float Elasticity;
	
	public override Tween CreateTween(GameObject target, float duration, EasingType easing,
		float delay = 0f, LoopType loopType = LoopType.None, int loopCount = -1)
	{
		return Tweener.PunchScale( target, duration, Punch, Vibrato, Elasticity, easing, delay, loopType, loopCount );
	}
}
