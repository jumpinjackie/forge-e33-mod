# Cards

## Catapault Sakapatate

```
1R
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
When this creature dies, you may have this creature deal 2 damage to target creature.

2/2
```

[card implementation](/custom/cards/c/catapault_sakapatate.txt)

### Design Note

 - In the game, when you defeat a Catapault Sakapatate, it will try to do a last minute suicide move to do some damage before it goes.
 - Represented mechanically here as a simple shock-creature-on-death trigger.

## Earth Rising

```
2R
Kindred Sorcery - Expeditioner
This spell deals 2 damage to each creature without flying and each player.
```

[card implementation](/custom/cards/e/earth_rising.txt)

### Design Notes

 - Just a mini-earthquake
 - Needed a sweeper to give control strategies something to stymie go-wide strategies

## Fortune's Fury

```
1R
Kindred Instant - Expeditioner
Target creature gains double strike until end of turn. (It deals both first-strike and regular combat damage.)
```

[card implementation](/custom/cards/f/fortunes_fury.txt)

### Design Notes

 - In the game, this is Sciel's ability that grants double-damage to one of her allies.
 - Easy mechanical map to double-strike

## Get Out Of My Way!

```
XR
Kindred Sorcery - Expeditioner
X target Gestral creatures can't block this turn.
```

[card implementation](/custom/cards/g/get_out_of_my_way.txt)

### Design Notes

 - In the game, this is the "password" Golgra passed down to the Expeditioners to get past the Gestral guards at Esquie's Nest
 - Mechanically, it make sense (and is hilarious) to make Gestrals unable to block.

## Gestral Volleyball Strike

```
2R
Kindred Sorcery - Gestral
As an additional cost to cast this spell, sacrifice a Gestral. This spell deals 5 damage to any target.
```

### Design Notes

 - In the game, there is a mini game where you have to win a game of gestral volleyball against a Sakapatate who flings little gestrals at you. You win the mini game by parrying the flung gestrals back at the Sakapatate a certain number of times. Failure to parry will damage the raft you are standing on an after a certain number of hits, the raft explodes and you will lose the mini game.
 - Gestral version of Goblin Grenade / Reckless Abandon
 - Made it a bit more expensive to offset the ease of casting gestral creatures in general and the fact that a Gestral sol land is in this set.

## Golgra, Gestral Chief

```
5
Legendary Artifact Creature - Gestral
Other Gestral creatures you control get +2/+2
{2}: Put a shield counter on target Gestral you control.
Enrage - Whenever Golgra is dealt damage, choose one:
 - Put a Double strike counter on Golgra.
 - Put a Vigilance counter on Golgra.
 - Put a Trample counter on Golgra.
 - Draw a card.

5/6
```

[card implementation](/custom/cards/g/golgra_gestral_chief.txt)

### Design Notes

 - Obviously the Gestral lord of this set.
 - In the game, when Golgra gets below 50% health, she goes "Super Saiyan" and her attacks increase in power.
 - Mechanically, I've gone with Enrage as a way to approximate this "Super Saiyan" state and went with an assortment of combat-boosting abilities that could be granted from being enraged.

## Lightning Dance

```
2RR
Kindred Sorcery - Expeditioner
This spell deals 1 damage to any target, 2 damage to another target, and 3 damage to a third target.
```

[card implementation](/custom/cards/l/lightning_dance.txt)

### Design Notes

 - Just Cone of Flame made {1} cheaper and Expeditioner aligned