module Tests

open Fable.Pyxpecto
open ProjectNameVar

let test_ProjectNameVar = testList "ProjectNameVar" [
    testCase "hello" <| fun _ ->
        Main.hello("{GITOWNER}")
        Expect.pass()
    testCase "hello, from" <| fun _ ->
        Main.hello("{GITOWNER}", "Kevin")
        Expect.pass()
    testCase "tuples" <| fun _ ->
        Main.printTuples(["test1", "test1a"; "test2", "test2b"])
        Expect.pass()
]

let all = testList "main" [
    test_ProjectNameVar
]

[<EntryPoint>]
let main argv = Pyxpecto.runTests (ConfigArg.fromStrings argv) all