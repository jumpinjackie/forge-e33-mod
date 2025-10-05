# Cards

## A Storm is Coming

```
Kindred Sorcery - Expeditioner
Suspend 1—{U}{R} (Rather than cast this card from your hand, pay {U}{R} and exile it with one time counter on it. At the beginning of your upkeep, remove a time counter. When the last is removed, you may cast it without paying its mana cost.)

This spell deals 3 damage to any target.
Create a Lumina token.
```

[card implementation](/custom/cards/a/a_storm_is_coming.txt)

### Design Notes

 - Lighting bolt with suspend to convey the "storm is coming". Lumina reward as standard with any Expeditioner spell

## Alicia Dessendre, Silenced by Fire

```
WR
Legendary Creature - Human Painter
Activated abilities of Nevrons and Pictos cannot be activated.

2/2
```

[card implementation](/custom/cards/zDevelopment/alicia_dessendre_slienced_by_fire.txt)

### Design Notes

 - Gone with a targeted (Null Rod / Cursed Totem) effect to mechanically emphasize the "silence"
 - The real gimmick is melding with Maelle, Child of Lumiere. Meld is 100% the mechanic to sell the transformation
    - 23/09/2025: Getting meld to work has been nothing but failure. I give up. Alicia will now be standalone.

## Ballet

```
1(R/G)(R/G)
Creature - Nevron
Devoid (This card has no color.)
Flying.
When this creature dies, target opponent creates a Lumina token.

2/2
```

[card implementation](/custom/cards/b/ballet.txt)

### Design Notes

 - Another vanila Nevron. Flying because these things are hard to hit with melee attacks in the actual game.
 - 23/09/2025: Move color identity from white/green to red/green to make way for White Nevrons.

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
 - 23/09/2025: TODO: Replace white with a different color if intending to stay multi-color to make way for White Nevrons.

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

## Breaking Rules

```
(W/G)
Kindred Instant - Expeditioner
Kicker {2}.
Destroy target artifact or enchantment with mana value 2 lor less.
If this spell was kicked, destroy that artifact or enchantment if its mana value is 5 or less instaed.
```

[card implementation](/custom/cards/b/breaking_rules.txt)

### Design Notes

 - In the game, Breaking Rules is one of Maelle's abiliites.
 - For the card, I've disregarded all thematic/mechanical associations and designed the card only based on the name. We need cheap artifact/enchantment hate in this set, so I've turned this to a variant of Overload that can also hit enchantments.

## Chorale

```
1(R/G)
Creature - Nevron
Flying.
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.

2/1
```

[card implementation](/custom/cards/c/chorale.txt)

### Design Notes

 - Another vanilla Nevron
 - 5/10/2025: Switched PT from 1/2 to 2/1 for more offensive punch.

## Chroma is Flowing

```
(W/G)
Kindred Sorcery - Expeditioner
Create two Chroma tokens.
```

[card implementation](/custom/cards/c/chroma_is_flowing.txt)

### Design Notes

 - In the game, this is one of Lune's quotes during battle.
 - Went with 2 Chroma tokens, so it still ramps for strategies that can take advantage, but not to Dark Ritual levels.

## Chromatic Petrification

```
WB
Enchantment - Aura
Enchant permanent.
Enchanted permanent becomes an artifact and loses all abilities.
```

[card implementation](/custom/cards/c/chromatic_petrification.txt)

### Design Notes

 - Represents the effect inflicted on a good bunch of previous Expeditioners that turned them into statues with their Chroma trapped within.
 - I orignally wanted this to turn into a "do nothing" artifact, but I think the "Enchant creature" restriction means this is a nonbo and the aura immediately "falls off". Will revisit later with "Enchant permanent" to see if this gives my desired result.
    - Until then, I've gone with a 0/1 artifact creature.
    - 23/09/2025: Now enchanting permanents so we can achieve the "inert artifact" effect. A slight flavor loss since this can now target more than just creatures, but I am more after the petrification effect than it needing to only target creatures

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
    - For the clone ability, I preserved the original triggering condition but went against making token copies as that seemed really degenerate as the cloning trigger would also pass on to the tokens.

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

## Expedition 34 Mage

```
WUR
Creature - Human Expeditioner Wizard
{2}{W}: Tap target creature.
{2}{U}: Put a stun counter on target creature.
{2}{R}: This creature deals 1 damage to any target.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](/custom/cards/e/expedition_34_mage.txt)

### Design Notes

 - In the game, Expedition 34 was focused on an elemental strategy to exploit weaknesses in Nevrons. This strategy worked until they encountered Nevrons with no elemental weaknesses, at which point this expedition promptly failed.
 - Mechanically gone with a multi-color wizard with an appropriate on-color activated ability with standard Expeditioner death bonus.

## Expedition 41

```
1BR
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I, II - Destroy target Nevron.
III — Destroy all Nevrons. Create a Lumina token for each Nevron destroyed this way.
```

[card implementation](/custom/cards/e/expedition_41.txt)

### Design Notes

 - Journal is a story of expeditioners engaged in a competition to see who can kill the most Nevrons.
 - Obvious mechanical map to just killing Nevrons, and more Nevrons.

## Expedition 53 Herbalist

```
1(W/G)
Creature - Human Expeditioner Cleric
Mercy Kill - Sacrifice an Expeditioner creature: You gain X life and scry X, where X is the sacrified creature's power.
When this creature dies, create a Chroma token.

1/2
```

[card implementation](/custom/cards/e/expedition_53_herbalist.txt)

### Design Notes

 - In the game, members of Expedition 53 mercy-killed a fellow expeditioner whose injuries had left them in a coma.
 - This card represents one such member.
 - Mechanically mapped to an Expeditioner sac ability for lifegain + scry

## Expedition 59

```
BG
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Destroy target Nevron. Create a Food token.
II — Create 2 Food tokens.
III — Until end of turn, Food tokens you control gain "Sacrifice this artifact: Target creature deals 3 damage to itself"
```

[card implementation](/custom/cards/e/expedition_59.txt)

### Design Notes

 - Journal is a story of Expeditioners making the fatal mistake of eating dead nevrons for sustenance
 - "Food poisoning" ability adapted from Asmoranomardicadaistinaculdacar's ability

## Expedition 59 Chef

```
1(B/G)
Creature - Human Expeditioner
Whenever a Nevron creature dies, create a Food token.
Sacrifice a Food token: Target creature deals 3 damage to itself.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](/custom/cards/e/expedition_59_chef.txt)

### Design Notes

 - In the game, Expedition 59 attempted to eat dead Nevrons for sustenance.
 - This card represents the genius who suggested such an idea.
 - Has strong mechanical similarity to Asmoranomardicadaistinaculdacar so has the same "food poisoning" ability.
 - 5/10/2025: Reduced cost from 2(B/G) to 1(B/G)

## Expedition 60

```
2WG
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Un-modified creatures you control gain vigilance until end of turn.
II — Un-modified creatures you control gain vigilance and menace until end of turn.
III — Un-modified creatures you control gain vigilance, menace, trample and +3/+3 until end of turn.
```

[card implementation](/custom/cards/e/expedition_60.txt)

### Design Notes

 - Journal is a story of expeditioners who almost succeeded in their mission through raw human strength and discovered the true enemy is not The Paintress, but someone underneath the Monolith, but this realization came too late as they were claimed by the Gommage before this discovery could be relayed back the citizens of Lumiere.
 - Mechanically mapped to giving various offensive buffs to un-modified creatures with an overrun with extras on the final chapter. Only buffs un-modified creatures because these giga-chads don't have use for pithy things like clothing and armor.
 - 30/09/2025: Changed from 1RG to 2WG, double strike -> vigilance, hexproof -> menance. Original card was too powerful wtih "go wide" strategies

## Expedition 63 Driver

```
1(W/R)
Creature - Human Expeditioner Pilot
This creature saddles Mounts and crews Vehicles as though its power were 2 greater.
When this creature dies, create a Chroma token.

2/2
```

### Design Notes

 - In the game, Expedition 63 employed the use of automobiles to traverse the continent. This expedition failed when their vehicles crashed into a Nevron for driving too fast.
 - This card models such a driver.

## Expedition 67 Demolitions Expert

```
2BR
Creature - Human Expeditioner
Flash.
When this creature enters, destroy target creature or artifact.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](/custom/cards/e/expedition_67_demolitions_expert.txt)

### Design Notes

 - In the game, Expedition 67 employed the use of explosives to tear down walls in Sirene's coliseum. They succumbed to Sirene's musical wiles.
 - This card models one such crew member.

## Expedition 70

```
2WU
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I, II — Search your library for an Expeditioner card, reveal it and put it into your hand, then shuffle.
III — Search your library for an Expeditioner permanent, put it onto the battlefield, then shuffle.
```

[card implementation](/custom/cards/zDevelopment/expedition_70.txt)

### Design Notes

 - Journal is a story of an Expedition that made it inside the Monolith in the final few days of their lifetimes and installing grapple points for those who come after.
 - 21/09/2025: This is an enabler engine for Expeditioner tribal strategies

## Expedition 78 Aircrew

```
2(W/U)(W/U)
Flying.
This creature can block only creatures with Flying.
When this creature dies, create a Chroma token.

4/4
```

### Design Notes

## Expedition 81 Interpreter

```
2(W/U)
Creature - Human Expeditioner Wizard
You may choose not to untap this creature during your untap step.
Nevron Whisperer - {2},{T}: Gain control of target Nevron creature for as long as this creature remains tapped.
When this creature dies, create a Chroma token.

1/2
```

### Design Notes

## For Those Who Come After

```
(W/U)(W/U)
Kindred Sorcery - Expeditioner
Create 3 Lumina tokens if {U} was spent to cast this spell. Create 2 Chroma tokens if {W} was spent to cast this spell.
```

[card implementation](/custom/cards/f/for_those_who_come_after.txt)

### Design Notes

 - Just another Chroma/Lumina token strategy enabler

## Gestral Foot Race Challenge

```
(R/G)
Enchantment
Whenever a creature enters, you may put a quest counter on this enchantment.
Bronze Rank - As long as there are three or more quest counters on this enchantment, creatures you control have haste.
Silver Rank - As long as there are four or more quest counters on this enchantment, creatures you control have Ward 1.
Gold Rank - As long as there are five or more quest counters on this enchantment, creatures you control have trample.
```

[card implementation](/custom/cards/g/gestral_foot_race_challenge.txt)

### Design Notes

 - In the game, the Gestral Foot Race Challenge is 1 of 5 challenge minigames. This minigame in particular requires clearing an obstacle course in under a certain amount of time. There are 3 ranks the player can achieve based on how fast they cleared the course.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - Went with a simple creature entering as the trigger condition, with 3 different "ranks" of various buffs as payoffs.

## Gestral Parkour Challenge

```
(W/R)
Enchantment
Whenever a Human you control enters, you may put a quest counter on this enchantment.
As long as this enchantment as two or more counters, creatures you control gain vigilance.
As long as this enchantment as three or more counters, creatures you control gain prowess.
```

[card implementation](/custom/cards/g/gestral_parkour_challenge.txt)

### Design Notes

 - In the game, the Gestral Parkour Challenge is 1 of 5 challenge minigames. This minigame in particular requires clearing an obstacle course and answering a riddle at the end.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - Made the enter trigger human only to make this more Expeditioner-aligned.

## Gestral Raft Volleyball Challenge

```
(U/R)
Enchantment
Whenever a creature you control becomes the target of a spell or ability, you may put a quest counter on this enchantment.
Normal Difficulty - As long as this enchantment has three or more quest counters on it, whenever a creature you control becomes the target of a spell or ability, draw a card.
Hard Difficulty - {U/R}{U/R}: You may choose new targets for target spell or ability. Activate this ability only if this enchantment has five or more quest counters on it.
```

[card implementation](/custom/cards/g/gestral_raft_volleyball_challenge.txt)

### Design Notes

 - In the game, the Gestral Raft Volleyball Challenge is 1 of 5 challenge minigames. This minigame in particular requires playing a game of volleyball on a raft against a Sakapatate. Failure to parry a flung gestral back at the Sakapatate will damage your raft. After a certain amount of hits, the raft will explode and you'll lose the minigame, unless you do it to the Sakapatate first.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - Went with any of your creatures being targeted as the triggering condition as that best describes gestrals being flung at you.
 - First payoff is card draw. Second (and more flavorful) payoff is to be able to redirect opponent's spells and abilities to signify the mastery of parrying flung gestrals back at the opponent.
 - 5/10/2025: Cost reduced from (U/R)(U/R) to (U/R) in line the other challenge enchantments

## Gradient Charge

```
2(W/B)
Sorcery - Gradient
This spell costs {1} less to cast if you control a Painter.
Search your library for a Gradient card, reveal that card, put it into your hand, then shuffle.
```

[card implementation](/custom/cards/zDevelopment/gradient_charge.txt)

### Design Notes

 - In the game, Gradient attacks are "Epic" tier attacks. To use such attacks you need to fill up a Gradient gauge. The Gradient gauge holds up to 3 charges. Gradient attacks cost anywhere between 1 to 3 charges.
 - Mechanically, this is just a Gradient spell tutor to assist in Painter-based strategies.

## Gommage

```
3WB
Sorcery - Gradient
This spell costs {1} less to cast if you control a painter.
Exile all nonland permanents that aren't legendary or Nevrons.
```

[card implementation](/custom/cards/g/gommage.txt)

### Design Notes

 - In the game, the Gommage is a yearly event where people above a certain age (indicated on the Monolith) are erased from existence. It is also a gradient attack power that Maelle gains in the late game that can deal extreme singular damage.
 - Mechanically, this is easily a mass exile effect. It spares legendaries and Nevrons as this event only affects the humans of the continent.
 - Has painter's discount as this is clearly a power wielded by the painters.

## Gustave, Lumiere Engineer

```
1W(U/R)
Legendary Creature - Human Expedition Engineer
Whenever Gustave becomes untapped, attacks or blocks, put a charge counter on him.
Marking Shot - {R},{T}: Gustave deals 1 damage to target creature. Put a marked counter on it.
From Fire = {W}{R},{T}: Gustave deals 3 damage to target creature, you gain 3 life.
Strike Storm - {W}{R}: Gustave gains double-strike until ene of turn, put two charge counters on him. Activate only once per turn.
Overcharge - {T}, Remove X charge counters from Gustave: Gustave deals X damage to target creature and that creature's controller.

3/2
```

[card implementation](/custom/cards/g/gustave_lumiere_engineer.txt)

### Design Notes

 - Key mechanical gimmick we want to replicate from the game is his overcharge ability, which obviously requires charge build up. We had a choice between energy counters or charge counters. We settled on charge counters as energy counters are a global resource, whereas charage counters would be a resource localized to Gustave himself.
 - Marking shot is just a creature ping that puts a marked counter on it. A creature with a marked counter will be a magnet for more damage.
 - From fire in the game is an ability that heals Gustave a bit if the target is burning. Translated this to a creature bolt + life gain.
 - Strike storm in the game is just a flurry of strikes. Translated this to temporary double strike.
 - Finally, overcharge (the ability we're all building towards) in the game deals high lightning damage based on the number of charges. Translated this to an X damage ability to a creature and its controller (where X is the number of charge counters removed).
 - 23/09/2025: It may look a bit odd to have blue color identity but no actual abilities that cost blue mana. I added the blue color identity strictly for flavor purposes because he's an engineer and engineers are almost always a blue color identity.

## Lampmaster

```
4WB
Legendary Creature - Nevron Horror
Flying. Ward 3.
Ball of Light - {2}{W},{T}: Tap up to three target creatures. They lose all abilities until end of turn.
Sword of Light - {2}{W}{B},{T}: Separate creatures target opponent controls into two separate piles. That opponent chooses a pile. Destroy all creatures in that pile. Creatures in the other pile have base toughess 1 until end of turn.

4/4
```

[card implementation](/custom/cards/l/lampmaster.txt)

### Design Notes

 - In the game, this is the final boss of Act 1.
 - Ball of Light: In the game The Lampmaster gathers light energy in a sphere and then releases it as a horizontal wave, inflicting Silence upon contact.
    - Translated to an effect that taps multiple creatures and giving them temporarily humility.
 - Sword of Light: In the game, The Lampmaster creates a large blade from light and swings it four times, dealing massive damage to the whole party and inflicting Blight.
    - Translated to a Fact or Fiction style "split into 2 piles" effect where opponent choose the pile to be destroyed and the other pile will all have toughness of 1 until end of turn (which is how I interpret the blight effect).

## Leave this Canvas!

```
1WB
Sorcery - Gradient
This spell costs {1} less to cast if you control a painter.
Exile target nonland permanent.
```

[card implementation](/custom/cards/l/leave_this_canvas.txt)

### Design Notes

 - One of Maelle's quotes as she's about to gommage some sorry Nevron out of existence.
 - Painter bonus because this is a painter's power.

## Maelle, Child of Lumiere

```
1WR
Legendary Creature - Human Expeditioner

3/3
```

[card implementation](/custom/cards/zDevelopment/maelle_child_of_lumiere_maelle_the_reawakened_paintress.txt)

### Design Notes

 - In the game, Maelle is Alicia painted over and reborn when she enters the canvas. After the ending of Act 2, Maelle is gommaged and returns with the memories of Alicia coming back and her paintress origins and powers re-discovered.
 - Mechanically, it's no-brainer we have to represent (Act 3) Maelle as a planeswalker and that we use the Meld mechanic to combine Alicia and (pre-Act 3) Maelle into this planeswalker.
    - Human Maelle's abilities TBD. I've mainly been focusing on nailing down the meld interaction first. Having limited success so far, thus this card currently does not work. I have been using The Mightstone and Weakstone + Urza, Lord Protector as the initial template.
    - If I can get the meld interaction to finally work and if Forge's rule engine will allow for it, I'd like to try to get the meld to trigger off of Maelle being exiled (for maximum flavor). If this is not feasible, then we'll stick with the existing activation cost.
 - 23/09/2025: I give up trying to get meld to work. Human Maelle will remain a standalone card. Abilities TBD. 

## Maelle, The Reawakend Paintress

```
3WB
Legendary Planeswalker - Maelle
Human spells you cast cost {1} less to cast.
[+2]: Create a Chroma Token.
[+1]: Return target Human from your graveyard or in exile and put it onto the battlefield tapped.
[0]: Create two 1/1 White Human Expeditioner tokens with "When this creature dies, create a Chroma token".
[-3]: Exile target nonland, non-Human permanent.
[-8]: Return all Humans from your graveyard onto the battlefield.
```

### Design Notes

 - 23/09/2025: Splitting this off to its own card. I *really* wanted this to be the meld target of Maelle and Alicia for maximum flavor, but Forge simply would not cooperate with me.
 - Planeswalker Maelle's abilities for the most part map to her in-game abilities:
   - +2: She now has greater mastery of Chroma in the canvas
   - +1: She now has the power of reanimating dead expeditioners to fight for her
   - 0: Same theme of reanimating/rallying dead expeditioners to her cause
   - -3: She now has the power to erase enemies from the canvas
   - -8: Same theme of reanimating/rallying dead expeditioners to her cause
 - 25/09/2025: I'd thought about maybe an alternative cost of saccing Alicia and Human Maelle as an alternative way to "meld". But I don't think Forge supports saccing 2 cards with different qualities (name) as there is no pre-existing card with such an alternate cost and the #1 way to determine the feasibility of implementing a card a certain way is if there is a pre-existing card that does something similar.

## Manor Entrance // Manor Hidden Room

```
Manor Entrance
3G
Enchantment - Room
When you unlock this door, you may put a creature card from your hand onto the battlefield.

Manor Hidden Room
3B
Enchantment - Room
When you unlock this door, return target creature card from your graveyard to the battlefield.
```

[card implementation](/custom/cards/m/manor_entrance_manor_hidden_room.txt)

### Design Notes

 - In the game, the Manor entrance is there the expedition flag is to save. There is room that is hidden behind a painting that is accessible by jumping through the painting.
 - Gone with an effect to cheat a creature into play with each side represent a different way to cheat said creature into play.

## Manor Greenhouse // Manor Gallery

```
Manor Greenhouse
2G
Enchantment - Room
When you unlock this door, search your library for a land card, put it onto the battlefield, then shuffle.

Manor Gallery
2U
Enchantment - Room
Painter and Gradient spells you cast cost {1} less to cast.
```

[card implementation](/custom/cards/m/manor_greenhouse_manor_gallery.txt)

### Design Notes

 - In the game, the Greenhouse is at the top of the Manor. The gallery is the room with Verso's canvas (that the world of the continent is in)
 - Greenhouse is a land tutor, because it's ... green!
 - Gallery is another cost reducer to enable painter strategies
 - 3/10/2025: Might rename Manor Gallery to Manor Atelier. I haven't played the video game in months, so I forget if the Atelier is where Verso's canvas resides so Gallery is a placeholder name. Either way this is supposed to be "Manor $ROOM_THAT_HAS_VERSOS_CANVAS"

## Manor Kitchen // Manor Cellar

```
Manor Kitchen
1G
Enchantment - Room
When you unlock this door, create two Food tokens.

Manor Cellar
1W
Enchantment - Room
When you unlock this door, choose one:
 - Create two Chroma tokens.
 - Create two Lumina tokens.
```

[card implementation](/custom/cards/m/manor_kitchen_manor_cellar.txt)

### Design Notes

 - In the game, the Kitchen connects to the entrance. The cellar is accessible after solving a puzzle in the kitchen.
 - Kitchen is an easy mechanical map to food tokens.
 - Cellar I've decided to mechanically map to Chroma/Lumina tokens as that is some of the loot that's available in the game.

## Manor Library // Manor Fireplace

```
Manor Library
2U
Enchantment - Room
When you unlock this door, draw two cards.

Manor Fireplace
1R
Enchantment - Room
When you unlock this door, it deals 3 damage to any target.
```

[card implementation](/custom/cards/m/manor_library_manor_fireplace.txt)

### Design Notes

 - In the game, the library connects the entrance on the side. The fireplace connects to the main dining hall.
 - Library is an easy mechanical map to card draw.
 - Fireplace is an easy mechanical map to a bolt effect because ... fireplace > fire > burn spell.

## Monoco, Collector of Feet

```
2(W/G)(W/G)
Legendary Artifact Creature - Gestral
Whenever a nontoken Nevron creature dies, exile it with a Foot counter.
My, what lovely feet! - Monoco has activated abilities of all Nevrons in exile with a Foot counter on them. Monoco has flying as long an exiled Nevron creature with a Foot counter has flying. The same is true for first strike, double strike, deathtouch, haste, hexproof, indestructible, lifelink, meance, reach, trample and vigilance.
{1}{G},{T}: Monoco fights target creature.
{2}{W}: Untap Monoco.

4/4
```

[card implementation](/custom/cards/m/monoco_collector_of_feet.txt)

### Design Notes

 - In the game, Monoco is a Gestral that joins your party in Act 2. Every Nevron you defeat with Monoco in the party will add a foot to Monoco's collection. Monoco's skills are based on the Nevron feet that Monoco has equipped. Each Nevron foot grants some ability of the defeated Nevron.
 - Mechanically and flavorfully, this easily maps to one of the many existing "ability stealing" cards already in the card game. So it is a matter of choosing which ability stealing variant we want to copy from. We've gone with a combination of stealing activated abilities of slain Nevron along with a bunch of keyword abilities.
 - Exile with a Foot counter is a book-keeping mechanism to easily track which creatures Monoco will be stealing abilities from.
 - Fight ability provided because Monoco is a Gestral, and Gestrals love to fight, and also serves as an enabler for ability stealing.
 - The untap ability is provided for synergy with any tap activated abilities that Monoco may steal.

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

## Rally the Expeditioners

```
3(W/B)
Kindred Instant - Expeditioner
This spell costs {1} less to cast if you control an Expeditioner.
Choose one:
 - Create two 1/1 white Human Expeditioner tokens with "When this creature dies, create a Chroma token".
 - Up to two target creatures you control each get +2/+2 until end of turn.
 - Destroy target non-Expeditioner creature.
```

[card implementation](/custom/cards/r/rally_the_expeditioners.txt)

### Design Notes

 - In the game, this symbolizes the moment where re-awakened Maelle arrives in Lumiere with party and resurrected Expeditioners to commence the final assault.
 - Made this a variant of Rally the Monastery with Expeditioner-aligned benefits.

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

## Sciel, Grieving for Many

```
2WB
Legendary Creature - Human Expeditioner
Each nonland card in your hand without foretell has foretell. Its foretell cost is equal to its mana cost reduced by {2}. (During your turn, you may pay {2} and exile it from your hand face down. Cast it on a later turn for its foretell cost.)
Whenever you fortell a card, you gain 2 life.
Marking Card - {B},{T}: Sciel deals 1 damage to target creature, put a marked counter on it.
Grim Harvest - {W}{B},{T}: Sciel deals 3 damage to target creature. You gain 3 life.
Intervention - {W}{W},{T}: Untap target creature. Create a Chroma token.
Our Sacrifice - {1}{B}{B},{T}, Pay X life: All creatures target opponent controls get -X/-X until end of turn.

3/3
```

[card implementation](/custom/cards/s/sciel_grieving_for_many.txt)

### Design Notes

 - Sciel is a kind, emphatheic, nurturing character that specializes in weapons and attacks that deal dark damage. Clearly an Orzhov color identity.
 - In the game, Sciel's attacks build up foretell, which can then be consumed later on for even more powerful attacks. We are using Foretell in the *literal* sense by re-using the existing Foretell mechanic by having Sciel granting all nonland cards in your hand to be foretelled.
 - Marking Card is just a creature ping that puts a marked counter on it. A creature with a marked counter will be a magnet for more damage.
 - Grim Harvest deals dark damage heals allies. Translated to a creature bolt that also gives you life.
 - Intervention in the game lets an ally play immediately and gain 4 AP. Translated to untapping a creature and giving you a Chroma token.
 - Our Sacrifice in the game deals extreme dark damage to all enemies, absorbing allies' health to deal more damage. Translated to paying X life to -X/-X an opponent's board.

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
Kindred Sorcery - Expeditioner
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

[card implementation](/custom/cards/t/tomorrow_comes.txt)

### Design Notes

 - Another tutor to enable the Expeditioner tribal strategy / Expeditioner spell toolbox.

## Void Meteors

```
2BR
Sorcery - Gradient
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
4W
Sorcery
Return all Expeditioner permanent cards from your graveyard to the battlefield.

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
    - "We continue" evokes in my mind a Time Walk effect.
 - 23/09/2025: I will most likely change the "When One Falls" side to be a straight mass Expeditioner reanimation effect instead of one that only reanimates those that died this turn, which would make it more of a game-swinging bomb when cast fused, because if you are able to resolve this fused, you deserve to win the game at that point.
 - 3/10/2025: Changed "When one Falls" side to a straight mass Expeditoner reanimation effect and bumped cost from 3W to 4W