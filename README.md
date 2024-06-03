# Fable.Multiverse

<a href="https://www.nuget.org/packages/Fable.Multiverse/0.1.0"><img src="https://img.shields.io/nuget/dt/Fable.Multiverse?style=for-the-badge&logo=nuget"></a>
<a href="https://www.nuget.org/packages/Fable.Multiverse/0.1.0"><img alt="NuGet Version" src="https://img.shields.io/nuget/v/Fable.Multiverse?style=for-the-badge"></a>

A template to get up and running as fast as possible with Fable and publishing to multiple languages.

On creation this template supports:

* FSharp
* JavaScript
* TypeScript
* Python
* CSharp

---
## Install

`dotnet new install Fable.Multiverse`

---
## Create

1. `dotnet new fable.multiverse -n <project-name> --git-owner <git-owner>`
2. Follow the instructions in the README.md of the created project. 🎉

---
## Overview

This template creates:

- Build Project
  - Testing
  - Bundling
  - Publishing
  - Automatic index file creation
  - Code generator for C# access layer
- Src Projects
  - F# Project
  - C# Access layer project
- Test Projects
  - [Fable.Pyxpecto](https://github.com/Freymaurer/Fable.Pyxpecto) Project
  - C# Xunit Project
  - Python pytest Project
  - JavaScript Mocha Project
- TypeScript support for tests and publishing with types.
