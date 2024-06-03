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
    |> CmdLine.appendPrefix "-o" (Path.Combine(pyPath,"siren_dsl"))
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
    clean(pyDir)
    Command.Run("dotnet", transpileFSharp pyDir)
    Index.PY.generate pyDir
    copyMetadata pyDir
    Command.Run("python", peotryBundle, workingDirectory=pyDir)