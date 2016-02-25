# UnityGame
This repository houses many scripts I've written in my own time as I learn to use the Unity3D Game engine. Feel free to make use of them yourself! The scripts are designed to work in a 2D sidescroller game environment.

Noteworthy Items:

- The code in this repository is object oriented C# (Not to be confused with Unity's Javascript) and is used in Unity version 5.X+, which is important to note due to changes in syntax between Unity 4.X and 5.X

- Many scripts require you to link variables to objects in the Unity3D engines editor, for example 'public GameObject Player Object' would require you to attach the ingame player GameObject. This is then used in the script to directly reference the game object and is more optimized than using 'FindWithTag' methods.
  - An error will show up in the Unity editors Console as an indicator if you forget to do this: "The variable PlayerObject of Player.cs has not been assigned. You probably need to assign the GameObject variable of Player.cs script in the inspector.

- If you do use one of these scripts, let me know as I love to hear about others projects :)
