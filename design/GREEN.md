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

## Expedition 00 Tracker

```
2G
Creature - Human Expeditioner Scout
{4}{G},{T}: Look at the top four cards of your library. You may reveal an Expeditioner card from among them and put it into your hand. Put the rest on the bottom of your library in a random order.
When this creature dies, create a Chroma token.

2/3
```

[card implementation](/custom/cards/e/expedition_00_tracker.txt)

### Design Notes

 - In the game, Expedition 00 was the first "search and rescue" team to find any survivors of The Fracture.
 - Gone with a variant of Brightwood Tracker

## Expedition 35 Bridge

```
2G
Kindred Enchantment - Expeditioner
Sacrifice an Expeditioner: Draw a card
```

[card implementation](/custom/cards/e/expedition_35_bridge.txt)

### Design Notes

 - In the game, Expedition 35 perished to Nevrons in Falling Leaves. In their final moments, as they were becoming petrified, they threw themselves on top of each other to form a bridge for future expeditions to cross.
 - I've symbolized this as an enchantment where Expeditioners can be sacrificed for card draw, since each Expeditioner creature has a Chroma token death bonus, this can potentially be a combo engine to rip through your deck for some game winning payoff.

## Expedition 55 Drummer

```
1G
Creature - Human Expeditioner
Other Expeditioner creatures you control get +1/+1.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](/custom/cards/e/expedition_55_drummer.txt)

### Design Notes

 - In the game, Expedition 55 tried using musically-augmented pictos. This was mostly effective until they encountered Sirene whose minions and herself were immune to these pictos.
 - Since the main theme of this Expedition was music, it can be safely assumed that most of the crew were musicians or were proficient in one kind of music, giving us ample design space to fill out the Expeditioner creature roster with various creatures of various utility. In this case, I've gone with a drummer and a lord buff effect.

## Expedition 55 Trumpeter

```
2(W/G)
Creature - Human Expeditioner
Expeditioner spells you cast cost {1} less to cast.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](/custom/cards/e/expedition_55_trumpeter.txt)

### Design Notes

 - In the game, Expedition 55 tried using musically-augmented pictos. This was mostly effective until they encountered Sirene whose minions and herself were immune to these pictos.
 - Since the main theme of this Expedition was music, it can be safely assumed that most of the crew were musicians or were proficient in one kind of music,  giving us ample design space to fill out the Expeditioner creature roster with various creatures of various utility. In this case, I've gone with a trumpeter and a cost-reduction effect.

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

## Expedition 69 Explorer

```
G
Creature - Human Expeditioner
Sacrifice a Chroma token: Search your library for a basic land card, reveal it, put it into your hand, then shuffle.
Sacrifice two Chroma tokens: You may put a basic land from your hand onto the battlefield tapped.
When this creature dies, create a Chroma token.

1/1
```

[card implementation](/custom/cards/e/expedition_69_explorer.txt)

### Design Notes

 - In the game, Expedition 69 were responsible for most of the grappling points installed throughout the continent. Obviously then, members of this expeditions have a strong exploration theme.
 - For this card, gone with a one drop that can ramp out extra land drops if they have surplus chroma tokens.

## Expedition 69 Mountaineer

```
2G
Creature - Human Expeditioner
This creature can't be blocked except by creatures with flying.
When this creature dies, create a Chroma token.

3/2
```

[card implementation](/custom/cards/e/expedition_69_mountaineer.txt)

### Design Notes

 - In the game, Expedition 69 were responsible for most of the grappling points installed throughout the continent. Obviously then, members of this expeditions have a strong exploration theme.
 - For this card, instead of a mana/land ramp theme I've gone with a variant of Treetop Rangers / Silhana Ledgewalker. With such experience in climbing, this creature clearly isn't grounded and thus can only be engaged with in combat by flyers.

## Expedition 69 Surveyor

```
3G
Creature - Human Expeditioner
When this creature enters, you may search your library for a basic land card, put that card onto the battlefield tapped, then shuffle.
Whenever this creature attacks, surveil 1.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](/custom/cards/e/expedition_69_surveyor.txt)

### Design Notes

 - In the game, Expedition 69 were responsible for most of the grappling points installed throughout the continent. Obviously then, members of this expeditions have a strong exploration theme.
 - For this card, I've gone with a land ramp effect with a surveil attack trigger to sell the Surveyor > Surveiling.

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