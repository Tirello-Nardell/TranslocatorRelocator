using HarmonyLib;
using System.Runtime.CompilerServices;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace TranslocatorRelocator.src.harmony.server
{
    [HarmonyPatchCategory(Core.ServerPatchCategory)]
    [HarmonyPatch(typeof(Block), "OnBlockBroken")]
    class BlockServerReversePatch //Reverse patch to stub the base method of OnBlockBroken
    {
        [HarmonyReversePatch]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void OnBlockBroken(Block instance, IWorldAccessor world, BlockPos pos, IPlayer byPlayer, float dropQuantityMultiplier = 1f)
        {
            instance.OnBlockBroken(world, pos, byPlayer, dropQuantityMultiplier);
        }
    }
}
