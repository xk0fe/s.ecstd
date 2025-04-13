using Sandbox.k.Tweening.Enums;
using Sandbox.Utility;

namespace Sandbox.k.Tweening.Extensions;

public static class TweenExtensions
{
	/// <summary>
	/// Converts the EasingType enum to a string for use in the Sandbox.Utility.Easing function.
	/// </summary>
	private static readonly Dictionary<EasingType, string> _names = new()
	{
		{ EasingType.Linear, "linear" },
		{ EasingType.QuadraticIn, "ease-in" },
		{ EasingType.QuadraticOut, "ease-out" },
		{ EasingType.QuadraticInOut, "ease" },
		{ EasingType.ExponentialInOut, "ease-in-out" },
		{ EasingType.ExponentialIn, "ease-in" },
		{ EasingType.ExponentialOut, "ease-out" },
		{ EasingType.BounceIn, "bounce-in" },
		{ EasingType.BounceOut, "bounce-out" },
		{ EasingType.BounceInOut, "bounce-in-out" },
		{ EasingType.SineEaseIn, "sin-ease-in" },
		{ EasingType.SineEaseOut, "sin-ease-out" },
		{ EasingType.SineEaseInOut, "sin-ease-in-out" }
	};
	
	public static Easing.Function EasingFunction( EasingType easingType )
	{
		return Easing.GetFunction( easingType.ToCustomString() );
	}

	private static string ToCustomString(this EasingType type)
	{
		return _names.TryGetValue(type, out var name) ? name : type.ToString();
	}
}
