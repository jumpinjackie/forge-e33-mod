# Cards

> Last generated: 1/1/2026 9:08:04 am

## Abbest

```
G
Creature - Nevron
{T}: Add {G}.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

1/2
```

[card implementation](../custom/cards/a/abbest.txt)

### Design Notes

 - Just a "vanilla" bear with stock Nevron card text.
 - 23/09/2025: Changed casting cost from 1G to G and PT from 2/2 to 1/2 to make it unique from the (now fully green) Lancelier
 - 13/10/2025: Removed Devoid.
 - 23/10/2025: Promoted to mana dork.

## All Suns' Dawn

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=All Suns' Dawn)
### Notes

 - Thematically on-point reprint. Dawn signifying tomorrow. Tomorrow comes.

## Band Together

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Band Together)
### Notes

 - Flavorful (based on art) [removal / combat trick] reprint

## Bargaining

```
3GG
Creature - Incarnation
Trample
Sacrifice a nonland creature: Draw cards equal to the sacrificed creature’s power, then discard three cards.
---
Verso: I don't want this life... I don't want this life...
Maelle: I just- I just wanted to live this lifetime together. This lifetime that was stolen from us. Please, brother... Please.

4/5
```

[card implementation](../custom/cards/b/bargaining.txt)

### Design Notes

 - No in-game basis, but Grief is such a central theme of Expedition 33 that having a cycle dedicated to the 5 stages is a total flavor nuke.
 - Bargaining is the third stage. On name-basis alone you would think this is easily a black creature with "life for cards" motif, but it is actually green because this is the color that has the hardest time thematically associating to any of the 5 stages. Bargaining has some thematic leeway with green if you try to view it through a "Greater Good" kind of lens and thus I went with a creature variation of Greater Good.
 - 17/11/2025: Changed PT from 4/4 to 4/5
 - 21/11/2025: Added nonland clause to avoid being able to sac The Reacher for +5 net CA without any mana investment first.

## Cultivate

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Cultivate)
### Notes

 - Obligatory commander staple.

## Doubling Season

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Doubling Season)
### Notes

 - Commander staple.

## Esquie's Wine Compartment

```
1G
Legendary Artifact - Food
Esquie's Wine Compartment enters with five wine counters on it.
Remove a wine counter from Esquie's Wine Compartment: Target creature you control gets +1/-1 until end of turn. You gain 1 life.
{2}, {T}, Sacrifice Esquie's Wine Compartment: You gain 3 life.
---
I stored my personal stash inside him. All excellent vintages. I don’t normally share, but I suppose tonight deserves an exception.
- Verso
```

[card implementation](../custom/cards/e/esquies_wine_compartment.txt)

### Design Notes

 - In the game, after slaying the two Axons and acquiring enough Chroma for The Curator to forge the Barrier Breaker, the party congregates at camp, amazed that the possibility that they can actually now take down The Paintress. It was at this moment that Sciel reveals a terrible secret to the rest of the party: That Esquie has a hidden compartment for storing wine. Everybody (except Maelle) have some wine to celebrate the occasion.
 - The temporary +1/-1 is my attempt to model drunkeness.
 - Wine is technically food/nourishment, so it falls under the Food classifier and has the standard Food token ability.

## Expedition 00 Tracker

```
2G
Creature - Human Expeditioner Scout
{4}{G}, {T}: Look at the top four cards of your library. You may reveal an Expeditioner card from among them and put it into your hand. Put the rest on the bottom of your library in a random order.
When this creature dies, create a Chroma token.

2/3
```

[card implementation](../custom/cards/e/expedition_00_tracker.txt)

### Design Notes

 - In the game, Expedition 00 was the first "search and rescue" team to find any survivors of The Fracture.
 - Gone with a variant of Brightwood Tracker

## Expedition 35 Bridge

```
2G
Kindred Enchantment - Expeditioner
Sacrifice a creature: Scry 1.
Sacrifice an Expeditioner: Draw a card.
---
Yet in their final moments, they used their bodies to create a bridge for those who come after. Expedition 35 is over but tomorrow comes.
```

[card implementation](../custom/cards/e/expedition_35_bridge.txt)

### Design Notes

 - In the game, Expedition 35 perished to Nevrons in Falling Leaves. In their final moments, as they were becoming petrified, they threw themselves on top of each other to form a bridge for future expeditions to cross.
 - I've symbolized this as an enchantment where Expeditioners can be sacrificed for card draw, since each Expeditioner creature has a Chroma token death bonus, this can potentially be a combo engine to rip through your deck for some game winning payoff.
 - 26/10/2025: Added creature sac for scry ability to avoid parasitism.

## Expedition 55 Drummer

```
1G
Creature - Human Expeditioner
Other Expeditioner creatures you control get +1/+1.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](../custom/cards/e/expedition_55_drummer.txt)

### Design Notes

 - In the game, Expedition 55 tried using musically-augmented pictos. This was mostly effective until they encountered Sirène whose minions and herself were immune to these pictos.
 - Since the main theme of this Expedition was music, it can be safely assumed that most of the crew were musicians or were proficient in one kind of music, giving us ample design space to fill out the Expeditioner creature roster with various creatures of various utility. In this case, I've gone with a drummer and a lord buff effect.

## Expedition 60 Messenger

```
3G
Creature - Human Expeditioner Scout
When this creature leaves the battlefield, investigate (Create a Clue token. It’s an artifact with “{2}, Sacrifice this token: Draw a card.”)
This creature gets +2/+2 as long as it’s un-modified. (Equipment, Auras you control, and counters are modifications.)
When this creature dies, create a Chroma token.
---
One last swim separates me from Lumière, but even with my mighty muscles, I don’t know if I can outswim the Gommage.

2/2
```

[card implementation](../custom/cards/e/expedition_60_messenger.txt)

### Design Notes

 - Depicts the member of the gigachad expedition that almost made it back to Lumière to relay the message about the true enemy.
 - The clue token left behind represents the expedition journal.
 - Has un-modified buffs because these gigachads don't require pithy things like clothing and armor.
 - 1/1/2026: Fixed bad trigger description

## Expedition 69

```
2G
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Search your library for a basic land card, put it onto the battlefield tapped, then shuffle.
II — You may play an additional land this turn.
III — Search your library for a land card, put it onto the battlefield, then shuffle.
```

[card implementation](../custom/cards/e/expedition_69.txt)

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

[card implementation](../custom/cards/e/expedition_69_explorer.txt)

### Design Notes

 - In the game, Expedition 69 were responsible for most of the grappling points installed throughout the continent. Obviously then, members of this expeditions have a strong exploration theme.
 - For this card, gone with a one drop that can ramp out extra land drops if they have surplus chroma tokens.

## Expedition 69 Mountaineer

```
2G
Creature - Human Expeditioner
This creature can't be blocked except by creatures with flying.
When this creature dies, create a Chroma token.
---
I still remember the first mountain we scaled. Watching the sun rise above the clouds was magical. But rappelling down as we set the handholds was pure exhilaration.
- Fleur, Expedition 69

3/2
```

[card implementation](../custom/cards/e/expedition_69_mountaineer.txt)

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
---
It may not be glamorous, but truly essential work rarely is. Doesn’t make it any less important.
- Fleur, Expedition 69

2/2
```

[card implementation](../custom/cards/e/expedition_69_surveyor.txt)

### Design Notes

 - In the game, Expedition 69 were responsible for most of the grappling points installed throughout the continent. Obviously then, members of this expeditions have a strong exploration theme.
 - For this card, I've gone with a land ramp effect with a surveil attack trigger to sell the Surveyor > Surveiling.

## Explore

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Explore)
### Notes

 - Easy on-flavor reprint.

## Farseek

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Farseek)
### Notes

 - Easy on-flavor reprint.

## Gault

```
2G
Creature - Nevron
Protection from green.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

3/2
```

[card implementation](../custom/cards/g/gault.txt)

### Design Notes

 - In the game, Gaults can be found in Yellow Harvest.
 - Vanilla Nevron with protection from green, since in the game it aborbs damage from any earth (green) attacks.

## Gestral Climbing Challenge

```
G
Enchantment
Whenever a creature you control becomes tapped, you may put a quest counter on this Enchantment.
As long as there are two or more quest counters on this enchantment. Creatures you control have reach.
As long as there are four or more quest counters on this enchantment. You may play an additional land on each of your turns.
---
I've been trying to overcome this gestral's challenge for months now but it seems even more of a challenge than defeating the Paintress. I guess I'll never see the Gestral's grand prize. That's my only regret in life.
- Laure, Expedition 37
```

[card implementation](../custom/cards/g/gestral_climbing_challenge.txt)

### Design Notes

 - In the game, the Gestral Climbing Challenge is 1 of 5 challenge minigames. This minigame in particular requires climbing a tower-like structure to the top, while dodging falling projectiles.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - In the case of this card, the condition is creatures being tapped (to indicate exertion of effort in climbing up) and the payoffs are your creatures having reach (most flavorful ability imo) and a bigger payoff being an Exploration effect (that's how Expedition 69 was able to explore, climb and install all those grapple points)

## Lancelier

```
1G
Creature - Nevron
First Strike.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/l/lancelier.txt)

### Design Notes

 - Another generic vanilla Nevron to round out the creature roster for limited/draft.
 - In game, Lancelier's wield a lance. So clearly this should have First Strike.
 - 23/09/2025: Now green instead of white/green. White Nevrons will be their own unique sub-race that we don't want regular Nevrons to bleed into.
 - 5/10/2025: Added missing Devoid.
 - 13/10/2025: Removed Devoid.

## Nevron Disguise

```
G
Kindred Enchantment - Expeditioner
All creature cards on the battlefield, graveyard and libraries are Nevrons in addition to their existing types.
{1}, Sacrifice this enchantment: Draw a card.
---
The idea was we'd only have to fool the first one. Then Jules can wear its carcass to trap the next, and so on, until we all have proper cover. But disguising ourselves as Nevrons has proven to be extremely ineffective, to say the least. Maybe they recognize each other by their chroma?
- Nicolas, Expedition 44
```

[card implementation](../custom/cards/n/nevron_disguise.txt)

### Design Notes

 - In the game, the journal of Expedition 44 tells of an attempt by Expeditioners to disguise themselves as Nevrons in order to try and gain an advantage. It didn't work.
 - Simple creature type changing effect. Probably absolute dreck in draft/limited with fringe utility in constructed, but this one is all about flavor.
 - 6/10/2025: Changed to an enchantment with the type changing an activated ability. Also added a sac cantrip for utility.
 - 29/12/2025: Remove the type changing activated ability to a continuous "Painter's Servant"-style add Nevron sub-type to all creatures in battlefield, graveyards and libraries. Also upshifted to uncommon.

## Nevron Pecking Order

```
3G
Kindred Enchantment - Nevron
{1}{G}, Sacrifice a Nevron: Search your library for a Nevron permanent with mana value X or less and put it into the battlefield where X is the sacrificed Nevron's mana value plus one. Activate this ability only once each turn.
---
Even in an artificial painted world, there is a natural order.
```

[card implementation](../custom/cards/n/nevron_pecking_order.txt)

### Design Notes

 - This is a bone thrown to Nevrons to solidify that archetype.
 - Modeled on Birthing Pod.
 - 21/10/2025: Made search criteria X or less. Fixed incorrect sac cost.

## Ophelie, Lumière Florist

```
1G
Legendary Creature - Human Citizen
{T}: Create a Flower token. (It’s an artifact with “{T}, Sacrifice this artifact: Add {U}, {R} or {G}.”)
When this creature dies, create a Chroma token.
---
Hi Gustave. You’re back. Did you want to pick out a different flower?

1/2
```

[card implementation](../custom/cards/o/ophelie_lumiere_florist.txt)

### Design Notes

 - In the game, Ophelie operates a stand in the Lumière flower market.
 - Easy map to a creature that makes Flower tokens.

## Portier

```
2G
Creature - Nevron
Jumps — {1}{G}: This creature gains Reach until end of turn.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

3/3
```

[card implementation](../custom/cards/p/portier.txt)

### Design Notes

 - Vanilla Nevron

## Revitalization

```
2G
Kindred Sorcery - Expeditioner
Return up to one target creature card in your graveyard to your hand.
Luminous — If you control three or more Lumina tokens, also return up to one target non-creature card in your graveyard to your hand.
```

[card implementation](../custom/cards/r/revitalization.txt)

### Design Notes

 - In the game, this is Lune's healing ability.
 - No mechanical relation. We've just re-approriated the name for a green regrowth-style spell.
 - 23/11/2025: Rework the card so that the base is regrowing a creature card, with the additional regrowth of a non-creature card being a Luminous bonus.

## Rock Throw

```
G
Instant
Kicker — {2}, Exert a tapped creature you control.
Rock Throw deals 2 damage to target creature. If this spell was kicked, Rock Throw deals 4 damage instead.
---
Have you tried throwing with your other arm instead? If you could hit the Paintress directly that would be useful.
- Maelle
```

[card implementation](../custom/cards/r/rock_throw.txt)

### Design Notes

 - In the game, Gustave has a penchant for throwing rocks.
 - To give green some bones in spot removal for draft/limited, this is a shock for creatures that can be upgraded in damage.
 - 1/1/2026: Fixed the kicker to exert a tapped creature as exert does not tap the creature as part of the exerting. I don't believe Forge supports a "tap and exert" action, so this is the closest thing.

## Sapling

```
1G
Creature - Nevron
Protection from black
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/s/sapling.txt)

### Design Notes

 - In the game, Saplings can be found in Yellow Harvest and Falling Leaves.
 - Absorbs dark attacks ergo. Protection from black.

## Shrine to The Paintress

```
4G
Legendary Enchantment - Shrine
At the beginning of your upkeep, create a 1/1 colorless Nevron creature token for each Shrine you control.
---
Gustave: The Paintress destroyed our world. And someone built her a shrine?
Lune: The weak-minded turn to whatever they can to explain the unknown.
Sciel: When you're at the mercy of a power you don't understand, you might try anything.
```

[card implementation](../custom/cards/s/shrine_to_the_paintress.txt)

### Design Notes

 - In the game, the Shrine can be found at Stone Wave Cliffs, prompting the discussion referenced in the flavor text.
 - Nevron variant of Honden of Life's Web.

## Volester

```
G
Creature - Nevron
Flying
When this creature becomes the target of a spell or ability an opponent controls, sacrifice it.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/1
```

[card implementation](../custom/cards/v/volester.txt)

### Design Notes

 - In the game, Volester is one of the lower-tier enemies with flying that has a weak point in its chest.
 - Like Démineur, gave this one a Skulking Ghost sac effect to emphasize its weakness to targeted attacks.
 - 13/10/2025: Removed Devoid.
 - 18/10/2025: Made the skulking ghost effect triggered by opponents

