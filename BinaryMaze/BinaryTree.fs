namespace MazeDefs
open System
// WE cana move North or East.gri
// Fpr each cell work out the north./east and then randomly decide which to use
module BinaryTree = 
    let private rando = Random()
        
    let private GetNorthEastNeighbours cell = 
        let getNeighbour direction acc = 
            match(direction) with
            | Some dir -> dir::acc
            | None -> acc
        let ac1 = getNeighbour cell []
        getNeighbour cell ac1
    let linkCells cell = 
        let neighbours = GetNorthEastNeighbours cell
        let idx = rando.Next(neighbours.Length)
        let neighbout = neighbours.[idx]
        Cells.link cell neighbout
    let Build grd = 
       grd.Cells |> Array2D.iter (fun g-> linkCells g)
