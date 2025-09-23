# Cards

## Aberration

```
4B
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
3/3
```

[card implementation](/custom/cards/a/aberration.txt)

### Design Notes

 - Just a vanilla placeholder for now until I have figured out some suitable abilities for it

## Chapelier

```
2BB
Creature - Nevron
Flying.
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
{1}{B},{T}: Create a 1/1 colorless Jar creature token.
Exhaust on death - When this creature dies, tap target creature an opponent controls, put a stun counter on it. (If a permanent with a stun counter would become untapped, remove one from it instead.)
```

[card implementation](/custom/cards/c/chapelier.txt)

### Design Notes

 - In the game, Chapelier summons jars to attack the party of not shot down and causes party exhaustion on defeat.
 - Gave it a token generation ability and mechanically represent exhaustion with tap + stun counter.

## Maelle's Nightmare

```
B
Sorcery - Gradient
Target opponent reveals their hand. You choose either an Expeditioner card or a noncreature, nonland card from it. That player discards that card.
```

### Design Notes

 - Duress with an ability to hit Expeditioner cards of any kind

## Noire

```
3BB
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.

5/5
```

[card implementation](/custom/cards/n/noire.txt)

### Design Notes

 - In the game, Noires are high-tier Nevrons found on the Dark Shores and are an excellence source of XP farming in the late game.
 - Placeholder vanilla Nevron. Abilities TBD.

## Obscur

```
2B
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
{1}{B},{T}: Target creature an opponent controls gets -1/-1 until end of turn.
{1}{B},{T}: Untap target creature you control.
```

[card implementation](/custom/cards/o/obscur.txt)

### Design Notes

 - In the game, Obscur is the other half of Clair.
 - Mechanically, it's main ability is to give its allies the ability to act twice, which I've mapped to untapping creatures.
 - And to round out its abilities I've given it a generic -1/-1 affliction ability.

## Piercing Strike

```
3B
Instant - Gradient
Devoid. Split Second.
This spell costs {1} less to cast if you control a painter.
This spell costs {1} less to cast if it targets an Expeditioner.
Destroy target creature.
```

### Design Notes

 - This is meant to flavorfully and mechanically represent Painted Renoir's killing blow to Gustave.