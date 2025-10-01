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

 - In the game, Chapelier summons jars to attack the party if not shot down and causes party exhaustion on defeat.
 - Gave it a token generation ability and mechanically represent exhaustion with tap + stun counter.

## Clea's Chromatic Mastery

```
2B
Sorcery
Search your library for a Nevron card, reveal it, put it into your hand, then shuffle.
```

[card implementation](/custom/cards/c/cleas_chromatic_mastery.txt)

### Design Notes

 - A Nevron tutor to support Nevron tribal strategies

## Here's Your Card!

```
B
Kindred Instant - Expeditioner
Target creature gets -2/-2 until end of turn.
Foretell {0} (During your turn, you may pay {2} and exile this card from your hand face down. Cast it on a later turn for its foretell cost.)
```

[card implementation](/custom/cards/h/heres_your_card.txt)

### Design Notes

 - In the game, this is one of Sciel's quotes when performing a regular attack.
 - Simple targeted creature kill with Foretell to name-tie (not mechanically-tie) it to Sciel's skillset. The keyword ability is already there, so let's just use it!

## Maelle's Nightmare

```
B
Sorcery - Gradient
Target opponent reveals their hand. You choose either an Expeditioner card or a noncreature, nonland card from it. That player discards that card.
```

[card implementation](/custom/cards/m/maelles_nightmare.txt)

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

 - In the game, Noires are high-tier Nevrons found on the Dark Shores and are an excellent source of XP farming in the late game.
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

[card implementation](/custom/cards/p/piercing_strike.txt)

### Design Notes

 - This is meant to flavorfully and mechanically represent Painted Renoir's killing blow to Gustave.

## Renoir's Will

```
2B
Sorcery - Gradient
Until end of turn, you may play lands and cast Nevron or Gradient spells from your graveyard.
If a card would be put into your graveyard from anywhere this turn, exile that card instead.
```

### Design Notes

 - The card symbolizes the moment that Renoir was finally free from the bottom of the Monolith upon the defeat of The Paintress and Aline was expelled from the canvas and now had free reign to carry out his will: To destroy the canvas.
 - So mechanically, we've gone with a variation of Yawgmoth's Will, but with extra restrictions on the type of cards that can be replayed, allowing us to keep the same mana cost.

## The 67th Gommage

```
4BB
Legendary Sorcery
(You may cast a legendary sorcery only if you control a legendary creature or planeswalker.)
Each player with 33 or more life loses the game.
```

[card implementation](/custom/cards/t/the_67th_gommage.txt)

### Design Notes

 - This is meant to flavorfully and mechanically represent the moment Renoir triggers the 67th gommage, erasing every human 33 years and older.
 - Except in our case, instead of humans, it's players and instead of age its life total. Basically this card is just another excuse to weave in a thematic and flavorful use of the number 33.
 - Further playtesting may reveal the truth, but I don't believe the win condition is *that easy* to achieve. It goes against the general plan of victory for most decks, which is to get your opponent to 0 or less life. So having to get your opponent to above a certain life total to enable the victory condition is at least a unique angle.