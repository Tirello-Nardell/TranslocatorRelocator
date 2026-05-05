using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace TranslocatorRelocator.src.block
{
    public class BlockBehaviorDefaultDropsHorizontalOrientable : BlockBehaviorHorizontalOrientable //BlockBehaviorHorizontalOrientable derived class that allows for custom drops
    {
        public BlockBehaviorDefaultDropsHorizontalOrientable(Block block) : base(block)
        {
        }

        public override ItemStack[] GetDrops(IWorldAccessor world, BlockPos pos, IPlayer byPlayer, ref float dropQuantityMultiplier, ref EnumHandling handled)
        {
            handled = EnumHandling.PassThrough;
            return null;
        }
    }
}
