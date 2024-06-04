module Index.PY

open System
open System.IO

let private getAllJsFiles(path: string) = 
    Util.getAllFiles(path,"*.py")

let private pattern (className: string) = sprintf @"^class (?<ClassName>%s)+(\(|:).*$" className

let private findPyClasses (rootPath: string) (whiteList: string []) (filePaths: string []) = 
    Util.findClasses rootPath whiteList pattern filePaths

open System.Text

let private createImportStatements (info: (string*string) []) =
    let sb = StringBuilder()
    let importCollection = info |> Array.groupBy snd |> Array.map (fun (p,a) -> p, a |> Array.map fst )
    for filePath, imports in importCollection do
        let p = filePath |> Path.GetFileNameWithoutExtension
        sb.Append (sprintf "from .%s import " p) |> ignore
        sb.AppendJoin(", ", imports) |> ignore
        sb.AppendLine() |> ignore
    sb.ToString()

let private generateIndexfile (rootPath: string, fileName: string, whiteList: string []) =
    getAllJsFiles(rootPath)
    |> findPyClasses rootPath whiteList
    |> createImportStatements
    |> Util.writeIndexFile rootPath fileName

let generate(rootPath: string) (name: string) = 
   
    let snake_case_white_list = WhiteList.WhiteList |> Array.map Utils.camelCaseToSnakeCase
    generateIndexfile(rootPath, name, snake_case_white_list)