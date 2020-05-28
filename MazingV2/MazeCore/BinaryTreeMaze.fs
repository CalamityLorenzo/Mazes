namespace MazeCore.MazeType
open MazeCore.Models
open System
open MazeCore.Grids
module BinaryTreeMaze =
    let private rando = Random()
    let private getNorthEastNeigbourCell cell =
        let getNeighbour direction acc = 
            match direction with
            | Some dir -> dir::acc
            | None -> acc
        let ac1 = getNeighbour cell.North []
        getNeighbour cell.East ac1
    
    let pickNeighbourRef cell = 
        let neighbours = getNorthEastNeigbourCell cell
        match neighbours.Length with
        | len when len>0 ->
                let idx = rando.Next(neighbours.Length)
                Some neighbours.[idx]
        | _ -> None
    let BuildMaze grd = 
        let mutable grid = grd
        for x in 0..grd.Size do
            let cell = grid.Cells.[x]
            let neighbour = pickNeighbourRef cell
            match (neighbour) with
            | Some nCell -> let linkCell = Grids.findCell grid nCell
                            match linkCell with
                            | Some lc -> grid <- Grids.LinkCell grid cell lc
                            | None ->()
            | None -> ()
        grid            

