module Test.CSharp

open SimpleExec
open BlackFox.CommandLine
open Build
open Utils.Path.Operators

let handle (args: string list) =
    let isWatch = args |> List.contains "--watch"

    let args : string =
        CmdLine.empty
        |> CmdLine.appendIf isWatch "watch"
        |> CmdLine.appendRaw "test"
        |> CmdLine.append (ProjectInfo.TestPaths.CSharpDirectory </> ProjectInfo.Projects.TestsCSharp)
        |> CmdLine.toString

    Command.Run(
        "dotnet",
        args
    )