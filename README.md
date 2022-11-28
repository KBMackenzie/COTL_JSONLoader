A Cult of the Lamb modding API that lets you create mods using JSON and the COTL API, without the need for any coding or coding knowledge.

This mod is currently in **beta**. If you find any bugs, please contact me in the [Cult of the Lamb Modding Server](https://discord.gg/jZ2DytX3TX).

## Installation
This mod’s only dependencies are BepInEx .

#### Installation (Mod Manager)
1. Download and install [r2modman](https://thunderstore.io/package/ebkr/r2modman/) or the [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager).
2. Install this mod and all of its dependencies with the help of the mod manager! 

#### Installation (Manual)
1. Download and install [BepInExPack CultOfTheLamb](https://cult-of-the-lamb.thunderstore.io/package/BepInEx/BepInExPack_CultOfTheLamb/) and the [COTL API](https://cult-of-the-lamb.thunderstore.io/package/xhayper/COTL_API/).
3. Place the contents of **"COTL_JSONLoader.zip"** in its own folder within the BepInEx/plugins folder.

## How To Use
Your JSON files, along with any images you use, should be placed inside of the BepInEx/plugins folder in order for this mod to find them.

## Creating Skins
This mod supports creating custom skins through JSON.

This mod tries to keep the process of creating skins with JSON as close to how it's done through the COTL API as possible. Thus, following the tutorial for creating skins through the API will still be extremely helpful for you when creating a skin with this mod.

[COTL API's Skin Tutorial](https://cotl-api.vercel.app/skins)

There are two types of skins you can create: Player skins (for Lamb) and Follower skins.

### Lamb Skins
For **Player Skins** (i.e. Lamb skins), your JSON file's name should end in `_lamb.json`.

Your file should look like this:
```json
{
  "name": "Example Skin",
  "imagePath": "ExampleSkin.png",
  "overrides": [
    {
      "name": "HeadBack",
      "rect": "0, 0, 128, 128"
    },
    {
      "name": "HeadBackDown",
      "rect": "128, 0, 128, 128"
    },
    {
      "name": "HeadBackDown_RITUAL",
      "rect": "0, 128, 128, 128"
    },
    {
      "name": "HeadBackDown_SERMON",
      "rect": "128, 128, 128, 128"
    },
    {
      "name": "HeadFront",
      "rect": "256, 0, 128, 128"
    },
    {
      "name": "HeadFrontDown",
      "rect": "256, 128, 128, 128"
    }
  ]
}
```

And here's an explanation of each field.

| Field     | Description                                                                                                                                                                  |
|-----------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| name      | The name of your skin.                                                                                                                                                       |
| imagePath | The path to your image (that is, your skin's spritesheet).                                                                                                                   |
| overrides | The overrides for your skin. A full list of the available overrides for Player skins can be found in the [COTL API's Skin documentation](https://cotl-api.vercel.app/skins). |


### Follower Skins
For **Follower Skins**, your JSON file's name should end in `_follower.json`.

Your file should look like this:
```json
{
  "name": "Example Follower",
  "imagePath": "ExampleFollower.png",
  "overrides": [
    {
      "name": "LEFT_ARM_SKIN",
      "rect": "0, 0, 128, 128"
    },
    {
      "name": "RIGHT_ARM_SKIN",
      "rect": "128, 128, 256, 256"
    }
  ],
  "colors": [
    [
      {
        "name": "LEFT_ARM_SKIN",
        "hex": "#FF0000"
      },
      {
        "name": "RIGHT_ARM_SKIN",
        "hex": "#FF0000"
      }
    ]
  ]
}
```

| Field     | Description                                                                                                                                                                                                        |
|-----------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| name      | The name of your skin.                                                                                                                                                                                             |
| imagePath | The path to your image (that is, your skin's spritesheet).                                                                                                                                                         |
| overrides | The overrides for your skin. A full list of the available overrides for Follower skins can be found in the [COTL API's Skin documentation](https://cotl-api.vercel.app/skins).                                     |
| colors    | The available colors for your Follower skin. You can add custom colors this way! All white pixels in your selected overrides will be replaced by the selected color. This mod supports using Hex codes for colors! |


## Changelog
- 0.1.0 -- Initial upload.