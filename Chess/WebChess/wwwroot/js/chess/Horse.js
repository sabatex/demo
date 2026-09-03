import { Figure } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";

export class Horse extends Figure {
    constructor(color) {
        super(color);
        this.figureOrder = 3;
    }
    showFigure1(cellElement, fillColor) {
        cellElement.innerHTML = '';
        let altFillColor = '#FFFFFF';
        if (fillColor == undefined) {
            if (this.color == FigureColor.black) {
                fillColor = '#000000';
                altFillColor = '#FFFFFF';
            } else {
                fillColor = '#FFFFFF';
                altFillColor = '#000000';
            }

        }

        let canvas = document.createElement("canvas");
        cellElement.appendChild(canvas);
        let ctx = canvas.getContext("2d");
        ctx.beginPath();
        ctx.moveTo(0, 0);
        ctx.lineTo(50, 50);
        ctx.lineTo(50, 0);
        ctx.moveTo(0, 0)
        ctx.stroke();
        //ctx.fill();


        let path = new Path2D('M 22,10 C 32.5,11 38.5,18 38,39 L 15,39 C 15,30 25,32.5 23,18');
        ctx.fillStyle = fillColor;
        ctx.strokeStyle = '#000000';
        ctx.stroke(path);
        ctx.fill(path);

        path = new Path2D('M 24,18 C 24.38,20.91 18.45,25.37 16,27 C 13,29 13.18,31.34 11,31 C 9.958,30.06 12.41,27.96 11,28 C 10,28 11.19,29.23 10,30 C 9,30 5.997,31 6,26 C 6,24 12,14 12,14 C 12,14 13.89,12.1 14,10.5 C 13.27,9.506 13.5,8.5 13.5,7.5 C 14.5,6.5 16.5,10 16.5,10 L 18.5,10 C 18.5,10 19.28,8.008 21,7 C 22,7 22,10 22,10');
        ctx.stroke(path);
        ctx.fill(path);

        path = new Path2D('M 15 15.5 A 0.5 1.5 0 1 1  14,15.5 A 0.5 1.5 0 1 1  15 15.5 z');
        ctx.fillStyle = altFillColor;
        ctx.strokeStyle = altFillColor;
        //ctx.transform(0.866, 0.5, -0.5, 0.866, 9.693, -5.173);
        ctx.stroke(path);
        ctx.fill(path);


        path = new Path2D('M 24.55,10.4 L 24.1,11.85 L 24.6,12 C 27.75,13 30.25,14.49 32.5,18.75 C 34.75,23.01 35.75,29.06 35.25,39 L 35.2,39.5 L 37.45,39.5 L 37.5,39 C 38,28.94 36.62,22.15 34.25,17.66 C 31.88,13.17 28.46,11.02 25.06,10.5 L 24.55,10.4 z');
        ctx.fillStyle = fillColor;
        ctx.strokeStyle = altFillColor;
        ctx.stroke(path);
        ctx.fill(path);

    }


    showFigure(cellElement) {
        let draw = this.getDraw(cellElement);

        if (this.color == FigureColor.black) {
            let p = draw.path('M 22,10 C 32.5,11 38.5,18 38,39 L 15,39 C 15,30 25,32.5 23,18');
            p.style('fill:#000000; stroke:#000000;');
            p = draw.path('M 24,18 C 24.38,20.91 18.45,25.37 16,27 C 13,29 13.18,31.34 11,31 C 9.958,30.06 12.41,27.96 11,28 C 10,28 11.19,29.23 10,30 C 9,30 5.997,31 6,26 C 6,24 12,14 12,14 C 12,14 13.89,12.1 14,10.5 C 13.27,9.506 13.5,8.5 13.5,7.5 C 14.5,6.5 16.5,10 16.5,10 L 18.5,10 C 18.5,10 19.28,8.008 21,7 C 22,7 22,10 22,10');
            p.style('fill:#000000; stroke:#000000;');
            p = draw.path('M 9.5 25.5 A 0.5 0.5 0 1 1 8.5,25.5 A 0.5 0.5 0 1 1 9.5 25.5 z');
            p.style('fill:#ffffff; stroke:#ffffff;');
            p = draw.path('M 15 15.5 A 0.5 1.5 0 1 1  14,15.5 A 0.5 1.5 0 1 1  15 15.5 z');
            p.transform('matrix(0.866,0.5,-0.5,0.866,9.693,-5.173)');
            p.style('fill:#ffffff; stroke:#ffffff;');
            p = draw.path('M 24.55,10.4 L 24.1,11.85 L 24.6,12 C 27.75,13 30.25,14.49 32.5,18.75 C 34.75,23.01 35.75,29.06 35.25,39 L 35.2,39.5 L 37.45,39.5 L 37.5,39 C 38,28.94 36.62,22.15 34.25,17.66 C 31.88,13.17 28.46,11.02 25.06,10.5 L 24.55,10.4 z');
            p.style('fill:#ffffff; stroke:none;');
        } else {
            draw.path('M 22,10 C 32.5,11 38.5,18 38,39 L 15,39 C 15,30 25,32.5 23,18').style('fill:#ffffff; stroke:#000000;');
            draw.path('M 24,18 C 24.38,20.91 18.45,25.37 16,27 C 13,29 13.18,31.34 11,31 C 9.958,30.06 12.41,27.96 11,28 C 10,28 11.19,29.23 10,30 C 9,30 5.997,31 6,26 C 6,24 12,14 12,14 C 12,14 13.89,12.1 14,10.5 C 13.27,9.506 13.5,8.5 13.5,7.5 C 14.5,6.5 16.5,10 16.5,10 L 18.5,10 C 18.5,10 19.28,8.008 21,7 C 22,7 22,10 22,10').style('fill:#ffffff; stroke:#000000;');
            draw.path('M 9.5 25.5 A 0.5 0.5 0 1 1 8.5,25.5 A 0.5 0.5 0 1 1 9.5 25.5 z').style('fill:#000000; stroke:#000000;');
            let p = draw.path('M 15 15.5 A 0.5 1.5 0 1 1  14,15.5 A 0.5 1.5 0 1 1  15 15.5 z');
            p.transform('matrix(0.866,0.5,-0.5,0.866,9.693,-5.173)');
            p.style('fill:#000000; stroke:#000000;');
        }
    }
    checkMove(rowPos, columnPos, rowDestination, columnDestination, color = globalThis.playerDesk.chessDesk.currentPlayer) {
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;

        let a = Math.abs(rowDestination - rowPos);
        let b = Math.abs(Math.abs(columnDestination - columnPos));
        if ((a === 1 && b === 2) || (a === 2 && b === 1)) {
            if (Math.abs(a - b) !== 1) return MoveState.cannot;

            let targetCell = chessDesk.getCell(rowDestination, columnDestination);
            if (targetCell.figure == undefined) return MoveState.can;
            if (targetCell.figure.color === this.color)
                return MoveState.cannot;
            else
                return MoveState.fight;

        } else return MoveState.cannot;
    }


}
