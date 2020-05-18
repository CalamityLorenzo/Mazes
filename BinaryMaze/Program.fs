// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open MazeDef
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    
    let grid = Grids.PrepareGrid 4 4
    let binaryGrid = BinaryTree.Build grid

    printfn "%s" (MazeConsoleDisplay.ToConsole binaryGrid)

    0 // return an integer exit code