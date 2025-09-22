# Cards

## A storm is coming

```
Kindred Sorcery - Expeditioner
Suspend 1—{U}{R} (Rather than cast this card from your hand, pay {U}{R} and exile it with one time counter on it. At the beginning of your upkeep, remove a time counter. When the last is removed, you may cast it without paying its mana cost.)

This spell deals 3 damage to any target.
Create a Lumina token.
```

[card implementation](/custom/cards/a/a_storm_is_coming.txt)

### Design Notes

 - Lighting bolt with suspend to convey the "storm is coming". Lumina reward as standard with any Expeditioner spell

## Alicia Dessendre, Slienced by Fire

```
WR
Legendary Creature - Human Painter
Activated abilities of Nevrons and Pictos cannot be activated.
(Melds with Maelle, Child of Lumiere.)

2/2
```

[card implementation](/custom/cards/zDevelopment/alicia_dessendre_slienced_by_fire.txt)

### Design Notes

 - Gone with a targeted (Null Rod / Cursed Totem) effect to mechanically emphasize the "silence"
 - The real gimmick is melding with Maelle, Child of Lumiere. Meld is 100% the mechanic to sell the transformation

## Ballet

```
1GW
Creature - Nevron
Devoid (This card has no color.)
Flying.
When this creature dies, target opponent creates a Lumina token.

2/2
```

[card implementation](/custom/cards/b/ballet.txt)

### Design Notes

 - Another vanila Nevron. Flying because these things are hard to hit with melee attacks in the actual game.

## Benisseur

```
2WR
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.

4/4
```

[card implementation](/custom/cards/b/benisseur.txt)

### Design Notes

 - Currently a placeholder vanilla Nevron. Abilities TBD.

## Braseleur

```
1UR
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.

3/2
```

[card implementation](/custom/cards/b/braseleur.txt)

### Design Notes

 - Currently a placeholder vanilla Nevron. Abilities TBD.

## Chorale

```
1(R/G)
Creature - Nevron
Flying.
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.

1/2
```

[card implementation](/custom/cards/c/chorale.txt)

### Design Notes

 - Another vanilla Nevron

## Chromatic Petrification

```
WB
Enchantment - Aura
Enchant creature.
Enchanted creature becomes an artifact creature with base power and toughness 0/1 and loses all abilities.
```

[card implementation](/custom/cards/c/chromatic_petrification.txt)

### Design Notes

 - Represents the effect inflicted on a good bunch of previous Expeditioners that turned them into statues with their Chroma trapped within.
 - I orignally wanted this to turn into a "do nothing" artifact, but I think the "Enchant creature" restriction means this is a nonbo and the aura immediately "falls off". Will revisit later with "Enchant permanent" to see if this gives my desired result.
    - Until then, I've gone with a 0/1 artifact creature.

## Danseuse

```
2UR
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
{R},{T}: This creature deals 2 damage to target creature.
{U},{T}: Tap target creature. Put a stun counter on it.
When this creature dies, if you control no creatures, put two 2/2 Red and Blue Danseuse Clone creature tokens into play.

2/2
```

[card implementation](/custom/cards/d/danseuse.txt)

### Design Notes

 - In the game, a Danseuse attacks with fire and ice magic. If it is the only enemy left in battle, it can summon up to 2 clones.
 - Mechanically I went with:
    - A creature shock ability for the fire/red ability
    - Tap and stun for the ice/blue ability
    - For the clone ability, I preserved the original triggering condition

## Esquie, Friend of Verso

```
3UG
Legendary Artifact Creature - Mount
Saddle 2.
Esquie has Islandwalk as long as you control a card named Florrie.
Esquie has Flying as long as you control a card named Soarrie.
Esquie has Trample as long as you control a card named Dorrie.
When Esquie attacks, if you control a card named Urrie, Surveil 2.
When Esquie attacks, if it is saddled, choose one:
 - Draw a card.
 - Put a land card from your hand onto the battlefield.

6/6
```

[card implementation](/custom/cards/e/esquie_friend_of_verso.txt)

### Design Notes

 - In the game, Esquie is the character the rest of the party rides on to travel across the Continent overworld.
 - In the game, Esquie gains additional powers through consuming the rocks, Florrie (swimming), Dorrie (smash thorugh coral barriers), Soarrie (flying) and Urrie (diving)
 - Mechanically, it makes 100% sense this should be a Mount artifact creature with Saddle
    - Because I want to enable an "Urzatron" strategy with the 4 legendary rocks, I am deviating from lore by having these 4 rocks grant extra abilities to Esquie when on the battlefield instead of sacrificing them to Esquie to give them these abilities
    - Mechanically I've interpreted Esquies abilities as:
       - Swimming - Islandwalk
       - Smashing through coral barriers - Trample
       - Flying - Flying
       - Diving - Surveil on attack
 - Because this is a Mount creature with Saddle, I've given it the Uro (draw a card or put a land) triggered ability as the saddle attacking bonus.

## Expedition 70

```
2WU
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I, II — Search your library for an Expeditoner card, reveal it and put it into your hand, then shuffle.
III — Search your library for an Expeditioner permanent, put it onto the battlefield, then shuffle.
```

[card implementation](/custom/cards/zDevelopment/expedition_70.txt)

### Design Notes

 - Journal is a story of an Expedition that made it inside the Monolith in the final few days of their lifetimes and installing grapple points for those who come after.
 - 21/09/2025: This is an enabler engine for Expeditioner tribal strategies

## For Those Who Come After

```
(W/U)(W/U)
Kindred Sorcery - Expeditioner
Create 3 Lumina tokens if {U} was spent to cast this spell. Create 2 Chroma tokens if {W} was spent to cast this spell.
```

[card implementation](/custom/cards/f/for_those_who_come_after.txt)

### Design Notes

 - Just another Chroma/Lumina token strategy enabler

## Gommage

```
3WB
Sorcery
This spell costs {1} less to cast if you control a painter.
Exile all nonland permanents that aren't legendary or Nevrons.
```

[card implementation](/custom/cards/g/gommage.txt)

### Design Notes

 - In the game, the Gommage is a yearly event where people above a certain age (indicated on the Monolith) are erased from existence. It is also a gradient attack power that Maelle gains in the late game that can deal extreme singular damage.
 - Mechanically, this is easily a mass exile effect. It spares legendaries and Nevrons as this event only affects the humans of the continent.
 - Has painter's discount as this is clearly a power wielded by the painters.

## Lancelier

```
1(W/G)
Creature - Nevron
First Strike.
When this creature dies, target opponent creates a Lumina token.

2/2
```

[card implementation](/custom/cards/l/lancelier.txt)

### Design Notes

 - Another generic vanilla Nevron to round out the creature roster for limited/draft.
 - In game, Lancelier's wield a lance. So clearly this should have First Strike.

## Leave this Canvas!

```
1WB
Sorcery
This spell costs {1} less to cast if you control a painter.
Exile target nonland permanent.
```

[card implementation](/custom/cards/l/leave_this_canvas.txt)

### Design Notes

 - One of Maelle's quotes as she's about to gommage some sorry Nevron out of existence.
 - Painter bonus because this is a painter's power.

## Maelle, Child of Lumiere // Maelle, The Reawakend Paintress

```
Legendary Creature - Human Expeditioner
{2}: If you both own and control Maelle, Child of Lumiere and a creature named Alicia Dessendre, Silenced by Fire, exile them, then meld them into Maelle, The Reawakened Paintress.
```

Melds into ...

```
Legendary Planeswalker - Maelle
Human spells you cast cost {1} less to cast.
[+2]: Create a Chroma Token.
[+1]: Return target Human from your graveyard or in exile and put it onto the battlefield tapped.
[0]: Create two 1/1 White Human Expeditioner tokens with "When this creature dies, create a Chroma token".
[-3]: Exile target nonland, non-Human permanent.
[-8]: Return all Humans from your graveyard onto the battlefield.
```

[card implementation](/custom/cards/zDevelopment/maelle_child_of_lumiere_maelle_the_reawakened_paintress.txt)

### Design Notes

 - In the game, Maelle is Alicia painted over and reborn when she enters the canvas. After the ending of Act 2, Maelle is gommaged and returns with the memories of Alicia coming back and her paintress origins and powers re-discovered.
 - Mechanically, it's no-brainer we have to represent (Act 3) Maelle as a planeswalker and that we use the Meld mechanic to combine Alicia and (pre-Act 3) Maelle into this planeswalker.
    - Human Maelle's abilities TBD. I've mainly been focusing on nailing down the meld interaction first. Having limited success so far, thus this card currently does not work. I have been using The Mightstone and Weakstone + Urza, Lord Protector as the initial template.
    - If I can get the meld interaction to finally work and if Forge's rule engine will allow for it, I'd like to try to get the meld to trigger off of Maelle being exiled (for maximum flavor). If this is not feasible, then we'll stick with the existing activation cost.
    - Planeswalker Maelle's abilities for the most part map to her in-game abilities:
       - +2: She now has greater mastery of Chroma in the canvas
       - +1: She now has the power of reanimating dead expeditioners to fight for her
       - 0: Same theme of reanimating/rallying dead expeditioners to her cause
       - -3: She now has the power to erase enemies from the canvas
       - -8: Same theme of reanimating/rallying dead expeditioners to her cause

## Painted Clea, the Mistress

```
2UB
Legendary Creature - Painter God
Devoid
Nevron spells you cast cost {2} less to cast.
Nevron creatures you control get +2/+2
At the beginning of your upkeep, create a 1/1 colorless Nevron creature token.
{5},{T}: Search your library for a Nevron card, reveal that card and put it into your hand.

3/4
```

[card implementation](/custom/cards/p/painted_clea_the_mistress.txt)

### Design Notes

 - In the game, Painted Clea was painted by Aline, but was then repainted over by the real Clea and re-purposed to be what amounts to an endless "Nevron factory"
 - Mechanically, Painted Clea is our Nevorn lord, so I've gone with an assortment of "build around" abilities.
    - Nevron cost reduction
    - Nevron P/T buffs
    - Ability to put out Nevron tokens automatically every upkeep
    - A Nevron tutoring ability
 - NOTE: This is not the Clea Planeswalker so Francois does not have affinity towards it. Nothing in the actual game suggests Francois has any affection towards Clea's painted counterpart.


## Reaper Cultist

```
2WB
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.

1/4
```

[card implementation](/custom/cards/r/reaper_cultist.txt)

### Design Notes

 - Vanilla placeholder Nevron

## Serpenphare

```
5UR
Legendary Creature - Nevron Serpent
Flying. Ward 3.
{1}{U}: Tap target creature and put a stun counter on it. Put a charge counter on this creature.
{4}{R}, Remove X charge counters from Serpenphare: Serpenphare deals X damage to each creature.

7/7
```

[card implementation](/custom/cards/s/serpenphare.txt)

### Design Notes

 - In the game, Serpenphare is an optional end-game boss. Its most prominent attack is an AP draining ability, if it consumes too much AP with this move, it will explode.
 - Mechanically, we modeled the AP draining ability as a tap and stun with a charge counter being given. The "explode" ability is modeled as removing X charge counters to X damage to every creature (including itself)

## The Greatest Expedition In History

```
WUBRG
Sorcery
You win the game if you control a total of 33 or more Expeditioners, Chroma, Lumina or Pictos permanents.
```

[card implementation](/custom/cards/t/the_greatest_expedition_in_history.txt)

### Design Notes

 - If you're doing nothing with these Chroma and Lumina tokens being generated then this spell is a goal to reach towards.
 - This card also let's us do something with the number 33, which has great symbolic significance in the game.

## Tomorrow Comes

```
2(U/W)
Kindred Sorcery - Expeditioner
Search your library for an Expeditioner card, reveal it and put it into your hand, then shuffle.
```

[card implementation](/custom/cards/zDevelopment/tomorrow_comes.txt)

### Design Notes

 - Another tutor to enable the Expeditioner tribal strategy / Expeditoner spell toolbox.

## Void Meteors

```
2BR
Sorcery
Devoid
This spell costs {2} less to cast if you control a painter.
This spell deals 4 damage divided as you choose among any number of targets
```

[card implementation](/custom/cards/v/void_meteors.txt)

### Design Notes

 - In the game, this is one of the Paintress' moves in the boss fight with her.
 - Mechanically, I based this on Pyrotechnics, but moved to Rakdos colors and with a Painter's discount.

## Whee // Whoo

```
Whee
1WU
Instant
Untap all creatures you control.

Whoo
1UB
Instant
Tap all creatures your opponents control. They don't untap during their controllers' next untap steps.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](/custom/cards/w/whee_whoo.txt)

### Design Notes

 - In the game, Esquie describes his moods as sometimes being Whee (happy) and sometimes being Whoo (sad)
 - Mechanically, I based Whoo on Melancholy, but for all creatures. Once I got the Whoo part down, the Whee part is obviously the opposite effect. And since sometimes one can feel a little bit of Whee and a little bit of Whoo, I've added the Fuse ability so that both halves can be cast at once.

## When One Falls // We Continue

```
when One Falls
3W
Sorcery
Return to the battlefield, all Expeditioners that were put there from the battlefield this turn.

We Continue
4U
Sorery
Take an extra turn after this one.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](/custom/cards/w/when_one_falls_we_continue.txt)

### Design Notes

 - In the game. "When one falls, we continue" is the expeditioner's motto. To strive onwards and continue, no matter what setbacks.
 - Mechanically:
    - "When one falls" evokes in my mind an effect akin to Second Sunrise, so I've based it on that but scoped to Expeditioners
    - "We continues" evokes in my mind a Time Walk effect.