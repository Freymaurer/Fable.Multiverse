module Build.Test.FSharp

open SimpleExec
open BlackFox.CommandLine
open Build
open Utils.Path.Operators

let handle (args: string list) =
    let isWatch = args |> List.contains "--watch"

    let args : string =
        CmdLine.empty
        |> CmdLine.appendIf isWatch "watch"
        |> CmdLine.appendRaw "run"
        |> CmdLine.appendPrefix "--project" (ProjectInfo.TestPaths.CoreDirectory </> ProjectInfo.Projects.Tests)
        |> CmdLine.appendRaw "--silent"
        |> CmdLine.toString

    Command.Run(
        "dotnet",
        args
    )