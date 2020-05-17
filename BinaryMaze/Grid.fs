namespace MazeDef

module Grid =
    type T ={ Row:int; Column:int; Cells:Cell [,]}

    let private prepGrid rows cols =
        Array.init (rows*cols) (fun s-> Cells.newCell (s/rows) (s%rows))

    let private findCell row col (grid:T) =
        if row < 0 && row >= grid.Row then None
        elif col < 0 &&  col >= grid.Column then None
        else Some grid.Cells.[row,col]
       

    let configureGrid grd =
        //Cells.MapLocation 
        grd

    let PrepareGrid row cols =
        let grid = prepGrid row cols
        configureGrid grid
            