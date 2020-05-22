namespace MazeDef
module MazeConsoleDisplay = 
    let isVertBoundry  bdry = 
        match (bdry) with
        | true -> " "
        | false -> "|"
    let isHorizBoundry  bdry = 
        match (bdry) with
        | true -> "   "
        | false -> "---"
    let repeatString  (str:string) count = 
        let l = seq{
            for i in 1..count do yield str
        }
        String.concat "" l
    let ToConsole grid =
        
       let mutable output = "+" + (repeatString "---+" grid.Column) + "\n"
       for r in 0..grid.Row-1 do
        let mutable top = "|"
        let mutable bottom = "+"
        for c in 0..grid.Column-1 do
            let cell = grid.Cells.[r,c]
            let body = "   "
            /// INCORRECT CHECK THE FUCKING LINKS!!
            let eastBoundry = isVertBoundry (Cells.linked cell cell.East)
            let southBoundry = isHorizBoundry (Cells.linked cell cell.South)
            let corner = "+"
            top <- top + body + eastBoundry
            bottom <- bottom + southBoundry + corner    
        output <- output + top+"\n"+ bottom + "\n"
       output
            


