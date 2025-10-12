# Cards

> Last generated: 12/10/2025 4:16:27 PM

## Catapault Sakapatate

```
1R
Creature - Nevron
When this creature dies, target opponent creates a Lumina token.
When this creature dies, you may have this creature deal 2 damage to target creature.

2/2
```

[card implementation](../custom/cards/c/catapault_sakapatate.txt)

### Design Notes

 - In the game, when you defeat a Catapault Sakapatate, it will try to do a last minute suicide move to do some damage before it goes.
 - Represented mechanically here as a simple shock-creature-on-death trigger.
 - 13/10/2025: Removed Devoid.

## Earth Rising

```
2R
Kindred Sorcery - Expeditioner
This spell deals 2 damage to each creature without flying and each player.
```

[card implementation](../custom/cards/e/earth_rising.txt)

### Design Notes

 - In the game, this is one of Lune's skills
 - Just a mini-earthquake
 - Needed a sweeper to give control strategies something to stymie go-wide strategies

## Entering the Canvas

```
4R
Instant
You may put a creature card from your hand onto the battlefield. That creature gains haste. Sacrifice that creature at the beginning of the next end step.
```

[card implementation](../custom/cards/e/entering_the_canvas.txt)

### Design Notes

 - This symbolizes the moment in the game where real Alicia enters Verso's canvas to try and help real Renoir in expelling Aline out of the canvas, but ends up being consumed by Aline's chroma and is "reborn" as Maelle.
 - Mechanically/thematically translated to near carbon copy of Through the Breach.

## Fortune's Fury

```
1R
Kindred Instant - Expeditioner
Target creature gains double strike until end of turn. (It deals both first-strike and regular combat damage.)
```

[card implementation](../custom/cards/f/fortunes_fury.txt)

### Design Notes

 - In the game, this is Sciel's ability that grants double-damage to one of her allies.
 - Easy mechanical map to double-strike

## Gestral Volleyball Strike

```
2R
Kindred Sorcery - Gestral
As an additional cost to cast this spell, sacrifice a Gestral.
This spell deals 5 damage to any target.
```

[card implementation](../custom/cards/g/gestral_volleyball_strike.txt)

### Design Notes

 - In the game, there is a mini game where you have to win a game of gestral volleyball against a Sakapatate who flings little gestrals at you. You win the mini game by parrying the flung gestrals back at the Sakapatate a certain number of times. Failure to parry will damage the raft you are standing on an after a certain number of hits, the raft explodes and you will lose the mini game.
 - Gestral version of Goblin Grenade / Reckless Abandon
 - Made it a bit more expensive to offset the ease of casting gestral creatures in general and the fact that a Gestral sol land is in this set.

## Get Out Of My Way!

```
XR
Kindred Sorcery - Expeditioner
X target Gestral creatures can't block this turn.
```

[card implementation](../custom/cards/g/get_out_of_my_way.txt)

### Design Notes

 - In the game, this is the "password" Golgra passed down to the Expeditioners to get past the Gestral guards at Esquie's Nest
 - Mechanically, it make sense (and is hilarious) to make Gestrals unable to block.

## Lightning Dance

```
2RR
Kindred Sorcery - Expeditioner
This spell deals 1 damage to any target, 2 damage to another target, and 3 damage to a third target.
```

[card implementation](../custom/cards/l/lightning_dance.txt)

### Design Notes

 - Just Cone of Flame made {1} cheaper and Expeditioner aligned

## Mutinous Expedition 48 Soldier

```
1R
Creature - Human Expeditioner Soldier
Mutiny! - Whenever an Expeditioner creature you control dies, target opponent gains control of this creature.
When this creature dies, create a Chroma token.

3/3
```

[card implementation](../custom/cards/m/mutinous_expedition_48_soldier.txt)

### Design Notes

 - In the game, Expedition 48 was an expedition fraught with Mutiny and Treachery.
 - The mutinous nature has been captured with this creature joining the other side when one of your Expeditioner compatriots dies.

