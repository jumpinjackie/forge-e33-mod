# Cards

## Chroma Barrier

```
2WW
Legendary Enchantment
Creatures cannot attack you unless their controller sacrifices a Chroma token for each creature they control that's attacking you.
{3}: Create a Chroma token. Any player may activate this ability.
```

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
```

[card implementation](/custom/cards/c/chroma_prison.txt)

### Design Notes

 - Oblivion Ring variant #234898572343
 - This represents the barrier that Painted Renoir traps Maelle in at the Stone Wave Cliffs.
 - Gave it Nevron/Painter affiliated bonuses
 - 26/09/2025 Converted from Kindred Enchantment - Nevron to a regular Enchantment and give the flash bonus only for painters.

## Clair

```
2W
Creature - Nevron
Devoid (This card has no color.)
When this creature dies, target opponent creates a Lumina token.
{2}{W},{T}: Target creature an opponent controls loses all abilities until end of turn.
{1}{W},{T}: Put a shield counter on target creature you control.

2/2
```

[card implementation](/custom/cards/c/clair.txt)

### Design Notes

 - In the game, it has abilities to shield its party and cause silence to player characters.
 - Mechanically represented here as:
    - Granting shield counters
    - A temporary "humility" effect to represent silencing.

## Expedition 49

```
3W
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — You gain 2 life for each creature you control.
II — Put a shield counter on each creature you control.
III — Creatures you control gain indestructible until end of turn.
```

### Design Notes

 - Journal is about expeditioners who carried out their mission through strong defense/healing tactics, which proves to be their downfall as their weak offensive capabilities prove to be ineffective against the Nevrons.
 - Easy mechanical map to life gain and defensive buffs.

## Healing Light

```
XW
Kindred Sorcery - Expeditioner
Each player gains twice X life.
```

### Design Notes

 - In the game, Healing Light is one of Lune's abilities that heals an ally.
 - Easy mechanical translation to life gain, but with a twist. It's symmetrical for a reason: As an enabler for The 67th Gommage.
    - Thus a card like this will not only help buy extra turns to get you to 6 mana to cast The 67th gommage, but also to get your opponent to 33 life or above.

## Repaint

```
1W
Sorcery
As an additional cost to cast this spell, sacrifice X Chromas. Return target card from exile with mana value X to your hand, where X is the number of sacrificed Chromas.
```

[card implementation](/custom/cards/zDevelopment/repaint.txt)

### Design Notes

 - This is meant to represent (paintress) Maelle's new-found ability to resurrect the citizens of Lumiere provided she has some of their Chroma, as demonstrated by being able to bring back Lune and Sciel after their gommage.
 - Mechanically this means we can also bring back cards from exile.
 - Currently not working (the sacrifice X chromas condition). See BUGS.md

## Sciel's Intervention

```
1W
Kindred Instant - Expeditioner
Untap target creature you control. It gains hexproof until end of turn.
```

[card implementation](/custom/cards/zDevelopment/sciels_intervention.txt)

### Design Notes

 - In the game, Intervention is Sciel's ability that lets an ally take their turn immediately along with an AP boost
 - Mechanically, we've mapped "granting extra turns" to untapping creatures. Nothing approximates an "AP boost" for creatures, so we've given it a granting of hexproof.
 - This has the name of "Sciel's Intervention" as "Intervention" on its own has a risk of being "name-squatted" by an actual card from Wizards in the future.

## The Fracture

```
3W
Legendary Sorcery
(You may cast a legendary sorcery only if you control a legendary creature or planeswalker.)
Destroy all non-basic lands. Search your library for a card named The Monolith, put it onto the battlefield and shuffle.
```

[card implementation](/custom/cards/t/the_fracture.txt)

### Design Notes

 - In the game, The Fracture is a cataclysmic event which marks the appearance of The Monolith and sets in motion the annual yearly gommage.
 - Mechanically, this event itself is only catalclysmic in terms of the continent landscape, while there may have been human casualties in this event, this event was more about the altered landscape of the continent, thus it is clear that this event should be a non-basic land mass destruction effect like Ruination (non-basic so it doesn't become a strictly better Armageddon and to reward players who play basic lands).
     - The tutoring effect for The Monolith thematically maps to the appearance of The Monolith in the game.