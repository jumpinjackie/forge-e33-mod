# Cards

## Chroma Filter

```
2
Artifact
When this artifact enters, draw a card.
{1}, {T}: Add one mana of any color.
{T}, Sacrifice a Chroma token: Add two mana of any one color.
```

[card implementation](/custom/cards/c/chroma_filter.txt)

### Design Notes

 - Just an artifact to provide color fixing and some minor ramp if you hava Chroma tokens to spare.

## Dorrie

```
1
Legendary Artifact - Rock
{T}: Target creature you control gains Trample until end of turn.
{1},Sacrifice Dorrie: Draw a card.
```

[card implementation](/custom/cards/d/dorrie.txt)

### Design Notes

 - In the game Dorrie is a quest item which will grant Esquie the ability to smash through coral barriers when swimming in the Continent overworld
 - In this set, Dorrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, Trample is the closet ability to "smashing through coral barriers"

## Energy Tint

```
2
Artifact
{T}: Add {C}
{T}: Add {C}{C}{C}. Activate this ability only if you control at least 3 Lumina tokens
```

[card implementation](/custom/cards/e/energy_tint.txt)

### Design Notes

 - Just a mana rock for this set
 - Yes it may look dangerous to have a Grim Monolith with no downside, but you need some Lumina token investment first to take advantage, so there is some setup involved. The ideal turn 1 An Advantage!, turn 2 Energy Tint line is something I can accept as variance.

## Expedition Cache

```
2
Artifact
{T},Sacrifice this artifact: Create 2 Lumina tokens.
{T},Sacrifice this artifact: Create 2 Chroma tokens.
```

[card implementation](/custom/cards/e/expedition_cache.txt)

### Design Notes

 - Just an enabler for Lumina/Chroma token strategies

## Florrie

```
1
Legendary Artifact - Rock
{T}: Target creature you control gains Islandwalk until end of turn.
{1},Sacrifice Florrie: Draw a card.
```

[card implementation](/custom/cards/f/florrie.txt)

### Design Notes

 - In the game Florrie is a quest item which will grant Esquie the ability to swim in the Continent overworld
 - In this set, Florrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, Islandwalk is the closet ability to swimming

## Gestral Fighter

```
2
Artifact Creature - Gestral
Whenever this creature attacks, it gets +2/+0 until end of turn for each other attacking Gestral.
1/2
```

[card implementation](/custom/cards/g/gestral_fighter.txt)

### Design Notes

 - The Gestral version of Goblin Piledriver. If we want a viable Gestral tribal deck, it needs a "heavy hitter". This is the heavy hitter.
 - May increase cost to 3 in the future.

## Gestral Lackey

```
1
Artifact Creature - Gestral
Whenever Gestral Lackey deals damage to a player, you may put a Gestral permanent card from your hand onto the battlefield.
```

[card implementation](/custom/cards/g/gestral_lackey.txt)

### Design Notes

 - The Gestral version of Goblin Lackey

## Gestral Merchant

```
3
Artifact Creature - Gestral
Whenever this creature is dealt damage, create that many Chroma tokens

2/3
```

[card implementation](/custom/cards/g/gestral_merchant.txt)

### Design Notes

 - In the game, Gestral Merchants sell you various items. You can fight them to unlock additional items upon defeat
 - Mechanically, I went with rewarding you with Chroma tokens when it is dealt damage
 - Currently has a bug where it can be overkilled. See BUGS.md

## Gestral Ringleader

```
5
Artifact Creature - Gestral
Haste (This creature can attack and {T} as soon as it comes under your control.)
When this creature enters, reveal the top four cards of your library. Put all Gestral cards revealed this way into your hand and the rest on the bottom of your library in any order.
```

[card implementation](/custom/cards/g/gestral_ringleader.txt)

### Design Notes

 - Gestral version of Goblin Ringleader. A Gestral tribal deck needs at least one card that can provide raw card advantage. This is that card.

## Gestral Statue

```
2
Artifact
This card enters tapped.
{T}: Add {C}.
{2}: This card becomes a 2/2 Gestral artifact creature until end of turn.
```

[card implementation](/custom/cards/g/gestral_statue.txt)

### Design Notes

 - Gestral version of Guardian Idol.
 - A mana rock to support the Gestral tribal strategy, while providing some extra offensive punch if required.

## Gestral Villager

```
2
Artifact Creature - Gestral
2/1
```

[card implementation](/custom/cards/g/gestral_villager.txt)

### Design Notes

 - Just a vanilla Gestral to round out a Gestral tribal deck and to round out the creature roster for draft/limited

## Gustave's Journal

```
4
Legendary Artifact
Whenever a Nevron dies, put a study counter on Gustave's Journal.
{2},{T},Remove X study counters from Gustave's Journal: Draw X cards
```

[card implementation](/custom/cards/g/gustaves_journal.txt)

### Design Notes

 - In the game, whenever at camp Gustave (and later Maelle) writes down his experiences in his expedition thus far. It has been said (and lamented by many gamers) that this should have been represented as an in-game bestiary of all the Nevrons you have encountered.
 - Mechanically, I went with an artifact that charges up with every Nevron kill, that can be cashed in later down the road for extra cards.

## Health Tint

```
2
Artifact
Sacrifice this artifact: You gain 5 life.
Sacrifice this artifact: You gain 10 life. Activate this ability only if you control at least 3 Lumina tokens.
```

[card implementation](/custom/cards/h/health_tint.txt)

### Design Notes

 - Another enabler for Lumina token strategies

## Limonsol, Matchmaker

```
3
Legendary Artifact Creature - Gestral
{2},{T}: Target Gestral you control fights another target creature. (Each deals damage equal to its power to the other.)

2/2
```

[card implementation](/custom/cards/l/limonsol_matchmaker.txt)

### Design Notes

 - In the game, Limonsol sets up fights in the Gestral Arena
 - Mechanically, I just repeated Gestral Arena and gave him a fight ability

## Lorieniso, Gestral Musician

```
3
Legendary Artifact Creature - Gestral Bard
At the beginning of your upkeep, you may put a verse counter on Lorieniso.
{2},{T}: Search your library for a Gestral card with mana value X or less and put it into your hand, where X is the number of verse counters on this creature.

1/3
```

[card implementation](/custom/cards/l/lorieniso_gestral_musician.txt)

### Design Notes

 - This is the Gestral's Goblin Matron / Gestral Tutor. Adapted from Yisan, the Wanderer Bard
 - 20/09/2025: Initial playtesting shows this is quite broken in multiples. Made into a legendary creature and changed P/T to 1/3

## Lost Gestral

```
1
Artifact Creature - Gestral
When this creature enters, if you control a card named Sastro, the Concerned, create 2 Chroma tokens.
Whenever this creature becomes the target of a spell or ability an opponent controls, put this creature on the bottom of its owner's library.

1/1
```

[card implementation](/custom/cards/l/lost_gestral.txt)

### Design Notes

 - In the game, there is a side-quest where you have to find a bunch of Lost Gestrals and return them to Sastro. Every Lost Gestral you find and return to Sastro gives you rewards. For the first ability I went with rewarding the player with Chroma tokens if Sastro is in play when a Lost Gestral enters as a mechanical analogy to this side quest.
 - The second ability was taken from Fblthp, the Lost to mechanically explain why these Gestrals keep getting lost.
 - The chroma granting ability seems bugged atm. See BUGS.md

## Lumina Converter

```
2
Artifact
{T}, Remove a counter from a permanent you control: Create a Lumina token.
{T}, Sacrifice a Chroma token: Create a Lumina token.
{T}, Sacrifice a Nevron: Create a Lumina token.
```

[card implementation](/custom/cards/l/lumina_converter.txt)

### Design Notes

 - Utility artifact to support a Lumina token strategy. Inspired by Power Conduit.

## Matthieu, The Colossus

```
7
Legendary Artifact Creature - Gestral
Trample. Menace.
Matthieu does not untap during your untap step.
Tap 3 creatures you control: Untap Matthieu.

8/8
```

[card implementation](/custom/cards/m/matthieu_the_colossus.txt)

### Design Notes

 - Has the word "Colossus" in its name, so therefore it's the big fatty Gestral of the set.
 - Modeled mostly on Phyrexian Colossus, but with Trample, downgraded Super-Menace to Menace and changed the untap cost to tapping 3 other creatures instead of life payment.
 - Yes, it can be Lackey'd out, but I can accept the variance on that line and also needing 3 other creatures to untap it will keep this strategy grounded.

## Sastro, the Concerned

```
4
Legendary Artifact Creature - Gestral
When Sastro enters, put 2 1/1 Gestral artifact creature tokens into play.

2/2
```

[card implementation](/custom/cards/s/sastro_the_concerned.txt)

### Design Notes

 - This is the Gestral (Siege-Gang Commander / Deranged Hermit)
 - Should have one more ability at least. Further abilities TBD.

## Soarrie

```
1
Legendary Artifact - Rock
{T}: Target creature you control gains flying until end of turn.
{1},Sacrifice Soarrie: Draw a card.
```

[card implementation](/custom/cards/s/soarrie.txt)

### Design Notes

 - In the game Soarrie is a quest item which will grant Esquie the ability to fly
 - In this set, Soarrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, Flying maps to ... Flying! (duh!)

## The World Canvas

```
4
Legendary Artifact
{T}: Add 3 mana of any one color. Spend this mana only to cast a Nevron, Gestral, Painter, Expeditioner or Picto spell.
When The World Canvas leaves the battlefield, exile all permanents with a name originally printed in this expansion.
```

[card implementation](/custom/cards/t/the_world_canvas.txt)

### Design Mode

 - In the game, the continent is discovered to be inside a living canvas. The final part of the game is about deciding the fate of this canvas.
 - Mechanically:
    - The "black lotus" mana ability has spending restrictions to keep in flavor. You can only spend this mana on things that actually live in this canvas.
    - The destruction of this canvas signals the destruction of everything inside it. Mass exiling everything by expansion filter nicely symbolizes the finality of such an act.

## Urrie

```
1
Legendary Artifact - Rock
{1},{T}: Surveil 2.
{1},Sacrifice Urrie: Draw a card.
```

[card implementation](/custom/cards/u/urrie.txt)

### Design Notes

 - In the game Urrie is a quest item which will grant Esquie the ability to dive when swimming in the Continent overworld
 - In this set, Urrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, my line of thought is diving > digging > Surveiling.