# Cards

## Abbest

```
G
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
1/2
```

[card implementation](/custom/cards/a/abbest.txt)

### Design Notes

 - Just a "vanilla" bear with stock Nevron card text.
 - 23/09/2025: Changed casting cost from 1G to G and PT from 2/2 to 1/2 to make it unique from the (now fully green) Lancelier

## Expedition 69

```
2G
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Search your library for a basic land card, put it onto the battlefield tapped, then shuffle.
II — You may play an additional land thus turn.
III — Search your library for a land card, put it onto the battlefield, then shuffle.
```

[card implementation](/custom/cards/e/expedition_69.txt)

### Design Notes

 - Journal is thematically the same as Expedition 70: a story of exploring everywhere and installing grapple points for those who come after.
 - The one puts more emphasis on the exploration (ie. Land/mana ramp)

## Gestral Climbing Challenge

```
G
Enchantment
Whenever a creature you control becomes tapped, you may put a quest counter on this Enchantment.
As long as there are two or more counters on this enchantment. Creatures you control have reach.
As long as there are four or more counters on this enchantment. You may play an additional land on each of your turns.
```

[card implementation](/custom/cards/g/gestral_climbing_challenge.txt)

### Design Notes

 - In the game, the Gestral Climbing Challenge is 1 of 5 challenge minigames. This minigame in particular requires climbing a tower-like structure to the top, while dodging falling projectiles.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - In the case of this card, the condition is creatures being tapped (to indicate exertion of effort in climbing up) and the payoffs are your creatures having reach (most flavorful ability imo) and a bigger payoff being an Exploration effect (that's how Expedition 69 was able to explore, climb and install all those grapple points)

## Lancelier

```
1G
Creature - Nevron
First Strike.
When this creature dies, target opponent creates a Lumina token.

2/2
```

[card implementation](/custom/cards/l/lancelier.txt)

### Design Notes

 - Another generic vanilla Nevron to round out the creature roster for limited/draft.
 - In game, Lancelier's wield a lance. So clearly this should have First Strike.
 - 23/09/2025: Now green instead of white/green. White Nevrons will be their own unique sub-race that we don't want regular Nevrons to bleed into.

## Nevron Disguise

```
G
Kindred Instant - Expeditioner
Target non-Nevron creature becomes a Nevron until end of turn.
```

### Design Notes

 - In the game, the journal of Expedition 39 tells of an attempt by Expeditioners to disguise themselves as Nevrons in order to try and gain an advantage. It didn't work.
 - Simple creature type changing effect. Probably absolute dreck in draft/limited with fringe utility in constructed, but this one is all about flavor.

## Nevron Pecking Order

```
3G
Kindred Enchantment - Nevron
{1}{G}: Sacrifice a Nevron: Search your library for a Nevron permanent with mana value X and put it into the battlefield where X is the sacrificed Nevron's mana value plus one. Activate this ability only once each turn.
```

[card implementation](/custom/cards/n/nevron_pecking_order.txt)

### Design Notes

 - Painters have tutors, Expeditioners have tutors, Gestrals have tutors. This was a bone thrown to Nevrons so they at least had a tutor as well.
 - Modeled on Birthing Pod.

## Revitalization

```
2G
Sorcery
Choose up to one target creature and up to one target non-creature card in your graveyard. Return them to your hand.
```

[card implementation](/custom/cards/r/revitalization.txt)

### Design Notes

 - In the game, this is Lune's healing ability.
 - No mechanical relation. We've just re-approriated the name for a green regrowth-style spell.
 - The targeting restrictions don't seem to be working, meaning any two cards can be targeted. See BUGS.md

## Volester

```
G
Creature - Nevron
Flying.
Devoid (This card has no color.)
When this creature becomes the target of a spell or ability, sacrifice it.
When this creature dies, target opponent creates a Lumina token.

2/1
```

[card implementation](/custom/cards/v/volester.txt)

### Design Notes

 - In the game, Volester is one of the lower-tier enemies with flying that has a weak point in its chest.
 - Like Demineur, gave this one a Skulking Ghost sac effect to emphasize its weakness to targeted attacks.