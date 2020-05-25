namespace MazeDef
open System
    type Grid ={ Row:int; Column:int; Cells:Cell [,]; Size:int}

module Grids =
    let private random = Random()

    let private prepGrid rows cols =
       {Row=rows; Column=cols; Size=rows*cols; Cells =Array2D.init rows cols (fun rows cols-> Cells.newCell rows cols)}

    let private findCell row col grid  =
        if row < 0 || row >= grid.Row then None
        elif col < 0 ||  col >= grid.Column then None
        else Some grid.Cells.[row,col]

    let ConfigureGrid grd =
       let cells = grd.Cells |> Array2D.map (fun c -> Cells.MapLocation c (findCell (c.Row-1) c.Column grd) (findCell c.Row (c.Column+1) grd) (findCell (c.Row+1) c.Column grd) (findCell c.Row (c.Column-1) grd)   )
       {grd with Cells = cells}

    let PrepareGrid row cols =
        let grid = prepGrid row cols
        ConfigureGrid grid

    let RandomCell grid = 
        let r = random.Next grid.Row
        let c = random.Next grid.Column
        grid.Cells.[r,c]
    
    let matchCell (cell1:Cell) (cell2:Cell) = 
        (cell1.Row = cell2.Row && cell1.Column = cell2.Column)

    let LinkCell grid cell (neighbour:Cell) = 
        // update the cells
        let nCell = grid.Cells.[neighbour.Row, neighbour.Column]
        let updatedCells = Cells.link cell nCell
        {grid with Cells = grid.Cells |> Array2D.map (fun c-> if (matchCell c cell) 
                                                                    then fst updatedCells 
                                                                elif (matchCell c neighbour) 
                                                                    then snd updatedCells 
                                                                else c)}
                                                                

    let EveryRow grd = 
        seq{
            for r in 0..grd.Row do
                yield grd.Cells.[r,0..grd.Column-1]
        }

    let EveryCell grd = 
        seq{
            for r in 0..grd.Row do
                for c in 0..grd.Column -> grd.Cells.[r, c]
        }
