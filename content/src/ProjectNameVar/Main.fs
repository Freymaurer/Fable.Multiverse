namespace ProjectNameVar

open Fable.Core

[<AttachMembers>]
type Main =
    static member hello (name: string, ?from: string) = 
        match from with
        | Some f -> printfn "Hello, %s! (from %s)" name f
        | None -> printfn "Hello, %s!" name

    static member printTuples(tuples:#seq<string*string>) =
        for first, second in tuples do
            printfn "%s: %s" first second
