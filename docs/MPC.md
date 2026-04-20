# Printing this set with MPC (MakePlayingCards)

This set already includes an MPC Autofill XML project file that is ready to upload to MPC.

The project file defines a full 612-card MPC order with the following allocations:

 * 405 card base set
    * 6 separate Meld/DFC back faces as separate cards. This is because this author likes to be able to play these cards without sleeves and printing actual double-faced/meld cards goes against this plan. If you are happy to print actual DFC/meld cards, then you can edit the project file and free up 6 slots for extra tokens or other cards.
 * 42 card commander supplement
 * 125 basic lands (25 of each basic land type)
 * 34 assorted double-faced tokens. Token allocations is defined [in this CSV file](../custom/design/mpc_token_allocations.csv)

# Editing this project file

> These instructions currently require the experimental version of MPC Autofill at: https://mpcautofill.github.io/

> You also need to use Chrome in order to set up a local folder image source.

1. Go to: https://mpcautofill.github.io/
2. Click the "Sources" button. This will open a "Configure Sources" drawer.
3. Under "Local Folder", click "Choose Folder". Browse to the `custom/src_pics` directory of this repo. Say yes to any permission prompts.
4. Once the local source is synchronized, click "Jump into the project editor!"
5. Click "Add Cards" and choose "XML"
6. In the "Add Cards - XML" dialog, choose "Use XML Cardback" and attach the `custom/src_pics/cards.xml`
7. The project is now loaded. Make your desired adjustments. Once you have finished making your changes, click "I've Finished My Project".
8. Download the project back to `custom/src_pics/cards.xml`
9. Download the appropriate version of mpcautofill for your platform. Run it and follow the prompts.