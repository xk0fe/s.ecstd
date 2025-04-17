using Sandbox.Source.Features.Turrets.Configs;

namespace Sandbox.Source.Features.Enemy.Configs;

public class EnemyModel
{
	[Property] public string Id { get; set; }
	[Property] public GameObject Prefab { get; set; }
	[Property] public string Name { get; set; }
	[Property, InlineEditor, Feature("Stats")] public StatModifiers Stats { get; set; }
}
