# General

## All cards have common rarity and no collector numbers

This is intentional because the card list is still not yet fixed, so until that happens there is no point in assigning collector numbers. Without collector numbers, Forge will interpret such cards at common rarity.

# Card-specific

## Manor Door

AI seems to have issues unlocking its own doors. Check if Keys to the House has the same issues.

## Maelle, The Reawakened Paintress

The mass human reanimation ultimate is not working.

## Golgra, Gestral Chief

I am being prompted for the mode before the enrage trigger goes on the stack, I kind of expected the prompt to happen on trigger resolution. And the trigger description on the stack is the full modal prompt and not the choice made. Not sure if it ultimately matters because it behaviourally works as expected.

## Esquie's Cave

The WUBRG mana ability is not preventatively disabled if you don't meet the activation condition. The ability however will (correctly) not add WUBRG if you don't meet the activation condition.

## Esquie, Friend of Verso

Getting the same ordering issue on the Uro modal trigger as Golgra.

## Expedition 41

Chapter 3: Not getting lumina tokens for destroyed Nevron tokens

## Revitalization

Can target any two cards in graveyard (the creature and non-creature restrictions are being ignored)

## Thermal Transfer

AI seems to be able to tap+stun two targets instead of tap+stun (0...1) target creature and bolt another (0...1) target creature