module MazeCore.Grids
open Cells
open System

    type Grid = {Rows:int; Columns:int; Cells:Cell []; Size:int}

module Grids =
    let private rando = Random()]

    let fetchArrayRef rows row col = 
        row*rows+(col+1)
    let private createGrid rows cols= 
        {Rows= rows; Columns = cols; Size=rows*cols; Cells = Array.init (rows*cols) (fun i -> Cells.newCell {Row=(i/rows);Column=(i%rows)})}
    let findCell grid row col  = 
        if row<0 || row >= grid.Rows then None
        elif col<0 || col >= grid.Columns then None
        else Some grid.Cells.[row*grid.Rows+(col+1)]
    let cellPosition grid row col = 
        match findCell grid row col with
        | Some c-> Some c.Position
        | None -> None
    let ConfigureCells grid =
        let getCellPos  = cellPosition grid 
        let cells = grid.Cells |> Array.map (fun c-> Cells.MapLayout c (getCellPos (c.Position.Row-1) c.Position.Column) (getCellPos c.Position.Row (c.Position.Column+1)) (getCellPos (c.Position.Row+1) c.Position.Column) (getCellPos c.Position.Row (c.Position.Column-1))) 
        {grid with Cells = cells}
    let PrepareGrid row cols = 
        let grid = createGrid row cols
        ConfigureCells grid
    
    let RandomCell grid = 
        let r = rando.Next grid.Rows
        let c = rando.Next grid.Columns
        grid.Cells.[(fetchArrayRef grid.Rows r c)]
    
    let LinkCell grid cell neighbourCell =
        let nCell = grid.Cells.[fetchArrayRef grid.Rows neighbourCell.Position.Row neighbourCell.Position.Column]
        let updateCell = Cells.link cell neighbourCell.Position
        let nCellUpdate = Cells.link nCell cell.Position
        {grid with Cells = grid.Cells|> Array.map (fun c-> if Cells.MatchCell c cell then updateCell
                                                           elif Cells.MatchCell c nCellUpdate then nCellUpdate 
                                                           else c)}
    let EveryRow grd =
        seq {
            let mutable resArray = []
            for r in 0..grd.Rows do
                for c in 0..grd.Columns do
                    resArray <- grd.Cells.[(fetchArrayRef grd.Rows r c)]::resArray
                yield resArray |> List.rev
        }
    let EveryCell grd = 
        seq{
            for c in 0..grd.Size do
                yield grd.Cells.[c]
        }
    