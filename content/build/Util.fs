module Utils

open System.IO
open System


module Path =

    module Operators =

        let (</>) (p1: string) (p2: string) : string = Path.Combine(p1, p2)

    type Path =

        /// <summary>
        /// Resolve a path relative to the repository root
        /// </summary>
        static member Resolve([<ParamArray>] segments: string array) : string =
            // No idea why but __SOURCE_DIRECTORY__ is not working on CI
            // it doesn't returns the correct path
            // let paths = Array.concat [ [| __SOURCE_DIRECTORY__; ".." |]; segments ]

            // Use Environment.CurrentDirectory instead even if it means that we
            // need to be in the expected directory when running the build script
            let paths =
                Array.concat
                    [
                        [| Environment.CurrentDirectory |]
                        segments
                    ]

            // Use GetFullPath to clean the path
            Path.GetFullPath(Path.Combine(paths))

// code to make camelcase to snakecase
/// This is because we currently snake_case everything that does not start with a capital letter
let camelCaseToSnakeCase (str: string) = 
    if Char.IsUpper str.[0] then
        str 
    else
        str 
        |> Seq.fold (fun (acc: string) c -> 
            if Char.IsUpper c then 
                acc + "_" + string (Char.ToLower c) 
            else 
                acc + string c
        ) ""