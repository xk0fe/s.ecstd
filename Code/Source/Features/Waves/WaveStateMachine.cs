using Sandbox.k.ECS.Core;
using Sandbox.k.ECS.Extensions.Utils;
using Sandbox.k.StateMachine.Common;
using Sandbox.k.StateMachine.Core;
using Sandbox.k.StateMachine.Interfaces;
using Sandbox.Source.Features.Common.Components;
using Sandbox.Source.Features.Enemy.Components;
using Sandbox.Source.Features.Enemy.Resources;
using Sandbox.Source.Features.Spawners;
using Sandbox.Source.Features.Waves.Common;
using Sandbox.Source.Features.Waves.Models;
using Sandbox.Source.Features.Waves.Resources;

namespace Sandbox.Source.Features.Waves;

public class WaveStateMachine : ConditionalStateMachine
{
	public const float WAVE_START_DURATION = 5f;
	public const float WAVE_IN_PROGRESS_DURATION = 10f; // gonna be a variable later
	public const float WAVE_END_DURATION = 15f;

	public WaveStateMachine( WaveDatabase waveDatabase, IConditionalState initialState ) : base( initialState )
	{
	}
}

public abstract class WaveTimedState : TimedConditionalState
{
	protected int _wave;
	protected WaveDatabase _waveDatabase;
	protected EnemyDatabase _enemyDatabase;
	protected float _duration;

	protected WaveTimedState( int wave, WaveDatabase waveDatabase, EnemyDatabase enemyDatabase, float duration ) :
		base( duration )
	{
		_wave = wave;
		_enemyDatabase = enemyDatabase;
		_duration = duration;
	}
}

public class WaveStartState : WaveTimedState
{
	public WaveStartState( int wave, WaveDatabase waveDatabase, EnemyDatabase enemy, float duration )
		: base( wave, waveDatabase, enemy, duration )
	{
		World.Default.CreateEntity().SetComponent( new SpawnCurrentWave() );
		
		var spawner = new Spawner(); // todo
		var currentWave = waveDatabase.GetWave( wave );
		foreach ( var spawn in currentWave.Spawns )
		{
			for ( var i = 0; i < spawn.SpawnCount; i++ )
			{
				if ( !enemy.TryGetEnemyPrefab( spawn.EnemyId, out var prefab ) ) continue;
				spawner.Spawn( prefab, instance =>
				{
					var entity = World.Default.CreateEntity();
					entity.SetComponent( new GameObjectComponent { Value = instance, } );
					entity.SetComponent( new EnemyTag() );
					entity.SetComponent( new EnemyFollowPathTag() );
				} );
			}
		}
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}

	public override IConditionalState GetNextState()
	{
		return new WaveInProgressState( _wave, _waveDatabase, _enemyDatabase, _duration );
	}
}

public class WaveInProgressState : WaveTimedState
{
	public WaveInProgressState( int wave, WaveDatabase waveDatabase, EnemyDatabase enemy, float duration ) 
		: base( wave, waveDatabase, enemy, duration )
	{
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}

	public override IConditionalState GetNextState()
	{
		return new WaveEndState( _wave, _waveDatabase, _enemyDatabase, _duration );
	}
}

public class WaveEndState : WaveTimedState
{
	public WaveEndState( int wave, WaveDatabase waveDatabase, EnemyDatabase enemyDatabase, float duration ) 
		: base( wave, waveDatabase, enemyDatabase, duration )
	{
		_wave = wave + 1;
		_enemyDatabase = enemyDatabase;
		_duration = duration;
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}

	public override bool ShouldTransition()
	{
		return true;
	}

	public override IConditionalState GetNextState()
	{
		return new WaveStartState( _wave, _waveDatabase, _enemyDatabase, _duration );
	}
}
