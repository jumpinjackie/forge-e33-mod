# Cards

> Last generated: 8/12/2025 6:17:33 pm

## Abbest Cave

```

Land - Cave
{T}: Add {C}.
{4}{G}, {T}: Create a 1/1 green Nevron creature token named Abbest.
```

[card implementation](../custom/cards/a/abbest_cave.txt)

### Design Notes

 - In the game the Abbest Cave is a location where you can fight a Chromatic Abbest
 - Repurposed as a Nevron token factory land.

## Blade's Graveyard (Caves of Koilos)

> This card is a nicknamed reprint of (Caves of Koilos)
[Scryfall](https://scryfall.com/search?q=Caves of Koilos)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Boat Graveyard (Underground River)

> This card is a nicknamed reprint of (Underground River)
[Scryfall](https://scryfall.com/search?q=Underground River)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Command Tower

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Command Tower)
### Notes

 - Obligatory mana fixing land for Commander

## Crimson Forest (Karplusan Forest)

> This card is a nicknamed reprint of (Karplusan Forest)
[Scryfall](https://scryfall.com/search?q=Karplusan Forest)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Crushing Cavern

```

Land - Cave
This land enters tapped.
{T}: Add {C}.
{2}, {T}, Sacrifice Crushing Cavern: Destroy target attacking creature without flying
---
If anyone finds this journal, do not enter this cave, the Nevron inside will crush you.
- Cassandra, Expedition 45
```

[card implementation](../custom/cards/c/crushing_cavern.txt)

### Design Notes

 - In the game the Crushing Cavern is a location where the player engages in a time-limited battle with the Giant Sapling. Failing to defeat the Giant Sapling results in a crushing defeat. The journal in this area recalls a previous failed attempt at defeating the Giant Sapling.
 - Mechanically represented as Pit Trap on a land. Comes into to play tapped to give any creature already on the battlefield at least one turn to get their shot in before they become the potential kill target.
 - 29/11/2025: Increased activation cost from {1} to {2}

## Dark Gestral Arena (Battlefield Forge)

> This card is a nicknamed reprint of (Battlefield Forge)
[Scryfall](https://scryfall.com/search?q=Battlefield Forge)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Dark Shores

```

Land
As this land enters, you may reveal a Nevron card from your hand. If you don't, this land enters tapped.
{T}: Add {U} or {B}.
{T}: Add {U}{B}. Spend this mana only to cast Nevron spells or activate abilities of Nevrons. This land doesn't untap during your next untap step.
---
The starting point of Expedition 33, the final destination for most of them.
```

[card implementation](../custom/cards/d/dark_shores.txt)

### Design Notes

 - In the game this is the place where most of Expedition 33 got massacred and later in the game is a place where high-tier Nevrons are and is a great XP farming location in the late game.
 - Mechanically I went with a dimir dual with extra benefits for Nevrons.

## Endless Tower

```

Legendary Land
At the beginning of your upkeep, you may put a challenge counter on Endless Tower.
{T}: Add {C}
{T}, Remove X challenge counters from Endless Tower: You may put a Nevron creature card with mana value X from your hand onto the battlefield.
---
It's not selfish to make your own choices, sister.
- Fading Woman
```

[card implementation](../custom/cards/e/endless_tower.txt)

### Design Notes

 - In the game, the Endless Tower was a 33-battle gauntlet against Nevrons of increasing difficulty
 - Figured the best way to mechanically model this gauntlet is to have something between Aether Vial and Mercadian Lift that grows counters and can put out Nevrons of increasing size based on the number of counters.
 - We take the automatic growing counters effect of Aether Vial with the "removing counters as part of activation" part of Mercadian Lift. It would be hideously broken if we kept the Aether Vial activation as then this would be a strictly better and uncounterable Aether Vial, even if it had a Nevron-only restriction and legendary.

## Esquie's Nest

```

Legendary Land - Cave
{T}: Add one mana of any type that a land you control could produce.
{T}: Add {W}{U}{B}{R}{G}. Activate this ability only if you control a card named Soarrie, a card named Florrie, a card named Dorrie and a card named Urrie.
---
Bonjour, mes amis!
- Esquie
```

[card implementation](../custom/cards/e/esquies_nest.txt)

### Design Notes

 - In the game, this is the place where Esquie dwells.
 - Esquie's Nest visually resembles most artistic depictions of the card Reflecting Pool, so I gave it the same mana ability.
 - I've gone with making this card one of the beneficiaries of the "Urzatron" rock strategy.

## Expedition Camp

```

Land
{T}: Add {C}.
{3}, {T}: Exile target Expeditioner you control. At the beginning of the next end step, return that card to the battlefield under its owner's control. If it entered under your control and is a creature, put a +1/+1 counter on it.
---
So uh... We can rest a bit, but the moon is bright, I want to keep moving.
- Gustave
```

[card implementation](../custom/cards/e/expedition_camp.txt)

### Design Notes

 - In the game, the party can set up camp in the overworld to upgrade their equipment and replenish party health.
 - I envision this card as a "refuge" for Expeditioners ala. Safe Haven, so I've gone with a blink effect to signify the Expeditioner taking refuge and it coming back with a +1/+1 counter to signify it having ugpraded some of their equipment.
 - Intentionally worded to allow blinking of any Expeditioner *permanent*

## Falling Leaves (Yavimaya, Cradle of Growth)

> This card is a nicknamed reprint of (Yavimaya, Cradle of Growth)
[Scryfall](https://scryfall.com/search?q=Yavimaya, Cradle of Growth)
### Notes

 - In the game, Falling Leaves is an optional area gated behind coral barriers. The Scavager boss can be found here.
 - Due to its eternal autumn setting, I've gone with a nickname reprint of Yavimaya, Cradle of Growth.

## Floating Cemetery (Ominous Cemetery)

> This card is a nicknamed reprint of (Ominous Cemetery)
[Scryfall](https://scryfall.com/search?q=Ominous Cemetery)
### Notes

 - In the game, Floating Cemetery is an optional area where an Unfinished Chalier can be found.
 - Chose a nickname reprint of Ominous Cemetery just on name-basis alone.

## Flying Casino

```

Land
This land enters tapped.
{T}: Add {C}.
{1}{R}, {T}, Sacrifice this land: Search your library for a card and put it into your hand. Discard a card at random. Activate only as a sorcery.
---
I maintain this place even after its fall so its history is never forgotten.
- Unknown Gestral
```

[card implementation](../custom/cards/f/flying_casino.txt)

### Design Notes

 - In the game, the Flying Casino is a location where one can acquire an outfit for Monoco. It looks like cut content that was going to be more than what was in the final game (maybe a place to play various gambling mini-games?)
 - Mechanically, I've gone with replicating Gamble

## Flying Waters

```

Land
This land enters tapped
{T}: Add {U}.
{U}, {T}: Target creature you control gains flying until end of turn.
---
Gustave: Expedition 68. Their boat was blown into the air by a storm. Lumiere lost sight of it but assumed they crashed on the continent.
Lune: And they survived. The storm, at least.
```

[card implementation](../custom/cards/f/flying_waters.txt)

### Design Notes

 - In the game, Flying Waters is one of the early dungeons with a heavy water/nautical theme
 - Mechanically this clearly is a land that should tap for blue mana. Gave it a flying granting ability just because of the name.

## Forgotten Battlefield

```

Legendary Land
{T}: Add {C}.
{1}{B}, {T}: Put target Nevron card from your graveyard on top of your library.
---
These siege engines seemed much more powerful in Lumiere. But on this battlefield, next to all these broken bodies, staring at the true size of the monolith, I feel despair.
- Carla, Expedition 57
```

[card implementation](../custom/cards/f/forgotten_battlefield.txt)

### Design Notes

 - In the game, the Forgotten Battlefield is one of the areas the Expedition 33 crew must traverse to reach Monoco's Station.
 - Volrath's Stronghold for Nevrons

## Frozen Hearts (Shivan Reef)

> This card is a nicknamed reprint of (Shivan Reef)
[Scryfall](https://scryfall.com/search?q=Shivan Reef)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Gestral Arena

```

Land
{T}: Add {C}.
{1}{R/G}, {T}: Target Gestral creature you control fights another target creature
---
Gestral Announcer: Hey humans! We’re here to see some fighting. If you don’t wanna fight, we’ll come down and fight ourselves!
Sciel: They’re expecting a bit of a show. Shall we?
```

[card implementation](../custom/cards/g/gestral_arena.txt)

### Design Notes

 - In the game, the Gestral Village has an arena where Gestrals fight. Sciel was discovered to be competing here.
 - Gestral loves to fight. So naturally a Gestral Arena should have an ability that lets a Gestral fight someone else.

## Gestral Beach

```

Land
{T}: Add {C}.
Cycling {2} ({2}, Discard this card: Draw a card.)
```

[card implementation](../custom/cards/g/gestral_beach.txt)

### Design Notes

 - In the game, various Gestral beaches in the continent are home to various challenge mini-games.
 - Origially I wanted a cheaper cycling 1 ability if you control a Gestral, but I don't think Forge supports multiple cycling abilities as it is keyworded, so I can't attach conditions to a keyworded ability.

## Gestral Village

```

Land - Town
{T}: Add {C}.
{T}: Add {C}{C}. Spend this mana only to cast Gestral spells or activate abilities of Gestrals.
---
Lune: It's ... it's really a village of Gestrals!
Gustave: They seem better at surviving than humans.
```

[card implementation](../custom/cards/g/gestral_village.txt)

### Design Notes

 - In the game, this is the home of the Gestrals.
 - A sol land for Gestral tribal decks. Due to their artifact nature, Gestrals are significantly easier to cast (unlike Eldrazi which require explicit coloress-pip producing lands), so where applicable, costs have increased, but this card is a bone thrown to to this deck to allow for some acceleration.

## Lost Woods (Llanowar Wastes)

> This card is a nicknamed reprint of (Llanowar Wastes)
[Scryfall](https://scryfall.com/search?q=Llanowar Wastes)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Lumiere Aquafarm

```

Land
This land enters tapped unless you control an Expeditioner.
{T}: Add {W} or {U}.
{4}, {T}: Create a Food token.
---
The Aquafarm project ensured that Lumiere would have a plentiful supply of food for years to come.
```

[card implementation](../custom/cards/l/lumiere_aquafarm.txt)

### Design Notes

 - In the game, Gustave lead the Aquafarm project which ensured the food supply for the city of Lumiere.
 - This gives us an opportunity to add another dual land to this set.
 - Obviously expeditioner aligned so they get a ETB tapped sidestep.
 - It's a farm so obviously needs a Food token generating ability.

## Lumiere Opera House

```

Land
At the beginning of your upkeep, you may put a verse counter on this land.
{T}: Add {C}.
{T}, Remove two verse counters from this land: Expeditioner creatures you control get +1/+1 until end of turn.
---
Maybe when this is over, we can fix up the opera house and you can perform for us. I want my first concert to be yours. And don't worry, I'll make sure the room is packed. I'll put up posters everywhere in town.
- Maelle
```

[card implementation](../custom/cards/l/lumiere_opera_house.txt)

### Design Notes

 - In the game, in Maelle's ending. Verso plays piano at the Lumiere Opera House (forever and ever?)
 - Mechanically speaking, music generally translates to creature buffs (see almost any "Anthem" card printed), so I went with a land that grows verse counters that can be spent to momentarily buff your force.

## Lumiere, The Last Bastion

```

Legendary Land - Town
{T}: Add {W}.
{1}{W}, {T}: Create a 1/1 white Human Expeditioner token with "When this creature dies, create a Chroma token."
{1}{W}, {T}: Create a Map token
---
Every year, the population dwindles, yet the citizens persist in their determination to take down the Paintress once and for all.
```

[card implementation](../custom/cards/l/lumiere_the_last_bastion.txt)

### Design Notes

 - In the game, Lumiere is the city where the humans live. It is also the last bastion of human civilization that is slowly dying each year with the yearly Gommages, hence the sub-title.
 - Mechanically, modeled on Kjeldoran Outpost but produces Human Expeditioner tokens instead of Soldiers
 - To go with the Expedition/Exploration theme, this land also makes map tokens.

## Manor Gardens

```

Land
This land enters tapped.
{T}: Add {G}.
{T}, Sacrifice this land: Search your library for a Room card, reveal it, put it into your hand, then shuffle.
```

[card implementation](../custom/cards/m/manor_gardens.txt)

### Design Notes

 - In the game, the Manor Gardens is outside of the Manor entrance.
 - Gardens > Green mana
 - Since everything Manor-related has a room sub-theme, this land also acts as a room tutor.

## Monoco's Station

```

Land
{T}: Add {C}.
{T}: Add {U} or {R}. Activate this ability only if you control a Gestral or Grandis.
---
The Grandis have embraced us with such warmth and hope. What a balm for the soul to know that other beings survived, that we in Lumiere are not alone! It truly is a miracle.
- Aurelien, Expedition 65
```

[card implementation](../custom/cards/m/monocos_station.txt)

### Design Notes

 - In the game, Monoco's Station is situated in an icy and mountainous region of the continent.
 - Therefore this should clearly be a blue/red dual land.
 - Since it's occupied by Monoco (a Gestral) and various Grandis creatures. They get the no-strings-attached dual land experience.
 - 29/11/2025: Dropped the secondary dual mana ability (to eliminate potential confusion in paper) and downshift to Uncommon

## Painted Bluffs

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Painted Bluffs)
### Notes

 - Has "Painted" in its name, color fixes. Easy on-flavor reprint candidate.

## Sinister Cave (Sulfurous Springs)

> This card is a nicknamed reprint of (Sulfurous Springs)
[Scryfall](https://scryfall.com/search?q=Sulfurous Springs)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Sirene's Coliseum

```

Land
This land enters tapped unless you control a Nevron or Painter.
{T}: Add {C}
{T}: Add one mana of any color. This land deals 1 damage to you.
---
Maybe. Maybe we'll just stay here and... enjoy the melody.
- Luc, Expedition 67
```

[card implementation](../custom/cards/s/sirenes_coliseum.txt)

### Design Notes

 - In the game, this is the home of Sirene, one of the Axons.
 - Modelled on Grand Coliseum with drawbacks removed if you are Nevron/Painter aligned.

## Sky Island (Yavimaya Coast)

> This card is a nicknamed reprint of (Yavimaya Coast)
[Scryfall](https://scryfall.com/search?q=Yavimaya Coast)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Spring Meadows (Razorverge Thicket)

> This card is a nicknamed reprint of (Razorverge Thicket)
[Scryfall](https://scryfall.com/search?q=Razorverge Thicket)
### Notes

 - In the game, Spring Meadows is the opening area of Act 1.
 - Gone with nickname reprint of Razorverge Thicket.

## Stone Quarry

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Stone Quarry)
### Notes

 - In the game, Stone Quarry is an optional area. It features a non-hostile NPC known as the Unfinished Troubador
 - Name was already taken, and we lack a Boros dual land, so we'll take it.

## Stone Wave Cliffs (Stormcarved Coast)

> This card is a nicknamed reprint of (Stormcarved Coast)
[Scryfall](https://scryfall.com/search?q=Stormcarved Coast)
### Notes

 - In the game, a Stone Wave Cliffs is the final area of Act 1.
 - Gone with nickname reprint of Stormcarved Coast.

## Sunless Cliffs (Blackcleave Cliffs)

> This card is a nicknamed reprint of (Blackcleave Cliffs)
[Scryfall](https://scryfall.com/search?q=Blackcleave Cliffs)
### Notes

 - In the game, a Sunless Cliffs is an optional area. It features a battle against a special mime.
 - Gone with nickname reprint of Blackleave Cliffs

## The Hauler

```

Legendary Land
{T}: Add {C}.
{T}: Add one mana of any color. The Hauler does not untap during your next untap step.
{7}: The Hauler becomes an 8/8 Axon colorless creature with Trample until end of turn. It's still a land.
```

[card implementation](../custom/cards/t/the_hauler.txt)

### Design Notes

 - In the game, The Hauler is one of the four Axons created by Renoir. The Hauler represents Clea and has an entire city on its back, symbolizing the burden of family affairs being carried by Clea. The Hauler was killed by Simon.
 - Obviously mechanically maps to being a man-land. Given the legendary and epic nature of Axons, it clearly must animate into something big and monstrous.

## The Indigo Tree (The World Tree)

> This card is a nicknamed reprint of (The World Tree)
[Scryfall](https://scryfall.com/search?q=The World Tree)
### Notes

 - In the game, The Indigo Tree was the rallying point for Expedition 33 if party members got split off.
 - Chose a nickname reprint of The World Tree as its God tutoring ability has some relevance in this set.

## The Meadows (Brushland)

> This card is a nicknamed reprint of (Brushland)
[Scryfall](https://scryfall.com/search?q=Brushland)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## The Monolith

```

Legendary Land
The Monolith enters with ten gommage counters.
At the beginning of your upkeep, remove a gommage counter, then exile all non-land, non-legendary permanents with mana value greater than or equal to the number of gommage counters on The Monolith.
When The Monolith has no gommage counters on it, sacrifice it.
{T}: Add {C}
```

[card implementation](../custom/cards/t/the_monolith.txt)

### Design Notes

 - In the game, The Monolith is where The Paintress resides and is an everlasting reminder to the humans of Lumiere that time is running out.
 - For lore accuracy, this would've been 100 counters instead of 10, but that simply takes way too long in MTG "game time". A game is lucky to reach 50 turns, let alone 100! Reducing it to 10 sacrifices lore accuracy, but retains mechanical accuracy of something that's constantly counting down and wiping out everything older than that number.

## The Monolith Interior

```

Land
You may have this land enter tapped as a copy of any land on the battlefield, except it has "At the beginning of your upkeep, you may have this land become a copy of target land, and it has this ability."
---
It bears the twisted memories of lands previously visited.
```

[card implementation](../custom/cards/t/the_monolith_interior.txt)

### Design Notes

 - In the game, the interior of The Monolith contains twisted variations of locations visited by Expedition 33
 - Basically a Vesuvan Doppelganger for lands. Meant to mechanically capture the memories of places visited by Expedition 33
 - I am hoping I can copy Vesuvan Doppelganger for the most part and change the targeting parameters from creatures to lands.
 - 5/10/2025: It works!
 - May change targeting to only non-basic lands to curb power level if required.

## The Reacher

```

Legendary Land Creature - Axon
Trample. Reach.
The Reacher enters with seven sky counters.
The Reacher cannot attack or block while it has one or more sky counters.
Whenever a creature with flying enters or attacks, remove a sky counter from The Reacher.
{T}: Add {G} or {U}.
{2/U}: Remove a sky counter from The Reacher.
---
Little one, there's more to life, if you can just see how big the sky truly is. Reach out your hand, and it's yours...

8/8
```

[card implementation](../custom/cards/t/the_reacher.txt)

### Design Notes

 - In the game, The Reacher is an Act 3 dungeon. It is also one of the four Axons created by Renoir and represents Alicia.
 - The Reacher is a landmark, but also an Axon. So in MTG terms, it's both a land and a creature.
 - To make something uniquely different from The Hauler (which is a man-land). I've gone with a legendary land creature, following the pattern of Dryad Arbor.
 - Now how do we balance out an 8/8 trampling uncounterable Axon that could drop on turn 1? We take a page out of Dark Depths and have this ETB with 7 sky counters. While it has sky counters, it cannot attack or block and is effectively dormant as a creature. You can still use it as a regular U/G dual land until you've remove the last sky counter.

## The Sacred River

```

Legendary Land
{T}: Add {C}.
{5}, {T}: Return target Gestral card from your graveyard and put it into your hand. This ability costs {2} less to activate if you control a creature named Golgra, Gestral Chief
---
MONOCO! You're trying to skip the queue again you old... uh... old... lazy... retired warrior!
- Golgra
```

[card implementation](../custom/cards/t/the_sacred_river.txt)

### Design Notes

 - In the game, the Sacred River is a place where Gestrals can be resurrected.
 - Per game lore and rules established by Golgra, you need to be "in a queue" to get a Gestral resurrection, but if you're in favor with Golgra you could get a discount and "jump the queue". So I've gone with a regrowth ability with a discount if you have Golgra on the battlefield.

## Twilight Quarry

```

Land
This land enters tapped. As it enters, choose a color.
{T}: Add one mana of the chosen color.
```

[card implementation](../custom/cards/t/twilight_quarry.txt)

### Design Notes

 - In the game, the Twilight Quarry is an area where a collectible record can be found
 - Another land to provide mana fixing

## Visages // He Who Guards Truth With Lies

```

Legendary Land
{T}: Add {C}
{2}{R}, {T}: Put a Seething counter on this land.
{3}{W}, {T}: Put a Jovial counter on this land.
{4}{B}, {T}: Put a Sorrowful counter on this land.
Remove a Seething, Jovial and Sorrowful counter from this land: Transform this land.

6/6
```

Transforms into:

```

Legendary Creature - Axon
Ward {3}
Determination Mask — {2}{B}: Choose target card in your graveyard. You may play it this turn. If that card would be put into a graveyard, exile it instead.
Doubt Mask — {2}{U}: Tap target creature.
Peace Mask — {2}{W}: Target creature cannot attack this turn.
Anxiety Mask — {2}{R}: Target creature cannot block this turn.

8/8
```

[card implementation](../custom/cards/v/visages_he_who_guards_truth_with_lies.txt)

### Design Notes

 - In the game, Visages is an Axon. It is one of two Axons that must be defeated in order to assemble enough Chroma for The Curator to forge the Barrier Breaker weapon to breach the Monolith barrier. It is both a location and boss encounter. Players must defeat three primary masks (Jovial, Seething, Sorrowful) to weaken Visages.
 - In line with other Axons not named Sirene, because it is both a boss and a landmark I want to weave both land and creature aspects. In this case I've gone with a land that transforms into its Axon creature counterpart.
 - Seething/Jovial/Sorrowful counter transformation condition approximates defeating the three primary masks before facing the Axon.

## White Sands (Adarkar Wastes)

> This card is a nicknamed reprint of (Adarkar Wastes)
[Scryfall](https://scryfall.com/search?q=Adarkar Wastes)
### Notes

 - Nicknamed painland reprint to flesh out commander mana bases

## Yellow Harvest (Copperline Gorge)

> This card is a nicknamed reprint of (Copperline Gorge)
[Scryfall](https://scryfall.com/search?q=Copperline Gorge)
### Notes

 - In the game, Yellow Harvest is an optional area.
 - Went with a nickname reprint of Copperline Gorge 

