# Unity Singleton Pattern - Unitfy

Welcome to **Unitfy**, a simple and educational Unity project demonstrating the Singleton Pattern in action. Whether you’re a beginner or someone looking to strengthen your understanding of software design principles, this project provides a practical example of creating reusable and maintainable code in Unity.

---

## Table of Contents
- [What is the Singleton Pattern?](#what-is-the-singleton-pattern)
- [Project Overview](#project-overview)
- [Features](#features)
- [How to Run](#how-to-run)
- [Code Explanation](#code-explanation)
- [Contributing](#contributing)
- [License](#license)

---

## What is the Singleton Pattern?
The Singleton Pattern ensures a class has only one instance and provides a global access point to it. In Unity, this is commonly used for managing core systems like:

- Game Managers
- Audio Controllers
- UI Handlers

By using Singleton, we:

- Avoid duplicating instances.
- Maintain global state consistency.
- Simplify access to shared resources.

However, it’s crucial to use Singleton responsibly to prevent tight coupling and ensure adherence to design principles like **SOLID**.

---

## Project Overview
**Unitfy** is a music player application built in Unity, featuring:

- A `MusicManager` that uses the Singleton Pattern to manage audio playback.
- Simple UI controls to play, stop, and switch tracks.
- Clean and modular code designed with **OOP** and **SOLID principles**.

### Tech Stack
- **Unity Engine** (2021+)
- **C#**

---

## Features

- **Play Music**: Start or stop music with a single button.
- **Random Track Selector**: Switch to a random track from a predefined list.
- **Dynamic UI Updates**: Display the current track’s name and artist dynamically.
- **Reusable Code**: Easily adapt the `MusicManager` to other projects.

---

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/unitfy.git
   ```
2. Open the project in Unity.
3. Press **Play** in the Unity Editor.
4. Use the UI buttons to interact with the music player.

### Requirements

- Unity 2021.3 or higher
- Basic understanding of Unity Editor and C#

---

## Code Explanation

### MusicManager
```csharp
public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance => _instance;

    private AudioSource audioSource;
    public AudioClip CurrentTrack => audioSource.clip;
    public bool IsPlaying => audioSource.isPlaying;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayRandomTrack(AudioClip[] tracks)
    {
        AudioClip randomTrack = tracks[Random.Range(0, tracks.Length)];
        audioSource.clip = randomTrack;
        audioSource.Play();
    }
}
```

The `MusicManager`:

- Implements the Singleton Pattern.
- Manages audio playback using an `AudioSource` component.
- Offers public methods to control music (`PlayMusic`, `StopMusic`, `PlayRandomTrack`).

### UI Integration

UI buttons call the `MusicManager` methods to control playback. Track names are dynamically updated using helper functions to parse artist and song names from the file.

---

