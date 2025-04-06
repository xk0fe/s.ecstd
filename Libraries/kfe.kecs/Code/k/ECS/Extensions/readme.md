# Feature
Feature is a class that contains a list of systems related to a specific ... feature. 
For example, a feature could be "combat", and the systems related to that feature could be "attack", "defend", etc.

Example:
```cs
public class CombatFeature : Feature
{
    public CombatFeature()
    {
        Add(new AttackSystem());
        Add(new DefenseSystem());
    }
}
```

# System
System is a class that contains a filter and operates on entities that match that filter.

Example:
```cs
public class AttackSystem : System
{
    private Filter _filter;
    
    public override bool Initialize()
    {
        _filter = new Filter().With<AttackComponent>();
    }
    
    public override void Update(float deltaTime)
    {
        foreach (var entity in _filter.GetEntities())
        {
            var attackComponent = entity.Get<AttackComponent>();
            // Perform attack logic here
        }
    }
}
```

# InitializerBase
Initializer base class allows us to easily manage game features.

Example:
```cs
public class MyInitializer : InitializerBase
{
    protected override void OnAwake()
    {
        AddFeature( new CombatFeature() );
        base.OnAwake();
    }
}
```