module MazeBitmaps
open System.Drawing
open MazeDef
open System
    
    let paintImage image (rect:Rectangle) colour =
        using (Graphics.FromImage(image)) (fun gfx->
            use broosh = new SolidBrush(colour)
            gfx.FillRectangle(broosh, rect))

    let drawLine image (x1:int) (y1:int) (x2:int) (y2:int) (colour:Color) = 
        using (Graphics.FromImage(image)) (fun gfx->
                use pen = new Pen(colour)
                gfx.DrawLine(pen, x1, y1, x2, y2)
            )

    let private paintBackground image colour =
        paintImage image (Rectangle(0,0,image.Width, image.Height)) colour

    let private NoWall direct f = 
        match direct with
        | Some -> ()
        | None ->  f()

    let ToImage (grd:Grid) (path:string) cellSize = 
        // Our image to be created
        let img = new Bitmap(cellSize* grd.Row+1, cellSize * grd.Column+1)
        let BackgroundColour = Color.White;
        let WallColour = Color.Black
        paintBackground img BackgroundColour
        //drawWall img 0 0 img.Width 10 WallColour

        grd.Cells |> Array2D.iter(fun c->
            let x1 = c.Column * cellSize
            let y1 = c.Row * cellSize
            let x2 = (c.Column+1) * cellSize
            let y2 = (c.Row+1)* cellSize
            
            NoWall c.North (fun () -> drawLine img x1 y1 x2 y1 WallColour)
            NoWall c.West (fun () -> drawLine img x1 y1 x1 y2 WallColour)
            let links = Cells.linked c
            if not(links c.East) then    
                drawLine img x2 y1 x2 y2 WallColour
            if not(links c.South) then
                 drawLine img x1 y2 x2 y2 WallColour
        ) 
        img.Save(path)
        



