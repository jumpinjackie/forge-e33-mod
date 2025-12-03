# Cards

> Last generated: 3/12/2025 10:33:25 am

## A Life to Love (Farewell)

> This card is a nicknamed reprint of (Farewell)
[Scryfall](https://scryfall.com/search?q=Farewell)
### Notes

 - Staple commander board wipe

## Acceptance

```
2WW
Creature - Incarnation
This creature enters with a shield counter on it.
Any damage dealt to you is dealt to this creature instead.
{2}{W}: Put a shield counter on this creature.
---
I'm FINE. I've lived 33 good years. Look around. We've had our whole lives to prepare. We'll be fine.
- Sophie

2/2
```

[card implementation](../custom/cards/a/acceptance.txt)

### Design Notes

 - No in-game basis, but Grief is such a central theme of Expedition 33 that having a cycle dedicated to the 5 stages is a total flavor nuke.
 - I'm taking the word Acceptance literally (or is it figuratively?) and gone with a creature that "accepts" all damage that would've gone your way.

## Austere Command

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Austere Command)
### Notes

 - Staple commander board wipe

## Chroma Barrier

```
2WW
Legendary Enchantment
Creatures cannot attack you unless their controller sacrifices a Chroma token for each creature they control that's attacking you.
{3}: Create a Chroma token. Any player may activate this ability.
---
This looks similar to Lumiere's shield dome. Maybe we can just cross it.
- Lune
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
Gustave: For those who come after, right?
Maelle: No no no no... You promised...
```

[card implementation](../custom/cards/c/chroma_prison.txt)

### Design Notes

 - Oblivion Ring variant #234898572343
 - This represents the barrier that Painted Renoir traps Maelle in at the Stone Wave Cliffs.
 - Gave it Nevron/Painter affiliated bonuses
 - 26/09/2025 Converted from Kindred Enchantment - Nevron to a regular Enchantment and give the flash bonus only for painters.

## Clair

```
2W
Creature - Nevron
Performs a silencing combo — {2}{W}, {T}: Target creature an opponent controls loses all abilities until end of turn.
Protects its allies — {1}{W}, {T}: Put a shield counter on target creature you control.
When this creature dies, target opponent creates a Lumina token. (It's an artifact with "{T}, Sacrifice this artifact: Scry 1.")

2/2
```

[card implementation](../custom/cards/c/clair.txt)

### Design Notes

 - In the game, it has abilities to shield its party and cause silence to player characters.
 - Mechanically represented here as:
    - Granting shield counters
    - A temporary "humility" effect to represent silencing.
 - 13/10/2025: Removed Devoid.

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
For our allies who come after, sadly our lives may have proven that defense is both absolutely necessary and wholly insufficient.
- Christophe, Expedition 49

2/2
```

[card implementation](../custom/cards/e/expedition_49_healer.txt)

### Design Notes

 - In the game, Expedition 49 employed strong defensive and healing tactics against Nevrons which proved ineffective as their offensive capabilities were really weak.
 - Easy mechanical map to a creature with life gain and damage prevention abilities.

## Expedition Recruiter

```
2W
Creature - Human Expeditioner
When this creature enters, you may search your library for an Expeditioner card, reveal it, put it into your hand, then shuffle.
When this creature dies, create a Chroma token.
---
Your time left in this life is limited, why not make it count for something?

1/1
```

[card implementation](../custom/cards/e/expedition_recruiter.txt)

### Design Notes

 - No direct representation in the video game, but I can easily imagine there are some people in Lumiere whose job is to be trying to recruit citizens who are soon to be gommaged, persuading them to embark on the next Expedition, to make use of the limited time they have left in this world.
 - Goblin Matron, but for Expeditioners with standard death bonus.
 - 3/10/2025: This + Tomorrow Comes + Expedition 70 gives us effectively 12 Expeditioner tutors. This may be overkill and the Expeditioner strategy too consistent and we may have to rework one or more of these cards. Further playtesting will tell us.

## Healing Light

```
XW
Kindred Sorcery - Expeditioner
Each player gains twice X life.
Luminous — Put a shield counter on up to one target creature you control and draw a card if you control at least three Lumina tokens.
---
Please survive!
```

[card implementation](../custom/cards/h/healing_light.txt)

### Design Notes

 - In the game, Healing Light is one of Lune's abilities that heals an ally.
 - Easy mechanical translation to life gain, but with a twist. It's symmetrical for a reason: As an enabler for The 67th Gommage.
    - Thus a card like this will not only help buy extra turns to get you to 6 mana to cast The 67th gommage, but also to get your opponent to 33 life or above.
 - 27/11/2025: Added Luminous bonus.

## Lumiere Assault

```
2WW
Kindred Instant - Expeditioner
Create two 1/1 white Human Expeditioner tokens with "When this creature dies, create a Chroma token."
Luminous — Draw a card if you control at least three Lumina tokens.
Flashback — Sacrifice two Lumina tokens.
```

[card implementation](../custom/cards/l/lumiere_assault.txt)

### Design Notes

 - Primarily designed to support the Crippling Tsunami Prison strategy
 - 7/11/2025: Changed flashback cost from saccing 2 Chroma tokens to 2 Lumina tokens.

## Lumierian Apprentice

```
1W
Creature - Human Citizen
Whenever another non-Expeditioner creature enters, investigate. (Create a Clue token. It's an artifact with "{2}, Sacrifice this artifact: Draw a card.")
---
He eagerly absorbs the knowledge given to him, for he knows when his time comes, it will be a valuable resource.

1/3
```

[card implementation](../custom/cards/l/lumierian_apprentice.txt)

### Design Notes

 - In the game, some of the children/teenagers of Lumiere are apprentices of Expeditioners, absorbing as much knowledge passed down to them should they fail and they will eventually become Expeditioners themselves and need to take up the mantle.
 - Modeled their "curiosity" as giving you clues whenever a "foreign" creature type enters the battlefield.
 - One of the rare humans in this set that are not Expeditioners.

## Path to Exile

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Path to Exile)
### Notes

 - Obligatory spot removal in Commander

## Payback (Roil's Retribution)

> This card is a nicknamed reprint of (Roil's Retribution)
[Scryfall](https://scryfall.com/search?q=Roil's Retribution)
### Notes

 - In the game, this is one of Maelle's skills
 - Roil's Retribution fits the bill (in both flavor and mechanics), so it was chosen as a nickname reprint for this.

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

## Repaint

```
1W
Sorcery
As an additional cost to cast this spell, sacrifice three Chroma tokens.
Return target card you own from exile to your hand.
---
Painting isn't about verisimilitude, it's about essence. The truth of who they are.
- Verso
```

[card implementation](../custom/cards/r/repaint.txt)

### Design Notes

 - This is meant to represent (paintress) Maelle's new-found ability to resurrect the citizens of Lumiere provided she has some of their Chroma, as demonstrated by being able to bring back Lune and Sciel after their gommage.
 - Mechanically this means we can also bring back cards from exile.
 - Currently not working (the sacrifice X chromas condition).
 - 7/10/2025: Change Chroma token sac requirement to 3 tokens instead of a variable amount and make the card in exile targeting have no restrictions instead of variable based on the amount of Chroma tokens sacced. This made it work.

## Sciel's Intervention

```
1W
Kindred Instant - Expeditioner
Untap target creature you control. It gains hexproof until end of turn.
Luminous — Draw a card if you control at least three Lumina tokens.
---
Don't worry, I'm here.
```

[card implementation](../custom/cards/s/sciels_intervention.txt)

### Design Notes

 - In the game, Intervention is Sciel's ability that lets an ally take their turn immediately along with an AP boost
 - Mechanically, we've mapped "granting extra turns" to untapping creatures. Nothing approximates an "AP boost" for creatures, so we've given it a granting of hexproof.
 - This has the name of "Sciel's Intervention" as "Intervention" on its own is too generic has a risk of being "name-squatted" by an actual card from Wizards in the future.

## Seal of Approval

```
2W
Enchantment
When this enchantment enters, draw a card.
Sacrifice this enchantment: The next historic spell you cast costs {1} less to cast. (Artifacts, legendaries, and Sagas are historic.)
```

[card implementation](../custom/cards/s/seal_of_approval.txt)

### Design Notes

 - In the game, Sciel gives her "glowing endorsement" of Gustave for "shouting the password as loud as you can" to get access to Esquie's Nest.
 - This card 100% based on the "Sciel of Approval" meme/pun.

## Swords to Plowshares

> This card is a reprint
[Scryfall](https://scryfall.com/search?q=Swords to Plowshares)
### Notes

 - Obligatory spot removal in Commander

## The Fracture

```
3W
Legendary Sorcery
(You may cast a legendary sorcery only if you control a legendary creature or planeswalker.)
Destroy all non-basic lands.
Search your library for a card named The Monolith, put it onto the battlefield and shuffle.
---
The city of Lumiere was uprooted and flung into the ocean. Soon after, The Monolith appeared, bearing the number “100”. Nobody at the time knew what this number meant.
```

[card implementation](../custom/cards/t/the_fracture.txt)

### Design Notes

 - In the game, The Fracture is a cataclysmic event which marks the appearance of The Monolith and sets in motion the annual yearly gommage.
 - Mechanically, this event itself is only catalclysmic in terms of the continent landscape, while there may have been human casualties in this event, this event was more about the altered landscape of the continent, thus it is clear that this event should be a non-basic land mass destruction effect like Ruination (non-basic so it doesn't become a strictly better Armageddon and to reward players who play basic lands).
     - The tutoring effect for The Monolith thematically maps to the appearance of The Monolith in the game.
 - 5/11/2025: NOTE the explicit unicode left and right double-quotes around the number 100 in the flavor text. This is intentional as it is to workaround a CardConjurer bug that improperly surrounds 100 with a pair of left unicode double quotes if you use regular ascii double quotes. DO NOT EDIT THIS unless you are going to rewrite the entire flavor text.

