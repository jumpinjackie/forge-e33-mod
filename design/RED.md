# Cards

> Last generated: 27/11/2025 11:42:53 am

## Anger

```
3R


---
Verso: We only need to incapacitate him.
Maelle: We'll find a way to kill him.
```

> This card is not yet implemented in Forge

### Design Notes

 - No in-game basis, but Grief is such a central theme of Expedition 33 that having a cycle dedicated to the 5 stages is a total flavor nuke.
 - Since we've gone with a cycle of 5 stages and Anger's already taken, let's just reuse that reprint.

## Catapault Sakapatate

```
1R
Creature - Nevron
This spell costs {1} less to cast if you control a Gestral.
When this creature dies, target opponent creates a Lumina token.
When this creature dies, you may have this creature deal 2 damage to target creature.

2/2
```

[card implementation](../custom/cards/c/catapault_sakapatate.txt)

### Design Notes

 - In the game, when you defeat a Catapault Sakapatate, it will try to do a last minute suicide move to do some damage before it goes.
 - Represented mechanically here as a simple shock-creature-on-death trigger.
 - 13/10/2025: Removed Devoid.
 - 21/10/2025: Added Gestral alliance cost reduction

## Chromatic Inversion

```
1R
Instant
Switch target creature's power and toughness until end of turn.
Draw a card.
```

[card implementation](../custom/cards/c/chromatic_inversion.txt)

### Design Notes

 - In the game, a party member can have an inverted status in battle. A member with inverted status cannot heal. Any attempt to heal the member results in damage being taken instead.
 - We've mechanically translated this to a P/T switch. ie. About Face, but with a cantrip bonus.

## Crustal Crush

```
3R
Kindred Instant - Expeditioner
You may sacrifice a Mountain rather than pay this spell's mana cost.
Crustal Crush deals 5 damage to target creature or planeswalker.
```

[card implementation](../custom/cards/c/crustal_crush.txt)

### Design Notes

 - In the game, this is one of Lune's skills.
 - Obviously a mountain/rock based attack so gone with Mine Collapse but with Expeditioner alignment and relaxed timing restrictions for the alt cost.

## Earth Rising

```
2R
Kindred Sorcery - Expeditioner
Earth Rising deals 2 damage to each creature without flying and each player.
Luminous — Earth Rising deals 3 damage to each creature without flying and each player instead if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/e/earth_rising.txt)

### Design Notes

 - In the game, this is one of Lune's skills
 - Just a mini-earthquake
 - Needed a sweeper to give control strategies something to stymie go-wide strategies
 - 27/11/2025: Added Luminous bonus

## Entering the Canvas

```
4R
Instant
You may put a creature card from your hand onto the battlefield. That creature gains haste. Sacrifice that creature at the beginning of the next end step.
---
This only truly ends if you destroy the canvas, and that means stopping the final sliver of Verso's soul from painting.
- Clea
```

[card implementation](../custom/cards/e/entering_the_canvas.txt)

### Design Notes

 - This symbolizes the moment in the game where real Alicia enters Verso's canvas to try and help real Renoir in expelling Aline out of the canvas, but ends up being consumed by Aline's chroma and is "reborn" as Maelle.
 - Mechanically/thematically translated to near carbon copy of Through the Breach.

## Fortune's Fury

```
1R
Kindred Instant - Expeditioner
Target creature gains double strike until end of turn. (It deals both first-strike and regular combat damage.)
Create a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")
```

[card implementation](../custom/cards/f/fortunes_fury.txt)

### Design Notes

 - In the game, this is Sciel's ability that grants double-damage to one of her allies.
 - Easy mechanical map to double-strike
 - 18/10/2025: Added lumina bonus

## Gestral Volleyball Strike

```
2R
Kindred Sorcery - Gestral
As an additional cost to cast this spell, sacrifice a Gestral.
Gestral Volleyball Strike deals 5 damage to any target.
```

[card implementation](../custom/cards/g/gestral_volleyball_strike.txt)

### Design Notes

 - In the game, there is a mini game where you have to win a game of gestral volleyball against a Sakapatate who flings little gestrals at you. You win the mini game by parrying the flung gestrals back at the Sakapatate a certain number of times. Failure to parry will damage the raft you are standing on an after a certain number of hits, the raft explodes and you will lose the mini game.
 - Gestral version of Goblin Grenade / Reckless Abandon
 - Made it a bit more expensive to offset the ease of casting gestral creatures in general and the fact that a Gestral sol land is in this set.

## Get Out Of My Way!

```
XR
Kindred Sorcery - Expeditioner
X target creatures can't block this turn.
---
Sunniso: Geez, you don't need to be so rude.
Gustave: Nononono, uh ... it's just, um ... it's the password ...
Sunniso: Well, I don't know! Golgra never told me the password. But whatever, just go in.
```

[card implementation](../custom/cards/g/get_out_of_my_way.txt)

### Design Notes

 - In the game, this is the "password" Golgra passed down to the Expeditioners to get past the Gestral guards at Esquie's Nest
 - Mechanically, it make sense (and is hilarious) to make Gestrals unable to block.
 - 27/11/2025: Dropped the Gestral restriction to avoid parasitism. So this is now just an Expeditioner-branded Wave of Indifference.

## Grosse Tete

```
3R
Legendary Creature - Nevron Elemental
Attacks by bouncing — At the beginning of your upkeep, Grosse Tete deals 2 damage to each creature without flying, then put a quake counter on Grosse Tete.
When Grosse Tete has three or more quake counters, sacrifice it.

1/5
```

[card implementation](../custom/cards/g/grosse_tete.txt)

### Design Notes

 - In the game, Grosse Tete is a boss whose gimmick is repeatedly bouncing and slamming the ground.
 - It starts off with 2 consecutive strikes and repeats, adding 2 consecutive strikes each time.
 - At 24 consecutive strikes, it self-destructs.
 - 2,4,6,8,10,12,14,16,18,20,22,24 = 12 times.
 - This is mechanically translated to a mini-earthquake every upkeep, adding a counter each time. Sac at 3 counters is its "self-destruct" sequence.
 - Like The Monolith, we are saccing at 3 instead of 12 counters for purposes of practicality. 12 counters means 12 turns and that is too long to wait it out in "MTG game time"
 - Big butt conveys the general tankiness.
    - 5 toughness was chosen so it can be taken out with a Gestral Volleyball Strike, so that a Gestral strategy does not completely fold to this card being in play and can take this out immediately if waiting it out is not an option.

## Hexga

```
2RR
Creature - Nevron Elemental
Double Strike
This creature enters with a shield counter on it. (If it would be dealt damage or destroyed, remove a shield counter from it instead.)
Shields its allies — When this creature enters, put a shield counter on target creature you control.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/h/hexga.txt)

### Design Notes

 - In the game, Hexga is a rock-based Nevron.
 - Thus it has an Elemental sub-type.
 - Comes in with a shield counter to convey tankiness.
 - Double strike maps to its 2/3-hit combo it does in-game.

## Lightning Dance

```
2RR
Kindred Sorcery - Expeditioner
Lightning Dance deals 1 damage to any target, 2 damage to another target, and 3 damage to a third target.
Luminous — Draw a card if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/l/lightning_dance.txt)

### Design Notes

 - Just Cone of Flame made {1} cheaper and Expeditioner aligned

## Marked!

```
R
Kindred Enchantment - Expeditioner Aura
Enchant Creature
Flash
If a source would deal damage to enchanted creature, it deals double that damage to that creature instead.
When this aura is put into a graveyard from the battlefield, return it to its owner's hand.
```

[card implementation](../custom/cards/m/marked.txt)

### Design Notes

 - In the game, marked is a status effect that causes the recipient to receive 50% more damage on the next hit.
 - Mechanically mapped to an aura that doubles any damage dealt to enchanted creature.
 - Basically copied the damage doubling template from Curse of Bloodletting, and swapped player for creature.
 - Added Flash for extra combat trickiness.
 - To have some utility, added Rancor's recurring effect.

## Mutinous Expedition 48 Soldier

```
1R
Creature - Human Expeditioner Soldier
Mutiny! - Whenever an Expeditioner creature you control dies, target opponent gains control of this creature.
When this creature dies, create a Chroma token.
---
It's a gutting realization, what has to be done. The mission is too important. The team is too important. We can't just throw our lives away for nothing. I hate that it came to this, but he broke our trust.
- Vincent, Expedition 48

3/3
```

[card implementation](../custom/cards/m/mutinous_expedition_48_soldier.txt)

### Design Notes

 - In the game, Expedition 48 was an expedition fraught with Mutiny and Treachery.
 - The mutinous nature has been captured with this creature joining the other side when one of your Expeditioner compatriots dies.

## Persuasive Argument

```
2R
Kindred Instant - Expeditioner
Gain control of target creature until end of turn. Untap that creature. It gains haste until end of turn.
Create a Lumina token.
---
Monoco: I will never join you again.
Verso: There will be a lot of fighting though.
Monoco: Oh yeah, that's true.
Verso: Yeah, it's true.
Monoco: There will be a lot of fighting.
Verso: Exactly.
Monoco: Count me in then.
```

[card implementation](../custom/cards/p/persuasive_argument.txt)

### Design Notes

 - In the game, Verso makes a persuasive argument that convinces Monoco to join the party.
 - The card design is completely based on this conversation, and the easiest thing that comes to mind is a standard red temp creature spell.

## Potier

```
3R
Creature - Nevron
Flying
Spawns pots — When this creature enters, create two colorless 1/1 Nevron Pot creature tokens with "This creature attacks each combat if able".
Buffs its allies — Nevrons you control have haste.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/p/potier.txt)

### Design Notes

 - Nevron version of Deranged Hermit / Siege-Gang Commander
 - 4/11/2025: Added missing death trigger for standard Nevrons

## Ranger Sakapatate

```
2R
Creature - Nevron
This spell costs {1} less to cast if you control a Gestral.
Attacks with its mighty sword — {R}, {T}: This creature deals 1 damage to target creature, put a stun counter on it.
Gestral Volleyball — {1}{R}, Sacrifice a Gestral: This creature deals 2 damage to any target.
When this creature dies, target opponent creates a Lumina token.
When this creature dies, you may have this creature deal 3 damage divided as you choose among one, two or three target creatures.

3/2
```

[card implementation](../custom/cards/r/ranger_sakapatate.txt)

### Design Notes

 - Like other Sakapatates, it will try to do a last minute suicide move to do some damage before it goes.
 - 21/10/2025: Added Gestral alliance cost reduction and Gestral volleyball fling ability since this is the one participating in the Gestral volleyball minigame.

## Robust Sakapatate

```
3R
Creature - Nevron
This spell costs {1} less to cast if you control a Gestral.
This creature enters with a shield counter.
Strikes with its dead partner — {2}, Sacrifice a Nevron: This creature deals damage equal to the sacrificed Nevron's mana value to target creature.
When this creature dies, target opponent creates a Lumina token.
When this creature dies, you may have this creature deal 2 damage to each non-Nevron creature.

3/3
```

[card implementation](../custom/cards/r/robust_sakapatate.txt)

### Design Notes

 - Like other Sakapatates, it will try to do a last minute suicide move to do some damage before it goes.
 - 21/10/2025: Added Gestral alliance cost reduction

## Terraquake

```
3RR
Kindred Sorcery - Expeditioner
Terraquake deals X damage to each creature without flying and each player, where X is twice the number of non-basic lands in play.
```

[card implementation](../custom/cards/t/terraquake.txt)

### Design Notes

 - In the game, this is one of Lune's abilities.
 - This is Earthquake and Price of Progress smushed together and is meant to check greedy non-basic mana bases.

## Thunderfall

```
R
Kindred Instant - Expeditioner
Thunderfall deals 2 damage to any target.
Luminous — Thunderfall deals 4 damage instead if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/t/thunderfall.txt)

### Design Notes

 - In the game, Thunderfall is one of Lune's skills that deals lightning damage.
 - As part of making Lumina tokens matter, this card has been modeled on Galvanic Blast, but with Luminous instead of Metalcraft.

