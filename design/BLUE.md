# Cards

## An Advantage!

```
U
Kindred Sorcery - Expeditioner
Create 3 Lumina tokens
```

[card implementation](/custom/cards/a/an_advantage.txt)

### Design Notes

 - In the game, a quote often said by Lune when loot is discovered.
 - A basic enabler of Lumina token ramping strategies

## Boucheclier

```
3U
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
This creature enters with a shield counter on it. (If it would be dealt damage or destroyed, remove a shield counter from it instead.)

3/3
```

[card implementation](/custom/cards/boucheclier.txt)

### Design Notes

 - Just a vanilla hill giant. Has shield counters because its game counterpart always has one and Shield counters are near 1:1 mechanically.

## Bruler

```
2U
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
This creature gets +2/+2 and Ward 2 if you control a creature named Cruler.

3/2
```

[card implementation](/custom/cards/b/bruler.txt)

### Design Notes

 - In the game, Bruler is generally in a party with Cruler. Thus I've gone with giving Bruler a buff if you also control Cruler

## Cache Discovery

```
U
Kindred Sorcery - Expeditioner
Create a Chroma token and a Lumina token.
Splice onto Expeditioner Instant or Sorcery {U} (As you cast an Expeditioner Instant or Sorcery, you may reveal this card from your hand and pay its splice cost. If you do, add this card's effects to that spell.)
```

[card implementation](/custom/cards/c/cache_discovery.txt)

### Design Notes

 - A card specifically designed to rapidly build up to the 33 permanent win condition of The Greatest Expedition In History
 - I am hoping that Forge's rule handling around splice is flexible enough to allow for this to work. Otherwise it's back to the drawing board.
    - 23/09/2025: It seems to work!

## Crippling Tsunami

```
2UU
Kindred Enchantment - Expeditioner
Tap an untapped creature you control: Tap target artifact or creature.
Tap an untapped Expeditioner you control: Tap target land.
```

[card implementation](/custom/cards/c/crippling_tsunami.txt)

### Design Notes

 - In the game, Crippling Tsunami is one of Lune's skills. It's basically an AOE variant of Ice Lance.
 - Made this a hybrid of Glare of Subdual and Opposition. Base effect is Glare, but Expeditioners can have the full Opposition experience.
 - Intentionally worded so that any Expeditioner permanent can be used to tap down. May change this to Expeditioner creatures only if proven to be too powerful.

## Cruler

```
2U
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
This creature gets +2/+2 and Ward 2 if you control a creature named Bruler.

2/3
```

[card implementation](/custom/cards/c/cruler.txt)

### Design Notes

 - The other half of Bruler. Thus like Cruler, decided to give the same buff if the other half is present.

## Demineur

```
U
Creature - Nevron
Flying.
Devoid (This card has no color.)
When this creature becomes the target of a spell or ability, sacrifice it.
When this creature dies, target opponent creates a Lumina token.

1/1
```

[card implementation](/custom/cards/d/demineur.txt)

### Design Notes

 - In the game, this is one of the weakest enemies in the game.
 - Went with a Nevron variation of Flying Men
 - 30/09/2025: Gave it a Skulking Ghost sac trigger to emphasize its weakness to targeted attacks (shots)

## Eternal Ice

```
2U
Enchantment - Aura
Enchant permanent
Enchanted permanent doesn't untap during its controller's untap step.
```

[card implementation](/custom/cards/e/eternal_ice.txt)

### Design Notes

 - Standard blue pin-down effect for limited/draft

## Expedition 40 Glider

```
2U
Creature - Human Expeditioner
Flying
This creature can block only creatures with flying.
When this creature dies, create a Chroma token.

3/1
```

[card implementation](/custom/cards/e/expedition_40_glider.txt)

### Design Notes

 - In the game, the journal of Expedition 40 details the story of trying to enter The Monolith by flying through the barrier. Those who tried got gommaged.
 - This card represents the poor bastards who tried.
 - I basically copied Rishadan Airship and stapled the Chroma death bonus to it.

## Expedition 43 Submersible

```
2U
Artifact - Expeditioner Vehicle
Islandwalk.
Whenever this deals combat damage to a player or planeswalker, draw a card.
Crew 2 (Tap any number of creatures you control with total power 2 or more: This Vehicle becomes an artifact creature until end of turn.)

2/3
```

[card implementation](/custom/cards/e/expedition_43_submersible.txt)

### Design Notes

 - In the game, Expedition 43 tried using Submarines to traverse the continent without encountering Nevrons. This ended in failure when they were wiped out by Serpenphare.
 - Easy mechanical map to a vehicle. Mostly adapted from Silent Submersible.

## Francois, Waiting for Clea

```
2UU
Legendary Artifact Creature - Turtle
Affinity for Clea Planeswalkers.
Defender.
The strongest ice attack ever - At the beginning of your upkeep, Francois deals 4 damage to target creature an opponent controls. Tap that creature and put a stun counter on it.
```

[card implementation](/custom/cards/f/francois_waiting_for_clea.txt)

### Design Notes

 - In the game Francois is Esquie's neighbor and "archnemesis" and is in possession of one of the rocks that Esquie desires. Francois was created by Clea and is forever longing for her return into the canvas.
 - Mechanically speaking:
    - Affinity for Clea Planeswalkers is simply added for flavor purposes. There is only (going to be) one Clea Planeswalker in this set.
    - It has defender as the game portrayal has him in a stationary position that never moves.
    - The strongest ice attack ever is just a triggered ability on each of your upkeeps to deal 4 damage to a creature and if that doesn't finish it off then it taps and stuns it for a turn in line with how an ice attack would generally be represented mechanically.
 - 23/09/2025: We could've given him shield counters to match his video game counterpart, but a sufficiently big butt conveys the same message. Also we can't give *every* creature shield counters for the sake of lore accuracy. Game balance is also a factor.

## Gestral Ascension Challenge

```
U
Enchantment
Whenever a creature you control with flying enters or a creature you control with flying attacks, put a quest counter on this enchantment.
Remove four counters from this enchantment and sacrifice it: Draw three cards.
```

[card implementation](/custom/cards/g/gestral_ascension_challenge.txt)

### Design Notes

 - In the game, the Gestral Ascension Challenge is 1 of 5 challenge minigames. This minigame in particular requires ascending upwards navigating various obstacles and jumps without falling down and starting over.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - In the case of this card, the condition involves flying creatures (we are trying to ascend to the top after all!) and the payoff is card draw.
 - Ancestral Recall in enchantment form may look broken at face value, but you really need to be all-in on an all-flyers strategy to reliably pop this off. If further playtesting shows we are popping this off *too* reliably, we can always bump up the quest counter requirement.

## Gradient Counter

```
U
Kindred Instant - Expeditioner
Counter target Gradient spell
```

[card implementation](/custom/cards/g/gradient_counter.txt)

### Design Notes

 - In the game, a Gradient attack is a super-charged attack. Such attacks can only be parried with a Gradient counter.
 - Mechanically, since we have Gradient instants/sorceries. This is obviously a thematically-relevant counter.

## Gustave's Ingenuity

```
3UU
Kindred Instant - Expeditioner
This spell costs {1} less to cast if you control an Expeditoner.
Draw three cards.
```

[card implementation](/custom/cards/g/gustaves_ingenuity.txt)

### Design Notes

 - Raw card draw with an expeditioner bonus

## Gustave's Insight

```
2U
Kindred Sorcery - Expeditioner
This spell has flash as long as you control an Expeditioner.
Look at the top five cards of your library. Put two of them into your hand and the rest on the bottom of your library in any order.
```

[card implementation](/custom/cards/g/gustaves_insight.txt)

### Design Notes

 - Stock Up with expeditioner benefits

## Ice Lance

```
2U
Kindred Instant - Expeditioner
Tap up to two target permanents. Put a stun counter on them.
```

[card implementation](/custom/cards/i/ice_lance.txt)

### Design Notes

 - Generic useful ice-themed tempo play in limited/draft environments.

## Lune's Denial

```
1U
Kindred Instant - Expeditioner
Counter target spell unless its controller pays {2}.
Create a Lumina token.
```

[card implementation](/custom/cards/l/lunes_denial.txt)

### Design Notes

 - Mandatory soft-counter with thematic uniqueness

## Luster

```
2U
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.

3/2
```

[card implementation](/custom/cards/l/luster.txt)

### Design Notes

 - Currently a vanilla placeholder Nevron. Abilities TBD

## Rip Apart Reality

```
3U
Instant - Gradient
Devoid
This spell costs {2} less to cast if you control a painter.
Put target permanent to the top or bottom of its owner's library.
```

[card implementation](/custom/cards/r/rip_apart_reality.txt)

### Design Notes

 - This is one of the Paintress' moves in the boss fight with her.
 - May or may not have any mechanical relation. I needed a soft-removal spell for blue in this slot and the name was a good enough match for such an effect.

## Sky Break

```
2UU
Kindred Sorcery - Expeditioner Gradient
Tap all creatures your opponents control, then put a stun counter on each of those creatures.
If {R} was spent on this spell, it deals 6 damage to each creature with a stun counter at the beginning of your next end step.
If {W} was spent on this spell, exile each creature with a stun counter at the beginning of your next end step.
If {G} was spent on this spell, you gain 2 life for each creature on the battlefield.
```

[card implementation](/custom/cards/s/sky_break.txt)

### Design Notes

 - In the game, Sky Break is a level 3 gradient attack for Lune. It deals extreme damage to all enemies in a single hit with elemental damage type determined by the most prominent Stain that Lune currently has. Can also break enemmies, stunning them.
 - Mechanically, we've gone with the tap and stun as the base effect, with extra effects based on what colors of mana (stains) you spent on the spell.
    - Red is damage
    - White is exile
    - Green is life gain
 - The damage or exiled is delayed as it was originally a symmetrical effect and only affected tapped creatures, giving you an opportunity to untap your creatures before the delayed effect kicks in. The delay is kept in for strategic purposes, giving the opponent an out until end of turn to try and save some of their creatures from an impending 6 damage or exile.
 - No black bonus because Lune does not have dark/black magic alignment.
 - Because this is a top tier gradient attack performed by an Expeditioner, this is one of the rare spells that has both Gradient and Expeditioner sub-types.
 - 30/09/2025: Cost adjusted from 3UU to 2UU so that you can't pick all 3 bonuses since the R bonus and W bonus kind of achieve the same goal.

## Swift Counter

```
1UU
Kindred Instant - Expeditioner
This spell costs {1} less to cast if you control an Expeditioner.
Counter target spell.
Create a Lumina token.
```

[card implementation](/custom/cards/s/swift_counter.txt)

### Design Notes

 - This set needs a hard counter. Give it the standard Expeditioner bonuses.

## The Search for Esquie's Rocks

```
1U
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Search your library for a rock card, put it onto the battlefield, then shuffle.
II - Scry 3.
III — Draw cards equal to the number of rock permanents you control.
```

[card implementation](/custom/cards/t/the_search_for_esquies_rocks.txt)

### Design Notes

 - In the game, you need to find a series of rocks for Esquie to unlock extra abilities to be able to traverse various parts of the overworld.
 - This is basically our "rock tutor" to enable our rock "Urzatron" strategy.

## Thermal Transfer

```
1U
Kindred Instant - Expeditioner
Kicker {R} (You may pay an additional {R} as you cast this spell.)
Tap target creature and put a stun counter on it. If this spell was kicked, this spell deals 3 damage to another target creature.
```

[card implementation](/custom/cards/t/thermal_transfer.txt)

### Design Notes

 - In the game this is one of Lune's abilities.
 - As the ability from the game has fire/ice elements, it naturally mechanically maps to a tap and stun on the ice side. For the fire side, I've decided to add a creature bolt ability behind a kicker cost.