# Cards

> Last generated: 22/11/2025 10:26:30 am

## Anti-Burn Picto

```
1
Artifact - Picto Equipment
Equipped creature has protection from red.
Equip {2}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/a/anti_burn_picto.txt)

### Design Notes

 - In the game, Anti-Burn grants immunity to Burn.
 - Easy mechanical map to protection from red.

## Anti-Freeze Picto

```
1
Artifact - Picto Equipment
Equipped creature has protection from blue.
Equip {2}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/a/anti_freeze_picto.txt)

### Design Notes

 - In the game, Anti-Freeze grants immunity to freeze
 - Easy mechanical map to protection from blue.

## Attack Lifesteal Picto

```
2
Artifact - Picto Equipment
Equipped creature has +1/+1 and lifelink.
Equip {2}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/a/attack_lifesteal_picto.txt)

### Design Notes

 - In the game, Attack Lifesteal allows a character to recover 15% health on base attack.
 - Easy mechanical map to lifelink.

## Attack Picto

```
4
Artifact - Picto Equipment
When this equipment enters, choose two —
• Put an augmented counter on this equipment
• Put a combo counter on this equipment
• Put a energizing counter on this equipment
Equipped creature gets +3/+3 if this equipment has an augmented counter on it and has double strike if this equipment has a combo counter on it.
Whenever equipped creature attacks, if this equipment has a energizing counter on it, create a Chroma token and a Lumina token.
Equip {2}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/a/attack_picto.txt)

### Design Notes

 - In the game, Attack pictos come in many prefixed variants, that all grant some kind of bonus to the character when they perform a base attack.
 - This is the first of 3 "epic" tier pictos that are modeled on one of these pictos that have many prefixed variants.
 - This picto has an ETB trigger that lets you pick 2 out of 3 types of counters (variants) to put on this equipment. We're not modeling every variant/prefix from the video game because of text box budget constraints.
 - The picto then will grant various buffs and abilities based on the type of counter chosen, in this case:
     - Augmented: Gives +3/+3
     - Combo: Gives double strike
     - Energizing: Gives Chroma token when equipped creature attacks
 - The station mechanic from Edge of Eternities has given us the ideal template to base this card implementation from as the buffs and abilities granted based on counter type follow the same pattern as buffs and abilities based on the number of charge counters in the station mechanic, only we're more finicky about the specific type of counter.
 - This is a slight deviation from the video game lore as we're effectively smushing 3 (in-game depicted) Pictos into one. But we are doing this for a good reason. Pictos indvidually are somewhat dull when translated to MTG mechanics. The replication gimmick is unique, but it ultimately still is just provides some basic buff or combat-related ability. This modal design allows us to strategically choose the best buffs/abilities for any given situation, with the replication ability allowing one to cover all bases ability-wise.
 - 11/11/2025: Made energizing counter mode also reward a Lumina token.

## Berrami, Collector of Journals

```
3
Legendary Artifact Creature - Gestral
At the beginning of your upkeep, you may mill a card. If you do, create two Lumina tokens. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")
---
You found all the journals? Moshi will be so happy.

2/2
```

[card implementation](../custom/cards/b/berrami_collector_of_journals.txt)

### Design Notes

 - In the game, Berrami is an NPC you can turn in journals for colors of lumina.
 - Mechanically, I've translated this to milling cards from your library for lumina tokens.

## Cheater Picto

```
3
Artifact - Picto Equipment
Untap equipped creature during each other player's untap step.
Equip {2}
Sacrifice three Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/c/cheater_picto.txt)

### Design Notes

 - In the game, Cheater allows a character to play (take turns) twice.
 - Easy mechanical map to untapping equipped creature on other's turns.

## Chroma Catalyst

```
3
Artifact
If you would create a Chroma or Lumina token, instead create one of each.
---
Exponentially useful.
```

[card implementation](../custom/cards/c/chroma_catalyst.txt)

### Design Notes

 - In the game, Chroma Catalysts are used to upgrade the levels of your weapons
 - For the card, we've decided to lean heavily on the word "Catalyst" and made this into a variant of Academy Manufactor, but covers our new token types.
 - We might revisit the design of this card if this assembles the 33+ token requirement for The Greatest Expedition In History too quickly.

## Chroma Filter

```
2
Artifact
When this artifact enters, draw a card.
{1}, {T}: Add one mana of any color.
{T}, Sacrifice a Chroma token: Add two mana of any one color.
Luminous — {T}: Add one mana of any color. Activate this ability only if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/c/chroma_filter.txt)

### Design Notes

 - This card has no in-game basis. Just an artifact to provide color fixing and some minor ramp if you hava Chroma tokens to spare.
 - 13/11/2025: Added Luminous bonus.

## Death Picto

```
3
Artifact - Picto Equipment
When this equipment enters, choose two —
• Put a burning counter on this equipment.
• Put a energizing counter on this equipment.
• Put a shielding counter on this equipment.
When equipped creature dies, it deals 4 damage to any target if this equipment has a burning counter, create a Chroma token and a Lumina token if this equipment has an energizing counter and put a shield counter on each creature you control if this equipment has a shielding counter.
Equip {2}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/d/death_picto.txt)

### Design Notes

 - In the game, Death pictos come in many prefixed variants, that all do something when the equipped character dies.
 - This is the second of 3 "epic" tier pictos that are modeled on one of these pictos that have many prefixed variants.
 - See Attack Picto for original design motivation for these "epic" tier pictos.
 - The picto will trigger on equipped creature's death and will do the following based on the type of counters chosen, in this case:
    - Burning: Shoot any target for 4 damage
    - Energizing: Reward a Chroma + Lumina token
    - Shielding: Gives a shield counter to each creature you control

## Dessendre Family Portrait

```
3
Artifact
Painter and Gradient spells you cast cost {1} less to cast.
{T}: Add one mana of any color. Spend this mana only to cast a Painter or Gradient spell.
{3},{T}: Search your library for a Painter card, reveal it and put it into your hand, then shuffle.
---
One family, united by passion for art, divided by grief.
```

[card implementation](../custom/cards/d/dessendre_family_portrait.txt)

### Design Notes

 - In the game, this is an optional quest item which if collected and installed at the Manor, will unlock a room.
 - Mechanically, this is just another enabler for Painter/Gradient magic strategies.

## Dominique Giant Feet

```
4
Legendary Artifact Creature - Gestral
Trample
{2}: Put a flying counter on Dominique Giant Feet.
Two-handed slam — {2}, {T}, Remove a flying counter from Dominique Giant Feet: Dominique Giant Feet deals 4 damage to target creature.
At the beginning of each end step, remove all flying counters on Dominique Giant Feet.


4/4
```

[card implementation](../custom/cards/d/dominique_giant_feet.txt)

### Design Notes

 - In the game, Dominique is a fighter in the Hidden Gestral Arena
 - With the two-handed slam ability Dominique leaps into the air and slams the opponent. I've mechanically translated this to giving Dominique an ability to add a flying counter (the jump) and another ability to deal the damage at the cost of some mana and removing a flying counter (the slam).
 - The end step removing all flying counters trigger is insurance against "banking" excess flying counters.
 - We use flying counters as opposed to temporarily granting the flying keyword as flying counters are logistically simpler to manage.

## Dorrie

```
1
Legendary Artifact - Rock
{T}: Target creature you control gains Trample until end of turn.
{1}, Sacrifice Dorrie: Draw a card.
---
Doesn't that look like one of Esquie's stones?
- Sciel
```

[card implementation](../custom/cards/d/dorrie.txt)

### Design Notes

 - In the game Dorrie is a quest item which will grant Esquie the ability to smash through coral barriers when swimming in the Continent overworld
 - In this set, Dorrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, Trample is the closet ability to "smashing through coral barriers"

## Energy Tint

```
2
Artifact
{T}: Add {C}.
Luminous — {T}: Add {C}{C}{C}. Activate this ability only if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/e/energy_tint.txt)

### Design Notes

 - In the game, Energy Tints help refill your party's AP during a battle or outside of battle when you're not near an Expedition flag.
 - Just a mana rock for this set.
 - Yes it may look dangerous to have a Grim Monolith with no downside, but you need some Lumina token investment first to take advantage, so there is some setup involved. The ideal turn 1 An Advantage!, turn 2 Energy Tint line is something I can accept as variance.

## Expedition 50 Ferris Wheel

```
5
Artifact - Expeditioner Vehicle
Trample.
Whenever this vehicle blocks or becomes blocked by a blue creature, destroy this vehicle at end of combat.
Crew 4
---
Apparently that was where people went on dates, you know.
- Sciel

6/6
```

[card implementation](../custom/cards/e/expedition_50_ferris_wheel.txt)

### Design Notes

 - In the game, Expedition 50 built a giant ferris wheel to traverse the waters of the continent, but Serpenphare stopped their progression.
 - This card depicts this contraption. Clearly a vehicle with fatty stats. The weakness to blue creatures in combat is a nod to Serpenphare being the wheel's achillies' heel.

## Expedition 64 Radio

```
4
Artifact - Expeditioner
Send Backup! - When this artifact enters, reveal the top four cards of your library. Put all Expeditioner cards revealed this way into your hand and the rest on the bottom of your library in any order.
{2}, Sacrifice this artifact: Draw a card.
```

[card implementation](../custom/cards/e/expedition_64_radio.txt)

### Design Notes

 - In the game, Expedition 64 used radio communications to keep in touch. The expedition started to collapse and eventually fail when their radio communications broke down.
 - I've interpreted the radio device as an artifact that has a ringleader effect when it ETBs to represent "calling for backup"

## Expedition Cache

```
2
Artifact
{T}, Sacrifice this artifact: Create two Lumina tokens.
{T}, Sacrifice this artifact: Create two Chroma tokens.
---
This could be useful!
- Gustave
```

[card implementation](../custom/cards/e/expedition_cache.txt)

### Design Notes

 - In the game, these caches are scattered throughout the continent, left by previous Expeditions "for those who come after"
 - Just an enabler for Lumina/Chroma token strategies

## Expedition Flag

```
3
Artifact
Expeditioner creatures you control get +1/+1.
{T}: Add one mana of any color.
---
Wanna plant it?
- Sciel, to Maelle
```

[card implementation](../custom/cards/e/expedition_flag.txt)

### Design Notes

 - In the game, Expedition flags are save points scattered throughout the continent laid down by previous Expeditions.
 - Gone with an Expeditioner-focused variant of Patchwork Banner.

## Florrie

```
1
Legendary Artifact - Rock
{T}: Target creature you control gains Islandwalk until end of turn.
{1}, Sacrifice Florrie: Draw a card.
---
See, Florrie helps me swim. But Florrie was stolen by my archnemesis!
- Esquie
```

[card implementation](../custom/cards/f/florrie.txt)

### Design Notes

 - In the game Florrie is a quest item which will grant Esquie the ability to swim in the Continent overworld
 - In this set, Florrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, Islandwalk is the closet ability to swimming

## Gestral Fighter

```
2
Artifact Creature - Gestral
Whenever this creature attacks, it gets +2/+0 until end of turn for each other attacking Gestral.
---
See, this here's where we come when we wanna go full brush-mode, you got me?

1/2
```

[card implementation](../custom/cards/g/gestral_fighter.txt)

### Design Notes

 - The Gestral version of Goblin Piledriver. If we want a viable Gestral tribal deck, it needs a "heavy hitter". This is the heavy hitter.
 - May increase cost to 3 in the future.

## Gestral Lackey

```
1
Artifact Creature - Gestral
Whenever Gestral Lackey deals damage to a player, you may put a Gestral permanent card from your hand onto the battlefield.

1/1
```

[card implementation](../custom/cards/g/gestral_lackey.txt)

### Design Notes

 - The Gestral version of Goblin Lackey

## Gestral Merchant

```
3
Artifact Creature - Gestral
Whenever this creature is dealt damage, create a Chroma token (It's an artifact with "{T}, Sacrifice this artifact: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.")
---
I have some useful items for you!

2/3
```

[card implementation](../custom/cards/g/gestral_merchant.txt)

### Design Notes

 - In the game, Gestral Merchants sell you various items. You can fight them to unlock additional items upon defeat
 - Mechanically, I went with rewarding you with Chroma tokens when it is dealt damage
 - 26/09/2025: Reduced reward to a single Chroma token, simply because Forge has no way to let me describe "up to this creature's toughness" in terms of the amount of Chroma tokens generated. Can still do fight tricks with weaklings to repeatedly generate tokens.

## Gestral Pot

```
2
Artifact
This artifact enters tapped.
{T}: Add {C}.
{2}: This artifact becomes a 2/2 Gestral artifact creature until end of turn.
---
"Someone's here."
"Is it Golgra?"
"Impossible! Golgra could never find us."
"Aww jeez, I just got reborn, I don't want to die again."
```

[card implementation](../custom/cards/g/gestral_pot.txt)

### Design Notes

 - Gestral version of Guardian Idol.
 - A mana rock to support the Gestral tribal strategy, while providing some extra offensive punch if required.
 - 13/10/2025: Formerly known as Gestral Statue. Renamed because Gestral Pots have an actual in-game basis. They are in front of the Dark Gestral Arena and a living Gestral is inside it.

## Gestral Ringleader

```
5
Artifact Creature - Gestral
Haste (This creature can attack and {T} as soon as it comes under your control.)
When this creature enters, reveal the top four cards of your library. Put all Gestral cards revealed this way into your hand and the rest on the bottom of your library in any order.

3/2
```

[card implementation](../custom/cards/g/gestral_ringleader.txt)

### Design Notes

 - Gestral version of Goblin Ringleader. A Gestral tribal deck needs at least one card that can provide raw card advantage. This is that card.

## Gestral Villager

```
2
Artifact Creature - Gestral

---
Expeditioners, eh? You're a fun looking bunch. Unless you try to cause problems. Then we'll beat you up. Which will be fun for me, but not for you.

2/1
```

[card implementation](../custom/cards/g/gestral_villager.txt)

### Design Notes

 - Just a vanilla Gestral to round out a Gestral tribal deck and to round out the creature roster for draft/limited

## Gestral Warrior

```
3
Artifact Creature - Gestral
This creature cannot attack or block alone.
---
You may come in.

3/3
```

[card implementation](../custom/cards/g/gestral_warrior.txt)

### Design Notes

 - In the game, Gestral Warriors reside in the Gestral Village.
 - Gestral version of Mogg Flunkies.
 - 18/10/2025: Downgraded PT from 4/3 to 3/3

## Gestral Worker

```
3
Artifact Creature - Gestral
This creature enters with a charge counter on it.
Sacrifice a Chroma token: Put a charge counter on this creature. Activate this ability only as a sorcery and only if this creature has less than three charge counters.
{2}, {T}: Target creature gets +1/+1 until end of turn for each charge counter on this creature.

1/2
```

[card implementation](../custom/cards/g/gestral_worker.txt)

### Design Notes

 - In the game, Gestral Workers reside in the Gestral Village.
 - Generally, any card with "worker" in its name either generates mana or buffs other creatures. Gone with buffing other creatures for this one.
 - Charging up is a way to spend any excess Chroma tokens you may have, but capped at 3 max so you can't overdo the buffing and is sorcery speed so you can't stack > 3 activations to bypass the limit.
 - 18/10/2025: Bumped pump activation cost from {1} to {2}

## Glass Cannon Picto

```
2
Artifact - Picto Equipment
Equipped creature can attack as though it didn't have defender and has base power and toughness 5/1
Equip {2}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/g/glass_cannon_picto.txt)

### Design Notes

 - In the game, Glass Cannon lets a chacter deal 25% more damage, but take 25% more damage as well.
 - Mapped to creature power pump at the expense of its toughness.
 - Granted defender exemption to incentivize equipping to Walls and other high toughness creatures that likely have defender.
 - 12/11/2025: Could not get the variable P/T pump to work, so gone with a flat 6/1 base P/T that conveys the same intent.
 - 15/11/2025: Changed base P/T from 6/1 to 5/1

## Golgra, Gestral Chief

```
5
Legendary Artifact Creature - Gestral
Other Gestral creatures you control get +2/+2
Enrage — Whenever Golgra is dealt damage, choose one —
• Put a Double strike counter on Golgra.
• Put a Vigilance counter on Golgra.
• Put a Trample counter on Golgra.
• Draw a card.
---
Really? A duel? Do you have a death wish?

5/6
```

[card implementation](../custom/cards/g/golgra_gestral_chief.txt)

### Design Notes

 - Obviously the Gestral lord of this set.
 - In the game, when Golgra gets below 50% health, she goes "Super Saiyan" and her attacks increase in power.
 - Mechanically, I've gone with Enrage as a way to approximate this "Super Saiyan" state and went with an assortment of combat-boosting abilities that could be granted from being enraged.

## Gustave's Journal

```
3
Legendary Artifact
Whenever a Nevron dies, put a study counter on Gustave's Journal.
{2}, {T}, Remove X study counters from Gustave's Journal: Draw X cards.
---
He spends some time writing in his journal. He writes about how dangerous the Nevrons are, but how beautiful the continent is. He hopes that one day, his apprentices will read everything he wrote.
```

[card implementation](../custom/cards/g/gustaves_journal.txt)

### Design Notes

 - In the game, whenever at camp Gustave (and later Maelle) writes down their experiences in the expedition thus far. It has been said (and lamented by many gamers) that this should have been represented as an in-game bestiary of all the Nevrons you have encountered.
 - Mechanically, I went with an artifact that charges up with every Nevron kill, that can be cashed in later down the road for extra cards.
 - 28/09/2025: Reduced cost from 4 to 3

## Healing Tint

```
2
Artifact
Sacrifice this artifact: Target player gains 5 life.
Luminous — Sacrifice this artifact: Target player gains 10 life. Activate this ability only if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/h/healing_tint.txt)

### Design Notes

 - In the game, health tints restore party member HP during a battle or outside of battle when not near an Expedition flag.
 - Another enabler for Lumina token strategies
 - 26/10/2025: Made lifegain targeted to support The 67th Gommage strategy
 - 6/11/2025: Renamed from "Health Tint"

## Julien Tiny Head

```
5
Legendary Artifact Creature - Gestral
Combo Jab — {2}: Julien gains double strike until end of turn.
Uppercut — {2}, {T}: Julien deals 2 damage to target creature, that creature gains flying until end of turn.
Haymaker — {2}: Julien gains trample until end of turn.

3/3
```

[card implementation](../custom/cards/j/julien_tiny_head.txt)

### Design Notes

 - In the game, Julien is a boxing-style fighter in the Hidden Gestral Arena
 - Julien has several moves which we've mechanically translated:
    - Combo Jab: Easy. A flurry of strikes. Ergo. Double Strike
    - Uppercut: Julien's punches are so strong that an uppercut would launch his opponent into the air (in my mind). Hence, the momentary flying after being dealt 2 damage (if it survives that punch!)
    - Haymaker: Interpreted as a really heavy punch and trample is a suitable way to convey such heaviness

## Limonsol, Matchmaker

```
3
Legendary Artifact Creature - Gestral
{2}, {T}: Target Gestral you control fights another target creature. (Each deals damage equal to its power to the other.)
---
Did I mention the prize is a powerful weapon? So, how about it?

2/2
```

[card implementation](../custom/cards/l/limonsol_matchmaker.txt)

### Design Notes

 - In the game, Limonsol sets up fights in the Gestral Arena
 - Mechanically, I just repeated Gestral Arena and gave him a fight ability

## Lorieniso, Gestral Musician

```
2
Legendary Artifact Creature - Gestral Bard
At the beginning of your upkeep, you may put a verse counter on Lorieniso.
{2}, {T}: Search your library for a Gestral card with mana value X or less and put it into your hand, where X is the number of verse counters on this creature.

1/3
```

[card implementation](../custom/cards/l/lorieniso_gestral_musician.txt)

### Design Notes

 - In the game, Lorieniso is one of the NPCs found in the Gestral Village. Clearly named after Lorien Testard, the composer of the OST for this game.
 - This is the Gestral's Goblin Matron / Gestral Tutor. Adapted from Yisan, the Wanderer Bard
 - 20/09/2025: Initial playtesting shows this is quite broken in multiples. Made into a legendary creature and changed P/T to 1/3

## Lost Gestral

```
1
Artifact Creature - Gestral
When this creature enters, if you control a card named Sastro, Gestral Guardian, create two Chroma tokens.
Whenever this creature becomes the target of a spell or ability an opponent controls, put this creature on the bottom of its owner's library.

1/1
```

[card implementation](../custom/cards/l/lost_gestral.txt)

### Design Notes

 - In the game, there is a side-quest where you have to find a bunch of Lost Gestrals and return them to Sastro. Every Lost Gestral you find and return to Sastro gives you rewards. For the first ability I went with rewarding the player with Chroma tokens if Sastro is in play when a Lost Gestral enters as a mechanical analogy to this side quest.
 - The second ability was taken from Fblthp, the Lost to mechanically explain why these Gestrals keep getting lost.
 - 23/10/2025: Fixed Sastro card name reference.

## Lumiere Flower Stand

```
2
Artifact
This artifact enters with three stock counters.
{1}, Remove a stock counter from this artifact, {T}: Create a Flower token (It's an artifact with "{T}, Sacrifice this artifact: Add {U}, {R} or {G}.")
{3}, {T}: Put a stock counter on this artifact
---
Sophie: Looks like you still have a lot of flowers left.
Tiffanie: Well, there are less and less people to buy them. I just wish you didn't have to wear one.
```

[card implementation](../custom/cards/l/lumiere_flower_stand.txt)

### Design Notes

 - In the game, the town of Lumiere has several market stands in the town square. Tiffanie operates one of these stands and sells flowers.
 - Just wanted another card to get extra usage out of Flower tokens (besides Goblu)

## Lumina Converter

```
2
Artifact
{T}, Remove a counter from a permanent you control: Create a Lumina token.
{T}, Sacrifice a Chroma token: Create a Lumina token.
{T}, Sacrifice a Nevron: Create a Lumina token.
---
It's about time you test it in real conditions.
- Lune
```

[card implementation](../custom/cards/l/lumina_converter.txt)

### Design Notes

 - In the game, the Lumina Converter is a device invented by Gustave that gives Expedition 33 the edge over previous expeditions.
 - Utility artifact to support a Lumina token strategy. Inspired by Power Conduit.

## Manor Door

```
2
Artifact
{T}: Add {C}.
{2}, {T}: Lock or unlock a door of target Room you control. Activate only as a sorcery.
---
Someone lives here.
- Lune
```

[card implementation](../custom/cards/m/manor_door.txt)

### Design Notes

 - In the game, there are various doors scattered throughout the continent that warps you to various rooms in the Manor, unlocking some previously inaccessible rooms in the process.
 - This clearly mechanically maps to an artifact that can lock/unlock rooms ala. Keys to the House
 - Added a mana ability so it can at least function as a mana rock if there's no rooms to interact with

## Matthieu the Colossus

```
7
Legendary Artifact Creature - Gestral
Trample. Menace.
Matthieu does not untap during your untap step.
Tap three creatures you control: Untap Matthieu.

8/8
```

[card implementation](../custom/cards/m/matthieu_the_colossus.txt)

### Design Notes

 - In the game, Matthieu is one of the gestral fighters in the Gestral Village Arena.
 - Has the word "Colossus" in its name, so therefore it's the big fatty Gestral of the set.
 - Modeled mostly on Phyrexian Colossus, but with Trample, downgraded Super-Menace to Menace and changed the untap cost to tapping 3 other creatures instead of life payment.
 - Yes, it can be Lackey'd out, but I can accept the variance on that line and also needing 3 other creatures to untap it will keep this line grounded.

## Ono-Puncho

```
2
Legendary Artifact Creature - Gestral
Whenever Ono-Puncho is dealt damage, return it to its owner's hand.
---
But remember, once you hit me, the battle's over, so make it count!

1/5
```

[card implementation](../custom/cards/o/ono_puncho.txt)

### Design Notes

 - In the game, Ono-Puncho resides in the Gestral Village, you can challenge him a battle to win a prize. The gimmick is that you only have one shot to deal 9999 damage.
 - We've translated that gimmick to a bounce trigger when it's dealt damage (signifying end of battle). To kill it means to "make it count" and deal it lethal damage so that state-based effects will send it to the graveyard before the bounce trigger can save it.

## Paint Spike

```
2
Artifact Creature - Wall
Defender.
When this creature enters, draw a card.
When this creature dies, choose one —
• Create a Chroma token.
• Create a Lumina token.
---
There must be some good loot behind there!

0/4
```

[card implementation](../custom/cards/p/paint_spike.txt)

### Design Notes

 - In the game, Paint Spikes are obstacles that block a secret/hidden area that normally has extra loot. The ability to break these barriers is unlocked when you rescue all the lost gestrals.
 - Mechanically represented as a wall. Gone with an artifact version of Wall of Blossoms with a chroma/lumina reward on death to symbolize the loot available now that this is no longer obstructing.

## Recoat

```
1
Artifact
{1}, {T}, Sacrifice this artifact and any number of token permanents you control: Choose one —
• Create X Chroma tokens, where X is the number of sacrificed token permanents.
• Create X Lumina tokens, where X is the number of sacrificed token permanents.
```

[card implementation](../custom/cards/r/recoat.txt)

### Design Notes

 - In the game, recoats are tints that let you respec your character attributes.
 - I've interpreted this as an artifact that let's you convert/respec tokens into Chroma or Lumina tokens.
 - 23/10/2025: Clarified what the X value represents (ie. Only counts the sacced tokens, and does not include Recoat itself)

## Revive Tint

```
2
Artifact
{1}, {T}, Sacrifice this artifact: Return target creature card from your graveyard to your hand.
Luminous — {3}, {T}, Sacrifice this artifact: Return target creature card from your graveyard to the battlefield tapped. Activate this ability only if you control at least three Lumina tokens.
---
You don't get to die yet.
- Lune
```

[card implementation](../custom/cards/r/revive_tint.txt)

### Design Notes

 - In the game, a Revive Tint resurrects a fallen party member in battle.
 - Mechanically, gone with a Raise Dead effect that also has reanimation if you meet the Lumina token requirement.

## Rush Picto

```
1
Artifact - Picto Equipment
Equipped creature gets +1/+0 and has haste.
Equip {1}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/r/rush_picto.txt)

### Design Notes

 - In the game, Greater Rush grants 25% to a character's Rush Speed.
 - Easy mechanical map to granting haste.

## Sastro, Gestral Guardian

```
4
Legendary Artifact Creature - Gestral
When Sastro enters, put two 1/1 Gestral artifact creature tokens into play.
{2}: Put a shield counter on target Gestral you control.
Whenever another nontoken Gestral creature you control enters, create a Chroma token.
---
I sure love being irresponsible!

2/2
```

[card implementation](../custom/cards/s/sastro_gestral_guardian.txt)

### Design Notes

 - This is the Gestral (Siege-Gang Commander / Deranged Hermit)
 - Should have one more ability at least. Further abilities TBD.
 - 6/10/2025: Gone with a Chroma rewarding ability.
 - 13/10/2025: Formerly known as Sastro, the Concerned
 - 22/10/2025: Fixed chroma bonus triggering on any nontoken creature

## Shot Picto

```
3
Artifact - Picto Equipment
When this equipment enters, choose two —
• Put a breaking counter on this equipment
• Put an energizing counter on this equipment
• Put a piercing counter on this equipment
Equipped creature has "{X}{X}, {T}: This creature deals X damage to target creature"
Whenever equipped creature deals damage to a creature, create a Chroma token and a Lumina token if this equipment has an energizing counter, tap that creature and put a stun counter on it if this equipment has a breaking counter, and it deals that amount of damage to its controller if this equipment has a piercing counter.
Equip {2}
Sacrifice two Lumina tokens: Create a token copy of this equipment attached to target creature you control. Activate this ability only if you control no token copies of this equipment.
```

[card implementation](../custom/cards/s/shot_picto.txt)

### Design Notes

 - In the game, Shot pictos come in many prefixed variants, that all do something when the equipped character dies.
 - This is the last of 3 "epic" tier pictos that are modeled on one of these pictos that have many prefixed variants.
 - See Attack Picto for original design motivation for these "epic" tier pictos.
 - The picto grant the equipped creature a shooting ability and will do the following on damage dealt based on the type of counters chosen, in this case:
    - Breaking: Tap and stun targeted creature (if it didn't die from the shot)
    - Energizing: Reward a Chroma + Lumina token
    - Piercing: Shoot targeted creature's controller for the same amount of damage

## Soarrie

```
1
Legendary Artifact - Rock
{T}: Target creature you control gains flying until end of turn.
{1}, Sacrifice Soarrie: Draw a card.
---
Esquie! Look what I found.
- Verso
```

[card implementation](../custom/cards/s/soarrie.txt)

### Design Notes

 - In the game Soarrie is a quest item which will grant Esquie the ability to fly
 - In this set, Soarrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, Flying maps to ... Flying! (duh!)

## The World Canvas

```
4
Legendary Artifact
{T}: Add three mana of any one color. Spend this mana only to cast a Nevron, Gestral, Painter, Expeditioner or Picto spell.
When The World Canvas leaves the battlefield, exile all permanents with a name originally printed in this expansion.
---
Verso's childhood canvas. Where we used to play ... Where he painted Esquie and Monoco. And where Maman and Papa now fight...
```

[card implementation](../custom/cards/t/the_world_canvas.txt)

### Design Notes

 - In the game, the continent is discovered to be inside a living canvas. The final part of the game is about deciding the fate of this canvas.
 - Mechanically:
    - The "black lotus" mana ability has spending restrictions to keep in flavor. You can only spend this mana on things that actually live in this canvas.
    - The destruction of this canvas signals the erasure of everything inside it. Mass exiling everything by expansion filter nicely symbolizes the finality of such an act.
 - 13/11/2025: Replaced flavor text with a better descriptive one.

## Urrie

```
1
Legendary Artifact - Rock
{1}, {T}: Surveil 2.
{1}, Sacrifice Urrie: Draw a card.
---
FINE, FINE, FINE, Here. Pah! Take your rock and SCRAM!
- Francois
```

[card implementation](../custom/cards/u/urrie.txt)

### Design Notes

 - In the game Urrie is a quest item which will grant Esquie the ability to dive when swimming in the Continent overworld
 - In this set, Urrie is 1 of 4 legendary "Rock" artifacts which will grant benefits to other cards if this or other members of the quartet are in play, just like Urza's Tower, Mine and Power Plant become more powerful when all of them are in play, I am trying to go for a similar outcome with this quartet.
    - Mechanically, my line of thought is diving > digging > Surveiling.

