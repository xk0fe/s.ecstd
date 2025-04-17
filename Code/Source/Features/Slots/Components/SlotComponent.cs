using Sandbox.Source.Features.Slots.Common;

namespace Sandbox.Source.Features.Slots.Components;

public struct SlotComponent
{
	[Property] public int CurrentMoney { get; set; }
	[Property] public TextRenderer TextRenderer { get; set; }
	[Property] public BoxCollider Collider { get; set; }
	[Property, InlineEditor] public SlotState[] States { get; set; }
}
