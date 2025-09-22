# Cards

## Crushing Cavern

```
Land

This land enters tapped.
{T}: Add {C}.
{1},{T},Sacrifice Crushing Cavern: Destroy target attacking creature without flying
```

[card implementation](/custom/cards/c/crushing_cavern.txt)

### Design Notes

 - In the game the Crushing Cavern is a location where the player engages in a time-limited battle with the Giant Sapling. Failing to defeat the Giant Sapling results in a crushing defeat. The journal in this area recalls a previous failed attempt at defeating the Giant Sapling.
 - Mechanically represented as Pit Trap on a land. Comes into to play tapped to give any creature already on the battlefield at least one turn to get their shot in before they become the potential kill target.

## Dark Shores

```
Land
As this land enters, you may reveal a Nevron card from your hand. If you don't this land enters tapped.
{T}: Add {U} or {B}.
{T}: Add {U}{B}. This land doesn't untap during your next untap step. Activate this ability only if you control a Nevron.
```

[card implementation](/custom/cards/d/dark_shores.txt)

### Design Notes

 - In the game this is the place where most of Expedition 33 got massacred and later in the game is a place where high-tier Nevrons are and is a great XP farming location in the late game.
 - Mechanically I went with a dimir dual with extra benefits for Nevrons.
 - Currently has some bugs, see BUGS.md

## Endless Tower

```
Legendary Land
At the beginning of your upkeep, you may put a challenge counter on this card.
{T}: Add {C}.
{T}, Remove X challenge counters from this card: You may put a Nevron permanent card with mana value X from your hand onto the battlefield.
```

[card implementation](/custom/cards/zDevelopment/endless_tower.txt)

### Design Notes

 - In the game, the Endless Tower was a 33-battle gauntlet against Nevrons of increasing difficulty
 - Figured the best way to mechanically model this gauntlet is to have something between Aether Vial and Mercadian Lift that grows counters and can put out Nevrons of increasing size based on the number of counters. 
 - We take the automatic growing counters effect of Aether Vial with the "removing counters as part of activation" part of Mercadian Lift. It would be hideously broken if we kept the Aether Vial activation as then this would be a strictly better and uncounterable Aether Vial, even if it had a Nevron-only restriction and legendary.
 - Currently not working as intended. See BUGS.md

## Esquie's Nest

```
Legendary Land - Cave
{T}: Add one mana of any type that a land you control could produce.
{T}: Add {W}{U}{B}{R}{G}. Activate this ability only if you control a card named Soarrie, a card named Florrie, a card named Dorrie and a card named Urrie.
```

[card implementation](/custom/cards/e/esquies_nest.txt)

### Design Notes

 - In the game, this is the place where Esquie dwells.
 - I've gone with making this card one of the beneficiaries of the "Urzatron" rock strategy.

## Flying Casino

```
This land enters tapped.
{T}: Add {C}.
{1}{R},{T},Sacrifice this land: Search your library for a card and put it into your hand. Discard a card at random. Activate only as a sorcery.
```

[card implementation](/custom/cards/f/flying_casino.txt)

### Design Notes

 - In the game, the Flying Casino is a location where one can acquire an outfit for Monoco. It looks like cut content that was going to me more than what was in the final game (maybe a place to play various gambling mini-games?)
 - Mechanically, I've gone with replicating Gamble

## Flying Waters

```
Land
This land enters tapped
{T}: Add {U}.
{U},{T}: Target creature you control gains flying until end of turn.
```

[card implementation](/custom/cards/f/flying_waters.txt)

### Design Notes

 - In the game, Flying Waters is one of the early dungeons with a heavy water/nautical theme
 - Mechanically this clearly is a land that should tap for blue mana. Gave it a flying granting ability just because of the name.

## Forgotten Battlefield

```
Legendary Land
{T}: Add {C}.
{1}{B}, {T}: Put target Nevron card from your graveyard on top of your library.
```

[card implementation](/custom/cards/f/forgotten_battlefield.txt)

### Design Notes

 - Volrath's Stronghold for Nevrons

## Gestral Arena

```
Land
{T}: Add {C}.
{1},{R/G},{T}: Target Gestral creature you control fights another target creature
```

[card implementation](/custom/cards/g/gestral_arena.txt)

### Design Notes

 - Gestral loves to fight. So naturally a Gestral Arena should have an ability that lets a Gestral fight someone else.

## Gestral Beach

```
Land
{T}: Add {C}.
Cycling {2} ({2}, Discard this card: Draw a card.)
```

[card implementation](/custom/cards/g/gestral_beach.txt)

### Design Notes

 - Origially I wanted a cheaper cycling 1 ability if you control a Gestral, but I don't think Forge supports multiple cycling abilities as it is keyworded, so I can't attach conditions to a keyworded ability.

## Gestral Village

```
Land - Town
{T}: Add {C}.
{T}: Add {C}{C}. Spend this mana only to cast Gestral spells or activate abilities of Gestrals.
```

[card implementation](/custom/cards/g/gestral_village.txt)

### Design Notes

 - A sol land for Gestral tribal decks. Due to their artifact nature, Gestrals are significantly easier to cast (unlike Eldrazi which require explicit coloress-pip producing lands), so where applicable, costs have increased, but this card is a bone thrown to to this deck to allow for some acceleration.

## Lumiere, The Last Bastion

```
Legendary Land - Town
{T}: Add {W}
{1}{W},{T}: Create a 1/1 White Human Expeditioner token with "When this creature dies, create a Chroma token"
{1}{W},{T}: Create a Map token
```

[card implementation](/custom/cards/l/lumiere_the_last_bastion.txt)

### Design Notes

 - In the game, Lumiere is the city where the humans live. It is the last bastion of human civilization that is slowly dying each year with the yearly Gommages.
 - Mechanically, modeled on Kjeldoran Outpost but produces Human Expeditioner tokens instead of Soldiers
 - To go with the Expedition/Exploration theme, this land also makes map tokens.

## Monoco's Station

```
Land
{T}: Add {C}.
{T}: Add {U} or {R}. Activate this ability only if you control a Gestral or Grandis.
{T}: Add {U} or {R}. This land doesn't untap during your next untap step
```

[card implementation](/custom/cards/m/monocos_station.txt)

### Design Notes

 - In the game, Monoco's Station is situated in an Icy Mountainous region of the continent.
 - Therefore this should clearly be a blue/red dual land.
 - Since it's occupied by Monoco (a Gestral) and various Grandis creatures. They get the no-strings-attached dual land experience.

## The Monolith

```
Legendary Land
The Monolith enters with 10 gommage counters.
At the beginning of your upkeep, remove a gommage counter, then exile all non-land, non-legendary permanents with mana value greater than or equal to the number of gommage counters on The Monolith.
When The Monolith has no gommage counters on it, sacrifice it.
{T}: Add {C}
```

[card implementation](/custom/cards/t/the_monolith.txt)

### Design Notes

 - For lore accuracy, this would've been 100 counters instead of 10, but that would take way too long in MTG "game time". Reducing it to 10 sacrifices lore accuracy, but retains mechanical accuracy of something that's constantly counting down and wiping out everything older than that number.

## Twilight Quarry

```
Land
This land enters tapped. As it enters, choose a color.
{T}: Add one mana of the chosen color.
```

[card implementation](/custom/cards/t/twilight_quarry.txt)

### Design Notes

 - Another land to provide mana fixing