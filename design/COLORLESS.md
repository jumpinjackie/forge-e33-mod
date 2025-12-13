# Cards

> Last generated: 13/12/2025 12:51:06 pm

## Jar

```
3C
Creature - Nevron
Performs a combo — {2}{C}: This creature gains double strike until end of turn. Put a charge counter on this creature.
Smashes the ground — {1}{C}, {T}, Remove X charge counters from this creature: This creature deals X damage to each creature without flying.

2/3
```

[card implementation](../custom/cards/j/jar.txt)

### Design Notes

 - In the game, Jars can be found in Yellow Harvest.
 - Made colorless as it has weaknesses to all elements in the game.

## Pétank

```
2C
Creature - Nevron
This creature enters with three shield counters and three countdown counters.
At the beginning of your upkeep, remove a countdown counter.
When this creature has no countdown counters, return it to its owner's hand.
When this creature dies, target opponent creates two Chroma tokens and two Lumina tokens.

1/3
```

[card implementation](../custom/cards/p/petank.txt)

### Design Notes

 - In the game, a Pétank is a special type of Nevron that can be defeated for special loot, but you have a limited time window to defeat it before it runs away. Pétanks are generally tanky enemies or has some defensive gimmick to add extra challenge to defeating it before it runs away.
 - Countdown counters symbolize the time window to kill it.
 - Shield counters to represent the tankiness.
 - Bounce back to hand to symbolize it running away.
 - Giving opponent Chroma/Lumina tokens on death symbolizes the loot reward for defeating it.

