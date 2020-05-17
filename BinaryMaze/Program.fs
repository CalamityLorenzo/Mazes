// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open MazeDef
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let oneCEll = Cells.newCell 0 5
    let twoCell = Cells.newCell 0 3
    let threeCElll = Cells.newCell 1 2
    let mutable fourCell = Cells.newCell 2 2
    let oneCella = Cells.link oneCEll twoCell
    let tweoCElla = Cells.link twoCell oneCEll

    fourCell <- Cells.North fourCell (Some oneCEll)
    
    printfn "col %d row %d " oneCEll.Column oneCEll.Row
    let rows = 3
    let cols = 3
    for i in 0 .. (rows*cols) do
         printfn "%d r : %d c : %d " i (i/rows) (i%rows)

    0 // return an integer exit code