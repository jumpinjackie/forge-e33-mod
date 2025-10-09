# Master Design File Spec

## Introduction

This repo originally started out as a series of custom set card scripts for Forge. But as I was getting bored of looking at the generic looking frames rendered by Forge in playtesting due to *lack of card art*, I looked at experimenting with some card designs in CardConjurer with great results, except this would mean I am now looking at maintaining several places for any given card:

 1. The card script for Forge
 2. The CardConjurer JSON to generate an image of this card
 3. The respective design notes md doc for this card
 4. BUGS.md if there are any new issues that need to be documented.
 5. The final set edition file

If I want to tweak the name, mana cost, type, PT or oracle text of any given card, that's up to 4 different places that need to be updated. This situation is un-tenable.

Hence the introduction of the master design file.

The master design file is the definitive "source of truth" for any card. It is where any of the following data points for a given card are defined:

 - Name
 - Mana Cost
 - Color Identity (for cards without a mana cost)
 - Type Line
 - Oracle Text
 - Flavor Text
 - Design Notes
 - Bugs/Known Issue
 - Forge card script

From this master design file, we can use the provided `CardProcess` tool to sync these changes across to:

 - Its forge card script file
 - Its CardConjurer JSON config
 - The respective design doc md
 - The BUGS.md file

## Design File Properties

A master design file specifies properties in a pseudo .ini style file format for ease of parsing by `CardProcess`

All valid properties in a design file is specified here.

> NOTE: This spec only covers only the elements/rules necessary for implementing the cards in this custom set. It does not encompass every mechanic/keyword/property/etc from every set ever printed.

### Name (`[Name]`)

The name of the card. Cannot span multiple lines.

### Mana Cost (`[ManaCost]`)

The mana cost of the card. Must be one line for each symbol/pip in the mana cost. For example a mana cost of 3UU would be specified as

```
[ManaCost]
3
U
U
```

If a mana cost has hybrid mana, the hybrid pair is its own line

```
[ManaCost]
1
W
UR
```

Although there doesn't seem to be a hard rule being enforced by Forge or CardConjurer, for the sake of consistency, in multi-color cards use CWUBRG order when defining the order of mana symbols in a multi-color card.

### Type Line (`[Types]`)

The type line of the card. Must be one line per type.

For example, Legendary Land would be specified

```
[Types]
Legendary
Land
```

Sub-types must be always specified *after* super-types. For example a card with the type line `Legendary Creature - Human Soldier` would be specified like

```
[Types]
Legendary
Creature
Human
Solider
```

### Rarity (`[Rarity]`)

The rarity of the card.

 - C: Common
 - U: Uncommon
 - R: Rare
 - M: Mythic Rare

### Oracle Text (`[Oracle]`)

The oracle text of the card. Can span multiple lines.

#### General Notes / Tips

- Where possible, try to provide reminder text around keyword and token references, unless it is clear that you are exhausting your "text box budget" by doing so.
   - You can use any of the existing variables/macros below to avoid having to specify the reminder text verbatim.
- Use Gatherer/Scryfall as reference for looking up similar cards and try to follow their text templating.

#### CardConjurer specific notes

Empty lines will be interpreted as-is. If this card has no flavor text, you can "nudge" the card text up a bit from the bottom of the card frame without having to mess with custom override bounds for the text box, by putting some empty lines as the end of the oracle text.

#### Forge-specific notes

Do not use `\n` characters. `CardProcess` will automatically concatenate all the lines in this file to a single line.

Empty lines are discarded.

#### Supported variables / macros

 - `~`: A reference to the name of this card. For non-legendary cards it will be `This [spell/creature/land/artifact/etc]`, for legendary cards it will be the name of the card (up to the first comma, if present).
 - `$DEVOID_REMINDER_TEXT`: Reminder text for the Devoid keyword.
 - `$LEGENDARY_SORCERY_REMINDER_TEXT`: Reminder text for Legendary Sorceries.
 - `$INVESTIGATE_REMINDER_TEXT`: Reminder text for the investigate keyword.
 - `$CHROMA_REMINDER_TEXT`: Reminder text for the Chroma token.
 - `$LUMINA_REMINDER_TEXT`: Reminder text for the Lumina token.
 - `$EXPEDITIONER_TOKEN_TEXT`: Token text for the Human Expeditioner token.

### Flavor Text (`[FlavorText]`)

The flavor text of the card. Each line is interpreted as-is. Used only for the CardConjurer JSON and design doc output.

You can "nudge" the flavor text up a bit from the bottom of the card frame without having to mess with custom override bounds for the text box, by putting some empty lines as the end of the flavor text.

### Ability Words (`[AbilityWords]`)

This indicates words that should be italicized when generating the CardConjurer JSON. One line per ability words to italicize.

Not used in any other context.

### Design Notes (`[DesignNotes]`)

This is where your thoughts around the design of the card can be specified. This is added verbatim to the design notes md document, so you can use any markdown syntax as long as you don't use any of the reserved property tokens here.

Not used for Forge and CardConjurer targets

### Known Issues / Bugs (`[Bugs]`)

Use this section to document known issues with this card in Forge. Used to compile the BUGS.md document. Like design notes, content is interpreted verbatim and you can use any markdown syntax as long as you don't use any of the reserved property tokens here.

## Forge Script (`[ForgeScript]`)

Use this to define the card script in forge. The following elements do not need to be defined as `CardProcess` will take care of them:

 - `Name` (from `[Name]`)
 - `ManaCost` (from `[ManaCost]`)
 - `Colors` (from `[ColorIdentity]`)
 - `Types` (from `[Types]`)
 - `Oracle` (from `[Oracle]`)