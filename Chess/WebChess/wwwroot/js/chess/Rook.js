import { Figure } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";
import { MoveState } from "./MoveState.js";

export class Rook extends Figure {
    constructor(color) {
        super(color);
        this.figureOrder = 4;
    }
    showFigure(cellElement) {
        let draw = this.getDraw(cellElement);
        if (this.color == FigureColor.black) {
            draw.style('opacity:1; fill:000000; fill-opacity:1; fill-rule:evenodd; stroke:#000000; stroke-width:1.5; stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            let p = draw.path('M 9,39 L 36,39 L 36,36 L 9,36 L 9,39 z ');
            p.style("stroke-linecap:butt;");
            p = draw.path("M 12.5,32 L 14,29.5 L 31,29.5 L 32.5,32 L 12.5,32 z ");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 12,36 L 12,32 L 33,32 L 33,36 L 12,36 z ");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 14,29.5 L 14,16.5 L 31,16.5 L 31,29.5 L 14,29.5 z ");
            p.style("stroke-linecap:butt;stroke-linejoin:miter;");
            p = draw.path("M 14,16.5 L 11,14 L 34,14 L 31,16.5 L 14,16.5 z ");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 11,14 L 11,9 L 15,9 L 15,11 L 20,11 L 20,9 L 25,9 L 25,11 L 30,11 L 30,9 L 34,9 L 34,14 L 11,14 z ");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 12,35.5 L 33,35.5 L 33,35.5");
            p.style("fill:none; stroke:#ffffff; stroke-width:1; stroke-linejoin:miter;");
            p = draw.path("M 13,31.5 L 32,31.5");
            p.style("fill:none; stroke:#ffffff; stroke-width:1; stroke-linejoin:miter;");
            p = draw.path("M 14,29.5 L 31,29.5");
            p.style("fill:none; stroke:#ffffff; stroke-width:1; stroke-linejoin:miter;");
            p = draw.path("M 14,16.5 L 31,16.5");
            p.style("fill:none; stroke:#ffffff; stroke-width:1; stroke-linejoin:miter;");
            p = draw.path("M 11,14 L 34,14");
            p.style("fill:none; stroke:#ffffff; stroke-width:1; stroke-linejoin:miter;");
        } else {
            draw.style('opacity:1; fill:#ffffff; fill-opacity:1; fill-rule:evenodd; stroke:#000000; stroke-width:1.5; stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            let p = draw.path("M 9,39 L 36,39 L 36,36 L 9,36 L 9,39 z ");
            p.style = ("stroke-linecap:butt;");
            p = draw.path("M 12,36 L 12,32 L 33,32 L 33,36 L 12,36 z ");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 11,14 L 11,9 L 15,9 L 15,11 L 20,11 L 20,9 L 25,9 L 25,11 L 30,11 L 30,9 L 34,9 L 34,14");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 34,14 L 31,17 L 14,17 L 11,14");
            p = draw.path("M 31,17 L 31,29.5 L 14,29.5 L 14,17");
            p.style("stroke-linecap:butt; stroke-linejoin:miter;");
            p = draw.path("M 31,29.5 L 32.5,32 L 12.5,32 L 14,29.5");
            p = draw.path("M 11,14 L 34,14");
            p.style("fill:none; stroke:#000000; stroke-linejoin:miter;");
        }
    }
    checkMove(rowPos, columnPos, rowDestination, columnDestination, color = globalThis.playerDesk.chessDesk.currentPlayer) {
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;
        if (rowPos !== rowDestination && columnPos !== columnDestination) return MoveState.cannot;


        if (rowPos === rowDestination) {
            // move to column
            let idx = Math.sign(columnDestination - columnPos);

            for (let i = columnPos + idx; i != columnDestination; i += idx) {
                let roadCell = chessDesk.getCell(rowPos, i);
                if (roadCell.figure != undefined) return MoveState.cannot;
            }
        } else {
            let idx = Math.sign(rowDestination - rowPos);
            for (let i = rowPos + idx; i != rowDestination; i += idx) {
                let roadCell = chessDesk.getCell(i, columnPos);
                if (roadCell.figure != undefined) return MoveState.cannot;
            }
        }
        let targetCell = chessDesk.getCell(rowDestination, columnDestination);
        if (targetCell.figure == undefined) return MoveState.can;
        if (targetCell.figure.color === this.color)
            return MoveState.cannot;
        else
            return MoveState.fight;
    }

}
