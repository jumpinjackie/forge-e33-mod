# Cards

## An Advantage!

```
U
Kindred Sorcery - Expeditioner
Create 3 Lumina tokens
```

[card implementation](/custom/cards/a/an_advantage.txt)

### Design Notes

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
When this creature dies, target opponent creates a Lumina token.

1/1
```

[card implementation](/custom/cards/d/demineur.txt)

### Design Notes

 - In the game, this is one of the weakest enemies in the game.
 - Went with a Nevron variation of Flying Men

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

 - In the game Francois is Esquie's "neighbor" and is in possession of one of the rocks that Esquie desires. Francois was created by Clea and is forever longing for her return into the canvas.
 - Mechanically speaking:
    - Affinity for Clea Planeswalkers is simply added for flavor purposes. There is only one Clea Planeswalker in this set.
    - It has defender as the game portrayal has him in a stationary position that never moves.
    - The strongest ice attack ever is just a triggered ability on each of your upkeeps to deal 4 damage to a creature and if that doesn't finish it off then it taps and stuns it for a turn in line with how an ice attack would generally be represented mechanically.

## Gradient Counter

```
U
Kindred Instant - Expeditioner
Counter target Gradient spell
```

[card implementation](/custom/cards/zDevelopment/gradient_counter.txt)

### Design Notes

 - In the game, a Gradient attack is a super-charged attack. Such attacks can only be parried with a Gradient counter.
 - Mechanically, since we have Gradient instants/sorceries. This is obviously a thematically-relevant counter.

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

## Swift Counter

```
1UU
Kindred Instant - Expeditioner
This spell costs {1} less to cast if you control an Expeditioner.
Counter target spell.
Create a Lumina token.
```

[card implementation](/custom/cards/zDevelopment/swift_counter.txt)

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