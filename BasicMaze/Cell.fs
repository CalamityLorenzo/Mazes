namespace MazeDef
open System.Collections.Generic

// Links are bi-drirectional, 
// update in one. Must update the other.
type Cell =
        {
            Row:int
            Column:int
            North:Cell option
            South:Cell option
            East:Cell option
            West:Cell option
            Links:Cell Set
        }

module Cells =
  
   let newCell row col = 
        {Row=row; Column=col;
        North=None;
        South=None;
        East=None;
        West=None;
        Links=Set.empty
         }
    
   let linked cell isLinked =
        match (isLinked) with
        | Some linked -> (Set.filter (fun s-> s.Row = linked.Row && s.Column = linked.Column ) cell.Links).Count > 0
        | None -> false

   let link cell link =
        
       let replaceCell =  {cell with Links = cell.Links |> Set.add link }
       let replaceLink = {link with Links = link.Links |> Set.add cell}
       (replaceCell, replaceLink)
       //replaceCell::replaceLink :: allCells |> List.filter (fun f -> not(f = cell) || not(f= link))

   let unlink cell link  = 
      let replaceCell =  {cell with Links = cell.Links |> Set.remove link}
      let replaceLink =  {link with Links = link.Links |> Set.remove cell}
      (replaceCell,replaceLink)
      
   let North itm cell = 
         {itm with North = cell}
   let East itm cell = 
             {itm with East = cell}
   let South itm cell = 
             {itm with South = cell}
   let West itm cell = 
             {itm with West = cell}
    
   let MapLocation itm nrth est sth wst =
    {itm with North = nrth; East = est; South = sth; West=wst }
   let neighbours  itm  = 
     let addIfFound (opt:Cell option) (lst:Cell list) = 
       match opt with 
       | Some s ->  s::lst
       | None -> lst

     let mutable v1 = addIfFound itm.North []
     v1 <- addIfFound itm.South v1
     v1 <- addIfFound itm.East v1
     v1 <- addIfFound itm.West v1
     v1 <- addIfFound itm.North v1
     v1
