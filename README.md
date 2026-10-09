# Mini Azeroth

<img width="800" height="446" alt="MiniAzeroth" src="https://github.com/user-attachments/assets/04d028da-63ec-4c97-9411-b013c68201ca" />

## Status of the project

Ongoing

## Goal

I wanted to use this project as a place where I could create and implement a wide variety of systems. For this, I decided to build a mini version of Northshire, the starting zone from World of Warcraft.

To achieve this, I need to implement many different systems, which will help me learn how to put together a larger game without the pressure of coming up with an entirely new game idea myself.

## What does the game do?

<img width="1520" height="852" alt="image" src="https://github.com/user-attachments/assets/377e6eda-f491-4344-82a5-2dc63436389e" />

### Features

#### Controls

<img width="273" height="252" alt="image" src="https://github.com/user-attachments/assets/848ac9d6-1c98-4a87-806f-1a9d0f5d955f" />

- **Movement:** WASD

**Combat**

<img width="520" height="177" alt="image" src="https://github.com/user-attachments/assets/23651317-07d8-4b42-a107-ab31a49ba80c" />

- **Spell selection:** Mouse wheel
- **Aiming:** Spells are fired towards the mouse cursor
- **Casting Frostbolt:** Hold down the left mouse button
- **Casting Fireblast:** Click the left mouse button (instant cast)

#### Enemy

<img width="357" height="261" alt="image" src="https://github.com/user-attachments/assets/166d17e8-40df-43db-b3cc-cce66bc7d3d2" />

- Enemies can be hit by spells
- Enemies can attack the player
- Both enemies and the player take damage when hit
- Both enemies and the player can die
- Enemies leave behind a dead body when they die
- Dead bodies despawn after a while
- Wolves respawn
- Wolves chase the player
- Wolves stop chasing when the player moves too far away
- Wolves return to their spawn point after losing the player
- Wolves become aggressive when the player gets too close

## Challenges

The biggest challenges usually come at the beginning of implementing a new system, simply because I've never done it before.

Another major challenge is getting all these systems to work together. For example, I had to refactor my wolf AI multiple times to make everything work while continuing to add new features.

I think this learning curve has been the greatest challenge so far, and I'm still in the middle of it. 

### Specific struggles

**Developing the spells**
- The aiming system was mainly based on my other project, "Kill the Dummy", where I had already experimented with it.
- In the beginning, I used particle effects for my spells, but later switched to spawning projectiles to have more control over their lifetime.
- This is also proving useful now that I want to implement sound effects, such as the impact sound when a Frostbolt hits something.

**Getting the enemy state machine right**
- In the beginning, I implemented the enemy behavior rather naively, using just a few if-else statements.
- As the project grew and I added more functionality, I realized that I needed something like a state machine.
- I implemented a simple state machine using a switch statement to keep the logic clean and simple.

**Structuring my scripts**
- My main struggle here is avoiding one huge script and figuring out when to split functionality into multiple scripts.
- I think I've found a good approach by asking myself: "What does this script control?"
- If the answer involves more than one responsibility, it's probably worth splitting it into multiple scripts.
- However, I know that I still have a lot to learn in this area.


**Making the environment look more natural**
- In the very beginning, I simply created a tree sprite and imported it into Unity. However, something looked off, and for a long time I couldn't figure out why.
- I realized that the tree was missing a shadow.
- My first solution was to create a simple round shadow underneath the tree, which already made a huge difference!
- Later, I wanted to make the environment look a bit more professional, but I'm still figuring out the best way to handle shadows in a 2D game.
- My current idea is to give each sprite its own shadow.
- Since this would take quite a bit of work, and I wanted to focus on implementing more systems first, I decided to postpone this task for now.


## What did I learn?

- Creating assets
- Creating Rule Tiles
- Managing multiple GameObjects
- Handling collisions between the player, projectiles, and environmental objects
- Adding colliders to Rule Tiles
- Working with Unity's Input System
- Spawning GameObjects
- Implementing enemies
    - Reacting to the player (aggro range, stopping the chase when the player moves too far away)
    - Using state machines to manage different enemy states
- Implementing animations for the player, enemies, and projectiles
- Creating animated assets
- Implementing simple scene transitions
- Implementing sound effects
- Working with prefabs
- Learning about Unity's project settings
- Working with Unity's Animator
- Implementing Unity Events
- And many more things I've probably already forgotten!


## Roadmap

**Main – Latest Finished Version (currently v1)**

**MVP – "Make It Work" (Finished)**
- Player movement implemented
- One working spell
- Basic environment in the game world
- A wolf enemy that can take damage from the player
    
**v1 – "Make It Fun" (Finished)**
- Player health bar
- Player can take damage from enemies
    
**v2 – "Make It Pretty" (Ongoing)**
- Add more sprites
- Rework animations (postponed)
- Add buildings
- Add sound effects
    
**v3 – "Make It Interactive" (Planned)**
- First NPC
- First quest
- Loot system

## Workflow

At some point, I had too many ideas in my head and struggled to keep track of everything.

To manage this, I created a Notion board where I collect my ideas and plan what I want to work on next.

This helps me avoid going down rabbit holes and trying to implement everything at once.

The Notion board is in German because it's easier for me to quickly write down my thoughts and ideas in my native language.

[Backlog at Notion](https://freezing-jumper-bcc.notion.site/Mini-Azeroth-3caa79dd047e809b8cfcf05f787963a1)

## Building the Project

If you want to play this game, you'll need to build the project using Unity. The project was developed using Unity 6.3 LTS.

The latest version that I know is working is **v1**, which is available on the `main` branch.

However, if you want to see all the new features and visual improvements I'm currently working on, you can switch to the `v2` branch.

Keep in mind that this branch is still under development and might not always work as expected.

## Use of AI

I intentionally developed this project without using AI.

For personal projects and learning purposes, I want to preserve the magic of programming and figure things out myself.

## Assets

All graphical assets were created by me.
Sound effects were taken from World of Warcraft and downloaded from Wowhead.

This is a non-commercial fan project created for personal learning purposes. It is not affiliated with or endorsed by Blizzard Entertainment.
## My other unity Projects


- Link to Kill the Dummy
- [Speedy](https://github.com/Annymea/Speedy)






