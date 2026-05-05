using System.Runtime.CompilerServices;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using HarmonyLib;

namespace TranslocatorRelocator.src.harmony.server
{
    [HarmonyPatchCategory(Core.ServerPatchCategory)]
    [HarmonyPatch(typeof(BlockStaticTranslocator), "OnBlockBroken")]
    class BlockStaticTranslocatorServerPatch //Patch to allow the block to be broken and calls a stub which basically calls the base method of Block and it just works
    {
        public static void Prefix(BlockStaticTranslocator __instance, IWorldAccessor world, BlockPos pos, IPlayer byPlayer, float dropQuantityMultiplier = 1f)
        {
            BlockEntity blockEntity = world.BlockAccessor.GetBlockEntity(pos);
            if (byPlayer.WorldData.CurrentGameMode == EnumGameMode.Creative || (blockEntity is BlockEntityStaticTranslocator translocatorEntity && translocatorEntity.FullyRepaired))
            {
                BlockServerReversePatch.OnBlockBroken(__instance, world, pos, byPlayer, dropQuantityMultiplier);
            }
        }
    }
}