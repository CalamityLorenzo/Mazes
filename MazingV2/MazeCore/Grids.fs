module MazeCore.Grids
open Cells
open System

    type Grid = {Rows:int; Columns:int; Cells:Cell []; Size:int}

module Grids =
    let private rando = Random()
    let privatecreateGrid rows cols= 
        {Rows= rows; Columns = cols; Size=rows*cols; Cells = Array.init (rows*cols) (fun i -> Cells.newCell {Row=(i/rows);Column=(i%rows)})}