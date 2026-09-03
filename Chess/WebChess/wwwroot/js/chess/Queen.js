import { Figure } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";

export class Queen extends Figure {
    constructor(color) {
        super(color);
        this.figureOrder = 5;
    }
    showFigure(cellElement) {
        let draw = this.getDraw(cellElement);
        if (this.color == FigureColor.black) {
            draw.style('opacity:1; fill:000000; fill-opacity:1; fill-rule:evenodd; stroke:#000000; stroke-width:1.5; stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            draw.circle(2.75).x(6).y(12);
            draw.circle(2.75).x(13).y(9);
            draw.circle(2.75).x(21).y(8);
            draw.circle(2.75).x(30).y(9);
            draw.circle(2.75).x(38).y(12);
            let p = draw.path("M 9,26 C 17.5,24.5 30,24.5 36,26 L 38.5,13.5 L 31,25 L 30.7,10.9 L 25.5,24.5 L 22.5,10 L 19.5,24.5 L 14.3,10.9 L 14,25 L 6.5,13.5 L 9,26 z");
            p.style("stroke-linecap:butt; stroke:#000000;");
            p = draw.path("M 9,26 C 9,28 10.5,28 11.5,30 C 12.5,31.5 12.5,31 12,33.5 C 10.5,34.5 10.5,36 10.5,36 C 9,37.5 11,38.5 11,38.5 C 17.5,39.5 27.5,39.5 34,38.5 C 34,38.5 35.5,37.5 34,36 C 34,36 34.5,34.5 33,33.5 C 32.5,31 32.5,31.5 33.5,30 C 34.5,28 36,28 36,26 C 27.5,24.5 17.5,24.5 9,26 z");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 11,38.5 A 35,35 1 0 0 34,38.5");
            p.style("fill:none; stroke:#000000; stroke-linecap:butt;");
            p = draw.path("M 11,29 A 35,35 1 0 1 34,29");
            p.style("fill:none; stroke:#ffffff;");
            p = draw.path("M 12.5,31.5 L 32.5,31.5");
            p.style("fill:none; stroke:#ffffff;");
            p = draw.path("M 11.5,34.5 A 35,35 1 0 0 33.5,34.5");
            p.style = ("fill:none; stroke:#ffffff;");
            p = draw.path("M 10.5,37.5 A 35,35 1 0 0 34.5,37.5");
            p.style("fill:none; stroke:#ffffff;");
        } else {
            draw.style('opacity:1; fill:#ffffff; fill-opacity:1; fill-rule:evenodd; stroke:#000000; stroke-width:1.5; stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            draw.circle(2.75).x(6).y(12);
            draw.circle(2.75).x(13).y(9);
            draw.circle(2.75).x(21).y(8);
            draw.circle(2.75).x(30).y(9);
            draw.circle(2.75).x(38).y(12);



            let p = draw.path("M 9,26 C 17.5,24.5 30,24.5 36,26 L 38,14 L 31,25 L 31,11 L 25.5,24.5 L 22.5,9.5 L 19.5,24.5 L 14,10.5 L 14,25 L 7,14 L 9,26 z ");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 9,26 C 9,28 10.5,28 11.5,30 C 12.5,31.5 12.5,31 12,33.5 C 10.5,34.5 10.5,36 10.5,36 C 9,37.5 11,38.5 11,38.5 C 17.5,39.5 27.5,39.5 34,38.5 C 34,38.5 35.5,37.5 34,36 C 34,36 34.5,34.5 33,33.5 C 32.5,31 32.5,31.5 33.5,30 C 34.5,28 36,28 36,26 C 27.5,24.5 17.5,24.5 9,26 z ");
            p.style("stroke-linecap:butt;");
            p = draw.path("M 11.5,30 C 15,29 30,29 33.5,30");
            p.style("fill:none;");
            p = draw.path("M 12,33.5 C 18,32.5 27,32.5 33,33.5");
            p.style("fill:none;");
        }
    }
    checkMove(rowPos, columnPos, rowDestination, columnDestination, color = globalThis.playerDesk.chessDesk.currentPlayer) {
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;

        let bishop = Math.abs(rowPos - rowDestination) === Math.abs(columnPos - columnDestination);
        let rock = !(rowPos !== rowDestination && columnPos !== columnDestination);

        if (bishop == false && rock == false) return MoveState.cannot;

        let idxRow = Math.sign(rowDestination - rowPos);
        let idxColumn = Math.sign(columnDestination - columnPos);

        for (let i = rowPos + idxRow, j = columnPos + idxColumn; i != rowDestination || j != columnDestination; i += idxRow, j += idxColumn) {
            let roadCell = chessDesk.getCell(i, j);
            if (roadCell.figure != undefined) return MoveState.cannot;
        }

        let targetCell = chessDesk.getCell(rowDestination, columnDestination);
        if (targetCell.figure == undefined) return MoveState.can;
        if (targetCell.figure.color === this.color)
            return MoveState.cannot;
        else
            return MoveState.fight;
    }

}
