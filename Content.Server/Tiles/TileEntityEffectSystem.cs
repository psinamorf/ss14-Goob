using Content.Shared.StepTrigger.Systems;
using Content.Shared.EntityEffects;

namespace Content.Server.Tiles;

public sealed class TileEntityEffectSystem : EntitySystem
{

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<TileEntityEffectComponent, StepTriggeredOffEvent>(OnTileStepTriggered);
        SubscribeLocalEvent<TileEntityEffectComponent, StepTriggerAttemptEvent>(OnTileStepTriggerAttempt);
    }
    private void OnTileStepTriggerAttempt(Entity<TileEntityEffectComponent> ent, ref StepTriggerAttemptEvent args)
    {
        args.Continue = true;
    }

    private void OnTileStepTriggered(Entity<TileEntityEffectComponent> ent, ref StepTriggeredOffEvent args)
    {
        var otherUid = args.Tripper;
        var effectArgs = new EntityEffectBaseArgs(otherUid, EntityManager);

        foreach (var effect in ent.Comp.Effects)
        {
            effect.Effect(effectArgs);
        }
    }
}
