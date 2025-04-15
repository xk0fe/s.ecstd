namespace Sandbox.Source.Features.Slots.Components;

public struct SlotComponent
{
	[Property] public int CurrentMoney { get; set; }
	[Property] public TextRenderer TextRenderer { get; set; }
	[Property] public GameObject[] States { get; set; }
}
