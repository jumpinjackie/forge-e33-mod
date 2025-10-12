# Cards

> Last generated: 12/10/2025 4:16:27 PM

## Chalier

```
1C
Creature - Nevron
When this creature dies, target opponent creates a Lumina token.

2/2
```

[card implementation](../custom/cards/c/chalier.txt)

### Design Notes

 - Vanilla Nevron. Could not determine approporiate color/elemental affinity so it's colorless.

## Petank

```
2C
Creature - Nevron
This creature enters with 3 shield counters and 3 countdown counters.
At the beginning of your upkeep, remove a countdown counter.
When this creature has no countdown counters, return it to its owner's hand.
When this creature dies, target opponent creates two Chroma tokens and two Lumina tokens.

1/3
```

[card implementation](../custom/cards/p/petank.txt)

### Design Notes

 - In the game, a Petank is a special type of Nevron that can be defeated for special loot, but you have a limited time window to defeat it before it runs away. Petanks are generally tanky enemies or has some defensive gimmick to add extra challenge to defeating it before it runs away.
 - Countdown counters symbolize the time window to kill it.
 - Shield counters to represent the tankiness.
 - Bounce back to hand to symbolize it running away.
 - Giving opponent Chroma/Lumina tokens on death symbolizes the loot reward for defeating it.
 - Reward is not triggering. See BUGS.md

## Troubador

```
2C
Creature - Nevron
Other nevrons you control get +1/+1.
When this creature dies, target opponent creates a Lumina token.

2/2
```

[card implementation](../custom/cards/t/troubador.txt)

### Design Notes

 - In the game, a Troubador uses its horn to buff the enemy party.
 - Mechanically, I've mapped this to a basic nevron lord buff effect.

