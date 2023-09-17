using Robust.Shared.GameObjects;
using Robust.Shared.Serialization;
using Robust.Shared.ViewVariables;

namespace Content.Shared.Ghost
{
    [RegisterComponent]
    public sealed class GhostComponent : Component
    {
        public override string Name => "Ghost";
        public override uint? NetID => ContentNetIDs.GHOST;
        public Color color = Color.White;

+       [ViewVariables]
+       public ActionType PoopBananaAction { get; } = new ActionType(nameof(PoopBananaAction));

        public override void ExposeData(ObjectSerializer serializer)
        {
            base.ExposeData(serializer);
            serializer.DataField(ref color, "color", Color.White);
        }
    }
}