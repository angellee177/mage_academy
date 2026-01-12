# Mage Academy Game

<img src="docs/img/Mage academy.gif" width="240" height="400" alt="Mage Academy Gameplay">

## Description
Help!! Emily is surrounded!
Trapped in the swirling mists of the Magic Tower, apprentice mage Emily is being swarmed by pesky bats! Use your magical reflexes to blast through the enemies and guide her to safety. Can you master the mystic spirals and save the academy?

----
## Project Setup

Before you start, ensure you have the following installed:

* **Unity Hub**
* **Unity Editor 6000.3.2f1**
* **Git LFS** (Required for large library files)

> [⚠️!IMPORTANT]
> This project uses **Git LFS** to store large binary files. If you clone without Git LFS installed, your build files will be corrupted. Install it via `brew install git-lfs` (Mac) or `sudo apt install git-lfs` (Linux) and run `git lfs install` before cloning.

### 1. Clone the Repository
you need to clone this repository first, copy paste this command below to your terminal:
```zsh
git clone https://github.com/angellee177/mage_academy
```

Then goto the folder.
```zsh
cd mage_academy
```

### 2. .NET Environment

Unity scripts require the .NET SDK for IntelliSense. Check your version:

```zsh
dotnet --version
```

If not found, download it from [dotnet.microsoft.com](https://dotnet.microsoft.com/download).

### 3. Open with Unity

1. Open **Unity Hub** and click **Add**.
2. Select the `mage_academy` folder.
3. Click the project to open.

> [⚠️ WARNING] <br>
> If you see a "Safe Mode" warning or compilation errors regarding `UnityEngine.InputSystem`, go to **Window > Package Manager**, search for **Input System**, and click **Install**. Unity will restart to enable the new back-ends.
