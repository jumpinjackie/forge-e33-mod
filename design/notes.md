# Set code

E33 or EXP

# Creature Type and Mechanical Design Constraints

Unfortunately the world of Expedition 33 is not very diverse in terms of creature types (blame the painter's lack of originality!).

Practically speaking there are only 4 tribes we have to work with:

 * Humans
 * Nevrons
 * Gestrals
 * Grandis

Humans at least allows us to bring in "backup" in the form of reprints of human creatures from other sets. We don't have that luxury with Nevrons or Gestrals.

We could use an existing creature type as a proxy for Nevrons and Gestrals, but that would be a flavor/thematic fail in my opinion. So as a result, we will proceed with what is essentially a new "parasitic" creature type (as there is very little external set synergy/interaction beyond Changelings) so we must ensure that this set provides sufficient quantity of Nevron and Gestral creature cards to build a tribal deck around.

Grandis is on this list just for completeness, but in practical terms there isn't enough Grandis creatures to be able to build a dedicated tribal deck, so these creatures will need some compelling abilities to be playable.

This is doubly compounded by the fact that creatures are the strategic backbone of any magic set, so we need these creatures to perform double-duty of not only providing a sufficiently deep pool to build a deck around in constructed, but deep enough to build a deck around in limited/draft environments as well.

On a similar tangent, the lore/flavor of the game overrides whatever default color pie mechanical assumptions you may have. This may mean that creatures may end up with mechanics that are outside of its usual color.

# Lands

## Lumiere, The Last Bastion

```
Legendary Land - Town

{T}: Add {W}
{1}{W},{T}: Create a 1/1 White Human Expeditioner token with "When this creature dies or is exiled, create a Chroma token"
{1}{W},{T}: Create a Map token
```

## Lumiere Opera House

```
Legendary Land
TBD
```

## Old Lumiere

```
Legendary Land
TBD
```

## Flying Manor

```
Legendary Land
TBD
```

## Flying Waters

```
Land

{T}: Add {U}
{U},T: Target creature you control gains flying until end of turn
```

## Stone Wave Cliffs

```
Land
```

## Dark Shores

```
Land

As this land enters, you may reveal a Nevron card in your hand. If you don't it enters tapped.
{T}: Add {B}. 
{T}: Add {B}{B}. This land doesn't untap during your next untap step. Activate this ability only if you control a Nevron.
```

### Design Notes

- I wanted to use stun counters as they are a nice physical/visual aid to indicate that something will not untap on your next untap step, but unfortunately I simply could not get Forge to cooperate with me (I suspect that Forge doesn't support putting stun counters on lands, even though it should be mechanically possible), so I had to revert to the old "does not untap during your next untap step" wording. Not a big deal in Forge where this is automatically enforced.

## Forgotten Battlefield

```
Legendary Land

{T}: Add {C}
{1}{B},T: Put target Nevron card from your graveyard on top of your library
```

### Design Notes

- Basically Volrath's Stronghold for Nevrons

## Gestral Village

```
Land - Town

{T}: Add {C}
{T}: Add {C}{C}. Spend this mana only to cast Gestral spells or activate abilities of Gestrals.
```

### Design Notes

- Basically Eldrazi Temple for Gestrals

## Gestral Beach

```
Land

{T}: Add {C}
Cycling: {2}
```

### Design Notes

- I originally wanted a cheaper cycling: 1 ability that you can only activate if you control a Gestral permanent, but I couldn't find an existing example of a card with multiple cycling abilities which suggests to me that this isn't quite doable.

## Gestral Arena

```
Land

{T}: Add {C}
{1}{R/G},T: Target Gestral you control fights another target creature
```

### Design Notes

 * Basically Constested Cliffs but for Gestrals. Since Gestrals love fighting, this is 100% on the mark flavor-wise.

## The Reacher

```
Land
TBD
```

### Design Notes

 - The Reacher is all about verticality (reaching for the skies). How do we mechanically represent that?

## Endless Tower

```
Legendary Land

At the beginning of your upkeep, you may put a challenge counter on this land.
{T}: Add {C}
{T}, Remove X challenge counters from this land: Put a Nevron creature with mana value X or less from your hand into play.
```

### Design Notes

 - In the game, the Endless Tower was a 33-battle gauntlet against Nevrons of increasing difficulty
 - Figured the best way to mechanically model this gauntlet is to have something between Aether Vial and Mercadian Lift that grows counters and can put out Nevrons of increasing size based on the number of counters. 
 - We take the automatic growing counters effect of Aether Vial with the "removing counters as part of activation" part of Mercadian Lift. It would be hideously broken if we kept the Aether Vial activation as then this would be a strictly better and uncounterable Aether Vial, even if it had a Nevron-only restriction.

## Monoco's Station

```
Land

{T}: Add {C}
{T}: Add {U} or {R}. Activate this ability only if you control a Gestral or Grandis.
{T}: Add {U} or {R}. Put a stun counter on this land.
```

### Design Notes

 - Monoco's station is located in an icy mountainous region of the continent. Thus it clearly a land that should tap for {U} or {R}
 - Monoco's station is the home of Monoco (a Gestral) and Grandis. So it goes that tapping for {U} or {R} should have no drawbacks if you have either one in play

## The Monolith Interior

```
Land

You may have this land enter as a copy of any non-basic land on the battlefield, except it has "At the beginning of your upkeep, you may have this land become a copy of target non-basic land, except it has this ability."
```

### Design Notes

- Basically a Vesuvan Doppelganger for lands. Meant to mechanically capture the Paintress' memories of places visited by Expedition 33
- I am hoping I can copy Vesuvan Doppelganger for the most part and change the targeting parameters from creatures to non-basic lands.
- In the event that the Forge rules engine won't cooperate, I think we can fallback to this being a variant of Vesuva

## The Monolith

```
Legendary Land

When The Monolith enters, exile all Aline Planeswalkers until The Monolith leaves the battlefield.

While The Monolith is in play, player cannot cast Aline Planeswalker spells.

The Monolith enters with 10 gommage counters.

At the beginnning of your upkeep, remove a gommage counter from The Monolith, then exile all nonland, non-legendary permanents with mana value greater than or equal to the number of gommage counters on The Monolith.

When The Monolith has no gommage counters, sacrifice it.

{T}: Add {C}
```

### Design Notes
 
 - For lore accuracy, this would've been 100 counters instead of 10, but that would take way too long in MTG "game time". Reducing it to 10 sacrifices lore accuracy, but retains mechanical accuracy of something that's constantly counting down and wiping out everything older than that number.
 - Exile/blocking effect meant to symbolize Aline being trapped in the Monolith.

## Renoir's Drafts

```
Land

When this land enters. Exile all Renoir Planeswalkers until this land leaves the battlefield.

While this land is in play, players cannot cast Renoir Planeswalker spells.

{T}: Add {C}
{T}: Add {U} or {B}. Activate this ability only if you control a Nevron.
{2}, Sacrifice this land: Draw a card
```

### Design Notes
 
 - Exile/blocking effect meant to symbolize Renoir being trapped underneath the Monolith
 - 20/09/2025: Nevron restriction added to prevent this from being a strictly better dual land. Added a {C} mana ability to at least make it do something if you don't have a Nevron

## Crushing Cavern

```
Land

This land enters tapped.
{T}: Add {C}
{1},{T},Sacrifice this land: Destroy target attacking creature without flying
```

### Design Notes

 - Having this enter tapped so any creature can at least get one shot in before this land could kill it
 - 20/09/2025: Added ETB tapped and extra {1} to the kill ability

## Sacred River

```
Legendary Land

{T}: Add {C}
{X},{T}: Put target Gestral card from your graveyard or exile with mana value X into play tapped. This ability costs {3} less if you control a card named Golgra, Gestral Chief
```

### Design Notes

 - In the game, the Sacred River is a place where Gestrals can be resurrected.
 - Per game lore and rules established by Golgra, you need to be "in a queue" to get a Gestral resurrection, but if you're in favor with Golgra you could get a discount and "jump the queue"

# Enchantments

## Expedition Journals

Journals can are modeled as Sagas. Doesn't have to cover every expedition, just the most notable ones or ones whose synopsis or overarching theme is translatable to MTG mechanics.

## Expedition 60

 - Color Identity: Gruul
 - Chapter 1: Un-modified creatures you control gain haste and double strike until end of turn (something that emphasises power of raw human strength)
 - Chapter 2: Un-modified creatures you control gain hexproof until end of turn (closest analogue I could find to gommage barrier immunity)
 - Chapter 3: Un-modified creatures you control gain trample and +3/+3 until end of turn
 - May need to tweak definition. Modern MTG templating would grant such abilities through ability counters which is a nonbo with un-modified creatures. Making buffs temporary would sidestep this issue.
    - Journal is a story of expeditioners who almost succeeded in their mission through raw human strength

## Expedition 63

 - Color Identity: Izzet
 - Chapter 1,2: You may crew a vehicle by tapping a creature with power 1 instead of its regular crew cost
 - Chapter 3: Sacrifice all vehicles you control. For each vehicle sacrificed, you may have it deal damage to target creature or planeswalker equal to the sacrified vehicle's mana value
    - Journal is a story of expeditioners using cars to traverse the continent only for their mission to end when they fatally crashed into some Nevrons
 
## Expedition 68

 - Color Identity: Blue
 - Chapter 1, 2: Create a 5/5 Airship Vehicle Token with Haste, Flying and Crew: 3
 - Chapter 3: Sacrifice all Airships you control
    - Journal is a story of expeditioners stealing a bunch of Airships to escape Lumiere.

## Expedition 41

```
1BR
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I, II — Destroy target Nevron.
III — Destroy all Nevrons. Create a Lumina token for each Nevron destroyed this way.
```

### Design Notes

 - Journal is a story of expeditioners engaged in a competition to see who can kill the most Nevrons.
 
## Expedition 59

```
GB
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Destroy target Nevron. Create a Food token.
II — Create 2 Food tokens.
III — Until end of turn, Food tokens you control gain "Sacrifice this artifact: Target creature deals 3 damage to itself"
```

### Design Notes

 - Journal is a story of Expeditioners making the fatal mistake of eating dead nevrons
 - "Food poisoning" mechanic adapted from Asmoranomardicadaistinaculdacar's ability

## Expedition 69

```
2G
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Search your library for a basic land card, put it onto the battlefield tapped, then shuffle.
II — You may play an additional land thus turn.
III — Search your library for a land card, put it onto the battlefield tapped, then shuffle.
```
### Design Notes

 - Journal is a story of exploring everywhere and installing grapple points for those who come after.
 
## Expedition 48

```
2RR
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Target creature an opponent controls deals damage equal to its power to another create target creature that player controls.
II — Gain control of up to one target creature an opponent controls until end of turn and untap it. That creature gains haste until end of turn.
III — Gain control of up to two target creatures an opponent controls and untap them. Those creatures gains haste until end of turn. Sacrifice those creatures at end of turn.
```

### Design Notes

 - Journal is basically a story of mutiny, so all chapters are variations on mutiny/disloyalty
    
## Expedition 49

```
3W
Enchantment - Saga
(As this Saga enters and after your draw step, add a lore counter. Sacrifice after III.)
I — Gain 2 life for each creature you control.
II — Put a shield counter on each creature you control.
III — Until the end of your opponent's turn, if you control a creature, damage that would reduce your life total to less than 1 reduces it to 1 instead.
```

### Design Notes

 - Journal is about expeditioners who carried out their mission through strong defense/healing tactics, which proves to be their downfall as their weak offensive capabilities prove to be ineffective against the Nevrons.

## Chroma Prison

```
2W
Kindred Enchantment - Nevron
If you control a Nevron or Painter, you may cast this spell as though it had flash.
When this enchantment enters, exile another target nonland permanent.
When this enchantment leaves the battlefield, return the exiled card to the battlefield under its owner's control.
```

### Design Notes

 - Oblivion Ring variant #29835534892
 - To make it unique (flavor-wise), give it extra benefits if you are playing Nevrons

# The Manor

Could be a new "dungeon" that can be ventured into

Or we could re-use the room mechanic introduced in Duskmourn

New dungeon would require enabler/support cards. Room mechanic reuse does not

20/09/2025: Decided to go with Duskmorn room mechanic

# Nevrons

Sounding like a sibling race to Eldrazi. ie.

 - No color identity
 - Maybe some Nevrons have elemental affinities so it would have colored mana in its casting cost, but have devoid

Painted Clea can be the "Nevron lord". Some analogue to Sliver Queen since she's the "mother/creator" of all these Nevrons.

All Nevrons have a triggered ability on death to give an opponent a Lumina token

# Chroma

Conceptually ties to mana. Could be something that grants you mana when you a Nevron or Expeditioner dies or a token that can be cashed in for mana at a later point in time (A chroma token, similar to a treasure token?).

# Tokens

## Chroma

```
Token Artifact - Chroma

{T},Sacrifice this artifact: Add one mana of any color, spend this mana only to cast a Nevron, Gestral or Expeditioner spell
```

## Lumina

```
Token Artifact - Lumina
{T},Sacrifice this artifact: Scry 1
```

### Design Notes

 - The real purpose of Lumina tokens is to serve as an alternate currency for certain costs or as a condition to unlock extra capabilities in certain permanents. Scry 1 was the most benign ability I could give without making Lumina tokens completely useless on their own.

# Gestrals

Artifact creatures with some squee-style immortality mechanic
 - Can cast from graveyard/exile
 - If in graveyard at beginning of upkeep, may return to hand
 
Or the immortality mechanic can be an ability of the Sacred River, which should obviously be a legendary land.

20/09/2025: Immorality mechanic relegated to Sacred River. Gestrals are now a specific sub-type of Artifact Creatures.

## Gestral Fighter

```
2
Artifact Creature - Gestral
Whenever this creature attacks, it gets +2/+0 until end of turn for each other attacking Gestral.

1/2
```

### Design Notes

 * Gestral version of Goblin Piledriver
 * Might bump cost to 3 because we have a Gestral sol land

## Gestral Lackey

```
1
Artifact Creature - Gestral
Whenever Gestral Lackey deals damage to a player, you may put a Gestral permanent card from your hand onto the battlefield.

1/1
```

### Design Notes

 * Gestral version of Goblin Lackey

## Gestral Merchant

```
3
Artifact Creature - Gestral
Whenever Gestral Merchant is dealt damage, create that many Chroma tokens

2/3
```

### Design Notes

 * In the game, you could fight Gestral Merchants to get better set of wares for sale if you beat them.
 * The best I could think of mechanically was to have this creature reward you with Chroma tokens if it takes damage.

## Lorieniso, Gestral Musician

```
2
Artifact Creature - Gestral
At the beginning of your upkeep, you may put a verse counter on Lorieniso
{2},{T}: Search your library for a Gestral card with mana value X or less and put it into your hand, where X is the number of verse counters on this creature.

1/3
```

### Design Notes

 * This is the Gestral's Goblin Matron / Gestral Tutor. Adapted from Yisan, the Wanderer Bard
 * 20/09/2025: Initial playtested shows this is quite broken in multiples. Made into a legendary creature and changed P/T to 1/3

## Gestral Ringleader

```
5
Artifact Creature - Gestral
Haste (This creature can attack and {T} as soon as it comes under your control.)
When this enters, reveal the top four cards of your library. Put all Gestral cards revealed this way into your hand and the rest on the bottom of your library in any order.

3/2
```

### Design Notes

 * This is the Gestral's Goblin Ringleader, the one that provides raw card advantage

## Gestral Villager

```
2
Artifact Creature - Gestral

2/1
```

## Golgra, Gestral Chief

```
Gestral creatures you control get +2/+2
{2}: Put a shield counter on target Gestral you control.
Enrage - Whenver Golgra is dealt damage, choose one:
 - Put a Double strike counter on Golgra.
 - Put a Vigilance counter on Golgra.
 - Put a Trample counter on Golgra.
 - Draw a card.
```

### Design Notes

 * This is obviously our Gestral lord
 * In the game, when you get Golgra to below 50% health, she goes "Super Saiyan" and has buffed up attacks. I think Enrage best mechanically represents going "Super Saiyan" when attacked.

## Lost Gestral

```
1
Artifact Creature - Gestral
When this creature enters, if you control a card named Sastro, the Concerned, create 2 Chroma tokens.
Whenever this creature becomes the target of a spell or ability an opponent controls, put this creature on the bottom of its owner's library.

1/1
```

### Design Notes

 * In the game, there is a side-quest where you have to find a bunch of Lost Gestrals and return them to Sastro. Every Lost Gestral you find and return to Sastro gives you rewards. For the first ability I went with rewarding the player with Chroma tokens if Sastro is in play when a Lost Gestral enters as a mechanical analogy to this side quest.
 * The second ability was taken from Fblthp, the Lost to mechanically explain why these Gestrals keep getting lost.

## Sastro, the Concerned

```
4
Legendary Artifact Creature - Gestral
When Sastro enters, put 2 1/1 Gestral artifact creature tokens into play.

2/2
```

### Design Notes

 * This is the Gestral version of "Siege-Gang Commander"/"Deranged Hermit"
 * Definitely needs a second ability. Yet to figure out what. Don't think I want something that requires sacrificing Gestrals (the game's lore doesn't explicitly state or dispel the notion that Gestrals have wilful disregard for each other)

# Legendary Creatures

Eveque
 - Color Identity: Green
 - Type: Legendary Creature - Nevron
Dualliste
 - Color Identity: Rakdos
 - Type: Legendary Creature - Nevron
Serpenphare
 - Color Identity: Izzet
 - Type: Legendary Creature - Nevron Serpent
   - Flying
   - Need a MTG mechanical analogue to its AP syphoning ability
Grosse Tete
 - Color Identity: Red
 - Type: Legendary Creature - Nevron Elemental
    - This is a rock-based being, Elemental was the closest creature type I could find
Gargant
 - Color Identity: Blue
 - Type: Legendary Creature - Nevron Elemental
    - This is a rock-based being, Elemental was the closest creature type I could find
Ultimate Sakapatate
 - Color Identity: Artifact
 - Type: Legendary Artifact Creature - Construct
Tisseur
 - Color Identity: Artifact
 - Type: Legendary Artifact Creature - Construct
Sprong
 - Color Identity: Blue
 - Type: Legendary Creature - Nevron
Lampmaster
 - Color Identity: Orzhov
 - Type: Legendary Creature - Nevron Spirit 
    - Spirit b/c the Lampmaster looks similar to various Kami from Kamigawa
Seething Boucheclier
Jovial Moissonneuse
Sorrowful Chapelier
Glissando
Visages
Mask Keeper
Sirene
 - Color Identity: White/Blue/Red
 - Type: Legendary Creature - Nevron
Goblu
 - Color Identity: Gruul
 - Type: Legendary Creature - Nevron
Francois
 - Color Identity: Blue
 - Type: Legendary Creature - Turtle
 - Affinity for Clea Planeswalkers

# The Fracture

Some saga with a mass-exile effect in one of its chapters.

Or it could just be a nickname reprint of "Urza's Ruinous Blast"

# Gommage

Some mass-exile effect conditonal on number of counters. Possibly tie into the chroma mechanic for exiled creatures.
 - Maybe incorporate clash with an opponent to determine if counters get added or removed. Symbolizing the clash between Renoir and Aline in the canvas.

The monolith is where counters get added or removed.

Or it could be a legendary sorcery with some mass-exile effect

Or it could just be a nickname reprint of "Urza's Ruinous Blast"

Or it could be an ability word for exiling target permanent

# Flavorful or Thematically-relevant Reprint Candidates

Some reprint cycle of allied + enemy duals
Explore
Exploration
Expedition Map
Expedition Envoy
Expedition Healer
Expedition Raptor
Expedition Diviner
Explorer's Scope
Explorer's Cache
Fortune Teller's Talent (Sciel)
Naturalize
Painter's Servant
Path to Exile
Painted Bluffs
Painter's Studio // Defaced Gallery
Pyrotechnics
Pyrokinesis
Sudden Death
Sudden Edict
Scour
The World Tree (nicknamed to some E33-relevant location)
Fire/Ice
Lightning Bolt
Earthquake
Ior Ruin Expedition (nicknamed if required for lore purposes)
Khalni Heart Expedition (nicknamed if required for lore purposes)
Nissa's Expedition (nicknamed reprint)
Soul Stair Expedition (nicknamed if required for lore purposes)
Sunspring Expedition (nicknamed if required for lore purposes)
Zektar Shrione Expedition (nicknamed if required for lore purposes)
Wasteland

Mine the Zendikar/Ixalan block sets for more reprint candidates due to the heavy exploration/expedition theme.

# Flavorful or Thematically-relevant mechanics/abilities

Kicker (When you nail perfect QTE timing)
Split Second (Painted Renoir's attacks)
Foretell (Sciel)
Shield Counters
Charge Counters (Gustave and AP-based abilities)
Flash (being able to do things on an opponent's turn)
First Strike (play first)
Untapping creatures (play again)
Explore / Map Tokens
Surveil
Fight (Gestrals love to fight)
Landfall
Clue Tokens (Lune's Research)
Party
 * Means that Cleric, Rogue, Warrior and Wizard need to be distributed amongst Maelle, Sciel, Verso and Lune

# Enchantments / Sagas

A Life to Love
A Life to Paint
A Life to Dream

Chroma Prison (ie. The thing Painted Renoir traps Maelle in before killing Gustave) - {2}{W}
Enchantment

Oblivion Ring effect #28483298493

Monolith Barrier - {3}{W}
Enchantment
Creatures cannot attack you unless they're un-configured Human creatures or its controller sacrifices a Chroma token for each attacking creature.

- The un-configured clause is a nod to Expedition 60 lore

# Instants and Sorceries

Can be derived from character abilities or enemy attacks

Dodge (blinking effect?), Parry (Damage redirection?), Gradient Parry (A souped up variant of parry based on charge counters)

Gradient attacks (Some charge counter based ability)

A Nevron tutor

## Get Out Of My Way!

```
XR
Sorcery
X target Gestral creatures can't block this turn.
```

### Design notes

 * Golgra's secret password to get past any Gestral bouncers.


## Leave this Canvas!

```
1WB
Sorcery
Exile target nonland permanent.
```

### Design notes

 - I want to add extra bonuses based on the kind of permanent exiled. Get a Lumina token if it was a Nevron. Get a Chroma token if it was an Expeditioner.
    - Have to figure out if Forge lets me describe this kind of conditional bonus

## Gommage

```
3WW
Sorcery
Exile all nonland permanents that are not legendary or Nevrons
```

### Design notes

 - May "downgrade" to destroy if playtesting reveals we have too many exile effects, despite being more flavorful

# Artifacts

Expedition Flotilla - {4}
Artifact - Vehicle

This vehicle's crew costs 1 less for every expeditioner you control
Crew: 5

5/5

Health Tint - {2}
Artifact

Sacrifice this artifact: You gain 5 life. If you control at least 3 Lumina tokens, gain 10 life instead.

Energy Tint - {2}
Artifact

T: Add {C}, If you control at least 3 Lumina tokens, add {C}{C}{C} instead

- Yes it may look dangerous to have a Grim Monolith with no downside, but you need some Lumina token investment first to take advantage.

Florrie - {1}
Legendary Artifact - Rock

T: Target creature gains Islandwalk until end of turn
1, Sacrifice this land: Draw a card

Soarrie - {1}
Legendary Artifact - Rock

T: Target creature gains flying until end of turn
1, Sacrifice this land: Draw a card

Urrie - {1}
Legendary Artifact - Rock

T: Surveil 2
1, Sacrifice this land: Draw a card

Lumina Converter - {2}
Arifact
 
T, Remove a counter from a permanent you control: Create a Lumina token
T, Sacrifice a Chroma token: Create a Lumina token
T, Sacrifice a Nevron: Create a Lumina token

The World Canvas - {4}
Legendary Artifact

T: Add 3 mana of any one color. Spend this mana only to cast a Nevron, Gestral, Painter, Expeditioner or Picto spell.
When The World Canvas leaves the battlefield, exile all permanents with a name originally printed in ~this expansion~

- Mass exile trigger just to emphasize the finality of destroying the canvas.

Heart of the Paintress - {3}
Legendary Artifact

T: Add {C}
T, Sacrifice this land: Search your library for a card named Barrier Breaker and put it into play. Activate this ability only if you control a card named The Curator
 
Barrier Breaker - {5}
Legendary Artifact - Equpiment

Equipped creature gets +4/+4 and has Shadow
When this land enters, if you control a card named Maelle, you may attach this land to it
Equip: {2}

- Need to think more about what MTG mechanic best represents "void damage"

## Pictos/Lumina/Weapons

Easy analogue of Pictos/Weapons is Equpiment. Can map buffs granted by Pictos/Luminas to existing MTG mechanics.
New subtype for interactions with other cards.
All Pictos have a "clone me" ability that can be paid with Lumina tokens (just like one spends Lumina points to get the same pictos ability for other characters)

Cheater - {2}
Artifact - Equipment Picto

At the beginning of each upkeep, untap equipped creature
Sacrifice 4 Lumina Tokens: Create a token copy of this artifact attached to a creature you control
Equip: {2}

Painted Power - {6}
Artifact - Equipment Picto

Equipped creature gets +9/+9
Sacrifice 8 Lumina Tokens: Create a token copy of this artifact attached to a creature you control
Equip: {2}

Death Bomb - {3}
Artifact - Equipment Picto

When equipped creature dies, deal 4 damage to every creature
Sacrifice 3 Lumina Tokens: Create a token copy of this artifact attached to a creature you control
Equip: {2}

Energising Death - {2}
Artifact - Equipment Picto

When equipped creature dies, create 3 Chroma tokens
Sacrifice 2 Lumina Tokens: Create a token copy of this artifact attached to a creature you control
Equip: {2}


# The number 33

Maybe some "you win the game" if you have 33 of something

Some beneficial effect that triggers when you are at 33 life


Name TBD - {1}{W}{U}{B}{R}{G}
Sorcery

You win the game if you control 33 or more of any of the following combined:

 - Expeditioner creatures
 - Chroma Tokens
 - Lumina Tokens

# Modeling shields / break damage

Use Shield Counters. Current rules allow for stacking multiple instances.

For gameplay fairness, should be applied on low/single-toughness creatures.

"Break meter" can be something that charges up with charge counters.

TBD what would model a "Break meter". Some artifact? Some emblem?

Spending the "Break meter" would remove all shield counters from one or more permanents.

Breaker - {1}{W}
Instant

Split Second
Remove all Shield counters from target permanent

Shields up - {X}{W}
Instant

Put X shield counters on target permanent

# NPCs

Lost Gestral
Gestral Merchant
Gestral Villager
Gestral Fighter
Gestral Musician
Gestral Bodyguard
 - Type: Artifact Creature - Gestral
 - Are Gestrals artificial beings in a MTG flavor sense? Alls signs point to this being the case.

Mime
 - Color Identity: TBD
 - Type: Creature - Mime

# Key Characters

Represented as either Legendary Creatures or Planeswalkers. Painters prime candidate to be Planeswalkers

Possibly include the "God" sub-type for painters, painted copies of them

Possibly introduce an "Expeditioner" sub-type just for flavor purposes. To mechanically do something with this type would be parasitic as no Expeditioners exist in any other set.

Sophie:
 - Color Identity: White
 - Type: Legendary Creature - Human Citizen
 - Soulbond or partner with Gustave
Emma:
 - Color Identity: White
 - Type: Legendary Creature - Human Citizen

Gustave - {U}{W}{R}
Legendary Creature - Human Expeditioner Engineer

First strike. Vigilance.
At the beginning of your upkeep and Whenever Gustave attacks or blocks, put a charge counter on him.

Marking Shot - T, Remove a charge counter from Gustave: Put a stun counter on target creature.
Shatter - T, Remove 3 charge counters from Gustave: Gustave deals 5 damage divided as you choose among any number of target creatures. Put a stun counter on them.
Overcharge - T, Remove 10 charge counters from Gustave: Gustave deals 10 damage to target creature, if that creature would die, exile it instead.

3/2

Maelle - {1}{U}{R}
Legendary Creature - Human Expeditioner

Offensive Stance - At the beginning of your upkeep, choose one:
 - Put a First strike counter on Maelle
 - Put a Vigilance counter on Maelle
Defensive Stance - At the beginning of your opponent's upkeep, choose one:
 - Put an Indestructible counter on Maelle
 - Put a shield counter on Maelle
At the end of every turn, remove all counters from Maelle.
When Maelle dies, you may exile her instead, if you do and you also control Alicia, exile her and meld them into Maelle (act 3)

3/2

 - some stance-based mechanic that buffs offense when attacking and defense when blocking
 - (Melds with Alicia)

Maelle (act 3)
Color Identity: TBD
Legendary Planeswalker - Maelle
Expeditioner spells you play cost {1} less to cast.
 + ability: TBD
 - ability: Return target Human or Expeditioner in your graveyard or exile and put it into play tapped
 - ability: TBD
 Ultimate: A suitable MTG analogue of Gommage Gradient Attack or Stendahl

Lune - {W}{U}{R}{G}
Legendary Creature - Human Expeditioner Wizard
Flying
Whenever Lune attacks or you cast a white, blue, red or green instant or sorcery spell, put a stain counter on Lune.
Lune cannot have more than 4 stain counters on her.
Immolation - Remove a stain counter from Lune: Lune deals 2 damage to target creature
Crippling Tsunami - Remove 2 stain counters from Lune: Lune deals 3 damage to up to 2 target creatures, put a stun counter on each
Elemental Genesis - Remove 4 stain counters from Lune: Lune deals 4 damage to all creatures your opponents control. If this would deal damage to a Nevron, it deals double that damage instead.

2/4

- Lore accuracy would dicatate that we use colored stain counters, but that is just too many words.
- Damage obviously scaled to MTG levels

Sciel
 - Color Identity: Orzhov
 - Type: Legendary Creature - Human Expeditioner
 - could re-use existing foretell mechanic
 - Some ability that buffs/untaps Expeditioner creatures
Verso
 - Color Identity: Dimir or Esper
 - Type: Legendary Creature - Human Expeditioner
 - Gain rank counters when attacking or using abilities.
    - To tie to his immortality, maybe treat rank counters like shield counters. If it dies or would take damage, remove a rank counter instead.
 - Payoff abilities paid with rank counters or can be activated once a certain number of rank counters is obtained
Monoco
 - Color Identity: Selesnya
 - Type: Legendary Artifact Creature - Gestral
    - Only giving the Artifact supertype because it's a Gestral and our current definition is that Gestrals are artificial beings, despite Monoco having very organic features.
 - Some die roll mechanic that maps to ability wheel
 - Obviously need some MTG mechanic that maps to his feet collection / gain ability mechanic
    - When it kills a nevron, exile it and it gains the abilities of the exiled nevron. Do something akin to Agatha's Soul Cauldron

Noco
 - Color Identity: TBD
 - Type: Legendary Artifact Creature - Gestral
 - Soulbond / Pairs with Monoco

Golgra - {2}{W}{G}{R}
Legendary Artifact Creature - Gestral
Gestral creatures you control get +2/+2
{2}: Put a shield counter on target Gestral you control
Enrage - Whenver Golgra is dealt damage, choose one:
 - Put a Double strike counter on Golgra
 - Put a Vigilance counter on Golgra
 - Put a Trample counter on Golgra
 - Draw a card
5/6

 - Provide a lord effect/buff to Gestrals
 - Some mechanic that can capture going super saiyan at 50% health. Enrage?
 
Renoir
 - Color Identity: TBD
 - Type: Legendary Planeswalker - Renoir
    - + ability: TBD
    - - ability: TBD
    - Ultimate: TBD
 
Aline
 - Color Identity: TBD
 - Type: Legendary Planeswalker - Aline
    - + ability: TBD
    - - ability: TBD
    - Ultimate: TBD

Clea
 - Color Identity: TBD
 - Type: Legendary Planeswalker - Clea
    - + ability: TBD
    - - ability: TBD
    - Ultimate: TBD

Alicia - {2}{W}
Legendary Creature - Human Painter

Activated abilities of Nevrons and Pictos cannot be activated
(Melds with Maelle)

 - Some mechanical allegory to silence or suppressing activated abilities (since she is mute IRL)
 
Simon (possibly double-faced or a Saga creature to represent the various phases)
 - Color Identity: Rakdos
 - Type: Legendary Creature - Human Expeditioner
 
Esquie - {3}{G}{U}
Legendary Artifact Creature - Mount
Saddle 2
As long as you control a card named Soarrie, Esquie has Flying
As long as you control a card named Florrie, Esquie has Islandwalk
As long as you control a card named Urrie, Esquie has "Whenever Esquie attacks, Surveil 2"
When Esquie attacks, if it is saddled choose one:
 - Draw a card
 - Put a land card from your hand into the battlefield
6/6

- Basically, a saddle version of Uro with extra buffs if you control the various rocks that Esquie desires

Painted Alicia
 - Color Identity: TBD
 - Type: Legendary Creature - Painter

Painted Renoir
 - Color Identity: TBD
 - Type: Legendary Creature - Painter

The Paintress
 - Color Identity: TBD
 - Type: Legendary Creature - Painter God

The Curator
 - Color Identity: TBD
 - Type: Legendary Creature - Painter

Perhaps Curator + Paintress can meld into Painted Love
Or Curator is a double-faced card, with (real) Renoir on the other side
Or Paintress is a double-faced card, with Aline on the other side

Noco/Gestrals could have some squee-style immortality mechanic

Maelle/Alicia could be a double-faced card, or melds into "Act 3" Maelle

# Deck Archetypes

Gestral Tribal
Nevron Tribal
Expeditioners
Painter Control
Lands

- Having Gestrals, Nevrons and Expeditioners as their own creature types may be too parasitic and prevents synergies with other sets, maybe we just piggy-back off of an existing creature type instead?
- If we were to use existing creature types then probably:
   - Nevrons - Nightmare or Eldrazi
   - Gestrals - Goblin Construct or just Construct
   - Expeditioner - Human

# Adventure Mode Considerations

This set cannot introduce new mechanics (as that would require rule engine updates). That's fine, we have 30+ years of existing MTG mechanics to pool ideas/designs from.

We assume defining new token types is doable in Forge. Otherwise we'll have to reuse existing token types for Chroma/Lumina.

For flavor, we can leverage ability words to group common sets of abilities/functionality (assuming Forge lets us have custom ability words easily)

Can we "localize" some game elements to match the flavor/lore of Expedition 33?

 - Gold -> Chroma
 - Towns -> Gestral Villages/Outposts

Bosses need to map to the 5 color biomes + colorless biome

 - Renoir
 - The Paintress
 - Simon
 - Painted Clea
 - Lampmaster
 - Dualliste