namespace Content.Server.Heretic.Components.PathSpecific;

[RegisterComponent]
public sealed partial class AristocratComponent : Component
{
    public float UpdateTimer = 0f;
    [DataField] public float UpdateDelay = 1.5f;
    [DataField] public float Range = 5f;
}
