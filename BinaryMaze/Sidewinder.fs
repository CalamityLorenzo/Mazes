namespace MazeDef

    open System

    module Sidewinder = 
        let private rando = Random()

        let private applyDirection drt grd =
            match drt with
            | Some direction -> grd direction
            | None -> ()
        let Build (grd:Grid) = 
            let mutable g = grd
            for r in 0..grd.Row-1 do
                let mutable currentRun:Cell list = []
                for c in 0..grd.Column-1 do
                    let cell = grd.Cells.[r,c]
                    currentRun <- cell::currentRun
                    let atEasternBounry = Option.isNone cell.East
                    let atNothernBoundry = Option.isNone cell.North
                    let shouldCloseOut = atEasternBounry || (not atNothernBoundry && rando.Next(2)=0)

                    if shouldCloseOut then
                        let memberCell = currentRun.[rando.Next(currentRun.Length-1)]
                        applyDirection memberCell.North (fun ab -> g <- Grids.LinkCell g memberCell ab)
                        currentRun <- []
                    else
                        applyDirection cell.East (fun ab -> g <- Grids.LinkCell g cell ab)
            g




                    

