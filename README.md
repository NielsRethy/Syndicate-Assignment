Syndicate Assignment
 info 

Time : 7 days

Your assignment is related to "Syndicate"

https://en.wikipedia.org/wiki/Syndicate_(video_game)
https://youtu.be/hPN4q8RjGDE?t=12m15s


This is a structure that would be good for you to use as a baseline to build the game on:

GameManager
- inherits from MonoBehaviour
- creates other Managers
- hold all static information
- holds Inventory
- creates visual prefabs based on info from other Managers

CharacterManager
- not Monobehaviour !!!
- list of Character (or 3 distinct members)
- list of Enemies
- selected character

UIManager or GUIManager
- not Monobehaviour !!!
- responsible to open panels
- keeps track of panels (members)
- initialize panels

SyndicatePanel
- inherits from MonoBehaviour
- abstract
-defines method for panels (initialise, refresh,...)

Character
- not MonoBehaviour !!!
- contains all info related to chars (name, hp, weap, stats, level, att, def,...)

Item
- not MonoBehaviour
- abstract
- contains enum ItemType (and member of that type)
- amount

Weapon
- not MonoBehaviour
- inherits from Item
- abstract
- holds common members

Gun / Rifle / Persuader
- not MonoBehaviour
- inherits from weapon
- contains specific weapon behaviour
- increase ATT stat of Character (not staff)

Inventory
- not MonoBehaviour
- contains List of Items 

InventoryPanel
- inherits from SyndicatePanel
- opens with pressing i (or button on HUD)
- shows me content of my inventory (just colored squares good enough, do not care about visuals)

VisualCharacter
- MonoBehaviour
- member of Character (link from UI to logic)
- single model (cube or capsule)

HUD
- MonoBehaviour
- get information from Managers and updates hud accordingly


That is for structure of the code, what I i would like to see now is 1 level I can walk through. I want the 4 characters I can switch between.
Camera is always focused on active character,( Nice to have not needed: I have option to have other 3 on auto follow or remain where they are).
I want to be able to switch between characters and camera automatically jumps over there (no need for smooth transition).
I want to be able to have different kinds of guns.
If an unit has several guns I would like to be able to switch between them.
