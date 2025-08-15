<div align="center">

<img src="res/images/icon.png" alt="NetEx.WinForms.ProgressDialog" width="75" />

# NetEx.Legacy

A collection of types and controls that have been removed from .NET, ported to work with newer runtime versions. :relaxed:

</div>

## 💬 Overview

The aim of this repo is to provide compatibility for projects using deprecated types and controls, to allow them to upgrade to newer framework versions without having to rewrite their codebase.

As such, **all existing namespaces have been preserved**, meaning that most/all of the code will reside in the `System` namespace. Whilst this shouldn't normally be used, because this package is for compatibility purposes, maintaining the original namespaces felt like the most appropriate option.

The code has been taken from the last available version within the official .NET repositories, and modified only where necessary to make it functional; as such, the majority of the code should be identical to the original code. Any libraries or compatibility shims are within the `Compatibility` folder.

The project is very much a **work-in-progress** and **perpetual alpha** (at least for the time being), and is currently focused on restoring types and controls that have been removed. In the future the code could be updated to take advantage of newer runtime features, or move out of the `System` namespace, but that isn't on the roadmap at present!

## 📦 Projects

This repo contains the following project:

### NetEx.Legacy.WinForms
[![NetEx.Legacy.WinForms)](https://img.shields.io/nuget/v/NetEx.Legacy.WinForms.svg)](https://www.nuget.org/packages/NetEx.Legacy.WinForms/) [![.NET](https://img.shields.io/badge/.net%20-5.0+-8A2BE2)](https://dotnet.microsoft.com/download) [![.NET Core](https://img.shields.io/badge/.net%20core-3.1-8A2BE2)](https://dotnet.microsoft.com/en-us/download/dotnet-framework)

A collection of controls that have been removed from **System.Windows.Forms**.

Currently supports:
- System.Windows.Forms.**ContextMenu**
- System.Windows.Forms.**MainMenu**
- System.Windows.Forms.**Menu**
- System.Windows.Forms.**MenuItem**

## 🙌 Usage

To use, simply install the required package from NuGet:

```powershell
# NetEx.Legacy.WinForms
Install-Package NetEx.Legacy.WinForms
```

## 📖 Documentation

Documentation and example code is available [here](https://peckmore.github.io/NetEx.Legacy).

Full API documentation can be found [here](https://peckmore.github.io/NetEx.Legacy/api/System.Windows.Forms.html).

## 🚀 Releases

A full list of all releases is available on the [Releases](https://github.com/Peckmore/NetEx.Legacy/releases) tab on GitHub.

A complete changelog can also be found [here](https://github.com/Peckmore/NetEx.Legacy/blob/main/CHANGELOG.md).

## 🔢 Versioning

**NetEx.Legacy** uses [Semantic Versioning](https://semver.org) for all packages.

## 📄 License

The code is licensed under the [MIT license](https://github.com/Peckmore/NetEx.Legacy?tab=readme-ov-file#MIT-1-ov-file).
