module Bundle.Python

open SimpleExec
open BlackFox.CommandLine
open Build
open Utils.Path.Operators

open System.IO

let private clean(pyPath: string) =
    if Directory.Exists pyPath then
        Directory.Delete(pyPath, true)

let private transpileFSharp(pyPath) =
    CmdLine.empty
    |> CmdLine.appendRaw "fable"
    // |> CmdLine.appendIf isWatch "--watch"
    |> CmdLine.appendRaw ProjectInfo.Projects.Main
    |> CmdLine.appendPrefix "-o" pyPath
    |> CmdLine.appendRaw "--noCache"
    |> CmdLine.appendPrefix "--lang" "py"
    |> CmdLine.appendPrefix "--fableLib" "fable-library"
    |> CmdLine.appendRaw "--noReflection"
    |> CmdLine.toString

let private copyMetadata(pyPath) =
    File.Copy(ProjectInfo.PyprojectTOML, pyPath </> ProjectInfo.PyprojectTOML)
    File.Copy(ProjectInfo.README, pyPath </> "README.md")

let private peotryBundle =
    CmdLine.empty
    |> CmdLine.appendPrefix "-m" "poetry"
    |> CmdLine.appendRaw "build"
    |> CmdLine.toString

let Main(pyDir: string) = 
    let projectName = Utils.camelCaseToSnakeCase ProjectInfo.ProjectNamePython |> _.Replace("-","_")
    let publishDir = pyDir </> projectName
    clean(pyDir)
    Command.Run("dotnet", transpileFSharp publishDir)
    Index.PY.generate publishDir "__init__.py"
    copyMetadata pyDir
    Command.Run("python", peotryBundle, workingDirectory=pyDir)