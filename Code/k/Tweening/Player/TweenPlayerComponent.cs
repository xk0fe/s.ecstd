using System;
using Sandbox.k.Tweening.Enums;
using Sandbox.k.Tweening.Player.Parameters;

namespace Sandbox.k.Tweening.Player;

public class TweenPlayerComponent : Component
{
	[Property, Change] public TweenType TweenType { get; set; } = TweenType.None;
	[Property] public float Duration { get; set; } = 1f;
	[Property] public float Delay { get; set; } = 0f;
	[Property] public EasingType EasingType { get; set; } = EasingType.Linear;
	[Property] public bool IsLooping { get; set; } = false;
	[Property, ShowIf("IsLooping", true)] public int LoopCount { get; set; } = 1;
	[Property, ShowIf("IsLooping", true)] public LoopType LoopType { get; set; } = LoopType.Loop;
	[Property] public bool PlayOnAwake { get; set; } = false;

	[Header("Settings")]
	[Property] TweenParameter Parameters { get; set; }
	
	// [Property] public TweenComponent TweenComponent { get; set; } = null;

	private Tween _tween;

	protected override void OnAwake()
	{
		base.OnAwake();
		if ( PlayOnAwake )
		{
			Play();
		}
	}

	[Button]
	public void Play()
	{
		_tween?.Kill();
		_tween = Parameters.CreateTween( GameObject, Duration, EasingType, Delay, IsLooping ? LoopType : LoopType.None, LoopCount );
	}
	
	private void OnTweenTypeChanged( TweenType oldValue, TweenType newValue )
	{
		RemoveParameter();
		AddParameter();
	}

	private void RemoveParameter()
	{
		if ( Parameters.IsValid() ) Parameters.Destroy();
	}

	private void AddParameter()
	{
		switch ( TweenType )
		{
			case TweenType.None:
				break;
			case TweenType.Position:
				break;
			case TweenType.Rotation:
				break;
			case TweenType.Scale:
				Parameters = GameObject.AddComponent<TweenScaleParameter>();
				break;
			case TweenType.Color:
				break;
			case TweenType.FOV:
				break;
			case TweenType.Alpha:
				break;
			case TweenType.ShakePosition:
				break;
			case TweenType.ShakeRotation:
				break;
			case TweenType.ShakeScale:
				break;
			case TweenType.ShakeColor:
				break;
			case TweenType.ShakeFOV:
				break;
			case TweenType.ShakeAlpha:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}
