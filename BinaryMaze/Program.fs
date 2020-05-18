// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open MazeDef
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    
    let grid = Grids.PrepareGrid 4 4
    let cell = Grids.RandomCell grid

    for i in 0..3 do
      for j in 0..3 do
        printfn "%d row:%d col:%d" i (grid.Cells.[i,j].Row) grid.Cells.[i,j].Column 
    0 // return an integer exit code