module ProjectInfo

open System.IO
open Utils
open Utils.Path
open Utils.Path.Operators

let root = Path.Resolve()

let Owner = "{Owner}"

[<Literal>]
let ProjectName = "ProjectNameVar"

[<Literal>]
let ProjectNameCSharp = "ProjectNameVar.CSharp"

/// This might require adjustment. If you adjust this also update pyproject.toml!
[<Literal>]
let ProjectNamePython = "ProjectNameVar"

/// This might require adjustment. If you adjust this also update package.json!
[<Literal>]
let ProjectNameJavaScript = "ProjectNameVar"

[<Literal>]
let Version = "0.1.0"

[<Literal>]
let PyprojectTOML = "pyproject.toml"

[<Literal>]
let PackageJSON = "package.json"

[<Literal>]
let README = "README.md"



module Keys =
    
    let [<Literal>] PyPi = "PYPI_KEY"
    let [<Literal>] NPM = "NPM_KEY" // not used currently
    let [<Literal>] Nuget = "NUGET_KEY"



module TestPaths =

    [<Literal>]
    let BaseDirectory = "tests"

    let CoreDirectory = BaseDirectory </> $"{ProjectName}.Tests"

    let CSharpDirectory = BaseDirectory  </> $"{ProjectName}.CSharp.Tests"

    let JSNativeDirectory = BaseDirectory </> $"{ProjectName}.JavaScript.Tests"

    let PyNativeDirectory = BaseDirectory </> $"{ProjectName}.Python.Tests"

module Packages =
    [<Literal>]
    let PackageFolder = "./dist"
    let FSHARP = Path.Resolve(PackageFolder, "fsharp")
    let CSHARP = Path.Resolve(PackageFolder, "csharp")
    let JS = Path.Resolve(PackageFolder, "js")
    let TS = Path.Resolve(PackageFolder, "ts")
    let PY = Path.Resolve(PackageFolder, "py")


module Projects =

    let MainDir = $"src\{ProjectName}"
    let MainCSharpDir = $"src\{ProjectNameCSharp}"

    let Main = $"{ProjectName}.fsproj"
    let MainCSharp = $"{ProjectNameCSharp}.csproj"
    let Tests = $"{ProjectName}.Tests.fsproj"
    let TestsCSharp = $"{ProjectNameCSharp}.Tests.csproj"


let getEnvVar key = System.Environment.GetEnvironmentVariable(key, System.EnvironmentVariableTarget.User)