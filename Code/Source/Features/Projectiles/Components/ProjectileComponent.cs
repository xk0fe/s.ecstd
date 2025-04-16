namespace Sandbox.Source.Features.Projectiles.Components;

public struct ProjectileComponent
{
	public Vector3 Position;
	public Vector3 Velocity;
	public float Impulse;
	public float Radius;
	public float Damage;
	public Scene Scene;
	public string[] AllowedTags;
}
