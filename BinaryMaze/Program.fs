// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open MazeDef
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    
    let mutable looper = true
    while looper do
        let grid = Grids.PrepareGrid 4 4
        let binaryGrid = BinaryTree.Build grid
        let sideWinderGrid = Sidewinder.Build grid
        printfn "%s" (MazeConsoleDisplay.ToConsole binaryGrid)
        printfn "\n"
        printfn "%s" (MazeConsoleDisplay.ToConsole sideWinderGrid)
        let key = Console.ReadKey()
        if (key.Key = ConsoleKey.Escape) then
            looper <- false
        else
            Console.Clear()
    0 // return an integer exit code