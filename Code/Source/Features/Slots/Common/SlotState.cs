namespace Sandbox.Source.Features.Slots.Common;

public class SlotState
{
	[Property] public GameObject UpgradeView { get; set; }
	[Property] public GameObject UpgradeColliderTarget { get; set; }

	public bool IsActive => UpgradeView.Enabled;
	
	public void SetActive( bool isActive, BoxCollider collider )
	{
		UpgradeView.Enabled = isActive;
		if ( isActive )
		{
			collider.Center = UpgradeColliderTarget.WorldPosition - collider.WorldPosition;
		}
	}
}
