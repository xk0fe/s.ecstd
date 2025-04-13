using Sandbox.Source.Features.Enemy.Models;

namespace Sandbox.Source.Features.Enemy.Storages;

public class EnemyStorage
{
	public Dictionary<int, EnemyDataModel> Enemies { get; set; } = new();
}
