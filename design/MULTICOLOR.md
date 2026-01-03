# Cards

> Last generated: 3/1/2026 6:42:36 pm

## A Storm is Coming

```

Kindred Sorcery - Expeditioner
Suspend 1 - {U}{R} (Rather than cast this card from your hand, pay {U}{R} and exile it with one time counter on it. At the beginning of your upkeep, remove a time counter. When the last is removed, you may cast it without paying its mana cost.)
A Storm is Coming deals 3 damage to any target.
Create a Lumina token.
```

[card implementation](../custom/cards/a/a_storm_is_coming.txt)

### Design Notes

 - In the game, this is one of Lune's quotes during battle
 - Lighting bolt with suspend to convey the "storm is coming". Lumina reward as standard with any Expeditioner spell

## Aberration

```
3BR
Creature - Nevron
Performs light strikes — When this creature enters, it deals 3 damage divided as you choose among any number of target creatures and/or planeswalkers.
Performs dark combo — {2}{B}, {T}: Target creature has base toughness 1 until end of turn.
Creates earthquakes — {3}{R}, {T}: This creature deals 1 damage to each creature without flying and each player.
When this creature dies, target opponent creates a Lumina token.

3/3
```

[card implementation](../custom/cards/a/aberration.txt)

### Design Notes

 - Just a vanilla placeholder for now until I have figured out some suitable abilities for it
 - 13/10/2025: Removed Devoid.

## Abrupt Decay

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Abrupt Decay)
### Notes

 - Staple commander spot removal.

## Alicia Dessendre, Silenced by Fire

```
RW
Legendary Creature - Human Painter
Each player who has cast a non-Painter, non-Gradient spell this turn can’t cast additional non-Painter, non-Gradient spells.
(Melds with Maelle, Child of Lumière.)

2/2
```

[card implementation](../custom/cards/a/alicia_dessendre_silenced_by_fire.txt)

### Design Notes

 - Gone with a targeted (Null Rod / Cursed Totem) effect to mechanically emphasize the "silence"
 - The real gimmick is melding with Maelle, Child of Lumière. Meld is 100% the mechanic to sell the transformation
    - 23/09/2025: Getting meld to work has been nothing but failure. I give up. Alicia will now be standalone.
 - 6/10/2025: Meld is back on the menu! Got it to work finally! Also extended null rod effect to Chroma and Lumina tokens.
 - 3/11/2025: Exchanged abilities with human Alicia. Canonist exemption changed from Nevrons/Gradient to Painters/Gradient. Reduce Chroma sac activation cost from 3 to 2 tokens.
 - 12/11/2025: Dropped the silencing activated ability as it makes no thematic sense to pay in tokens that don't exist in the "real world" that Alicia is in. Using straight mana payment then raises game balancing concerns around what is the appropriate cost. Better to just drop the ability.

## Aline's Return

```
WB
Sorcery
Destroy target Axon or Nevron.
Cycling {2} ({2}, Discard this card: Draw a card.)
---
Aline, you’re going to kill yourself! It’s too soon for you to return to any Canvas!
- Renoir
```

[card implementation](../custom/cards/a/alines_return.txt)

### Design Notes

 - In the game, during the final boss with Renoir, Aline momentarily returns to the Canvas to swing the battle to the party's favor.
 - Mapped to targeted Axon/Nevron kill.
 - Added cycling to offset its marginality.

## Ballet

```
(R/G)(R/G)
Creature - Nevron
Flying.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/b/ballet.txt)

### Design Notes

 - Another vanila Nevron. Flying because these things are hard to hit with melee attacks in the actual game.
 - 23/09/2025: Move color identity from white/green to red/green to make way for White Nevrons.
 - 13/10/2025: Removed Devoid.
 - 13/12/2025: Changed cost from 1{RG}{RG} to {RG}{RG}

## Bedevil

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Bedevil)
### Notes

 - Obligatory commander ramp.

## Bénisseur

```
2RG
Creature - Nevron
Vigilance.
Summons protective bubbles — This creature enters with a shield counter on it.
Bubbles are shielding enemies — {2}{G}, {T}: Put a shield counter on target creature you control.
Launches projectiles from its hat — {2}{R}, {T}: This creature deals 2 damage to target attacking creature. Put a stun counter on it.
When this creature dies, target opponent creates a Lumina token.

4/4
```

[card implementation](../custom/cards/b/benisseur.txt)

### Design Notes

 - Currently a placeholder vanilla Nevron. Abilities TBD.
 - 23/09/2025: TODO: Replace white with a different color if intending to stay multi-color to make way for White Nevrons.
 - 13/10/2025: Removed Devoid and pivoted to WG instead of WR.
 - 21/10/2025: Granted a series of defensive abilities
 - 4/11/2025: Change color identity from WG to GR. All abilities costing white mana now cost red.

## Bittersweet Reunion

```
WB
Enchantment
When this enchantment enters, target opponent discards a card and you lose 2 life.
Sacrifice this enchantment: Choose one —
• Creatures you control get +1/+1 until end of turn.
• Creatures you control gain hexproof until end of turn. (They can’t be the targets of spells or abilities your opponents control.)
---
Maelle: If you’re gonna give someone flowers, you should probably do it before they wither and die.
Gustave: What? The flower? Or Sophie?
Maelle: Ooh dark. Sophie would approve.
```

[card implementation](../custom/cards/b/bittersweet_reunion.txt)

### Design Notes

 - In the game's prologue, Gustave reunites with Sophie on the day of her gommage. It is undoubtedly a bittersweet reunion.
 - The base template is Family Reunion, it was a case of how best to weave in the "Bittersweet" aspect.
 - Gone with an enchantment that triggers an oppoent discard and life loss (the Bittersweet part)
 - The "Family Reunion" part is an ability activated through saccing the enchantment.

## Bourgeon

```
1RWB
Creature - Nevron
Eats party member — When this creature enters, exile another target creature.
When this creature leaves the battlefield, return the exiled card to the battlefield under its owner's control.
Multi-hit combo — {2}{R}: This creature gains double strike until end of turn.
Spits miasma — {2}{B}, {T}: This creature deals 2 damage to target creature. Put a stun counter on that creature.

4/4
```

[card implementation](../custom/cards/b/bourgeon.txt)

### Design Notes

 - In the game, Bourgeon is a semi-recurring boss.
 - Key abilities mapped as follows:
   - Eating a party member: An Oblivion Ring style exile effect on ETB that is released when this creature either dies or is stunned (by putting a stun counter on it)
   - 3/4/5-hit combos: Double strike
   - Spits miasma: A shock and stun on target creature.

## Braseleur

```
1UR
Creature - Nevron
This creature enters with two orb counters.
At the beginning of your upkeep, you may put an orb counter on this creature.
{R}, Remove an orb counter from this creature: This creature deals 1 damage to target creature.
{U}, Remove an orb counter from this creature: Tap target creature.
When this creature dies, target opponent creates a Lumina token.

3/2
```

[card implementation](../custom/cards/b/braseleur.txt)

### Design Notes

 - Currently a placeholder vanilla Nevron. Abilities TBD.
 - 13/10/2025: Removed Devoid.
 - 21/10/2025: Gone with the orb summoning gimmick as the basis for most abilities.

## Breaking Rules

```
(W/G)
Kindred Instant - Expeditioner
Kicker {2}.
Destroy target artifact or enchantment with mana value 2 lor less.
If this spell was kicked, destroy that artifact or enchantment if its mana value is 5 or less instead.
---
Some rules can be bent, some can be broken.
```

[card implementation](../custom/cards/b/breaking_rules.txt)

### Design Notes

 - In the game, Breaking Rules is one of Maelle's abiliites.
 - For the card, I've disregarded all thematic/mechanical associations and designed the card only based on the name. We need cheap artifact/enchantment hate in this set, and the name fits the bill for what I'm after, so I've turned this to a variant of Overload that can also hit enchantments.

## Chorale

```
1(R/G)
Creature - Nevron
Flying.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/1
```

[card implementation](../custom/cards/c/chorale.txt)

### Design Notes

 - Another vanilla Nevron
 - 5/10/2025: Switched PT from 1/2 to 2/1 for more offensive punch.
 - 13/10/2025: Removed Devoid.

## Chroma is Flowing

```
(W/G)
Kindred Sorcery - Expeditioner
Create two Chroma tokens. (It's an artifact with "{T}, Sacrifice this artifact: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.")
Luminous — Create three Chroma tokens instead if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/c/chroma_is_flowing.txt)

### Design Notes

 - In the game, this is one of Lune's quotes during battle.
 - Went with 2 Chroma tokens, so it still ramps for strategies that can take advantage, but not to Dark Ritual levels.
 - 13/11/2025: Added Luminous bonus of rewarding one extra Chroma token.

## Chromatic Petrification

```
WB
Enchantment - Aura
Enchant permanent.
Enchanted permanent becomes an artifact and loses all abilities.
---
The expeditioners, the ones killed by Nevrons. Gustave noticed their Chroma remains in their bodies. They never dissipated, like the Gommage.
- Lune
```

[card implementation](../custom/cards/c/chromatic_petrification.txt)

### Design Notes

 - Represents the effect inflicted on a good bunch of previous Expeditioners that turned them into statues with their Chroma trapped within.
 - I orignally wanted this to turn into a "do nothing" artifact, but I think the "Enchant creature" restriction means this is a nonbo and the aura immediately "falls off". Will revisit later with "Enchant permanent" to see if this gives my desired result.
    - Until then, I've gone with a 0/1 artifact creature.
    - 23/09/2025: Now enchanting permanents so we can achieve the "inert artifact" effect. A slight flavor loss since this can now target more than just creatures, but I am more after the petrification effect than it needing to only target creatures

## Chromatic Rebirth

```
2WB
Sorcery - Gradient
This spell costs {1} less to cast if you control a painter.
As an additional cost to cast this spell, sacrifice a creature.
Put target creature card from a graveyard onto the battlefield under your control.
---
Well. You're about to be reborn in this world as one of Aline's creations. Have fun.
- Clea
```

[card implementation](../custom/cards/c/chromatic_rebirth.txt)

### Design Notes

 - In the game, Alicia enters the Canvas to help Renoir only to be trapped by Aline's chroma and is "reborn" as Maelle.
 - Card depicts this moment.
 - 29/12/2025: Downshift to uncommon

## Chromatic Reclamation

```
2BG
Enchantment
Sacrifice a nontoken permanent you control: Create a Chroma token.
Exile a nontoken permanent you control: Create two Chroma tokens.
---
Hmm. It's old chroma, not pure. It won't be like bringing the two of you back, but... we could use it in other ways.
- Maelle
```

[card implementation](../custom/cards/c/chromatic_reclamation.txt)

### Design Notes

 - Intended to be a combo engine, just like Expedition 35 Bridge converts permanents to extra cards. This converts permanents to extra Chroma tokens.

## Clair Obscur

```
4WB
Creature - Nevron
Performs a silencing combo — {2}{W}, {T}: Target creature an opponent controls loses all abilities until end of turn.
Protects its allies — {1}{W}, {T}: Put a shield counter on target creature you control.
Performs a weakening strike — {1}{B}, {T}: Target creature an opponent controls gets -1/-1 until end of turn.
Applies rage on its allies — {1}{B}, {T}: Untap target creature you control.
When this creature dies, target opponent creates a Lumina token.

4/4
```

[card implementation](../custom/cards/c/clair_obscur.txt)

### Design Notes

 - In the game, Clair Obscur is a fusion of Clair and Obscur
 - Gone with a literal stapling of Clair and Obscur's abilities, mana costs and P/T together
 - 29/12/2025: Downshift to uncommon

## Clea Dessendre, Seeking Vengeance

```
2UB
Legendary Planeswalker - Clea
Nevron spells you cast cost {1} less to cast.
[+2]: Amass Nevrons 2
[-2]: Search your library for a Nevron creature card, reveal that card and put it into your hand.
[-4]: Exile target nonland permanent. Create a token that's a copy of that permanent, except it is a Nevron in addition to its other types.
[-10]: Gain control of all creatures target opponent controls.
```

[card implementation](../custom/cards/c/clea_dessendre_seeking_vengeance.txt)

### Design Notes

 - Planeswalker Clea's abilities map to her purported abilities in-game:
    - +2: She is a prolific Nevron creating machine
    - -2: She can conjure up any Nevron
    - -4: She is known to have the unique ability of "painting over" other's creations. Modeled as exile with Nevron clone copy.
    - -10: She is a shrewd manipulator
 - 26/11/2025: Made her -2 loyalty only tutor up Nevron creatures, so that Clea's Chromatic Mastery acutally does something unique (tutor up any Nevron card, not just creatures)
 - 14/12/2025: Changed her +2 loyalty to Amass a black Nevron army instead of creating a 1/1 Nevron to mix things up.

## Closure

```
1(W/B)
Instant
Exile all graveyards.
Draw a card.
---
For the sake of the living, we must part with the dead.
- Renoir
```

[card implementation](../custom/cards/c/closure.txt)

### Design Notes

 - Describes the moment in Verso's ending where he is truly laid to rest and the canvas is destroyed.
 - Obvious graveyard exile effect to indicate the finality of this moment. What's dead is dead and should be laid to rest.

## Contortionniste

```
1UB
Creature - Nevron
Lifelink.
Impales its target — When this creature enters, choose one —
• Destroy target creature with mana value 3 or less.
• Tap target creature and put a stun counter on it.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

3/3
```

[card implementation](../custom/cards/c/contortionniste.txt)

### Design Notes

 - In the game, Contortionniste is a mid/late game Nevron
 - Mapped "Absorbs health" to lifelink
 - Mapped "Impales its target" to creature kill or tap-and-stun.

## Danseuse

```
2UR
Creature - Nevron
{2}{R}, {T}: This creature deals 2 damage to target creature.
{2}{U}, {T}: Tap target creature. Put a stun counter on it.
When this creature dies, if you control no creatures, put two 2/2 blue and red Nevron creature tokens named Danseuse Clone into play.
When this creature dies, target opponent creates a Lumina token.

2/2
```

[card implementation](../custom/cards/d/danseuse.txt)

### Design Notes

 - In the game, a Danseuse attacks with fire and ice magic. If it is the only enemy left in battle, it can summon up to 2 clones.
 - Mechanically I went with:
    - A creature shock ability for the fire/red ability
    - Tap and stun for the ice/blue ability
    - For the clone ability, I preserved the original triggering condition but went against making token copies as that seemed really degenerate as the cloning trigger would also pass on to the tokens.
 - 13/10/2025: Removed Devoid.
 - 13/12/2025: Increased activated ability costs by {2}

## Death Stare (Gaze of Granite)

> This card is a nicknamed reprint of (Gaze of Granite)
[Scryfall](https://scryfall.com/search?q=Gaze of Granite)
### Notes

 - In the game, upon choosing Verso's ending Lune was powerless to stop the destruction of the canvas. All she could do was give Verso the most mortifying stare for the betrayal he just wrought.
 - Nicknamed reprint of Gaze of Granite. Originally thought about it being a commander reprint, but opted for a main set reprint, just so that we have a sweeper in Golgari colors.

## Dualliste

```
4BR
Legendary Creature - Nevron
Double strike
Dualliste's power and toughness are each equal to 3 plus the number of Blood tokens you control.
Stormblood — Whenever Dualliste deals combat damage, create a Blood token.
Applies Inverted — {B}{B}, Sacrifice a Blood token: Target creature has base toughness 1 until end of turn.

3+*/3+*
```

[card implementation](../custom/cards/d/dualliste.txt)

### Design Notes

 - In the game, Dualliste is a mid-game boss of Act 2.
 - Since the boss battle is in a death pit with a knee-deep pool of blood, all his abilities revolve around blood tokens.
 - Double strike because he does a lot of combo attacks.
 - Inverted status translated to setting a creature's base toughness to 1 until EOT.

## Elemental Trick

```
4(W/U)(R/G)
Kindred Instant - Expeditioner
Choose one or more —
• Exile target creature. Add {W}.
• Target player draws two cards. Add {U}.
• Elemental trick deals 4 damage to any target. Add {R}.
• Target player gains 6 life. Add {G}.
```

[card implementation](../custom/cards/e/elemental_trick.txt)

### Design Notes

 - In the game, Elemental Genesis is one of Lune's skills. It deals damage in each element and generates the corresponding stain if damage was critical.
 - Translated to a super-modal spell with one on-color mode for each of the 4 colors. Each mode also adds one mana of the corresponding color as a nod to the stain generation per element.

## Esquie, Friend of Verso

```
3GU
Legendary Artifact Creature - Toy Mount
Saddle 2.
Esquie has Islandwalk as long as you control a card named Florrie.
Esquie has Flying as long as you control a card named Soarrie.
Esquie has Trample as long as you control a card named Dorrie.
When Esquie attacks, if you control a card named Urrie, Surveil 2.
When Esquie attacks, if it is saddled, choose one —
• Draw a card.
• Put a land card from your hand onto the battlefield.


6/6
```

[card implementation](../custom/cards/e/esquie_friend_of_verso.txt)

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

## Esquie's Charge

```
GUR
Instant
Esquie’s Charge deals 3 damage to any target.
If you control a card named Florrie, scry 2.
If you control a card named Dorrie, draw a card.
If you control a card named Soarrie, you gain 3 life.
If you control a card named Urrie, you may put a land card from your hand onto the battlefield.
---
Gustave: So, wait. Esquie is that powerful?
Sciel: Apparently so. But also lazy.
```

[card implementation](../custom/cards/e/esquies_charge.txt)

### Design Notes

 - In the game, at the Stone Wave Cliffs, the party witnesses some of Esquie's power by effortlessly taking down a giant Bourgeon.
 - Gone with a bolt with various rock-boosted bonuses to flesh out the Rock Urzatron archetype.
 - Mild thematic mismatch in terms of bonuses given based on the given rock as the rocks are primarly combat-based buffs for Esquie (if you follow the lore to the letter). But if we want the Rock Urzatron archetype to be viable, we need some utility-based payoffs for assembling the quartet, so this is an acceptable thematic compromise.

## Esquie's Embrace

```
GU
Enchantment - Aura
Enchant Creature
Enchanted creature gets +2/+2.
Enchanted creature has Islandwalk if you control a card named Florrie, has trample if you control a card named Dorrie and has flying if you control a card named Soarrie.
Whenever enchanted creature attacks, if you control a card named Urrie, draw a card.
```

[card implementation](../custom/cards/e/esquies_embrace.txt)

### Design Notes

 - In the game, Esquie consoles Maelle after the death of Gustave and offers her a comforting embrace.
 - Another aura with rock-boosted bonuses to bolster the Rock Urzatron archetype.

## Esquie's Rescue

```
GU
Instant
Return target creature to its owner’s hand. You gain 3 life.
Create a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")
---
Sciel: It was you. You saved me. Back then. Wait, but how?
Esquie: I heard your tears. 
Sciel: From so far away?
Esquie: I heard you, so I came.
```

[card implementation](../custom/cards/e/esquies_rescue.txt)

### Design Notes

 - In the game, Sciel discovers that Esquie saved her from drowning in the past, thus explaining why he referred to her as "my poor swimmer friend"
 - Modeled as a bounce spell with various bonuses stapled on.

## Estelle, Lumière Sculptor

```
1WU
Legendary Creature - Human Citizen Artificer
{W}{U}, {T}: Target noncreature artifact becomes a copy of target creature until end of turn, except it is an artifact in addition to its other types.
When this creature dies, create a Chroma token.
---
I just finished my sculpture of the legendary Esquie. This may be my life’s finest work, yet not a single soul seems to care. How could I make it better?

1/4
```

[card implementation](../custom/cards/e/estelle_lumiere_sculptor.txt)

### Design Notes

 - In the game's prologue, Estelle (if spoken to) asks Sophie how to make her sculpture of Esquie stand out more.
 - Mapped sculpting to a creature clone ability the targets noncreature artifacts (the "clay" that she'll turn into a creature)

## Évêque

```
3RG
Legendary Creature - Nevron
Évêque enters with a shield counter. (If it would be dealt damage or destroyed, remove a shield counter from it instead.)
Casts a spell — {2}{R}, {T}: Évêque deals 2 damage to target creature.
Summons minions — {2}{G}{G}, {T}: Create two 1/1 green Nevron creature tokens named Abbest.

4/4
```

[card implementation](../custom/cards/e/eveque.txt)

### Design Notes

 - In the game, Évêque is the first boss, encountered at the end of Spring Meadows.

## Expedition 34 Mage

```
URW
Creature - Human Expeditioner Wizard
{2}{W}: Tap target creature.
{2}{U}: Put a stun counter on target creature.
{2}{R}: This creature deals 1 damage to any target.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](../custom/cards/e/expedition_34_mage.txt)

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

[card implementation](../custom/cards/e/expedition_41.txt)

### Design Notes

 - Journal is a story of expeditioners engaged in a competition to see who can kill the most Nevrons.
 - Obvious mechanical map to just killing Nevrons, and more Nevrons.
 - 28/12/2025: Fixed final chapter not granting Lumina tokens.

## Expedition 47 Drunkard

```
2(W/G)
Creature - Human Expeditioner
Whenever this creature attacks, it gets +3/-3 until end of turn.
When this creature dies, create a Chroma token.
---
The trick is finding that perfect point where your nerves have calmed enough that your mind and body are one, but not so calm that your reactions are dulled. Some of the lads haven’t quite managed riding that edge, but I remain in full control of my body and thoughts!

1/4
```

[card implementation](../custom/cards/e/expedition_47_drunkard.txt)

### Design Notes

 - Modeled drunkeness as temporary high power / low toughness

## Expedition 53 Herbalist

```
1(W/G)
Creature - Human Expeditioner Cleric
Mercy Kill - Sacrifice an Expeditioner creature: You gain X life and scry X, where X is the sacrified creature's power.
When this creature dies, create a Chroma token.
---
It's the right choice. It is. Even if it doesn't feel like it. Right? Right.
- Lilou, Expedition 53

1/2
```

[card implementation](../custom/cards/e/expedition_53_herbalist.txt)

### Design Notes

 - In the game, members of Expedition 53 mercy-killed a fellow expeditioner whose injuries had left them in a coma.
 - This card represents one such member.
 - Mechanically mapped to an Expeditioner sac ability for lifegain + scry

## Expedition 55 Trumpeter

```
2(W/G)
Creature - Human Expeditioner
Expeditioner spells you cast cost {1} less to cast.
When this creature dies, create a Chroma token.

2/2
```

[card implementation](../custom/cards/e/expedition_55_trumpeter.txt)

### Design Notes

 - In the game, Expedition 55 tried using musically-augmented pictos. This was mostly effective until they encountered Sirène whose minions and herself were immune to these pictos.
 - Since the main theme of this Expedition was music, it can be safely assumed that most of the crew were musicians or were proficient in one kind of music, giving us ample design space to fill out the Expeditioner creature roster with various creatures of various utility. In this case, I've gone with a trumpeter and a cost-reduction effect.

## Expedition 59

```
BG
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Destroy target Nevron. Create a Food token.
II — Create 2 Food tokens.
III — Until end of turn, Food tokens you control gain "{1}, Sacrifice this artifact: Target creature deals 3 damage to itself"
```

[card implementation](../custom/cards/e/expedition_59.txt)

### Design Notes

 - Journal is a story of Expeditioners making the fatal mistake of eating dead nevrons for sustenance
 - "Food poisoning" ability adapted from Asmoranomardicadaistinaculdacar's ability
 - 1/1/2026: Make the food poisoning ability cost {1} and sac.

## Expedition 59 Chef

```
1(B/G)
Creature - Human Expeditioner
Whenever a Nevron creature dies, create a Food token.
{1}, Sacrifice a Food token: Target non-Nevron creature deals 3 damage to itself.
When this creature dies, create a Chroma token.
---
I can't believe she convinced everyone to eat the Nevron. They've been puking for the past few hours. Great.
- Julien, Expedition 59

2/2
```

[card implementation](../custom/cards/e/expedition_59_chef.txt)

### Design Notes

 - In the game, Expedition 59 attempted to eat dead Nevrons for sustenance.
 - This card represents the genius who suggested such an idea.
 - Has strong mechanical similarity to Asmoranomardicadaistinaculdacar so has the same "food poisoning" ability.
 - 5/10/2025: Reduced cost from 2(B/G) to 1(B/G)
 - 1/1/2026: Made food poisioning cost {1} and sac and make it targeting non-Nevron creatures to avoid this being able to machine gun an entire board of low-tier Nevrons.

## Expedition 60

```
2GW
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Un-modified creatures you control gain vigilance until end of turn.
II — Un-modified creatures you control gain vigilance and menace until end of turn.
III — Un-modified creatures you control gain vigilance, menace, trample and +3/+3 until end of turn.
```

[card implementation](../custom/cards/e/expedition_60.txt)

### Design Notes

 - Journal is a story of expeditioners who almost succeeded in their mission through raw human strength and discovered the true enemy is not The Paintress, but someone underneath the Monolith, but this realization came too late as they were claimed by the Gommage before this discovery could be relayed back the citizens of Lumière.
 - Mechanically mapped to giving various offensive buffs to un-modified creatures with an overrun with extras on the final chapter. Only buffs un-modified creatures because these giga-chads don't have use for pithy things like clothing and armor.
 - 30/09/2025: Changed from 1RG to 2WG, double strike -> vigilance, hexproof -> menance. Original card was too powerful wtih "go wide" strategies

## Expedition 63 Driver

```
1(W/R)
Creature - Human Expeditioner Pilot
This creature saddles Mounts and crews Vehicles as though its power were 2 greater.
When this creature dies, create a Chroma token.
---
Damnit Hector, I told you to SLOW DOWN
- Damien, Expedition 63

2/2
```

[card implementation](../custom/cards/e/expedition_63_driver.txt)

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
---
We're out of explosives, but we've made enough holes in this place to reach that giant woman in the centre.
- Luc, Expedition 67

2/2
```

[card implementation](../custom/cards/e/expedition_67_demolitions_expert.txt)

### Design Notes

 - In the game, Expedition 67 employed the use of explosives to tear down walls in Sirène's coliseum. They succumbed to Sirène's musical wiles.
 - This card models one such crew member.

## Expedition 70

```
2WU
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I, II — Search your library for an Expeditioner card, reveal it and put it into your hand, then shuffle.
III — Search your library for an Expeditioner permanent, put it onto the battlefield, then shuffle.
```

[card implementation](../custom/cards/e/expedition_70.txt)

### Design Notes

 - Journal is a story of an Expedition that made it inside the Monolith in the final few days of their lifetimes and installing grapple points for those who come after.
 - 21/09/2025: This is an enabler engine for Expeditioner tribal strategies

## Expedition 78 Airship

```
2(W/U)(W/U)
Creature - Human Expeditioner
Flying.
This creature can block only creatures with Flying.
When this creature dies, create a Chroma token.
---
Our only choice is to take matters into our own hands. Fortune favors the bold. We must forge ahead with CONVICTION.

4/4
```

[card implementation](../custom/cards/e/expedition_78_airship.txt)

### Design Notes

 - In the game, Expedition 78 stole hundreds of airships from the Lumière Council and departed to take on the Paintress. The Expedition failed, but the fate of the expeditioners is unknown.
 - Card represents some of the Airship crew.
 - This is our heavy-hitter for an all-flyers strategy.
 - 12/11/2025: Renamed from Expedition 78 Aircrew to Expedition 78 Airship

## Expedition 81 Interpreter

```
2(W/U)
Creature - Human Expeditioner Wizard
You may choose not to untap this creature during your untap step.
Nevron Whisperer — {2}, {T}: Gain control of target Nevron creature for as long as this creature remains tapped.
When this creature dies, create a Chroma token.
---
Gregoire is, as usual, deeply suspicious, but this could change our entire understanding of Nevrons and the Paintre-
- Renee, Expedition 81

1/2
```

[card implementation](../custom/cards/e/expedition_81_interpreter.txt)

### Design Notes

 - In the game, Expedition 81 was the first expedition to ever communicate with a Nevron.
 - This card represents someone who has mastered the ability to communicate with Nevron.
 - Mechanically translated to taking control of Nevrons with a Vedalken Shackles style effect.

## Expedition Festival

```
1WU
Sorcery
You gain 2 life for each creature you control.
Draw a card.
Luminous — Create a 1/1 white Human Expeditioner token with "When this creature dies, create a Chroma token." if you control at least three Lumina tokens.
---
Five tables this year, you see that? Told you we’d beat the 34s.
- Catherine
```

[card implementation](../custom/cards/e/expedition_festival.txt)

### Design Notes

 - In the game's prologue, the Expedition Festival happens after the gommage, where the crew of Expedition 33 drink away their sorrows, say goodbye to their loved ones and do final preparations before departing for the Continent.
 - Gone with variable lifegain, like Festival of Trokin with a creature token Luminous bonus.

## Finesse // Grace

```
Finesse
1R
Instant
Target creature gains vigilance, haste and +2/+0 until end of turn.

Grace
1W
Instant
Target creature gains first strike, lifelink and +1/+1 until end of turn.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](../custom/cards/f/finesse_grace.txt)

### Design Notes

 - One of Maelle's quotes during battle.
 - Thematically sounds like a combat trick. Designed as such.

## Florian, Lumière Doomsayer

```
1UB
Legendary Creature - Human Cleric Citizen
At the beginning of your upkeep, choose a card name then reveal the top card of your library. If that card has the chosen name, put it into your hand. Otherwise, put it into your graveyard.
{2}{U}, {T}: Scry 2.
{2}{B}, {T}: Surveil 2.
When this creature dies, create a Chroma token.
---
The Paintress is going to punish you! You blasphemers. The Gommage is our fault! We brought this upon ourselves. Because we dared to defy her!

2/3
```

[card implementation](../custom/cards/f/florian_lumiere_doomsayer.txt)

### Design Notes

 - In the game's prologue, Florian can be seen near the harbor, preaching the end of days.
 - Mapped doomsaying > prediction. Thus has an upkeep trigger that lets you "predict" the top card of your library, if you guess right you get the card, otherwise it's milled.
 - Scry and Surveil abilities are to let you "shape your destiny".

## For Those Who Come After

```
(W/U)(W/U)
Kindred Sorcery - Expeditioner
Create three Lumina tokens if {U} was spent to cast this spell.
Create two Chroma tokens if {W} was spent to cast this spell.
---
This is our gift, for all the Expeditions to come.
- Charlotte, Expedition 70
```

[card implementation](../custom/cards/f/for_those_who_come_after.txt)

### Design Notes

 - Just another Chroma/Lumina token strategy enabler

## Full Deck

```
UB
Kindred Sorcery - Expeditioner
Destroy target creature. Mill cards equal to that creature's toughness.
Luminous — If you control three or more Lumina tokens, put a card from among those cards into your hand.
---
The cards have spoken!
```

[card implementation](../custom/cards/f/full_deck.txt)

### Design Notes

 - In the game, this is one of Sciel's quotes during battle.
 - Design-wise fully leaned in on the pun and based it around using "your deck" to take out any creature, if you can afford to mill the number of cards required.
 - Mild thematic mismatch as blue is not really part of Sciel's color identity or skillset IMO, but the milling and returning cards to hand from graveyard is in blue's wheelhouse.

## Gargant

```
3UR
Legendary Creature - Nevron
Freezes — {2}{U}, {T}: Tap target creature and put a stun counter on it.
Lands a series of punches — {1}{R}: Gargant gains double strike until end of turn.
Whenever Gargant is dealt damage from a red source, remove all counters from it and put a fire counter on it.
Whenever Gargant is dealt damage from a blue source, remove all counters from it and put an ice counter on it.
Gargant has protection from red as long as it has a fire counter on it and protection from blue as long as it has an ice counter on it.

2/6
```

[card implementation](../custom/cards/g/gargant.txt)

### Design Notes

 - In the game, Gargant is a boss in Frozen Hearts.
 - Rather than transcribe its abilities 1:1 like other Nevrons, I've gone for something different here and only tried to mechanically capture its "flip-flop" elemental immunity.

## Gestral Foot Race Challenge

```
(R/G)
Enchantment
Whenever a creature enters, you may put a quest counter on this enchantment.
Bronze Rank - As long as there are three or more quest counters on this enchantment, creatures you control have haste.
Silver Rank - As long as there are four or more quest counters on this enchantment, creatures you control have Ward 1.
Gold Rank - As long as there are five or more quest counters on this enchantment, creatures you control have trample.
---
00:36:500? Not a bad time, human.
```

[card implementation](../custom/cards/g/gestral_foot_race_challenge.txt)

### Design Notes

 - In the game, the Gestral Foot Race Challenge is 1 of 5 challenge minigames. This minigame in particular requires clearing an obstacle course in under a certain amount of time. There are 3 ranks the player can achieve based on how fast they cleared the course.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - Went with a simple creature entering as the trigger condition, with 3 different "ranks" of various buffs as payoffs.

## Gestral Parkour Challenge

```
(W/R)
Enchantment
Whenever a Human you control enters, you may put a quest counter on this enchantment.
As long as this enchantment as two or more quest counters, creatures you control gain vigilance.
As long as this enchantment as three or more quest counters, creatures you control gain prowess.
---
If I were a 2-year-old human, at what age would I gommage? ... You're probably right, I can't count anyway.
```

[card implementation](../custom/cards/g/gestral_parkour_challenge.txt)

### Design Notes

 - In the game, the Gestral Parkour Challenge is 1 of 5 challenge minigames. This minigame in particular requires clearing an obstacle course and answering a riddle at the end.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - Made the enter trigger human only to make this more Expeditioner-aligned.

## Gestral Raft Volleyball Challenge

```
(U/R)
Enchantment
Whenever a creature you control becomes the target of a spell or ability, you may put a quest counter on this enchantment.
Normal Difficulty — As long as this enchantment has three or more quest counters on it, whenever a creature you control becomes the target of a spell or ability, draw a card.
Hard Difficulty — {U/R}{U/R}: You may choose new targets for target spell or ability. Activate this ability only if this enchantment has five or more quest counters on it.
---
Oh, you won. You deserve this reward. Have fun with it!
```

[card implementation](../custom/cards/g/gestral_raft_volleyball_challenge.txt)

### Design Notes

 - In the game, the Gestral Raft Volleyball Challenge is 1 of 5 challenge minigames. This minigame in particular requires playing a game of volleyball on a raft against a Sakapatate. Failure to parry a flung gestral back at the Sakapatate will damage your raft. After a certain amount of hits, the raft will explode and you'll lose the minigame, unless you do it to the Sakapatate first.
 - All minigames are modeled as "quest" enchantments originating from Zendikar block and use the same terminology (charging with quest counters based on certain conditions with some payoff at the end once you reach a certain number of quest counters).
 - Went with any of your creatures being targeted as the triggering condition as that best describes gestrals being flung at you.
 - First payoff is card draw. Second (and more flavorful) payoff is to be able to redirect opponent's spells and abilities to signify the mastery of parrying flung gestrals back at the opponent.
 - 5/10/2025: Cost reduced from (U/R)(U/R) to (U/R) in line with the other challenge enchantments

## Giant Sapling

```
5RG
Legendary Creature - Nevron
At the beginning of your upkeep, put a crush counter on Giant Sapling.
Exhaust — Remove three crush counters from Giant Sapling: Giant Sapling deals 6 damage to each creature without flying. (Activate each exhaust ability only once)

7/7
```

[card implementation](../custom/cards/g/giant_sapling.txt)

### Design Notes

 - In the game, Giant Sapling is the boss in the Crushing Cavern.
 - Main gimmick being captured is its countdown to crushing doom.
 - Unfortunately, countdown via counters is hard because there is no precedent for a triggered ability on the removal of the last counter that is not a terminal ability (ie. The permanent sticks around afterwards). So it looks like my original intent of crushing on the last counter removal is not possible.
 - So I have pivoted to the crush ability being an Exhaust one, paid for with 3 counters, which you gain one every turn. So an opponent has 3 turns to deal with this creature before most of the board is wiped, flavorfully retaining the urgency of needing to dispatch this creature in the actual video game.

## Glaise

```
1RG
Creature - Nevron
This creature enters with a shield counter.
Pounds on the ground — {G}: This creature gains trample until end of turn.
Exhaust — {2}{R}: This creature deals 1 damage to up to three target creatures without flying. (Activate each exhaust ability only once)
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

3/4
```

[card implementation](../custom/cards/g/glaise.txt)

### Design Notes

 - In the game, Glaises can be found in Yellow Harvest and Falling Leaves

## Glissando

```
1GWU
Legendary Creature - Nevron Wurm
You may choose not to untap Glissando during your untap step.
Enchants its target — {T}: Gain control of target creature for as long as you control Glissando and Glissando remains tapped.
Summons Ballets to attack the Expedition — {T}: Create a 1/1 green Nevron creature token with flying named Ballet.

2/5
```

[card implementation](../custom/cards/g/glissando.txt)

### Design Notes

 - In the game, Glissando is an optional sub-boss in Sirène's coliseum
 - Has an appearance of a wurm, so gave it a that sub-type.

## Goblu

```
GUR
Legendary Creature - Nevron
Flash. Ward {2}. Reach.
Grows Flowers — At the beginning of your upkeep, create a Flower token (It's an artifact with "{T}, Sacrifice this artifact: Add {U}, {R} or {G}.")
Absorbs Flowers — Whenever a Flower token leaves the battlefield, choose one —
• Goblu deals 1 damage to any target.
• Put a +1/+1 counter on target creature.
• Put a shield counter on target creature.
• Draw a card.
---
Gustave, wait! It seems peaceful, as long as we don't touch the flowers.
- Lune

3/4
```

[card implementation](../custom/cards/g/goblu.txt)

### Design Notes

 - In the game, Goblu is the boss of Flying Waters.
 - Main gimmick we want to mechanically translate is Goblu's flower growing and consuming ability.
    - Represented Red and Blue flowers as separate artifact tokens.
    - Flower consumption is represented as abilities that trigger on Red/Blue Flower sacrifice (independent of the sac ability)
 - 25/10/2025: 
    - Added reach. 
    - Removed Red/Blue Flower tokens and gone with just a Flower token to which is a temur mana rock. There's not enough text box budget to mention two different tokens and the triggering off of both of them. 
    - Changed Flower leave triggers to a (mandatory) modal choice off of any flower token leaving. This was because Forge does not seem to acknowledge token leave triggers of a specific token name.
       - The shield and +1/+1 counter abiliies from the blue/red flower tokens have been moved here.

## Gommage

```
3WB
Sorcery - Gradient
This spell costs {1} less to cast if you control a painter.
Exile all nonland permanents that aren't legendary or Nevrons.
---
Your mother paints life. Whilst your father, death. What will you paint?
- Alicia
```

[card implementation](../custom/cards/g/gommage.txt)

### Design Notes

 - In the game, the Gommage is a yearly event where people above a certain age (indicated on the Monolith) are erased from existence. It is also a gradient attack power that Maelle gains in the late game that can deal extreme singular damage.
 - Mechanically, this is easily a mass exile effect. It spares legendaries and Nevrons as this event only affects the humans of the continent.
 - Has painter's discount as this is clearly a power wielded by the painters.
w - 26/11/2025: It has come to my attention that this name is already taken in French (for the English card: Blot Out). However since, this is an English printing and that this is a custom set, there is no collsion issues with this card in Forge.

## Gradient Charge

```
2(W/B)
Sorcery - Gradient
This spell costs {1} less to cast if you control a Painter.
Search your library for a Gradient card, reveal that card, put it into your hand, then shuffle.
```

[card implementation](../custom/cards/g/gradient_charge.txt)

### Design Notes

 - In the game, Gradient attacks are "Epic" tier attacks. To use such attacks you need to fill up a Gradient gauge. The Gradient gauge holds up to 3 charges. Gradient attacks cost anywhere between 1 to 3 charges.
 - Mechanically, this is just a Gradient spell tutor to assist in Painter-based strategies.

## Grandis Cleaner

```
WU
Creature - Grandis
{W/U}, {T}: Remove a counter from target permanent.
---
Cleaner 1: I can clear the snow and I can clear the rubble, but this is too much.
Cleaner 2: Must be truly dispose of this thing?
Cleaner 1:It does not obstruct the way. It is simply ... there.

1/4
```

[card implementation](../custom/cards/g/grandis_cleaner.txt)

### Design Notes

 - In the game, two Grandis Cleaners can be found outside Monoco's Station after you defeat the Stalact there. They are lamenting about the mess they have to clean up.
 - Mapped cleaning to removing a counter (of any type) from any permanent.

## Grandis Guard

```
WU
Creature - Grandis
Vigilance
{1}{W/U}, {T}: Tap target creature.
---
Contrary to what some believe, guard duty is quite rewarding. I find it meditative and instructional.

1/4
```

[card implementation](../custom/cards/g/grandis_guard.txt)

### Design Notes

 - In the game, a Grandis Guard stands outside Monoco's Station.
 - Gone with a vigilant, high-toughness creature with a creature tapping ability.

## Grandis Merchant

```
WU
Creature - Grandis
{T}: Draw a card, then discard a card.
{2}, {T}: Create a Lumina token.
{3}, {T}: Put a +1/+1 counter on target creature.
{4}, {T}: Put a shield counter on target creature.

1/3
```

[card implementation](../custom/cards/g/grandis_merchant.txt)

### Design Notes

 - In the game, Grandis Merchants reside in Monoco's Station and offers various items for sale.
 - Provides a suite of various items and buffs (for sale) if you have the mana to spend.

## Greatsword Cultist

```
1WB
Creature - Nevron
Covers her sword in blood — {X}{B}, {T}, Exert this creature: This creature deals X damage to target creature. This creature gets -0/-X until end of turn. Put a shield counter on this creature.
Is about to jump — {1}{W}: This creature gains flying until end of turn. This creature has base toughness 1 until end of turn. Put a shield counter on this creature.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/3
```

[card implementation](../custom/cards/g/greatsword_cultist.txt)

### Design Notes

 - In the game, Greatsword Cultists are found in the Stone Wave Cliffs
 - Main gimmick being captured is shielding herself at the expense of great self-inflicted suffering.

## Growth Spiral

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Growth Spiral)
### Notes

 - Obligatory commander ramp.

## Gustave, Lumière Engineer

```
1W(U/R)
Legendary Creature - Human Expeditioner
Whenever Gustave becomes untapped, attacks or blocks, put a charge counter on him.
From Fire — {W}{R},{T}: Gustave deals 3 damage to target creature, you gain 3 life.
Strike Storm — {W}{R}: Gustave gains double-strike until end of turn, put two charge counters on him. Activate only once per turn.
Overcharge — {T}, Remove X charge counters from Gustave: Gustave deals X damage to target creature and that creature's controller.
---
For those who come after.

3/3
```

[card implementation](../custom/cards/g/gustave_lumiere_engineer.txt)

### Design Notes

 - Key mechanical gimmick we want to replicate from the game is his overcharge ability, which obviously requires charge build up. We had a choice between energy counters or charge counters. We settled on charge counters as energy counters are a global resource, whereas charge counters would be a resource localized to Gustave himself.
 - Marking shot is just a creature ping that puts a marked counter on it. A creature with a marked counter will be a magnet for more damage.
 - From fire in the game is an ability that heals Gustave a bit if the target is burning. Translated this to a creature bolt + life gain.
 - Strike storm in the game is just a flurry of strikes. Translated this to temporary double strike.
 - Finally, overcharge (the ability we're all building towards) in the game deals high lightning damage based on the number of charges. Translated this to an X damage ability to a creature and its controller (where X is the number of charge counters removed).
 - 23/09/2025: It may look a bit odd to have blue color identity but no actual abilities that cost blue mana. I added the blue color identity strictly for flavor purposes because he's an engineer and engineers are almost always a blue color identity.
 - 13/10/2025: Dropped the marking shot ability due to text box budget constraints having seen this card for the first time in CardConjurer.

## Lampmaster

```
4WB
Legendary Creature - Nevron Horror
Flying. Ward 3.
Ball of Light — {2}{W}, {T}: Tap up to three target creatures. They lose all abilities until end of turn.
Sword of Light — {2}{W}{B}, {T}: Separate creatures target opponent controls into two separate piles. That opponent chooses a pile. Destroy all creatures in that pile. Creatures in the other pile have base toughess 1 until end of turn.

4/4
```

[card implementation](../custom/cards/l/lampmaster.txt)

### Design Notes

 - In the game, this is the final boss of Act 1.
 - Ball of Light: In the game The Lampmaster gathers light energy in a sphere and then releases it as a horizontal wave, inflicting Silence upon contact.
    - Translated to an effect that taps multiple creatures and giving them temporarily humility.
 - Sword of Light: In the game, The Lampmaster creates a large blade from light and swings it four times, dealing massive damage to the whole party and inflicting Blight.
    - Translated to a Fact or Fiction style "split into 2 piles" effect where opponent choose the pile to be destroyed and the other pile will all have toughness of 1 until end of turn (which is how I interpret the blight effect).

## Last Stand of Expedition 33

```
WUBRG
Kindred Sorcery - Expeditioner
Domain — 
Create a Chroma token and a Lumina token for each basic land type among lands you control.
Target opponent loses 1 life and you gain 1 life for each basic land type among lands you control.
Last Stand of Expedition 33 deals 2 damage to up to one target creature for each basic land type among lands you control.
Draw a card for each basic land type among lands you control and discard three cards.
```

[card implementation](../custom/cards/l/last_stand_of_expedition_33.txt)

### Design Notes

 - In the game, when your main party dies in battle, you have an option to send in the reserve team. If you do, the game acknowledges your reserve team as "The Last Stand of Expedition 33"
 - Gone with a variant of Last Stand, but based the bonuses on domain count.
 - Wording is somewhat verbose, but no pre-existing domain card does this, so I'm playing it safe.

## Leave this Canvas!

```
1WB
Sorcery - Gradient
This spell costs {1} less to cast if you control a painter.
Exile target nonland permanent.
```

[card implementation](../custom/cards/l/leave_this_canvas.txt)

### Design Notes

 - One of Maelle's quotes as she's about to gommage some sorry Nevron out of existence.
 - Painter bonus because this is a painter's power.

## Lost // Found

```
Lost
3U
Instant
Put target nonland permanent on the bottom of its owner’s library.

Found
W
Instant
Return target artifact card from your graveyard to your hand.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](../custom/cards/l/lost_found.txt)

### Design Notes

 - Design based solely on Esquie's quote in his Act 3 conversation with Sciel.
 - Lost: Clearly a send back to library effect
 - Found: An Argivian Find, but only targets artifacts (rocks)

## Lune, Charting a Path

```
RGWU
Legendary Creature - Human Expeditioner Wizard
Lune can't have more than four stain counters on her.
Whenever you cast an instant or sorcery spell, draw a card and put a stain counter on Lune for each of that spell's colors.
Tree of Life — {W}{G}, {T}, Remove a stain counter from Lune: Return target nonland, noncreature card from your graveyard to your hand. You gain 3 life.
Wildfire — {R}, {T}, Remove two stain counters from Lune: Lune deals 2 damage to each creature target opponent controls.
Elemental Genesis — {T}, Remove four stain counters from Lune: Lune deals 4 damage to each of up to four targets.
---
As long as even one of us stands, our fight is not over.

3/3
```

[card implementation](../custom/cards/l/lune_charting_a_path.txt)

### Design Notes

 - This was one of the hardest cards to design because Lune is a veritable "Jack of all trades" in terms of abilities in-game. Also we have to somehow emulate her stain gimmick in a way that doesn't look too out of flavor.
 - So in this respect, this is what I went with:
    - The stain gimmick is a triggered ability that gives you stain counters for the colors of any instant/sorcery cast.
        - The original intent was to have 4 different types of stain counters to match the colors of any instants/sorceries resolved. (eg. Resolve a blue spell, add a blue stain counter, etc). Her abilities would then be activated by spending the appropriate type of stain counters. But that is just too much text and we don't have the textbox budget for it!
        - The stain counters being "colorless" but an amount given based on the colors of the instant/sorcery cast was a compromise to save on text.
        - The second compromise is to spend stain counters + a mana of a particular color for a color-relevant ability.
    - In terms of abilities, we've made sure that every color in Lune's color identity is covered.
        - Blue: Draw a card from cast trigger.
        - Red: The Wildfire ability
        - Green/White: The Tree of Life ability
    - The Elemental Genesis "ultimate" requires no extra mana cost because getting to 4 stain counters is enough investment already.
 - 26/12/2025: Figured out a way to implement a max 4 stain counter limit to match her video game counterpart. Due to limitations on expressing this "4 stain counters max" constraint in Forge, I expect that this limit can be easily cicumvented through other means in Forge (ie. Alternate ways of putting stain counters that are not Lune's triggered ability) and I can live with that. The intent in *paper* play is definitely 4 stain counters max, no ifs or buts. No shenanigans with Doubling Season or other counter replicators.

## Maelle, Child of Lumière // Maelle, The Reawakened Paintress

```
1RW
Legendary Creature - Human Expeditioner
Stance Switch — At the beginning of combat, roll a six-sided die.
1-2 | Offensive Stance — Maelle gains Vigilance and +2/+0 until your next turn
3-4 | Defensive Stance — Maelle gains Hexproof, First Strike and +0/+2 until your next turn.
5-6 | Virtuose Stance — Maelle gains Double Strike and +1/-1 until your next turn.
At the beginning of your end step, if you both own and control Maelle, Child of Lumière and a creature named Alicia Dessendre, Silenced by Fire, exile them, then meld them into Maelle, The Reawakened Paintress.

3/3
```

Melds into:

```

Legendary Planeswalker - Maelle
Human and Gradient spells you cast cost {1} less to cast.
[+2]: Create a Chroma Token.
[+1]: Create two 1/1 White Human Expeditioner tokens with "When this creature dies, create a Chroma token.".
[-3]: Exile target nonland, non-Human permanent.
[-8]: Return all Humans from your graveyard onto the battlefield.
```

[card implementation](../custom/cards/m/maelle_child_of_lumiere_maelle_the_reawakened_paintress.txt)

### Design Notes

 - In the game, Maelle is Alicia painted over and reborn when she enters the canvas. After the ending of Act 2, Maelle is gommaged and returns with the memories of Alicia coming back and her paintress origins and powers re-discovered.
 - Mechanically, it's no-brainer we have to represent (Act 3) Maelle as a planeswalker and that we use the Meld mechanic to combine Alicia and (pre-Act 3) Maelle into this planeswalker.
    - Human Maelle's abilities TBD. I've mainly been focusing on nailing down the meld interaction first. Having limited success so far, thus this card currently does not work. I have been using The Mightstone and Weakstone + Urza, Lord Protector as the initial template.
    - If I can get the meld interaction to finally work and if Forge's rule engine will allow for it, I'd like to try to get the meld to trigger off of Maelle being exiled (for maximum flavor). If this is not feasible, then we'll stick with the existing activation cost.
 - 23/09/2025: I give up trying to get meld to work. Human Maelle will remain a standalone card. Abilities TBD.
 - 6/10/2025: Gave meld another try. I finally got it to work! Human Maelle's regular abilities still TBD.
 - Planeswalker Maelle's abilities for the most part map to her in-game abilities:
    - +2: She now has greater mastery of Chroma in the canvas
    - +1: She now has the power of reanimating dead expeditioners to fight for her
    - 0: Same theme of reanimating/rallying dead expeditioners to her cause
    - -3: She now has the power to erase enemies from the canvas
    - -8: Same theme of reanimating/rallying dead expeditioners to her cause
 - 28/10/2025: Fleshed out Human Maelle's abilities. Her main gimmick is stances, which confers certain attack/defense characteristics depending on stance.
   - Mechanically I've gone with mapping each stance to a set of buffs that last until your next turn.
      - Offensive Stance: Vigilance and +2/+0
      - Defensive Stance: Hexproof, First Strike and +0/+2
      - Virtuose Stance: Double Strike and +1/-1
   - How the stance is chosen is determined by something that's on flavor for any red card: Randomness by a six-sided die roll.
 - 3/11/2025: Abilities changed due to CardConjurer constraints. Removed single human reanimation ability. The 2 expeditioner generation ability moved to +1 loyalty. Cost discount expanded to cover Gradient spells too.
 - Hybrid mana pip is used where the color identity pip is because this particular planeswalker frame does not support color identity pips for some reason.
 - 17/11/2025: Remove hybrid mana pip and replaced with color identity pip as I figured out how to place it in CardConjurer

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

[card implementation](../custom/cards/m/manor_entrance_manor_hidden_room.txt)

### Design Notes

 - In the game, the Manor entrance is there the expedition flag is to save. There is room that is hidden behind a painting that is accessible by jumping through the painting.
 - Gone with an effect to cheat a creature into play with each side represent a different way to cheat said creature into play.

## Manor Fire

```
2(R/G)
Sorcery
Destroy all Rooms.
Draw a card.
---
You're ok.
```

[card implementation](../custom/cards/m/manor_fire.txt)

### Design Notes

 - In the game, this is the event that took Verso's life and started Aline's cycle of grief, made Alicia a pariah, started Clea's war against the writers and Renoir's attempts to get Aline out of the canvas, tearing the Dessendre family apart.
 - A basic foil for room strategies with a cantrip so it's not entirely useless when not facing against room strategies.

## Manor Greenhouse // Manor Gallery

```
Manor Greenhouse
2G
Enchantment - Room
When you unlock this door, search your library for a land card, put it onto the battlefield, then shuffle.

Manor Gallery
3R
Enchantment - Room
When you unlock this door, create a token that’s a copy of another target nonlegendary creature you control, except it has haste. Sacrifice it at the beginning of the next end step.

```

[card implementation](../custom/cards/m/manor_greenhouse_manor_gallery.txt)

### Design Notes

 - In the game, the Greenhouse is at the top of the Manor. The gallery is the room with Verso's canvas (that the world of the continent is in)
 - Greenhouse is a land tutor, because it's ... green!
 - Gallery is another cost reducer to enable painter strategies
 - 3/10/2025: Might rename Manor Gallery to Manor Atelier. I haven't played the video game in months, so I forget if the Atelier is where Verso's canvas resides so Gallery is a placeholder name. Either way this is supposed to be "Manor $ROOM_THAT_HAS_VERSOS_CANVAS"
 - 26/11/2025: Changed Manor Gallery to red and its unlock ability to be a Kiki-Jiki temp clone effect.

## Manor Kitchen // Manor Cellar

```
Manor Kitchen
1G
Enchantment - Room
When you unlock this door, create two Food tokens.

Manor Cellar
1W
Enchantment - Room
When you unlock this door, choose one —
• Create two Chroma tokens.
• Create two Lumina tokens.

```

[card implementation](../custom/cards/m/manor_kitchen_manor_cellar.txt)

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

[card implementation](../custom/cards/m/manor_library_manor_fireplace.txt)

### Design Notes

 - In the game, the library connects the entrance on the side. The fireplace connects to the main dining hall.
 - Library is an easy mechanical map to card draw.
 - Fireplace is an easy mechanical map to a bolt effect because ... fireplace > fire > burn spell.

## Mask Keeper

```
5UB
Legendary Creature - Axon
Trample. Ward {3}
Mask Keeper enters with an anger counter, a joy counter and a sadness counter.
At the beginning of your upkeep, put an anger, joy or sadness counter on him.
Anger mask — Remove an anger counter from Mask Keeper: Untap him.
Joy mask — Remove a joy counter from Mask Keeper: Mask Keeper gains lifelink until end of turn.
Sadness mask — Remove a sadness counter from Mask Keeper: Put a stun counter on target creature.
---
We all need masks.

8/8
```

[card implementation](../custom/cards/m/mask_keeper.txt)

### Design Notes

 - In the game, The Mask Keeper is the true Axon behind Visages.
 - Main gimmick I am capturing here is the 3 masks that grant him various buffs every turn, represented in card form as counters.
    - Anger Mask: Mapped playing twice to untapping himself.
    - Joy Mask: Mapped healing himself to giving himself lifelink temporarily as self-healing is redundant in MTG (all creatures who didn't die of lethal damage self-heal at cleanup anyways).
    - Sadness Mask: Mapped exhaust to putting a stun counter on a creature.
 - The upkeep trigger wording probably sounds a bit weird. Default instinct is to use modal ability templating, but there is no textbox budget for that and there is no other precedent for templating such a triggered ability in this manner. So it is worded this way as a "creative decision".
    - This will be implemented as a modal trigger in Forge.

## Mesmeric Deception

```
XUB
Instant
Tap X target creatures.
Target opponent discards a card.
Draw a card.
---
While the rest of the party was entranced by the memories of their loved ones, Verso had no such attachments and saw straight through Sirène’s deception.
```

[card implementation](../custom/cards/m/mesmeric_deception.txt)

### Design Notes

 - In the game, upon confronting Sirène, she mesmerizes the party with visions and memories of their loved ones. However, Verso had no such memories or attachments and saw straight through her ruse.
 - This cards depicts this moment.
 - Gone with a draft/limited tempo play with mild CA attached.

## Mime

```
2RW
Creature - Shapeshifter
Protects itself — This creature enters with a shield counter.
Hand-to-hand combo — {1}{R}: This creature gains double strike until end of turn.
Strange combo — {2}{W}, {T}: This creature deals 2 damage to target attacking or blocking creature.

2/4
```

[card implementation](../custom/cards/m/mime.txt)

### Design Notes

 - In the game, Mimes are special enemies encountered throughout the continent. Defeating them awards special loot.
 - You would think that mimes, that mimic things would have a blue color identity (the color of illusion and mimicry), but none of its ability set map to anything blue. So it is flavorfully a boros creature.

## Moissoneusse

```
UR
Creature - Nevron
Haste
Applies rush to her allies — {T}: Target creature gains haste until end of turn.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/m/moissoneusse.txt)

### Design Notes

 - In the game, Moissoneusses can be found in Visages.
 - Mapped applying rush to granting haste.

## Monoco, Collector of Feet

```
2(W/G)(W/G)
Legendary Artifact Creature - Gestral Expeditioner
Whenever a nontoken Nevron creature dies, exile it with a Foot counter.
My, what lovely feet! — Monoco has activated abilities of all Nevrons in exile with a Foot counter on them. Monoco has flying as long as an exiled Nevron creature with a Foot counter has flying. The same is true for first strike, double strike, deathtouch, haste, hexproof, indestructible, lifelink, menace, reach, trample and vigilance.
{1}{G}, {T}: Monoco fights target creature.
{2}{W}: Untap Monoco.

4/4
```

[card implementation](../custom/cards/m/monoco_collector_of_feet.txt)

### Design Notes

 - In the game, Monoco is a Gestral that joins your party in Act 2. Every Nevron you defeat with Monoco in the party will add a foot to Monoco's collection. Monoco's skills are based on the Nevron feet that Monoco has equipped. Each Nevron foot grants some ability of the defeated Nevron.
 - Mechanically and flavorfully, this easily maps to one of the many existing "ability stealing" cards already in the card game. So it is a matter of choosing which ability stealing variant we want to copy from. We've gone with a combination of stealing activated abilities of slain Nevron along with a bunch of keyword abilities.
 - Exile with a Foot counter is a book-keeping mechanism to easily track which creatures Monoco will be stealing abilities from.
 - Fight ability provided because Monoco is a Gestral, and Gestrals love to fight, and also serves as an enabler for ability stealing.
 - The untap ability is provided for synergy with any tap activated abilities that Monoco may steal.
 - 3/11/2025: Added Expeditioner sub-type

## Mortify

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Mortify)
### Notes

 - Staple commander removal.

## Nicolas, Seeking Inspiration

```
WU
Legendary Creature - Human Painter Citizen
{T}, Sacrifice a Chroma token: Draw a card.
When this creature dies, create a Chroma token.
---
I know, how about showing me a dance of love and sorrow? I am also the official painter of the Opera. Will you help me? If you inspire me, you may become the main painting of Lumière’s Opera.

1/3
```

[card implementation](../custom/cards/n/nicolas_seeking_inspiration.txt)

### Design Notes

 - In the game's prologue, Nicolas (if spoken to) asks you (Gustave) do dodge Sophie's attacks to inspire him with this painting. This is really just a thinly veiled tutorial on dodging attacks.
 - Mapped inspiration to saccing chroma tokens (Chroma being the "paint/lifeforce" of this world) for card draw.

## Painted Alicia, Eternally Suffering

```
WB
Legendary Creature - Painter God
Activated abilities of Expeditioners, Chroma, Lumina and Pictos cannot be activated.
---
Her silence is deafening.

2/2
```

[card implementation](../custom/cards/p/painted_alicia_eternally_suffering.txt)

### Design Notes

 - In the game, Painted Alicia is the painted counterpart of Alicia
 - Thematically gone with another variant of silence effects to mirror her human counterpart.
    - In this case, an Ethersworn Canonist with Nevron/Painter bias.
    - And a Silence effect for the cost of 3 chroma tokens.
 - 4/11/2025: Exchanged abiltiies with human Alicia. Replaced Nevrons with Expeditioners for the null rod effect.

## Painted Clea, the Regent

```
2UB
Legendary Creature - Painter God
Nevron spells you cast cost {1} less to cast.
Nevron creatures you control get +1/+1.
At the beginning of your upkeep, create a 1/1 colorless Nevron creature token.
Sacrifice a Nevron: Draw a card.
---
Verso: What happened to her?
Maelle: I bet Clea hated Maman's portrait of her. So she painted over her.

3/4
```

[card implementation](../custom/cards/p/painted_clea_the_regent.txt)

### Design Notes

 - In the game, Painted Clea was painted by Aline, but was then repainted over by the real Clea and re-purposed to be what amounts to an endless "Nevron factory"
 - Mechanically, Painted Clea is our Nevorn lord, so I've gone with an assortment of "build around" abilities.
    - Nevron cost reduction
    - Nevron P/T buffs
    - Ability to put out Nevron tokens automatically every upkeep
    - A Nevron tutoring ability
 - NOTE: This is not the Clea Planeswalker so François does not have affinity towards it. Nothing in the actual game suggests François has any affection towards Clea's painted counterpart.
 - 13/10/2025: Removed Devoid.
 - 26/10/2025: Replaced tutoring with a Nevron sac to draw a card.
 - 2/11/2025: Reduced Nevron buff from +2/+2 to +1/+1
 - 27/11/2025: Reduced cost reduction from {2} to {1}
 - 29/12/2025: Renamed to - Painted Clea, the Regent

## Painting Workshop

```
U(W/B)
Enchantment
Whenever you cast a Painter or Gradient spell, draw a card.
{2}{U}, Sacrifice this enchantment: Return target Gradient card from your graveyard to your hand.
```

[card implementation](../custom/cards/p/painting_workshop.txt)

### Design Notes

 - In the game, the Painting Workshop is an area where one must collect 3 items to unlock a barrier, where a Lampmaster boss battle happens.
 - Gone with a card that is a value engine for Painter/Gradient strategies.
 - This is an enchantment instead of a land as we've got enough non-basic lands in this set.

## Pelerin

```
2UR
Creature - Nevron
Whenever this creature is dealt damage from a red source, remove all counters from it and put a fire counter on it.
Whenever this creature is dealt damage from a blue source, remove all counters from it and put an ice counter on it.
This creature has protection from red as long as it has a fire counter on it and protection from blue as long as it has an ice counter on it.
Counterattack — When this creature is dealt combat damage, it deals that amount of damage to target creature an opponent controls.

2/4
```

[card implementation](../custom/cards/p/pelerin.txt)

### Design Notes

 - In the game, Pelerins can be encountered in Frozen Hearts
 - Has the same "flip-flop" elemental immunity as Stalact and Gargant, so has the same flip-flop protection.
 - Copied counterattack ability from Boucheclier as this is its primary gimmick in the game (always retaliating against whoever dealt damage to it)

## Primal Empathy

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Primal Empathy)
### Notes

 - Another case of a quote from the game looking for a suitable reprint to attach itself to.

## Putrefy

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Putrefy)
### Notes

 - Obligatory spot removal in Commander

## Rally the Expeditioners

```
3(W/B)
Kindred Instant - Expeditioner
This spell costs {1} less to cast if you control an Expeditioner.
Choose one —
• Create two 1/1 white Human Expeditioner tokens with "When this creature dies, create a Chroma token."
• Up to two target creatures you control each get +2/+2 until end of turn.
• Destroy target non-Expeditioner creature.
```

[card implementation](../custom/cards/r/rally_the_expeditioners.txt)

### Design Notes

 - In the game, this symbolizes the moment where re-awakened Maelle arrives in Lumière with party and resurrected Expeditioners to commence the final assault.
 - Made this a variant of Rally the Monastery with Expeditioner-aligned benefits.

## Reaper Cultist

```
WB
Creature - Nevron
Flying, First Strike
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/r/reaper_cultist.txt)

### Design Notes

 - Vanilla placeholder Nevron
 - 13/10/2025: Removed Devoid.
 - 13/12/2025: Set P/T to 2/2, changed cost from 2WB to WB, added flying and first strike.

## Sciel, Grieving for Many

```
2WB
Legendary Creature - Human Expeditioner
Each nonland card in your hand without foretell has foretell. Its foretell cost is equal to its mana cost reduced by {2}.
Whenever you foretell a card, you gain 2 life.
Twilight Slash - {W}{B},{T}: Sciel deals 2 damage to target creature, you gain 2 life.
Intervention - {W}{W},{T}: Untap target creature. Create a Chroma token.
Our Sacrifice - {1}{B}{B}, {T}, Pay X life: Creatures target opponent controls get -X/-X until end of turn.
---
Death is a friend who will welcome me home

3/3
```

[card implementation](../custom/cards/s/sciel_grieving_for_many.txt)

### Design Notes

 - Sciel is a kind, emphatheic, nurturing character that specializes in weapons and attacks that deal dark damage. Clearly an Orzhov color identity.
 - In the game, Sciel's attacks build up foretell, which can then be consumed later on for even more powerful attacks. We are using Foretell in the literal sense by re-using the existing Foretell mechanic by having Sciel granting all nonland cards in your hand to be foretelled.
 - Marking Card is just a creature ping that puts a marked counter on it. A creature with a marked counter will be a magnet for more damage.
 - Grim Harvest deals dark damage heals allies. Translated to a creature bolt that also gives you life.
 - Intervention in the game lets an ally play immediately and gain 4 AP. Translated to untapping a creature and giving you a Chroma token.
 - Our Sacrifice in the game deals extreme dark damage to all enemies, absorbing allies' health to deal more damage. Translated to paying X life to -X/-X an opponent's board.
 - 13/10/2025: Dropped the marking card ability due to text box budget constraints having seen this card for the first time in CardConjurer.

## Search // Rescue

```
Search
G
Instant
Search your library for a basic land card, reveal it, put it into your hand, then shuffle.

Rescue
U
Instant
Return target creature to its owner's hand.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](../custom/cards/s/search_rescue.txt)

### Design Notes

 - Represents the search and rescue mission conducted by Expedition 00.
 - Stapled Lay of the Land and Unsummon together.

## Serpenphare

```
5UR
Legendary Creature - Nevron Serpent
Flying. Ward {3}.
Absorbs all APs — {2}{U}: Tap target creature and put a stun counter on it. Put a charge counter on Serpenphare.
Absorbed too many APs, explodes — {4}{R}, Remove X charge counters from Serpenphare: Serpenphare deals X damage to each creature.
---
An omnipresent feature of the continent skies. A reminder that before one can even reach The Monolith, one must get past Serpenphare.

7/7
```

[card implementation](../custom/cards/s/serpenphare.txt)

### Design Notes

 - In the game, Serpenphare is an optional end-game boss. Its most prominent attack is an AP draining ability, if it consumes too much AP with this move, it will explode.
 - Mechanically, we modeled the AP draining ability as a tap and stun with a charge counter being given. The "explode" ability is modeled as removing X charge counters to X damage to every creature (including itself)
 - 19/11/2025: Increased tap-and-stun cost from 1U to 2U. Also added ability words.

## Simon, Consort of Clea // Simon, The Divergent Star

```
3BR
Legendary Creature - Human Expeditioner
Trample
When Simon enters, each other creature has base toughness 1 until end of turn.
Gathers Chroma — {B}{B}, {T}: Target creature has base toughness 1 until end of turn.
When Simon dies, return it to the battlefield transformed under it’s owner’s control.

5/5
```

Transforms into:

```

Legendary Creature - Human Expeditioner
Trample
Double Strike
Simon enters with a foreboding counter.
The dead are removed from the canvas — If a creature would be put into a graveyard from anywhere, exile it instead.
Gathers Chroma — {B}{B}, {T}: Target creature has base toughness 1 until end of turn.
The Expedition is removed from the canvas — {T}, Remove a foreboding counter from Simon: Choose a creature an opponent controls. Exile all creatures except for Simon and the chosen creature.

6/6
```

[card implementation](../custom/cards/s/simon_consort_of_clea_simon_the_divergent_star.txt)

### Design Notes

 - In the game, Simon is a secret endgame boss and is the hardest boss in the game.
 - He is mechanically represented as follows:
    - A double-faced card to represent Phase 1 (front face) and Phase 2/3 (back face)
    - Transforms on death in line with him advancing to Phase 2 upon defeating him in Phase 1.
    - "Gathers Chroma" translated to setting a creature's toughness to 1. Available on both sides in line with this ability being available in all phases.
    - Back side has double strike as a nod to 80% of his moves in the game being rapid-fire swings of his sword.
    - Back side enters with a foreboding counter as a signal that something bad is going to happen soon if Simon is not dealt with quickly.
    - Mapped "The dead are removed from the canvas" to a "Rest in Peace" continuous exile effect. Is in line with what happens when any of your party members die in combat (they are immediately erased).
    - Mapped "The Expedition is removed from the canvas" as a mass exile effect that spares only Simon and one of opponent's creatures. This is the ability spent with the foreboding counter.
 - 13/12/2025: "Simon, The Divergent Star" is now the name of the v2.0 Simon boss in the Endless Tower with the new DLC. Not changing the name of the back half as this name had existed long before the release of this DLC.

## Sirène, Who Plays With Wonder

```
4GWU
Legendary Creature - Axon
When Sirène enters, if you control a creature named Tisseur, put two shield counters on her.
The Grand Ballet Begins — {5}, {T}: For each color of mana spent on this ability, create a 1/1 green Nevron creature token with flying named Ballet.
A Widow Ballet Charms — Sacrifice four creature tokens named Ballet: Gain control of target creature.

8/8
```

[card implementation](../custom/cards/s/sirene_who_plays_with_wonder.txt)

### Design Notes

 - In the game, Sirène is one of two Axons the party must slay in order for The Curator to be able to forge the Barrier Breaker to destroy the Monolith Barrier and gain access to The Monolith.
 - Shield counter ETB a nod to the fact that if you did not defeat Tisseur before facing Sirène in the video game, she will start the battle with shields on her.
 - The main gimmicks we're translating are:
    - Summoning Ballets to do her bidding
    - Charming (ie. Creature control)

## Sprong

```
1UBR
Legendary Creature - Nevron
Multi-strike combo — {R}{R}: Sprong gains double strike until end of turn.
Sabotages the expedition — {U}{U}, {T}: Tap target creature and put a stun counter on it.
Charges Extermination Boom — {2}: Put a charge counter on Sprong.
Extermination Boom — {B}{B}, {T}, Remove X charge counters from Sprong: Sprong deals X damage divided as you choose among any number of target creatures.

5/5
```

[card implementation](../custom/cards/s/sprong.txt)

### Design Notes

 - In the game, Sprong is an optional overworld boss.
 - Grixis color identity chosen so double strike could be flavorfully woven in to its ability suite. Other abilities are on-flavor for their respective colors.

## Stalact

```
1UR
Creature - Nevron
This creature enters with a shield counter.
Whenever this creature is dealt damage from a red source, remove all counters from it and put a fire counter on it.
Whenever this creature is dealt damage from a blue source, remove all counters from it and put an ice counter on it.
This creature has protection from red as long as it has a fire counter on it and protection from blue as long as it has an ice counter on it.
Whenever this creature dies, if it had a fire counter on it, it deals 2 damage to target player. If it had an ice counter on it, draw a card.
Self-destruct — Sacrifice this creature: This creature deals 2 damage to target creature.

2/2
```

[card implementation](../custom/cards/s/stalact.txt)

### Design Notes

 - Has the same "flip-flop" elemental immunity as its big brother (Gargant), so has the same flip-flop protection.

## Stendhal

```
10BR
Sorcery
Devoid (This card has no color.)
Affinity for Lumina (This spell costs {1} less to cast for each Lumina you control.)
Stendhal deals 33 damage to target creature or planeswalker.
```

[card implementation](../custom/cards/s/stendhal.txt)

### Design Notes

 - In the game, Stendhal is one of Maelle's skills. It is unlocked in Act 3 and it notable for being hideously overpowered with the right combination of pictos/luminas and buffs and forms the basis of many "one shot" character builds.
 - Taken another chance to weave in a use of the number 33 by dealing that much to a creature or planeswalker. When you absolutely need to kill something, accept no substitute.
 - Has devoid because it deals extreme void damage in-game.
 - Has Affinity for Lumina (tokens) to not only make casting this easier, but also as a nod to the pictos/lumina investment required in-game to make Stendhal deal damage in the millions.
 - I orignally had thoughts about making it targeting players as well, but with some side-mission you must take to unlock the ability to target players (whether by suspend or mana payment requirements), but decided against that as this set already has 2 "you win the game if certain conditions are met" cards. That's enough, we don't need another one.

## Terminate

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Terminate)
### Notes

 - Obligatory spot removal for Limited/Commander

## The Curator // Renoir, Dessendre Patriarch

```
2UBR
Legendary Creature - Painter Spirit
Picto Reinforcement — {2}{U}, {T}: Create two Lumina tokens.
Upgrades your weapons — {2}{G/W}, {T}: Distribute two +1/+1 counters among one or two target creatures.
Latent skill activation — {3}{B}, {T}, Exert an Expeditioner creature: Destroy target creature.
When The Curator dies, return it to the battlefield transformed under it’s owner’s control.

4/5
```

Transforms into:

```

Legendary Planeswalker - Renoir
Whenever a Nevron you control dies, draw a card and each opponent discards a card.
[+2]: Reveal the top card of your library. If it is a Nevron, Painter or Gradient card, put it into your hand.
[-4]: Return target Nevron card from your graveyard to the battlefield.
[-10]: Exile all non-Nevron, non-Painter creatures.
```

[card implementation](../custom/cards/t/the_curator_renoir_dessendre_patriarch.txt)

### Design Notes

 - In the game, The Curator is an ally to Expedition 33, until Act 3 where he is revealed to be the real Renoir.
 - Abilities drawn from various abilities he offers at camp.
   - Latent skill activation is a nod to him "helping" Maelle gommage painted Renoir at the conclusion of his boss battle near the end of Act 2. Destroy instead of exile because her full painter powers are not yet fully unlocked.
 - As much as I personally despise double-faced cards (because of logistics around limited and sleeves, requiring paper hacks like checklist cards), flavorfully this has to be a creature that transforms to his Planeswalker half.
   - If we ever print this, it will be printed over 2 cards and not as a double-faced one, because I want a printed version of this set to be playable as-is without sleeves (as Richard Garfield intended).
 - Is a Painter Spirit instead of Painter God because The Curator is Renoir's *ethereal* form that allows him to escape his prison at the bottom of the Monolith.
 - In terms of Planeswalker design it revolves around the Nevron/Painter alliance and abilities that benefit them both.
 - 29/11/2025: Mana costs adjusted so that he can be a 5c Nevron commander.

## The Fate of the Canvas

```
4WB
Sorcery
Choose one —
• Fight as Verso — Exile all permanents. Exile all graveyards. Each player exiles their hand.
• Fight as Maelle — Return to the battlefield all Humans and Expeditioners you own from your graveyard and in exile.
---
Life keeps forcing cruel choices.
```

[card implementation](../custom/cards/t/the_fate_of_the_canvas.txt)

### Design Notes

 - In the game, this is the final point of no return that culminates in one of the two possible endings of the game.
 - Simply mechanically translated to a mass reset or mass resurrection.

## The Greatest Expedition in History

```
WUBRG
Kindred Sorcery - Expeditioner
You win the game if you control a total of 33 or more Expeditioner, Chroma, Lumina or Picto permanents.
---
When one falls, we continue.
```

[card implementation](../custom/cards/t/the_greatest_expedition_in_history.txt)

### Design Notes

 - If you're doing nothing with these Chroma and Lumina tokens being generated then this spell is a goal to reach towards.
 - This card also let's us do something with the number 33, which has great symbolic significance in the game.

## The Paintress // Aline Dessendre, Stricken by Grief

```
RGWU
Legendary Creature - Painter God
Void Meteors — {B}{R}, {T}: The Paintress deals 3 damage divided as you choose among any number of target creatures and/or planeswalkers.
Rips apart reality — {2}{U}, {T}: Up to two target nonland permanents phase out.
Heals an Expeditioner — {W}{G}, {T}: You gain 1 life for each Expeditioner you control.
When The Paintress dies, return it to the battlefield transformed under it's owner's control.

6/6
```

Transforms into:

```

Legendary Planeswalker - Aline
At the beginning of your upkeep, create a Chroma token.
[+2]: Aline Dessendre, Stricken by Grief deals X damage to up to one target creature or planeswalker and you gain X life, where X is the number of Chromas you control.
[-3]: Exile target nonland permanent.
[-8]: Creatures you control gain +X/+X until end of turn, where X is the number of Chromas you control.
```

[card implementation](../custom/cards/t/the_paintress_aline_dessendre_stricken_by_grief.txt)

### Design Notes

 - In the game, The Paintress is the main antagonist, until the conclusion of Act 2, when you discover she is not. She is in fact, trying to *protect* the people of Lumière from the true instigator of the yearly Gommages (Renoir) and her yearly countdown on The Monolith is a signal of her waning powers in fighting against this tide.
 - Abilities drawn from the various moves she has in her boss battle. Because 2 of these 3 abilities already exist as separate cards, we've gone with slight tweaks/variations for the abilities here.
   - Void Meteors: Only deals 3 damage and can only target creatures.
   - Rips apart reality: Phases out permanents instead of putting it on top/bottom of owner's library.
 - As much as I personally despise double-faced cards (because of logistics around limited and sleeves, requiring paper hacks like checklist cards), flavorfully this has to be a creature that transforms to her Planeswalker half.
   - If we ever print this, it will be printed over 2 cards and not as a double-faced one, because I want a printed version of this set to be playable as-is without sleeves (as Richard Garfield intended).
 - In terms of planeswalker design, the primary theme is around Chroma and her mastery of it.
 - 29/11/2025: Void meteor ability cost adjust so that she can be a 5c commander.

## The Scavenger

```
2BG
Legendary Creature - Nevron
Ward {2}.
When The Scavenger enters, return target permanent card with mana value 3 or less from your graveyard to tbe battlefield.
If an opponent would create a Lumina token, you create a Lumina token instead.
Sacrifice a Lumina token: Add one mana of any color.
Sacrifice a Nevron: Add two mana of any one color.
{2}{B/G}, {T}: Return target permanent card from your graveyard to your hand.


4/4
```

[card implementation](../custom/cards/t/the_scavenger.txt)

### Design Notes

 - In the game, Scavenger is a boss in the Falling Leaves.
 - We are deviating from any thematic mapping and 100% leaning in solely on the name to provide an all-round value engine for Nevrons.

## Tisseur

```
3BG
Legendary Artifact Creature - Nevron Construct
Reach, first strike
At the beginning of each player’s upkeep, that player sacrifices a creature they control with a cursed counter on it.
{4}, {T}: Put a cursed counter on target creature.
---
Maelle: What’s that?
Verso: The tisseur, it works for Sirène.
Lune: So he creates all of that for her.

4/5
```

[card implementation](../custom/cards/t/tisseur.txt)

### Design Notes

 - In the game, Tisseur is an optional boss in Sirène's Coliseum. Defeating it will make the upcoming boss fight against Sirène much easier.
 - Made it an artifact creature as it clearly has artificial instead of organic nature. It looks like a thread spindle with a head and arms attached to it. Nothing organic about that!
 - Has reach as I view Tisseur weaving fabric the same way a spider (a classic creature that always has reach) weaves webs.
 - Main gimmick I'm translating is its cursing ability which I'm translating it to putting "you are getting sacced next upkeep" counters on creatures.

## Tomorrow Comes

```
WU
Kindred Instant - Expeditioner
Look at the top three cards of your library. Put one of them into your hand and the rest on the bottom of your library in any order.
You gain 3 life.
Luminous — If you control three or more Lumina tokens, create two 1/1 Human Expeditioner tokens with "When this creature dies, create a Chroma token."
```

[card implementation](../custom/cards/t/tomorrow_comes.txt)

### Design Notes

 - Another tutor to enable the Expeditioner tribal strategy / Expeditioner spell toolbox.
 - 12/11/2025: Rework as a life-gaining impulse with a token generating Luminous bonus.

## Torture // Nurture

```
Torture
1B
Instant
Target creature gets -2/-2 until end of turn. It's controller loses 2 life.

Nurture
1W
Instant
Target creature gets +2/+2 until end of turn. It's controller gains 2 life.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](../custom/cards/t/torture_nurture.txt)

### Design Notes

 - Just wanted a card that's a wordplay on one of Sciel's character traits (nurturing) and its polar opposite.

## Troubador

```
1RG
Creature - Nevron
Applies powerful to allies — Other Nevron creatures you control get +1/+1.
Applies rush to allies — Nevrons you control have haste.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/t/troubador.txt)

### Design Notes

 - In the game, a Troubador uses its horn to buff the enemy party.
 - Mechanically, I've mapped this to a basic nevron lord buff effect.
 - 21/10/2025: Added lord haste effect to match its character sheet.
 - 26/10/2025: Made it red/green in line with the buffs it gives out.
 - 17/11/2025: Changed mana cost from 2(R/G) to 1RG

## Verso, Who Guards Truth With Lies

```
1U(W/B)
Legendary Creature - Human Expeditioner
Whenever Verso untaps or deals damage, put a rank counter on him.
Whenever Verso is dealt damage, remove all rank counters from him.
Immortality — {1}{W}{B}: Return Verso from your graveyard to the battlefield tapped with a stun counter.
Strike Storm — Verso has Double Strike as long has he has 3 or more rank counters.
Marking Shot — {U/B}, {T}: Verso deals 1 damage to any target. If you have 3 or more rank counters, it deals 2 damage to any target instead.
Phantom Stars — {4}{W}, {T}, remove X rank counters from Verso: Verso deals X damage to each creature your opponents controls.
---
Let's carve a path.

3/3
```

[card implementation](../custom/cards/v/verso_who_guards_truth_with_lies.txt)

### Design Notes

 - The main gimmick we want to mechanically capture is his rank. Rank is gained from dealing damage and is lost on taking damage.
 - Easy map to gain/loss of rank counters on dealing damage/taking damage. For game balance, Verso will lose all rank counters on a single hit.
 - Resurrection ability because he's immortal.
 - Added an assortment of buffs and abilities that are conditional on the number of rank counters.
 - "Phantom Stars" ultimate is paid in rank counters for game balance purposes. In game, none of Verso's abilities cost him is rank.

## Verso's Composition

```
GW
Enchantment
At the beginning of your upkeep, you may put a verse counter on this enchantment.
Sacrifice this enchantment: Target creature gets +X/+X and lifelink until end of turn, where X is the number of verse counters on this enchantment.
---
Maelle: What song was that? I feel like I know it.
Verso: Yeah, it’s an old song I used to play to my sister.
Maelle: Can you play another?
```

[card implementation](../custom/cards/v/versos_composition.txt)

### Design Notes

 - In the game, during one of the camp cutscenes, Verso plays some tunes on his piano.
 - Modeled on War Dance, with a lifelink bonus attached.

## Vicarious Envy

```
UB
Instant
Target creature you control becomes a copy of target creature until end of turn.
---
I envy them, those who can’t see. Those who know not, that they are not. And those who live, blithe and free, sins forgotten and thus absolved. A fresh dawn in their playground, while we live in shadows, swimming in ink. We are but a fragile dream, a singular weed, resisting, ever resisting.
- Masked Woman
```

[card implementation](../custom/cards/v/vicarious_envy.txt)

### Design Notes

 - In the game, before entering Stone Wave Cliffs, Maelle requests the party set up camp and rest. That night, Painted Alicia encounters Maelle while asleep, and begins an internal monologue about how she is envious of Maelle's situation of not knowing that she is actually the real Alicia painted over, not bearing the scars and torment that her painted counterpart has to endure in perpetuity.
 - This card is a flavorful translation of Painted Alicia's internal monologue as a temporary creature copy effect (to represent the desire to be someone else).
 - Name was chosen for maximum cromulence.
    - Vicarious: (adjective) Experienced or felt by empathy with or imaginary participation in the life of another person.

## Void Meteors

```
2BR
Sorcery - Gradient
Devoid (This card has no color.)
This spell costs {2} less to cast if you control a painter.
Void Meteors deals 4 damage divided as you choose among any number of targets.
---
How cruel of your father to use you like this.
- The Paintress
```

[card implementation](../custom/cards/v/void_meteors.txt)

### Design Notes

 - In the game, this is one of the Paintress' moves in the boss fight with her.
 - Mechanically, I based this on Pyrotechnics, but moved to Rakdos colors and with a Painter's discount.
 - 13/10/2025: Removed Devoid.
 - 15/11/2025: Devoid is back on the menu. I figured out how to add colorless frame layer to CardConjurer.

## Void Rend

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Void Rend)
### Notes

 - Commander spot removal.

## Whee // Whoo

```
Whee
1WU
Instant
Untap all creatures you control.

Whoo
1UB
Instant
Tap all creatures your opponents control, then put a stun counter on each of those creatures.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](../custom/cards/w/whee_whoo.txt)

### Design Notes

 - In the game, Esquie describes his moods as sometimes being Whee (happy) and sometimes being Whoo (sad)
 - Mechanically, I based Whoo on Melancholy, but for all creatures. Once I got the Whoo part down, the Whee part is obviously the opposite effect. And since sometimes one can feel a little bit of Whee and a little bit of Whoo, I've added the Fuse ability so that both halves can be cast at once.
 - 4/11/2025: Went with stun counters for Whoo which gives the same effect but simplifies book-keeping as physical counters are involved.

## When One Falls // We Continue

```
When One Falls
4W
Sorcery
Return all Expeditioner permanent cards from your graveyard to the battlefield.

We Continue
4U
Sorcery
Take an extra turn after this one.

Fuse (You may cast one or both halves of this card from your hand.)
```

[card implementation](../custom/cards/w/when_one_falls_we_continue.txt)

### Design Notes

 - In the game. "When one falls, we continue" is the expeditioner's motto. To strive onwards and continue, no matter what setbacks.
 - Mechanically:
    - "When one falls" evokes in my mind an effect akin to Second Sunrise, so I've based it on that but scoped to Expeditioners
    - "We continue" evokes in my mind a Time Walk effect.
 - 23/09/2025: I will most likely change the "When One Falls" side to be a straight mass Expeditioner reanimation effect instead of one that only reanimates those that died this turn, which would make it more of a game-swinging bomb when cast fused, because if you are able to resolve this fused, you deserve to win the game at that point.
 - 3/10/2025: Changed "When one Falls" side to a straight mass Expeditoner reanimation effect and bumped cost from 3W to 4W

