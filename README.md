# forge-e33-mod

This a mod for [Forge](https://github.com/Card-Forge/forge) and a custom set for [Cockatrice](https://cockatrice.github.io/) based on the video game [Clair Obscur: Expedition 33](https://store.steampowered.com/app/1903340/Clair_Obscur_Expedition_33/).

This mod is multi-faceted and consists of:

 * [Current Focus] A new custom expansion set for Forge and Cockatrice with cards inspired by the lore, story, flavor, characters and mechanics from the video game.
 * A music mod for Forge to replace the built-in menu/battle music with a curated selection of tracks from the video game OST. Basically streamlining [these instructions](https://gist.github.com/jumpinjackie/a1e2ee5c7da29bf444b0e76870ad1f97)
 * [Maybe in the future, if I'm still motivated] A custom [Forge quest mode](https://github.com/Card-Forge/forge?tab=readme-ov-file#-quest-modes) focused solely on the enemies and bosses of Expedition 33 with decks only from this custom set.
 * [In the long distant future maybe, if I'm really really motivated] A custom [Forge adventure mode](https://github.com/Card-Forge/forge?tab=readme-ov-file#-adventure-mode) plane focused solely on the world, enemies and bosses of Expedition 33 with decks only from this custom set.

# Installing (for Forge)

> Forge is only recommended for playing against AI opponents. My attempts to get Forge multiplayer working have been absolute failures. Cockatrice is the recommended app if you want multiplayer magic with this set.

## From source

> NOTE: You will need to have the .net SDK 9.0 or higher installed as both scripts will be building the CardProcess pre-processor tool.

1. Install forge (latest stable or snapshot release)
2. Git clone this repo
3. Run the `build.bat` (Windows) or `build.sh` (Linux) script to build and deploy the custom set assets into your Forge application data directory. Based on your OS, this will be:
   - Windows: `%APPDATA%\Forge`
   - Linux: `~/.forge`
   - OSX: TBD
4. (OPTIONAL) If you want to run custom cube drafts with this set, copy the following files
   - `custom/dist/forge/E33_Cube.dck` to `$YOUR_FORGE_INSTALL/res/cube/`
   - `custom/dist/forge/E33_Cube.draft` to `$YOUR_FORGE_INSTALL/res/draft/`
5. Start Forge

## From release assets

1. For the relevant release, download the `forge_assets.zip` and `forge_pics.zip` files
2. Extract the contents of `forge_assets.zip` into your custom data directory. This is:
   - Windows: `%APPDATA%\Forge\custom`
   - Linux: `~/.forge/custom`
   - OSX: TBD
3. Extract the contents of `forge_pics.zip` into your custom images directory. This is:
   - Windows: `%LOCALAPPDATA%\Forge\Cache\pics`
   - Linux: `~/.cache/pics`
   - OSX: TBD
4. (OPTIONAL) If you want to run custom cube drafts with this set, download:
   - `E33_Cube.dck` to `$YOUR_FORGE_INSTALL/res/cube/`
   - `E33_Cube.draft` to `$YOUR_FORGE_INSTALL/res/draft/`
5. Start Forge

## After installation

1. In the Deck Editor, to see the cards in this set, change the set filter (the magnifying glass) to only include custom sets, or search for `Set:E33` or `Set:E3C`
![screenshot](screenshot.png)
2. Start building decks with these new cards and have fun with some AI opponents!
![commander battle](screenshot_battle.png)

If you want to run a custom cube draft with this set, assuming you installed the `E33_Cube.dck` and `E33_Cube.draft` files to the correct directories, follow [these instructions](docs/FORGE_CUBE.md)

# Installing (for Cockatrice)

## From source

> NOTE: You will need to have the .net SDK 9.0 or higher installed as both scripts will be building the CardProcess pre-processor tool.

1. Install Cockatrice
2. Git clone this repo
3. Run `build.sh`. The Cockatrice assets will be under `custom/dist/cockatrice`
4. In Cockatrice, select `Card Database - Add custom sets/cards` and select the `custom/dist/cockatrice/E33.xml` file.

## From release assets

1. For the relevant release, download the `Expedition33.xml` file.
2. In Cockatrice, select `Card Database - Add custom sets/cards` and select the `Expedition33.xml` file you downloaded.

# Set overview

> IMPORTANT: This set is in the process of development. It has not received any stringent playtesting, expect broken stuff, expect underpowered stuff, expect unintended interactions and everything in between!

To see what cards are in this set, check out the various design docs which detail every card and the design motivation behind them.

> SPOILER ALERT: Plot and character spoilers galore when discussing design motivations for most cards. If you don't want to be spoiled, perhaps play through and finish the video game first and come back later :-)

 * [Artifacts](/design/ARTIFACTS.md)
 * [Black](/design/BLACK.md)
 * [Blue](/design/BLUE.md)
 * [Colorless](/design/COLORLESS.md)
 * [Green](/design/GREEN.md)
 * [Lands](/design/LANDS.md)
 * [Multi-color](/design/MULTICOLOR.md)
 * [Red](/design/RED.md)
 * [White](/design/WHITE.md)
 * [Card Name List](/design/CARDLIST.md)
 * [Visual Spoiler](/design/SPOILER.md)

# Other design notes

 * [Design Goals](/design/GOALS.md)
 * [Set Mechanics](/design/MECHANICS.md)
 * [Deck Archetypes](/design/ARCHETYPES.md)

# Known issues

 * [Current List](/design/BUGS.md)