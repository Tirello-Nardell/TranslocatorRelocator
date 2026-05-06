# Translocator Relocator Fork

Translocator Relocator was originally created by **Windows98** — see the [original mod page](https://mods.vintagestory.at/show/mod/22557). Updated here for **Vintage Story 1.22**.

Mod ID: `translocatorrelocatorfork`

## What it does

Mine a fully-repaired static translocator and you'll get a Relocated Translocator block back. Place it anywhere, sneak-right-click to assign a link key, then place a second one with the same key — and you've built a custom-routed teleporter pair.

You can read the original mod's design notes on [its mod page](https://mods.vintagestory.at/show/mod/22557).

## Installation

Drop the latest release zip into your Vintage Story `Mods` folder:

| Platform | Mods folder |
|---|---|
| Windows | `%APPDATA%\VintagestoryData\Mods\` |
| Linux | `~/.config/VintagestoryData/Mods/` |
| macOS | `~/Library/Application Support/VintagestoryData/Mods/` |

Or install via the Vintage Story mod manager once it's listed there.

Required Vintage Story version: **1.22.0 or later**.

## Migrating from Windows98's 1.0.3

This fork uses a different mod ID (`translocatorrelocatorfork` instead of `translocatorrelocator`) so it can be hosted alongside the original on the mod database. To migrate:

1. Remove `translocatorrelocator` (the original) from your `Mods` folder.
2. Drop this fork's zip in.
3. Load your world.

On first load, an automatic remap runs that renames every `translocatorrelocator:relocatedtranslocator-*` block placed in your world to `translocatorrelocatorfork:relocatedtranslocator-*`. Your existing translocator placements, link keys, and pairings are preserved. The remap is tracked per-save so it only ever runs once.

## Changes from the original 1.0.3

- Compatibility with Vintage Story 1.22.2 (.NET 10 retarget; `EvolvingNatFloat` particle field became a non-nullable struct in the 1.22 API)
- `modinfo.json` dependency string parses cleanly with no startup warning
- Arrivals land one block in front of the destination instead of dead-center on its collision pad — prevents the auto-respool bug that would teleport players back a few seconds after arriving
- `Harmony.UnpatchAll` is scoped to this mod's ID so disposing the mod doesn't accidentally strip patches from unrelated mods
- `modicon.png` is now correctly packaged into the build output (the source's csproj was missing a content reference)
- One-time block remap migration for users coming from the original 1.0.3 (see above)

## Building from source

Requires:

- .NET 10 SDK
- A Vintage Story 1.22+ install

```sh
git clone https://github.com/Tirello-Nardell/TranslocatorRelocator.git
cd TranslocatorRelocator
VINTAGE_STORY="/path/to/Vintagestory" dotnet build TranslocatorRelocator/TranslocatorRelocator.csproj -c Release
```

Build output lands at `TranslocatorRelocator/bin/Release/Mods/mod/`. Zip the contents of that directory and drop the zip into your VS `Mods` folder.

## Reporting issues

For bugs in this **fork specifically** (1.22-related issues, the migration, or anything introduced by the changes listed above), open an issue on [this repo](https://github.com/Tirello-Nardell/TranslocatorRelocator/issues).

For bugs that exist in the original mod's design or behavior, please report them upstream at [Wondiws98/TranslocatorRelocator](https://github.com/Wondiws98/TranslocatorRelocator) or via the [mod page comments](https://mods.vintagestory.at/show/mod/22557).

## Credits

| Role | Author | Links |
|---|---|---|
| Original mod | **Windows98** | [mod page](https://mods.vintagestory.at/show/mod/22557) · [GitHub](https://github.com/Wondiws98/TranslocatorRelocator) |
| 1.22 fork | **Tirello** | [GitHub](https://github.com/Tirello-Nardell/TranslocatorRelocator) |

## License

MIT — see [`LICENSE`](LICENSE).
