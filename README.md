# ClipCopy

🚀 Share to clipboard with(out) extra steps on your Android device.

![OS](https://img.shields.io/badge/OS-Android-blue)
![GitHub](https://img.shields.io/github/license/ezioleq/ClipCopy?color=blue)
![GitHub issues](https://img.shields.io/github/issues/ezioleq/ClipCopy?color=blue)
![GitHub milestone](https://img.shields.io/github/milestones/progress-percent/ezioleq/ClipCopy/1)
![GitHub Repo stars](https://img.shields.io/github/stars/ezioleq/ClipCopy)
![GitHub forks](https://img.shields.io/github/forks/ezioleq/ClipCopy)

Brings back the **Share to Clipboard** feature removed back in Android 10.
With this application you can choose to share a resource directly to your clipboard and thus copying it.

> [!WARNING]
> The application is under heavy development and not all of its features are currently available.

## ⚙️ It's not everything...

ClipCopy also allows you to save your previous clips and manage them by pinning your favorite entries,
copying them again or... disable this functionality whole and use it only as a clipboard share target 👍

### ✨ Features (planned)

- Shared clips history
- Pinning your favorite clips
- Sharing clips with others

## 📝 Additional information

### 🤖 Compatibility

This application is compatible with a wide range of Android devices.

- Minimum required Android version is `7.1.1` aka `Nougat` or `API Level 25`
- Target Android version is `13` aka `Tiramisu` or `API Level 33`

### 🏗️ Project structure

- `ClipCopy` - Main application project featuring activities, views, services etc.
- `ClipCopy.Database` - Project for storing models, database context and the most important - migrations, because
making them with [EntityFramework](https://learn.microsoft.com/en-us/ef/core/) is not supported in the Android project.

### 💼 Use cases

- Quoting Xamarin and MAUI, `To be added.`
