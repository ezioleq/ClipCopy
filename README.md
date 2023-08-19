# ClipCopy

🚀 Share to clipboard with(out) extra steps on your Android device.

Brings back the **Share to Clipboard** feature removed back in Android 10.
With this application you can choose to share a resource directly to your clipboard and thus copying it.

### 🚧 Under construction warning!

## ⚙️ It's not everyting...

ClipCopy also allows you to save your previous clips and manage them by pinning your favorite entries,
copying them again or... disable this functionality whole and use it only as a clipboard share target 👍

### ✨ Features

- Shared clips history
- Pinning your favorite clips
- Sharing clips with others

## 📝 Additional information

### 🤖 Compatibility

This application is compatible with a wide range of Android devices.

- Minimum required Android version is `7.1.1` aka `Nougat` or `API Level 25`
- Target Android version is `13` aka `Tiramisu` or `API Level 33`

### 🏗️ Project sructure

The project is built on top of [MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui) which is an [Xamarin](https://learn.microsoft.com/en-us/xamarin/get-started/what-is-xamarin) successor.
Both of the technologies aren't production ready for real and using them can be often cumbersome.
This application is using MAUI because of pleasure of using C# language and shreds of previous expierience of developing with Xamarin which is now deprecated.

- `ClipCopy` - Main application project featuring activities, views, services etc.
- `ClipCopy.Database` - Project for storing models, database context and the most important - migrations, because
making them with [EntityFramework](https://learn.microsoft.com/en-us/ef/core/) is not supported in the Android project.

### 💼 Use cases

- Quoting Xamarin and MAUI, `To be added.`
