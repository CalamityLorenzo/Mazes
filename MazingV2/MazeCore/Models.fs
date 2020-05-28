namespace MazeCore.Models

type Grid =
    { Rows: int
      Columns: int
      Cells: Cell []
      Size: int }
and Cell =
    { Position: R0C0
      North: R0C0 option
      South: R0C0 option
      East: R0C0 option
      West: R0C0 option
      Links: R0C0 Set } // All the joined cells for a maze[You can plot a route here].
and R0C0 = { Row: int; Column: int }
