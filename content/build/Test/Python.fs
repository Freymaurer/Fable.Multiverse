module Build.Test.Python

open SimpleExec
open BlackFox.CommandLine
open Utils.Path.Operators

let private outDir = ProjectInfo.TestPaths.CoreDirectory </> "py"
let private entryPoint = outDir </> "main.py"

let python = "python"

let handleNative (args: string list) =
    let isFast = args |> List.contains "--fast"

    let pytestCommand =
        CmdLine.empty
        |> CmdLine.appendRaw "-m pytest"
        |> CmdLine.appendRaw ProjectInfo.TestPaths.PyNativeDirectory
        |> CmdLine.toString

    if isFast then
        Command.Run(
          python,
          pytestCommand
        )
    else
        let dirPath = ProjectInfo.TestPaths.PyNativeDirectory </> ProjectInfo.ProjectName
        let fableTranspile =
            CmdLine.empty
            |> CmdLine.appendRaw "fable"
            |> CmdLine.appendRaw (ProjectInfo.Projects.MainDir </> ProjectInfo.Projects.Main)
            |> CmdLine.appendPrefix "--outDir" dirPath
            |> CmdLine.appendPrefix "--lang" "python"
            |> CmdLine.appendRaw "--noCache"
            |> CmdLine.toString
        Command.Run(
            "dotnet",
            fableTranspile
        )
        Index.PY.generate dirPath "index.py"
        Command.Run(
          python,
          pytestCommand
        )


let handle (args: string list) =
    let isWatch = args |> List.contains "--watch"

    let runArg =
        if isWatch then
            "--runWatch"
        else
            "--run"

    Command.Run(
        "dotnet",
        CmdLine.empty
        |> CmdLine.appendRaw "fable"
        |> CmdLine.appendRaw ProjectInfo.TestPaths.CoreDirectory
        |> CmdLine.appendPrefix "--outDir" outDir
        |> CmdLine.appendPrefix "--lang" "python"
        |> CmdLine.appendRaw "--noCache"
        |> CmdLine.appendIf isWatch "--watch"
        |> CmdLine.appendRaw runArg
        |> CmdLine.appendRaw python
        |> CmdLine.appendRaw entryPoint
        |> CmdLine.appendRaw "--silent"
        |> CmdLine.toString
    )
