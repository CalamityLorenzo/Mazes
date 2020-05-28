module MazeCore.Cells
    open MazeCore.Models 

    module Cells =
        let inline (=) (x:Cell) (y:Cell) = x.Position = y.Position

        let newCell {Row=r; Column=c} = 
            {
                Position= {Row=r; Column=c}
                North=None;
                South=None;
                East=None;
                West=None;
                Links=Set.empty
            }
        let link cell link =
            if cell.Links |> Set.contains link then
                cell
            else
                {cell with Links = cell.Links |> Set.add link}
        let unlink cell link = 
                {cell with Links = cell.Links |> Set.remove link}
        // returns the surrounding layout
        let neighbours cell =
            let getNeighour direction acc = 
                match direction with
                | Some s -> s::acc
                | None -> acc
            let mutable cells = getNeighour cell.North []
            cells<- getNeighour cell.South cells
            cells<- getNeighour cell.East cells
            cells<- getNeighour cell.West cells
            cells
    
        let North itm ref =
                     {itm with North = ref}
        let East itm ref =
                     {itm with East = ref}
        let South itm ref =
                     {itm with South = ref}
        let West cell ref =
                     {cell with West = ref}        
        let MapLayout cell nrth est sth wst =
                     {cell with North = nrth; East = est; South = sth; West=wst }
        
        let MatchCell c1 c2 = 
            c1 = c2
        