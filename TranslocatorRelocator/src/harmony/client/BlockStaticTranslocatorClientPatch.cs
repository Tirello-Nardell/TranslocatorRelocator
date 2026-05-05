using System.Runtime.CompilerServices;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using HarmonyLib;
using Newtonsoft.Json;
using Vintagestory.API.Config;

namespace TranslocatorRelocator.src.harmony.client
{
    [HarmonyPatchCategory(Core.ClientPatchCategory)]
    [HarmonyPatch(typeof(BlockStaticTranslocator), "GetPlacedBlockInfo")]
    class BlockStaticTranslocatorClientPatch
    {
        public static bool Prefix(BlockStaticTranslocator __instance, ref string __result, IWorldAccessor world, BlockPos pos, IPlayer forPlayer)
        {
            BlockEntity blockEntity = world.BlockAccessor.GetBlockEntity(pos);
            if (blockEntity is BlockEntityStaticTranslocator translocatorEntity && !translocatorEntity.FullyRepaired)
            {
                __result = Lang.Get("Seems to be missing a couple of gears. I think I've seen such gears before.");
                return false;
            }
            return true;
        }
    }
}