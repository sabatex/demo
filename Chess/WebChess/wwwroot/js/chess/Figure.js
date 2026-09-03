//import { MoveState } from "./MoveState.js";
import { FigureColor } from "./FigureColor.js"
import { drawPawn, drawRook, drawHorse, drawBishop, drawQueen, drawKing } from "./FiguresIMG.js";


export class FigureType {
    static king = 0;
    static pawn = 1;
    static bishop = 2;
    static horse = 3;
    static rook = 4;
    static queen = 5;
}

export class Figure {
    constructor(color, figureType, canMoves) {
        this.color = color;
        this.figureType = figureType;
        this.canMoves = canMoves;
    }
    drawFigure(cellElement) {

        switch (this.figureType) {
            case FigureType.pawn: return drawPawn(cellElement, this.color);
            case FigureType.rook: return drawRook(cellElement, this.color);
            case FigureType.horse: return drawHorse(cellElement, this.color);
            case FigureType.bishop: return drawBishop(cellElement, this.color);
            case FigureType.queen: return drawQueen(cellElement, this.color);
            case FigureType.king: return drawKing(cellElement, this.color);
            default: return undefined;
        }
    }
}


