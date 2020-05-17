namespace MazeDef
open System.Collections.Generic

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
     
   let link (itm:Cell) (cell:Cell) =
        {itm with Links = itm.Links |> Set.add cell }
   let unlink itm cell  = 
        {itm with Links = itm.Links |> Set.remove cell }
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
