# ProjectNameVar

This is a template for a multi-language [Fable](https://fable.io/docs/) library. 

---
## Local Development

### Requirements

Because this library targets multiple programming languages we need to support all of them:

- [nodejs and npm](https://nodejs.org/en/download)
    - verify with `node --version` (Tested with v20.10.0)
    - verify with `npm --version` (Tested with v9.2.0)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
    - verify with `dotnet --version` (Tested with 8.0.205)
- [Python](https://www.python.org/downloads/)
    - verify with `py --version` (Tested with 3.11.9, known to work only for >=3.11)

### Setup

This needs to be done on a fresh download once. Paths for python venv executable might be different depending on the OS.

1. `dotnet tool restore`, Restore .NET tools (fable)
2. `npm i`, install js dependencies
3. `py -m venv ./.venv`, setup python virtual environment
4. `.\.venv\Scripts\Activate.ps1`, activate python virtual environment
5. install python dependencies
    1. `python -m pip install -U pip setuptools`
    2. `python -m pip install poetry`
    3. `python -m poetry install --no-root`

### Testing

First activate python virtual environment (`.\.venv\Scripts\Activate.ps1`).

`.\build.cmd test`

*or specify target*

`.\build.cmd test [f#, c#, js [native], py [native]]`

### Publish

Requires API keys for Nuget and PyPi. 

The following command will run all tests, bundle and then start publishing!

`.\build.cmd publish pipeline`

*or only publish specific targets, without test and bundle*

`.\build.cmd publish [npm, pypi, nuget]`
