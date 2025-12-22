# Design Goals

The design of this set has several goals:

 1. To mechanically and flavorfully capture and represent the lore, setting, events, characters and bestiary from the Expedition 33 video game.
    - A big part of this is revisiting the approach of storyboard-like art direction of sets during the Weatherlight Saga (ie. Tempest, Urza, Mercadian, Invasion blocks). If you've ever played with cards from this era, the cards in the set can read like a visual novel/comic on art alone. You didn't need cards with [STORY SPOTLIGHT] stamped on it like a big neon sign saying "Hey guys here's the lore you wanted!". What does that mean for us with this set? If there is a cool or notable piece of art or screenshot or moment in the game, we want to make a card for it.
 2. All rules are enforceable through Forge to rapidly faciliate design/prototyping/playtesting and helps keep us grounded in our card ideas.
 3. To be a self-contained draftable cube for up to 4 players. Additional players would require bringing in extra real basic lands and having to sleeve up the cards so that proxy cards and real basic lands can be safely mixed in.
 4. To be a self-contained card pool that can compose into at least 2 100-card commander decks.
 5. The cards can be played as-is without sleeves (as Richard Garfield intended), so the set will include enough basic lands and supporting cards in the "reprint sheet" to round out the set.

# Design Considerations

## Real Proxy Printing

It is hoped that this entire set is printable through [makeplayingcards](https://www.makeplayingcards.com/), so as a result the design of the set is such that the required cards for the set, its tokens and "basic land" selection for supporting cube drafts and/or commander decks is enough to fit at or under the maximum 612 card deck size supported by MPC.

All card images will be produced with CardConjurer.

This also means we have to be grounded in the type of cards we want to make. We could conceivably make a double-sided saga enchantment creature, but it would be an absolute PITA to design in CardConjurer.

It is envisioned that we have around 300 cards unique to this set with around 100-150 reprints to support the commander and limited scenarios along with 20-30 supporting tokens and the rest being basic lands.

To retain the ability to play unsleeved, Double-faced and Meld cards that would normally be printed on the backside of a given card will be printed on its own front face and will occupy one slot in the 612 card deck. When a given card will transform or meld, just substitute with the card representing the other side.

## No new keywords. Emphasize Top-down design (flavor comes first). Reuse and remix existing mechanics.

While a ready to print set is the final goal, our development and design of the set is through digital prototyping and playtesting through Forge. As such, we cannot introduce new keywords or intrinsic behaviours as that would require updating Forge's rule engine to support that.

That does not mean we can't make something unique. The 30+ years of MTG design space gives us a rich tapestry of existing mechanics to pool from to reuse and remix to our needs.

We can easily create something unique by introducing some new sub-types, token and counter types and have cards that interact with these new types. The open-ended nature of most MTG mechanics means we can remix them to interact with these new types as well.

## Commander

It is expected that the 2 100-card commander decks will be:

Expeditioners/Gestrals

vs

Nevrons/Painters

And that the role of the "reprint sheet" in addition to rounding out draft/limited, will be to provide supporting cards to both these archetypes.

There are no "designed for commander" cards in this set. Thus the commander subset will be exclusively reprints or nicknamed reprints. They will be given their own unique set code to distinguish them from the regular set.

## Constructed

Constructed is only supported in digital form through Forge.

It is not practical to support for paper as that would require us to print at least 4 copies of certain cards and our 612 deck size constraint is not practical to support this.

See [ARCHETYPES.md](ARCHETYPES.md) for an overview of the constructed archetypes we want to support.

## Parasitism

Being a self-contained set, it will inevitably have some parasitic mechanics and card types that will make it difficult to integrate in the the general game of Magic as a whole. This is a compromise we have to live with, as design goal #1 of maximum flavor trumps all other considerations.

As it this is not an official set, but a fan-made custom one, there's no parasitism concerns in paper.

Digital (via Forge) may have issues if this set is incorporated into the Adventure mode card pool, but that is not a concern of ours. If these cards play nice with others in Adventure mode, great. Otherwise, it is what it is.