namespace MazeDef
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
        let ac1 = getNeighbour cell.North []
        getNeighbour cell.East ac1
   
    let pickNeighbour cell =
        let neighbours = GetNorthEastNeighbours cell
        match(neighbours.Length) with
        | len when len>0 ->
                       let idx = rando.Next(neighbours.Length)
                       // Hello there new neighbour
                       Some neighbours.[idx]
        | _ -> None

    let Build grd = 
        let mutable g = grd
        for x in 0..grd.Row-1 do
            for y in 0..grd.Column-1 do
                let cell = g.Cells.[x,y]
                let neighbour = pickNeighbour cell
                match (neighbour) with
                | Some nCell -> g <- Grids.LinkCell g cell nCell
                | None -> ()
        g
