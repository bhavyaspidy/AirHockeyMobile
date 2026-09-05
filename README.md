# AirHockeyMobile

A polished 2-player local multiplayer air hockey game built with Unity
6.3 LTS and designed for Android landscape devices.

## 🎮 Overview

AirHockeyMobile is a mobile-friendly air hockey game featuring two
players sharing the same device. The project was created as a Unity
gameplay/resume project, focusing on physics, player controls, game
state, UI, and mobile input.

## ✨ Features

-   🏒 Air hockey puck physics with wall bouncing
-   🔵 Player 1 and 🔴 Player 2
-   👥 2-player local multiplayer
-   ⌨️ Keyboard controls for development/testing
-   📱 Touch controls for Android
-   🥅 Separate goals for both players
-   🏆 Score tracking
-   🔄 Automatic puck reset and relaunch after scoring
-   🥇 First player to 5 points wins
-   🎉 Winner screen
-   🔁 Play Again functionality
-   📱 Android landscape support
-   🎨 Custom table, paddle, puck, and UI presentation

## 🕹️ Controls

### Player 1 🔵

**Keyboard:** W / A / S / D

**Mobile:** Touch and drag on the left side of the screen.

### Player 2 🔴

**Keyboard:** Arrow Keys

**Mobile:** Touch and drag on the right side of the screen.

## 🏆 Game Rules

-   Each goal awards 1 point to the player who scored.
-   The puck resets to the center after a goal and launches again.
-   The first player to reach **5 points** wins.
-   The winner screen provides a **PLAY AGAIN** button to start a new
    match.

## 🛠️ Built With

-   **Unity 6.3 LTS**
-   **Universal Render Pipeline (URP)**
-   **C#**
-   Unity Input System
-   Unity Physics / Rigidbody
-   TextMeshPro
-   Unity UI
-   Android build pipeline

## 🧱 Technical Highlights

### Player Movement

A reusable `PaddleController` handles player movement, boundaries,
keyboard input, and mobile touch input while keeping both players within
their respective halves of the table.

### Puck System

`PuckController` manages:

-   Initial launch
-   Maximum speed
-   Minimum speed protection
-   Wall bouncing
-   Paddle bounce response
-   Rigidbody-based physics

### Goal & Scoring System

Goals use trigger colliders to detect the puck. `GoalTrigger`
communicates with `GameManager`, which handles:

-   Player scores
-   Score UI updates
-   Puck reset
-   Puck relaunch
-   Winning condition

### Mobile Input

Mobile touch areas are separated into left and right screen regions. A
reusable `MobilePaddleController` sends touch and drag positions to the
appropriate paddle.

## 📂 Project Structure

``` text
Assets
├── Art
│   └── Materials
├── Audio
├── Prefabs
├── Scenes
│   └── AirHockey
├── Scripts
│   ├── Puck
│   ├── Paddle
│   ├── Game
│   ├── UI
│   └── Mobile
└── UI
```

## 📱 Platform

**Primary target:** Android

**Orientation:** Landscape Left

The project also supports keyboard controls in the Unity Editor for
development and testing.

## 📸 Screenshots

## 📸 Screenshots

### 🎮 Gameplay
![Air Hockey Gameplay](Assets/Screenshots/gameplay.png)

### 🏆 Score System
![Score System](Assets/Screenshots/score.png)

### 🎉 Winner Screen
![Winner Screen](Assets/Screenshots/winner.png)

## 🚀 Future Improvements

Possible future additions include:

-   Sound effects and background music
-   More visual effects
-   Start/countdown screen
-   Difficulty modes
-   Online multiplayer
-   Match statistics
-   Additional table themes

## 👨‍💻 Project Purpose

This project demonstrates practical Unity development skills including
gameplay programming, physics, UI, input handling, local multiplayer,
game-state management, debugging, and Android deployment.
