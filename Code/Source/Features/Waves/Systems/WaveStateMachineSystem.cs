using Sandbox.k.DependencyLocator;
using Sandbox.k.ECS.Extensions;
using Sandbox.Source.Features.Enemy.Resources;
using Sandbox.Source.Features.Waves.Resources;

namespace Sandbox.Source.Features.Waves.Systems;

public class WaveStateMachineSystem : SystemBase
{
	private WaveDatabase _database;
	private EnemyDatabase _enemyDatabase;
	private WaveStateMachine _stateMachine;

	public WaveStateMachineSystem( DlContainer container )
	{
		_database = container.Get<WaveDatabase>();
		_enemyDatabase = container.Get<EnemyDatabase>();
		_stateMachine = new WaveStateMachine( _database, null );
	}
	
	public override void Initialize()
	{
		base.Initialize();
		_stateMachine.ChangeState( new WaveStartState( 0, _database, _enemyDatabase, 5f ) );
	}
	
	public override void Update( float deltaTime )
	{
		base.Update( deltaTime );
		_stateMachine.Update();
	}
}
