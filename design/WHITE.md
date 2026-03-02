# Cards

> Last generated: 2/3/2026 2:28:47 pm

## A Life to Love (Farewell)

> This card is a nicknamed reprint of (Farewell)
[Scryfall](https://scryfall.com/search?q=Farewell)

### Notes

 - Staple commander board wipe

## Acceptance

```
2W
Creature - Incarnation
This creature enters with a shield counter on it.
Any damage dealt to you is dealt to this creature instead.
{4}{W}, {T}: Put a shield counter on this creature.
---
"I'm FINE. I've lived 33 good years. Look around. We've had our whole lives to prepare. We'll be fine."
—Sophie

2/2
```

[card implementation](../custom/cards/a/acceptance.txt)

### Design Notes

 - No in-game basis, but Grief is such a central theme of Expedition 33 that having a cycle dedicated to the 5 stages is a total flavor nuke.
 - I'm taking the word Acceptance literally (or is it figuratively?) and gone with a creature that "accepts" all damage that would've gone your way.
 - 28/12/2025: Made shield counter ability require a tap in its activation cost.
 - 14/01/2026: Reduced cost from 2WW to 2W and increased shield cost from [2W, T] to [4W, T]


### Rulings

 - Combat damage to you is one "unit" of damage absorbed by one shield counter. One or more creatures that deal double strike damage to you is two "unit"s of such damage and will kill this creature if it does not have at least 2 shield counters on it.

## All Set

```
3W
Kindred Instant - Expeditioner
Creatures you control get +0/+2 until end of turn.
If {R} was spent on this spell, creatures you control gain haste until end of turn.
If {G} was spent on this spell, creatures you control get +2/+0 until end of turn.
Create a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")
Foretell {2}{W}
```

[card implementation](../custom/cards/a/all_set.txt)

### Design Notes

 - In the game, All Set is one of Sciel's abilities. It grants Shell, Powerful and Rush to your entire party.
 - Mapped to an instant that grants toughness boost (Shell), with haste (Rush) and power boost (Powerful) if the appropriate colors of mana are spent.
 - 14/01/2026: Added Lumina token bonus on resolution.
 - 6/02/2026: Added Foretell to increase cards in set with Foretell and add more mystery to what a Foretold card could be.

## Amandine, Fashion Stylist

```
1W
Legendary Creature - Human Citizen
{W}, {T}: Attach target Equipment you control to target creature you control.
When this creature dies, create a Chroma token. (It's an artifact with "{T}, Sacrifice this artifact: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.")
---
"Oh hey handsome, perfect timing. I’m styling everyone before we ship out. Gotta look sharp when we hit the Paintress, eh?"

1/2
```

[card implementation](../custom/cards/a/amandine_fashion_stylist.txt)

### Design Notes

 - In the game's prologue, Amandine can be found at the Expedition Festival. You can trade her a festival token for a haircut.
 - Mechanically translated fashion to equipment, hence Amandine main ability is being able to attach equipment to other creatures.

## Austere Command

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Austere%20Command)

### Notes

 - Staple commander board wipe

## Blanche, the Unfinished Creation

```
WW
Legendary Creature - Nevron Horror
Whenever a white Nevron creature enters, create a Lumina token and you gain 2 life. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")
---
"You... The ones who conquered the Monolith... And bested she who claimed this painting as her own. Mistress shall be pleased to hear of your feat."

2/2
```

[card implementation](../custom/cards/b/blanche_the_unfinished_creation.txt)

### Design Notes

 - In the game, Blanche is an Unfinished Nevron. If you spared every Unfinished Nevron up to that point, she will reward you with lots of lumina.
 - Easy map to rewarding you lumina tokens and life when white (unfinished) nevrons enter.
 - 21/01/2026: Added Horror sub-type.

## Bruler & Cruler, Nevron Blacksmiths

```
2WW
Legendary Creature - Nevron Artificer
Vigilance
When Bruler & Cruler enters, if you control an Equipment, draw a card.
Equip abilities you activate cost {1} less to activate.
---
"Someone found our shop! I was this close to believing that we’d never have clients. Our location is terrible."

3/4
```

[card implementation](../custom/cards/b/bruler_&_cruler_nevron_blacksmiths.txt)

### Design Notes

 - In the game, an unfinished Bruler and Cruler can be found in the Coastal Caves. They've adopted a new career as blacksmiths and sell an assortment of weapons.
 - Added an assortment of equipment-related benefits in line with any "blacksmith" card printed thus far.

## Ceramic Chevalière

```
2W
Artifact Creature - Nevron Soldier
First strike
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

3/1
```

[card implementation](../custom/cards/c/ceramic_chevaliere.txt)

### Design Notes

 - In the game, Ceramic Chevalières can be found in Old Lumière.
 - Is an artifact creature due to its statue-like nature.
 - Moveset in game is somewhat unremarkable, so based on appearance I've gone with a Nevron version of Porcelain Legionnaire.

## Chroma Barrier

```
2WW
Legendary Enchantment
Creatures cannot attack you unless their controller sacrifices a Chroma token for each creature they control that's attacking you.
{3}: Create a Chroma token. Any player may activate this ability. (It's an artifact with "{T}, Sacrifice this artifact: Add one mana of any color. Spend this mana only to cast a Nevron, Gestral or Expeditioner spell.")
---
"This looks similar to Lumière's shield dome. Maybe we can just cross it."
—Lune
```

[card implementation](../custom/cards/c/chroma_barrier.txt)

### Design Notes

 - In the game, the Chroma Barrier protects The Monolith from external intrusion. Only Expedition 70, 60 and 33 have successfully breached this barrier.
 - I've mechanically mapped this to a Ghostly Prison style effect, but the attacking tax is Chroma counters.
 - To make it fair for players without a Chroma token generation strategy, I've added a symmetrical Chroma token generation ability. Thus the real attacking tax is {3} or saccing a Chroma token.

## Chroma Prison

```
2W
Enchantment
If you control a Painter, you may cast this spell as though it had flash.
When this enchantment enters, exile another target nonland permanent.
When this enchantment leaves the battlefield, return the exiled card to the battlefield under its owner's control.
---
"For those who come after, right?" said Gustave, resigned to his fate. "No no no no... You promised..." pleaded Maelle.
```

[card implementation](../custom/cards/c/chroma_prison.txt)

### Design Notes

 - Oblivion Ring variant #234898572343
 - This represents the barrier that Painted Renoir traps Maelle in at the Stone Wave Cliffs.
 - Gave it Nevron/Painter affiliated bonuses
 - 26/09/2025: Converted from Kindred Enchantment - Nevron to a regular Enchantment and give the flash bonus only for painters.

## Clair

```
2W
Creature - Nevron Horror
Performs a silencing combo — {2}{W}, {T}: Target creature an opponent controls loses all abilities until end of turn.
Protects its allies — {3}{W}, {T}: Put a shield counter on target creature you control.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/c/clair.txt)

### Design Notes

 - In the game, it has abilities to shield its party and cause silence to player characters.
 - Mechanically represented here as:
    - Granting shield counters
    - A temporary "humility" effect to represent silencing.
 - The only white nevron in this set that is finished (it cannot be any other color for flavor reasons). All other white nevrons are unfinished.
 - 13/10/2025: Removed Devoid.
 - 21/01/2026: Increased shield counter activation cost from 1W to 3W
 - 3/02/2026: Added Horror sub-type.

## Danseuse Teacher

```
3WW
Creature - Nevron
Vigilance
{2}{W}, {T}: This creature deals 2 damage to target attacking or blocking creature.
---
"How can you not care about the dance between life and death? It is thrilling, elegant, and the most intimate encounter you could ever have."

4/4
```

[card implementation](../custom/cards/d/danseuse_teacher.txt)

### Design Notes

 - In the game, the Danseuse Teacher is an unfinished Nevron that rewards you with a costume if you can beat her parry challenge.
 - Is white as that's the color we've designated for unfinished Nevrons.

## Expedition 32 Trainees

```
1W
Creature - Human Expeditioner
Training (Whenever this creature attacks with another creature with greater power, put a +1/+1 counter on this creature.)
When this creature dies, create a Chroma token.
---
Although the citizens of Lumière always hope for the current Expedition to succeed, trainees operate with the understanding that success is never guaranteed, that they will be next in line and must plan accordingly.

2/3
```

[card implementation](../custom/cards/e/expedition_32_trainees.txt)

### Design Notes

 - In the game, upon the defeat of The Paintress, the party triumphantly returns to Lumière. The next group of Expeditioners are among those welcoming back the party and wanting to pick their minds on how they did the impossible.
 - This card depicts such Expeditioners.
 - Training was already an existing mechanic, so this creature uses that.
 - 21/01/2026: Color-shifted from white to white/blue hybrid.
 - 3/03/2026: Color-shifted from white/blue hybrid back to white.

## Expedition 49

```
3W
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — You gain 2 life for each creature you control.
II — Put a shield counter on each creature you control.
III — Creatures you control gain indestructible until end of turn.
```

[card implementation](../custom/cards/e/expedition_49.txt)

### Design Notes

 - Journal is about expeditioners who carried out their mission through strong defense/healing tactics, which proves to be their downfall as their weak offensive capabilities prove to be ineffective against the Nevrons.
 - Easy mechanical map to life gain and defensive buffs.

## Expedition 49 Healer

```
2W
Creature - Human Expeditioner Cleric
Whenever you create a Chroma or Lumina token, you gain 1 life.
{2}, {T}: Prevent the next X damage that would be dealt to any target this turn, where X is the number of Chroma and Lumina tokens you control.
When this creature dies, create a Chroma token.
---
"For our allies who come after, sadly our lives may have proven that defense is both absolutely necessary and wholly insufficient."
—Christophe, Expedition 49

2/2
```

[card implementation](../custom/cards/e/expedition_49_healer.txt)

### Design Notes

 - In the game, Expedition 49 employed strong defensive and healing tactics against Nevrons which proved ineffective as their offensive capabilities were really weak.
 - Easy mechanical map to a creature with life gain and damage prevention abilities.

## Expedition 49 Protector

```
2W
Creature - Human Expeditioner Cleric
Flash
When this creature enters, put a shield counter on target creature.
{W}, {T}: Target creature you control gains protection from Nevrons until end of turn.
When this creature dies, create a Chroma token.
---
"We can hold the line for another few days but we need to find a way out, our water supply is running dangerously low."
—Christophe, Expedition 49

2/2
```

[card implementation](../custom/cards/e/expedition_49_protector.txt)

### Design Notes

 - Another combat trick for white.
 - Thematically, put it under the Expedition 49 banner as that was the expedition that emphasized defensive tactics.

## Expedition 54 Dissident

```
1W
Creature - Human Expeditioner Rebel
{4}, {T}: Search your library for a Rebel or Expeditioner permanent card with mana value 3 or less, put it onto the battlefield, then shuffle.
When this creature dies, create a Chroma token.
---
"Lumière operates a certain way. It favors a certain group and a certain outcome and if you question the Council, well, the Council’s going to question you. Push too hard to change things and you just might end up on the next Expedition."

2/2
```

[card implementation](../custom/cards/e/expedition_54_dissident.txt)

### Design Notes

 - Vanilla bear wtih Rebel sub-type (as a synonmym of dissent)
 - 26/01/2026: To improve playability, added the Rebel chain tutoring ability but can also get Expeditioners.

## Expedition Recruiter

```
2W
Creature - Human Expeditioner
When this creature enters, you may search your library for an Expeditioner card, reveal it, put it into your hand, then shuffle.
When this creature dies, create a Chroma token.
---
"Your time left in this lifetime is limited, why not make it count for something?"

1/1
```

[card implementation](../custom/cards/e/expedition_recruiter.txt)

### Design Notes

 - [OBSOLETE] No direct representation in the video game, but I can easily imagine there are some people in Lumière whose job is to be trying to recruit citizens who are soon to be gommaged, persuading them to embark on the next Expedition, to make use of the limited time they have left in this world.
 - Goblin Matron, but for Expeditioners with standard death bonus.
 - 3/10/2025: This + Tomorrow Comes + Expedition 70 gives us effectively 12 Expeditioner tutors. This may be overkill and the Expeditioner strategy too consistent and we may have to rework one or more of these cards. Further playtesting will tell us.
 - 24/12/2024: Upon a second NG+ playthrough it turns out there was Expedition recruiters in the prologue (it was Alan and Catherine doing the recruiting)! I must've been psychic (or had some latent medium-term memory to remember this fact!)


### Rulings

 - Can tutor for any card that has the sub-type of Expeditioner.

## Gustave's Burial

```
1W
Enchantment
When this enchantment enters, draw a card.
Whenever a creature dies, create a Lumina token and you gain 1 life. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")
---
"We could never tell if you were my brother or my father. But to me you were both. The best brother and father I’ve ever had."
—Maelle
```

[card implementation](../custom/cards/g/gustaves_burial.txt)

### Design Notes

 - In the game, after defeating the Dualliste, the party find a special tree at Verso's recommendation where Maelle buries Gustave's remains.
 - Card depicts this moment.
 - 19/01/2026: Added Lumina token bonus on creature death.

## Light the Path

```
1W
Instant
Target creature can’t be blocked this turn.
Draw a card.
Foretell {W} (During your turn, you may pay {2} and exile this card from your hand face down. Cast it on a later turn for its foretell cost.)
```

[card implementation](../custom/cards/l/light_the_path.txt)

### Design Notes

 - Inspired by a screenshot I captured from a DLC run in Stone Wave Cliffs
 - 6/02/2026: Added Foretell to increase cards in set with Foretell and add more mystery to what a Foretold card could be.

## Lumière Assault

```
2W
Kindred Instant - Expeditioner
Create two 1/1 white Human Expeditioner tokens with "When this creature dies, create a Chroma token."
Luminous — Draw a card if you control at least three Lumina tokens.
Flashback — Sacrifice two Lumina tokens.
---
With her newfound powers, Maelle brought back the spirits of Expeditions past to even the odds.
```

[card implementation](../custom/cards/l/lumiere_assault.txt)

### Design Notes

 - Primarily designed to support the Crippling Tsunami Prison strategy
 - 7/11/2025: Changed flashback cost from saccing 2 Chroma tokens to 2 Lumina tokens.

## Lumièrian Apprentice

```
1W
Creature - Human Citizen
Whenever another non-Human creature enters, investigate. (Create a Clue token. It's an artifact with "{2}, Sacrifice this artifact: Draw a card.")
---
He eagerly absorbs the knowledge given to him, for he knows when his time comes, it will be a valuable resource.

1/3
```

[card implementation](../custom/cards/l/lumierian_apprentice.txt)

### Design Notes

 - In the game, some of the children/teenagers of Lumière are apprentices of Expeditioners, absorbing as much knowledge passed down to them should they fail and they will eventually become Expeditioners themselves and need to take up the mantle.
 - Modeled their "curiosity" as giving you clues whenever a "foreign" creature type enters the battlefield.
 - One of the rare humans in this set that are not Expeditioners.
 - 21/01/2026: Color-shifted from white to white/blue hybrid.
 - 26/01/2026: Changed clue trigger from non-Expeditioner to non-Human as investigating when a Human (that's not an Expeditioner) enters is non-sensical from a flavor perspective.
 - 3/03/2026: Color-shifted from white/blue hybrid back to white.

## Path to Exile

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Path%20to%20Exile)

### Notes

 - Obligatory spot removal in Commander

## Payback

```
3WW
Kindred Instant - Expeditioner
Payback deals 5 damage divided as you choose among any number of target attacking or blocking creatures.
Create a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")
---
"Let’s dance!"
```

[card implementation](../custom/cards/p/payback.txt)

### Design Notes

 - In the game, this is one of Maelle's skills
 - Roil's Retribution fits the bill (in both flavor and mechanics), so it was chosen as a nickname reprint for this.
 - 21/01/2026: Converted to a functional reprint of Roil's Retirbution (instead of a nicknamed reprint) so we can add an Expeditioner sub-type and tack on a Lumina token bonus.

## Perfect Dodge

```
XW
Kindred Instant - Expeditioner
Exile X target creatures you control. Return them to the battlefield under its owner's control at the the beginning of the next end step.
Luminous — Draw a card if you control at least three Lumina tokens.
```

[card implementation](../custom/cards/p/perfect_dodge.txt)

### Design Notes

 - In the game, enemy attacks can be dodged or parried. A dodge performed at the right time is a perfect dodge.
 - Mechanically translated to a basic blink effect. Can be used as a defensive combat trick or to milk extra ETB triggers on your creatures.

## Sciel's Intervention

```
1W
Kindred Instant - Expeditioner
Untap target creature you control. It gains hexproof until end of turn.
Luminous — Draw a card if you control at least three Lumina tokens.
Foretell {W} (During your turn, you may pay {2} and exile this card from your hand face down. Cast it on a later turn for its foretell cost.)
---
"Your turn to shine!"
```

[card implementation](../custom/cards/s/sciels_intervention.txt)

### Design Notes

 - In the game, Intervention is Sciel's ability that lets an ally take their turn immediately along with an AP boost
 - Mechanically, we've mapped "granting extra turns" to untapping creatures. Nothing approximates an "AP boost" for creatures, so we've given it a granting of hexproof.
 - This has the name of "Sciel's Intervention" as "Intervention" on its own is too generic has a risk of being "name-squatted" by an actual card from Wizards in the future.
 - 6/02/2026: Added Foretell to increase cards in set with Foretell and add more mystery to what a Foretold card could be.

## Second Thoughts

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Second%20Thoughts)

### Notes

 - Another case of a quote from the game looking for a suitable reprint to attach itself to.
 - Useful spot removal in limited/draft.

## Sibling Overwatch

```
2W
Enchantment
Flash
As this enchantment enters, choose a creature type.
{W}, Tap an untapped creature you control of the chosen type: Prevent all damage that would be dealt to another target creature of the chosen type this turn.
---
"We are her guardians, not her jailers."
—Emma
```

[card implementation](../custom/cards/s/sibling_overwatch.txt)

### Design Notes

 - In the game, inside Verso's Treehouse in Verso's Drafts, there are various artpieces depicting Verso interacting with various family members. One of them is him keeping eye on his younger sister, Alicia.
 - Modeled as a "Circle of protection" for creatures that can protect a creature by tapping another creature of the same kind.
 - 3/2/2026: Added Flash to improve its standing as a combat trick.

## Swords to Plowshares

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Swords%20to%20Plowshares)

### Notes

 - Obligatory spot removal in Commander

## Unfinished Bénisseur

```
1W
Creature - Nevron
Defender, vigilance
Sacrifice a Chroma token: This creature loses defender. (This effect lasts indefinitely.)
---
"All this chroma has been rather... energizing. Thanks to you, I awaken from my slumber. Did my tales interest you this much?"

3/4
```

[card implementation](../custom/cards/u/unfinished_benisseur.txt)

### Design Notes

 - In the game, an Unfinished Bénisseur can be found in the Red Woods. It assumes the appearance of a "Wishing Well" requiring several Chroma donations of increasing quantities, which at that point it finally reveals itself and rewards you with a picto.
 - Mapped this to a cost-efficient creature with defender requiring a simple Chroma token "payment" to remove defender.

## Unfinished Bourgeon

```
W
Creature - Nevron
Whenever a Nevron creature dies, you may put a skin counter on this creature.
Remove three skin counters from this creature: It becomes a Nevron with base power and toughness 6/6, reach and trample.
---
"Need to go. High! Help me, grow!"

1/1
```

[card implementation](../custom/cards/u/unfinished_bourgeon.txt)

### Design Notes

 - In the game, the Unfinished Bourgeon can be found in a small cave. It is a small bourgeon that wants to consume the skin of a slain Bourgeon to be able to grow into a full size Bourgeon.
 - Modeled this as a tiny Nevron that gets skin counters on Nevron death that grows into a big boy Bourgeon for 3 skin counters.
    - Granting skin counters on any Nevron death is a small thematic compromise as there's only one Bourgeon in this set and that's too marginal of a triggering condition, even if it's lore accurate.
 - 17/01/2026: Changed trigger counter to "may"

## Unfinished Chalier

```
2W
Creature - Nevron
Flash
Sacrifice this creature: Choose one —
• Put two +1/+1 counters on target creature.
• Put a lifelink counter on target creature.
• Put a vigilance counter on target creature.
---
"My kind knows only battle. We are born into a world of strife, yet I seem to be the only one who does not revel in it."

2/3
```

[card implementation](../custom/cards/u/unfinished_chalier.txt)

### Design Notes

 - In the game, an Unfinished Chalier can be found in the Floating Cemetery. It asks you which weapon it should arm itself which, after which it challenges you to combat. Upon defeating it, it will ask you to finish the job. Finishing the job, it will reward you with a picto beforehand. Failure to do that, it will finish the job by itself and you will get no reward.
 - Modeled this as just a Nevron with a modal sac ability. One mode for each weapon.
 - 5/06/2026: Added Flash.

## Unfinished Démineur

```
W
Creature - Nevron
Exhaust — Sacrifice a nontoken artifact: Put a +1/+1 counter and a flying counter on this creature. (Activate each exhaust ability only once)
---
"It doesn’t seem threatening."

1/1
```

[card implementation](../custom/cards/u/unfinished_demineur.txt)

### Design Notes

 - In the game, an Unfinished Démineur can be found in Flying Waters. It is missing its mine. Returning back its missing mine will reward you with a picto.
 - Modeled this as a tiny Nevron with a one-time sac of a nontoken artifact (the missing "mine") to turn it to its fully realized self.

## Unfinished Hexga

```
1W
Creature - Nevron Elemental
This creature can't attack or block unless it has three or more crystal counters on it.
Whenever a land enters, you may put a crystal counter on this creature.
---
"Abandoned... and incomplete. Entrapped in stone.... Quite the situation I’m in, right?"

4/4
```

[card implementation](../custom/cards/u/unfinished_hexga.txt)

### Design Notes

 - In the game, an Unfinished Hexga can be found at the Stone Wave Cliffs. It wants you to find three rock crystals and install them on its back. Doing so will reward you with a picto.
 - Modeled this an an undercosted beater that can't attack or block until it has 3 crystal counters (the rock crystal). Triggered on land drops as finding the rock crytals in the video game requires *exploring*.
 - 17/01/2026: Changed trigger counter to "may"
 - 21/01/2026: Added Elemental sub-type.

## Unfinished Jar

```
4W
Creature - Nevron
When this creature enters, draw a card if {U} was spent to cast it, you gain 3 life if {G} was spent to cast it, put a Menace counter on it if {R} was spent to cast it and put a Lifelink counter on it if {B} was spent to cast it.
---
"Shine. I need to shine."

4/4
```

[card implementation](../custom/cards/u/unfinished_jar.txt)

### Design Notes

 - In the game, an Unfinished Jar can be found in Spring Meadows. It wants you to find something (resin) to light its lamp. Doing so will reward you wtih a healing tint shard.
 - Modeled this as a "vanilla" Nevron that "lights up" with extra abilities and beneficial ETB triggers if you spend extra colors of mana (the light) on it. If you can spend all 5 colors of mana on it, you get the full suite of benefits.

## Unfinished Portier

```
W
Creature - Nevron
Exhaust — Sacrifice a Forest: Put two +1/+1 counters and a Reach counter on this creature. (Activate each exhaust ability only once)
---
"My being... A core... With the form of a damned soul.... In this state, I am nothing but condemned."

1/1
```

[card implementation](../custom/cards/u/unfinished_portier.txt)

### Design Notes

 - In the game, the Unfinished Portier can be found in the Esoteric Ruins. It appears as its "weak point" missing a body, returning a set of wooden boards to it will "complete" it to a regular Portier.
 - Modeled as a tiny Nevron that can be "converted" to a regular Portier by saccing a Forest. Because a Forest is ... a source of wood!

## Unfinished Troubador

```
1W
Creature - Nevron
When this creature enters, put a verse counter on it if {G} was spent to cast this spell and put a rage counter if {R} was spent to cast this spell.
Other creatures you control get +1/+1 if this creature has a verse counter.
Other creatures you control have haste if this creature has a rage counter.
---
"Teach me... how to play."

2/2
```

[card implementation](../custom/cards/u/unfinished_troubador.txt)

### Design Notes

 - In the game, the Unfinished Troubador can be found in the Stone Quarry. It wants you to "teach" it how to play music, which consists of a parry challenge by parrying the "bad" notes and taking in the "good" notes. Passing the challenge will reward you with a picto.
 - Modeled as a bear that can fulfill one of its Troubador "roles" if you spend the right colors of mana on it.
 - 24/02/2026: Drop creature type prompt which did nothing.

