# ARM-Simulator

This Senior Design Project aims to simulate the Anti-Radiation Missile System AGM-88, which is widely used by various countries. It is most recently known for its application in the Russia-Ukraine war.

Built with Unity 2022.1.14f in C#

Originally known as "Project K".

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## TO OUR PREDECESSORS: 

First, we'd like to congratulate you on picking up this wonderful project! Feel free to make a clone of this repository, and everything we've prepared should get you started. The Unity packages can be imported directly into the editor so that you're able to see the entire workflow of what we've implemented. We've also included a working demo for you to preview and decide whether it's something you'd like to pursue. However, if Unity is not what you have in mind, worry not; you can still use the code we've written.

## What we've implemented & left for you to do:
- Functional **Jammer** object that sends out ~~constant~~ interruption power (Yes you need to fix it, and multiple **Jammers** too :>)
- Static **Target/Radar** object that the **Missile** needs to hit. (Right now, it doesn't send any signal for the **Missile** to pick up, so another thing you should consider implementing)
- Functional **Missile** object that has an adjustable FOV cone which is used to detect the **Jammer** and **Target/Radar** (No it can't differentiate between those two, and you need to implement a function that distinguishes the signals sent by those two, perhaps with the application of **The Huygens–Fresnel Principle**, which you definitely want to look up if it doesn't sound familiar to you)
- **User Interface** for adjusting parameters like **Missile Speed** (More parameters should be added depending on your implementations, but more options = super)

## Potential Ideas that we couldn't complete on time:
- Bringing the Simulator into the **3D** space (Unity 2D -> Unity 3D)
- **HUD element** that tracks the missile's location (This should be pretty easy to implement)
- Better **FOV** component (Right now, we're simply using a series of line segments to draw the triangle as the FOV; you could manipulate *Lighting* and *Post-Processing* to create the cone effect if you're more familiar with that)
- **Terrain Randomizer** (Now this is a tricky one, as there are so many aspects that can go wrong, not to mention the tedious debugging and testing phase)

Much respect,
Team K, May 2024

