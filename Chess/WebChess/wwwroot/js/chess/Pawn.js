import { Figure } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";

export class Pawn extends Figure {
    constructor(color) {
        super(color);
        this._firstMove = true;
        this.figureOrder = 1;
    }
    showFigure(cellElement) {
        if (globalThis.playerDesk != undefined) this._firstMove = false;
        let draw = this.getDraw(cellElement);
        draw.path('M 22,9 C 19.79,9 18,10.79 18,13 C 18,13.89 18.29,14.71 18.78,15.38 C 16.83,16.5 15.5,18.59 15.5,21 C 15.5,23.03 16.44,24.84 17.91,26.03 C 14.91,27.09 10.5,31.58 10.5,39.5 L 33.5,39.5 C 33.5,31.58 29.09,27.09 26.09,26.03 C 27.56,24.84 28.5,23.03 28.5,21 C 28.5,18.59 27.17,16.5 25.22,15.38 C 25.71,14.71 26,13.89 26,13 C 26,10.79 24.21,9 22,9 z');
        if (this.color == FigureColor.black) {
            draw.style('opacity:1; fill:#000000; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
        } else {
            draw.style('opacity:1; fill:#ffffff; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
        }
    }
    checkMove(rowPos, columnPos, rowDestination, columnDestination, color = globalThis.playerDesk.chessDesk.currentPlayer) {
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;


        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;
        // index for direction
        let idx = this.direction;
        let targetCell = chessDesk.getCell(rowDestination, columnDestination);
        if (rowDestination == rowPos + idx) {
            // try fight
            if (columnDestination == columnPos + 1 || columnDestination == columnPos - 1) {
                if (targetCell.figure != undefined) {
                    if (targetCell.figure.color != this.color) {
                        return MoveState.fight;
                    }
                }
                return MoveState.cannot;
            }
            if (columnPos == columnDestination) {
                if (targetCell.figure == undefined) {
                    return MoveState.can;
                }
            }
            return MoveState.cannot;
        }

        if (rowDestination == rowPos + idx + idx && columnDestination == columnPos && this._firstMove) {
            if (targetCell.figure == undefined) {
                let roadCell = chessDesk.getCell(rowPos + idx, columnPos);
                if (roadCell.figure == undefined) {
                    return MoveState.can;
                }
            }
        }
        return MoveState.cannot;
    }



}
