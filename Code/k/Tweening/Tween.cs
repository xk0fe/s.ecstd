using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.k.Tweening;

public class Tween
{
	private readonly CancellationTokenSource _cts;
	private readonly TweenBase _tweenBase;
	private Task _task;
	
	public Tween OnComplete(Action action)
	{
		Log.Info( "added eee action!" );
		_tweenBase.OnComplete += action;
		return this;
	}
	
	public Tween(TweenBase tweenBase, CancellationTokenSource cts)
	{
		_cts = cts;
		_tweenBase = tweenBase;
	}
	
	public Tween Start()
	{
		_task = _tweenBase.Run();
		return this;
	}

	public void Kill(bool complete = false)
	{
		_cts?.Cancel();
		if (complete) _tweenBase.Complete();
	}
	public bool IsCompleted => _task?.IsCompleted ?? true;
}
