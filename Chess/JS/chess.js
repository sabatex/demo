class FigureColor{
    static black=1;
    static white=0;
}

class MoveState{
    static can = 0;
    static cannot = 1;
    static fight = 2;
}

class Defines{
    static chessCellCanMove = "chessCellCanMove";
    static cellSelected ="cellSelected";
    static chessCellDestinationMark = "chessCellDestinationMark";
    static figureMustFight = "canBeat";
}




class Figure{
    constructor(color){
        this.color = color;
    }
    showFigure(cellElement){
        return 0;
    }
    checkMove(rowPos,columnPos,rowDestination,columnDestination,board){
        return MoveState.cannot;
    }
    get direction(){return this.color*2-1;}
    getDraw(cellElement){
        let draw = SVG(cellElement);
        this.figureId = draw.node.id;
        return draw;    
    }

}

class Bishop extends Figure{
    constructor(color){
        super(color);
        this.figureOrder = 2;
    }
    showFigure(cellElement){
        let draw = this.getDraw(cellElement);
        draw.path('M 9,36 C 12.39,35.03 19.11,36.43 22.5,34 C 25.89,36.43 32.61,35.03 36,36 C 36,36 37.65,36.54 39,38 C 38.32,38.97 37.35,38.99 36,38.5 C 32.61,37.53 25.89,38.96 22.5,37.5 C 19.11,38.96 12.39,37.53 9,38.5 C 7.646,38.99 6.677,38.97 6,38 C 7.354,36.06 9,36 9,36 z');
        draw.path('M 15,32 C 17.5,34.5 27.5,34.5 30,32 C 30.5,30.5 30,30 30,30 C 30,27.5 27.5,26 27.5,26 C 33,24.5 33.5,14.5 22.5,10.5 C 11.5,14.5 12,24.5 17.5,26 C 17.5,26 15,27.5 15,30 C 15,30 14.5,30.5 15,32 z');
        draw.path('M 25 8 A 2.5 2.5 0 1 1  20,8 A 2.5 2.5 0 1 1  25 8 z');
        let p = draw.path('M 17.5,26 L 27.5,26 M 15,30 L 30,30 M 22.5,15.5 L 22.5,20.5 M 20,18 L 25,18');

        if (this.color == FigureColor.black){
            draw.style('opacity:1; fill:#000000; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            p.style('fill:none; stroke:#ffffff; stroke-linejoin:miter;');
        } else{
            draw.style('opacity:1; fill:#ffffff; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            p.style('fill:none; stroke:#000000; stroke-linejoin:miter;');
        }
    } 
    checkMove(rowPos,columnPos,rowDestination,columnDestination,color=globalThis.playerDesk.chessDesk.currentPlayer){
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos === rowDestination && columnPos === columnDestination) return MoveState.cannot;
        
        if (Math.abs(rowPos - rowDestination) !== Math.abs(columnPos-columnDestination)) return MoveState.cannot;

        let idxRow = Math.sign(rowDestination - rowPos);
        let idxColumn = Math.sign(columnDestination - columnPos);
 
        for (let i=rowPos+idxRow,j=columnPos+idxColumn;i!=rowDestination && j !=columnDestination;i+=idxRow,j+=idxColumn){
            let roadCell = chessDesk.getCell(i,j); 
            if (roadCell.figure != undefined) return MoveState.cannot;   
        }
        let targetCell = chessDesk.getCell(rowDestination,columnDestination);
        if (targetCell.figure == undefined) return MoveState.can;
        if (targetCell.figure.color === this.color)
            return MoveState.cannot;
        else
            return MoveState.fight;
    }   
}
class Horse extends Figure {
    constructor(color){
        super(color);
        this.figureOrder = 3;
    }
    showFigure(cellElement){
        let draw = this.getDraw(cellElement);

        if (this.color == FigureColor.black){
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
        } else{
            draw.path('M 22,10 C 32.5,11 38.5,18 38,39 L 15,39 C 15,30 25,32.5 23,18').style('fill:#ffffff; stroke:#000000;');
            draw.path('M 24,18 C 24.38,20.91 18.45,25.37 16,27 C 13,29 13.18,31.34 11,31 C 9.958,30.06 12.41,27.96 11,28 C 10,28 11.19,29.23 10,30 C 9,30 5.997,31 6,26 C 6,24 12,14 12,14 C 12,14 13.89,12.1 14,10.5 C 13.27,9.506 13.5,8.5 13.5,7.5 C 14.5,6.5 16.5,10 16.5,10 L 18.5,10 C 18.5,10 19.28,8.008 21,7 C 22,7 22,10 22,10').style('fill:#ffffff; stroke:#000000;');
            draw.path('M 9.5 25.5 A 0.5 0.5 0 1 1 8.5,25.5 A 0.5 0.5 0 1 1 9.5 25.5 z').style('fill:#000000; stroke:#000000;');
            let p = draw.path('M 15 15.5 A 0.5 1.5 0 1 1  14,15.5 A 0.5 1.5 0 1 1  15 15.5 z');
            p.transform('matrix(0.866,0.5,-0.5,0.866,9.693,-5.173)');
            p.style('fill:#000000; stroke:#000000;');
        }
    } 
    checkMove(rowPos,columnPos,rowDestination,columnDestination,color=globalThis.playerDesk.chessDesk.currentPlayer){
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;
        
        let a = Math.abs(rowDestination-rowPos);
        let b = Math.abs(Math.abs(columnDestination-columnPos));
        if ((a===1 && b===2 ) || (a===2 && b===1)){
            if (Math.abs(a-b) !== 1) return MoveState.cannot;
            
            let targetCell = chessDesk.getCell(rowDestination,columnDestination);
            if (targetCell.figure == undefined) return MoveState.can;
            if (targetCell.figure.color === this.color)
                return MoveState.cannot;
            else
                return MoveState.fight;
    
        }else return MoveState.cannot;
    }      


}
class King extends Figure{
    constructor(color){
        super(color);
        this.figureOrder = 0;
    }
    showFigure(cellElement){
        let draw = this.getDraw(cellElement);
        if (this.color == FigureColor.black){
            draw.style=('fill:none; fill-opacity:1; fill-rule:evenodd; stroke:#000000; stroke-width:1.5; stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            let p = draw.path("M 22.5,11.63 L 22.5,6");
            p.style("fill:none; stroke:#000000; stroke-linejoin:miter;");
            p = draw.path("M 22.5,25 C 22.5,25 27,17.5 25.5,14.5 C 25.5,14.5 24.5,12 22.5,12 C 20.5,12 19.5,14.5 19.5,14.5 C 18,17.5 22.5,25 22.5,25" );
            p.style("fill:#000000;fill-opacity:1; stroke-linecap:butt; stroke-linejoin:miter;");
            p = draw.path("M 11.5,37 C 17,40.5 27,40.5 32.5,37 L 32.5,30 C 32.5,30 41.5,25.5 38.5,19.5 C 34.5,13 25,16 22.5,23.5 L 22.5,27 L 22.5,23.5 C 19,16 9.5,13 6.5,19.5 C 3.5,25.5 11.5,29.5 11.5,29.5 L 11.5,37 z ");
            p.style("fill:#000000; stroke:#000000;");
            p = draw.path("M 20,8 L 25,8");
            p.style("fill:none; stroke:#000000; stroke-linejoin:miter;");
            p = draw.path("M 32,29.5 C 32,29.5 40.5,25.5 38.03,19.85 C 34.15,14 25,18 22.5,24.5 L 22.51,26.6 L 22.5,24.5 C 20,18 9.906,14 6.997,19.85 C 4.5,25.5 11.85,28.85 11.85,28.85");
            p.style("fill:none; stroke:#ffffff;");
            p = draw.path("M 11.5,30 C 17,27 27,27 32.5,30 M 11.5,33.5 C 17,30.5 27,30.5 32.5,33.5 M 11.5,37 C 17,34 27,34 32.5,37");
            p.style("fill:none; stroke:#ffffff;");
        } else{
            let p = draw.path('M 22.5,11.63 L 22.5,6');
            p.style('fill:none; stroke:#000000; stroke-linejoin:miter;');
            p = draw.path('M 20,8 L 25,8');
            p.style('fill:none; stroke:#000000; stroke-linejoin:miter;');
            p = draw.path('M 22.5,25 C 22.5,25 27,17.5 25.5,14.5 C 25.5,14.5 24.5,12 22.5,12 C 20.5,12 19.5,14.5 19.5,14.5 C 18,17.5 22.5,25 22.5,25');
            p.style('fill:#ffffff; stroke:#000000; stroke-linecap:butt; stroke-linejoin:miter;');
            p = draw.path('M 11.5,37 C 17,40.5 27,40.5 32.5,37 L 32.5,30 C 32.5,30 41.5,25.5 38.5,19.5 C 34.5,13 25,16 22.5,23.5 L 22.5,27 L 22.5,23.5 C 19,16 9.5,13 6.5,19.5 C 3.5,25.5 11.5,29.5 11.5,29.5 L 11.5,37 z ');
            p.style("fill:#ffffff; stroke:#000000;");
            p = draw.path("M 11.5,30 C 17,27 27,27 32.5,30");
            p.style("fill:none; stroke:#000000;");
            p = draw.path("M 11.5,33.5 C 17,30.5 27,30.5 32.5,33.5");
            p.style("fill:none; stroke:#000000;");
            p = draw.path("M 11.5,37 C 17,34 27,34 32.5,37");
            p.style("fill:none; stroke:#000000;");
  
        }
    }    

}
class Pawn extends Figure {
    constructor(color){
        super(color);
        this._firstMove = true;
        this.figureOrder = 1;
    }
    showFigure(cellElement){
        if (globalThis.playerDesk != undefined) this._firstMove = false;
        let draw = this.getDraw(cellElement);
        draw.path('M 22,9 C 19.79,9 18,10.79 18,13 C 18,13.89 18.29,14.71 18.78,15.38 C 16.83,16.5 15.5,18.59 15.5,21 C 15.5,23.03 16.44,24.84 17.91,26.03 C 14.91,27.09 10.5,31.58 10.5,39.5 L 33.5,39.5 C 33.5,31.58 29.09,27.09 26.09,26.03 C 27.56,24.84 28.5,23.03 28.5,21 C 28.5,18.59 27.17,16.5 25.22,15.38 C 25.71,14.71 26,13.89 26,13 C 26,10.79 24.21,9 22,9 z');
        if (this.color == FigureColor.black){
            draw.style('opacity:1; fill:#000000; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
        } else{
            draw.style('opacity:1; fill:#ffffff; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
        }
    }
    checkMove(rowPos,columnPos,rowDestination,columnDestination,color=globalThis.playerDesk.chessDesk.currentPlayer){
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;


        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;
        // index for direction
        let idx = this.direction;
        let targetCell = chessDesk.getCell(rowDestination,columnDestination);
        if (rowDestination == rowPos + idx){
            // try fight
            if (columnDestination == columnPos+1 || columnDestination == columnPos-1){
                if (targetCell.figure != undefined){
                    if (targetCell.figure.color != this.color){
                        return MoveState.fight;
                    }
                }
                return MoveState.cannot;
            }
            if (columnPos==columnDestination){
                if (targetCell.figure == undefined){
                    return MoveState.can;
                }
            }
            return MoveState.cannot;
        }

        if (rowDestination == rowPos +idx + idx && columnDestination == columnPos && this._firstMove){
            if (targetCell.figure == undefined){
                let roadCell = chessDesk.getCell(rowPos+idx,columnPos);
                if (roadCell.figure == undefined){
                    return MoveState.can;
                }    
            }
        }
        return MoveState.cannot; 
    }
 


}

class Queen extends Figure {
    constructor(color){
        super(color);
        this.figureOrder = 5;
    }
    showFigure(cellElement){
        let draw = this.getDraw(cellElement);
        if (this.color == FigureColor.black){
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
            p.style=("fill:none; stroke:#ffffff;");
            p = draw.path("M 10.5,37.5 A 35,35 1 0 0 34.5,37.5");
            p.style("fill:none; stroke:#ffffff;");
        } else{
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
    checkMove(rowPos,columnPos,rowDestination,columnDestination,color=globalThis.playerDesk.chessDesk.currentPlayer){
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;
        
        let bishop = Math.abs(rowPos - rowDestination) === Math.abs(columnPos-columnDestination);
        let rock = !(rowPos !== rowDestination && columnPos !== columnDestination);

        if (bishop==false && rock==false) return MoveState.cannot;

        let idxRow = Math.sign(rowDestination - rowPos);
        let idxColumn = Math.sign(columnDestination - columnPos);
 
        for (let i=rowPos+idxRow,j=columnPos+idxColumn;i!=rowDestination || j !=columnDestination;i+=idxRow,j+=idxColumn){
            let roadCell = chessDesk.getCell(i,j); 
            if (roadCell.figure != undefined) return MoveState.cannot;   
        }

        let targetCell = chessDesk.getCell(rowDestination,columnDestination);
        if (targetCell.figure == undefined) return MoveState.can;
        if (targetCell.figure.color === this.color)
            return MoveState.cannot;
        else
            return MoveState.fight;
    }

}

class Rook extends Figure {
    constructor(color){
        super(color);
        this.figureOrder = 4;
    }
    showFigure(cellElement){
        let draw = this.getDraw(cellElement);
        if (this.color == FigureColor.black){
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
        } else{
            draw.style('opacity:1; fill:#ffffff; fill-opacity:1; fill-rule:evenodd; stroke:#000000; stroke-width:1.5; stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            let p = draw.path("M 9,39 L 36,39 L 36,36 L 9,36 L 9,39 z ");
            p.style=("stroke-linecap:butt;");
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
    checkMove(rowPos,columnPos,rowDestination,columnDestination,color=globalThis.playerDesk.chessDesk.currentPlayer){
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos == rowDestination && columnPos == columnDestination) return MoveState.cannot;
        if (rowPos !== rowDestination && columnPos !== columnDestination) return MoveState.cannot;
       
        
        if (rowPos === rowDestination){
            // move to column
            let idx =  Math.sign(columnDestination - columnPos);

            for (let i = columnPos+idx;i!=columnDestination;i+=idx){
                let roadCell = chessDesk.getCell(rowPos,i); 
                if (roadCell.figure != undefined) return MoveState.cannot;   
            }
        }else{
            let idx =  Math.sign(rowDestination - rowPos);
            for (let i = rowPos+idx;i!=rowDestination;i+=idx){
                let roadCell = chessDesk.getCell(i,columnPos); 
                if (roadCell.figure != undefined) return MoveState.cannot;   
            }
        }
        let targetCell = chessDesk.getCell(rowDestination,columnDestination);
        if (targetCell.figure == undefined) return MoveState.can;
        if (targetCell.figure.color === this.color)
            return MoveState.cannot;
        else
            return MoveState.fight;
    }
   
}

class ChessCell{
    constructor(row,column,figure,parrent){
        this._canBeat = false;
        this.parrent = parent;
        this.row = row;
        this.column = column;
        //this.figure = figure;
        let div = document.createElement("div");
        div.classList.add("chessCell");
        if ((row+column) % 2) div.classList.add("blackCell");
        div.id = this.getID();
        div.onclick = chessDeskCellClick;
        parrent.appendChild(div);
        this.figure = figure;
        this.canMoves = [];
    }
    // chess figure
    get figure(){return this._figure}
    set figure(value){
        let cellElement = this.cellElement;
        cellElement.innerHTML = "";
        this._figure = value;
        if (value != undefined)
            this._figure.showFigure(cellElement);
    }

    get canBeat(){return this._canBeat}
    set canBeat(value){
        this._canBeat = value;
        let draw = document.getElementById(this.figure.figureId);
        if (value)
            draw.classList.add(Defines.figureMustFight);
        else
            draw.classList.remove(Defines.figureMustFight);

    }

    getID(){
        return "cell"+this.row + this.column;
    }

    getCellElement(){
        return document.getElementById(this.getID());
    }
    
    // HTML tag elrment
    get cellElement(){
        return document.getElementById(this.getID());        
    }


    setFigure(figure){
        this.figure = figure;
        let cellElement = this.getCellElement();     
        if (figure==undefined){
            cellElement.innerHTML = "";
        }else{
            figure.showFigure(cellElement);
        }
    }


}


class CanMoveDestination{
    constructor(cell,moveState){
        this.cell = cell;
        this.moveState = moveState;
    }
}

class ChessDesk{
    constructor(deskElement){
        this.desk=[];
        this.selectedItem = undefined;
        let symbolsNumber = ['','a','b','c','d','e','f','g','h',''];
        for (let i in symbolsNumber){
            this.addDivElement(symbolsNumber[i],"gripDeskRow",deskElement)
        }
        this.addDivElement("1","gripDeskColumn",deskElement);
        this.desk.push(new ChessCell(0,0,new Rook(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,1,new Horse(FigureColor.black),deskElement)); 
        this.desk.push(new ChessCell(0,2,new Bishop(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,3,new Queen(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,4,new King(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,5,new Bishop(FigureColor.black),deskElement));
        this.desk.push(new ChessCell(0,6,new Horse(FigureColor.black),deskElement));                             
        this.desk.push(new ChessCell(0,7,new Rook(FigureColor.black),deskElement));
        this.addDivElement("1","gripDeskColumn",deskElement);
        this.addDivElement("2","gripDeskColumn",deskElement);
        for (let i=0;i<8;i++) this.desk.push(new ChessCell(1,i,new Pawn(FigureColor.black),deskElement));
        this.addDivElement("2","gripDeskColumn",deskElement);
        for(let i=2;i<6;i++){
            this.addDivElement(i+1,"gripDeskColumn",deskElement); 
            for (let j=0;j<8;j++) this.desk.push(new ChessCell(i,j,undefined,deskElement));
            this.addDivElement(i+1,"gripDeskColumn",deskElement);           
        }
        this.addDivElement("7","gripDeskColumn",deskElement);
        for (let i=0;i<8;i++) this.desk.push(new ChessCell(6,i,new Pawn(FigureColor.white),deskElement));
        this.addDivElement("7","gripDeskColumn",deskElement);
        this.addDivElement("8","gripDeskColumn",deskElement);
        this.desk.push(new ChessCell(7,0,new Rook(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,1,new Horse(FigureColor.white),deskElement)); 
        this.desk.push(new ChessCell(7,2,new Bishop(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,3,new King(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,4,new Queen(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,5,new Bishop(FigureColor.white),deskElement));
        this.desk.push(new ChessCell(7,6,new Horse(FigureColor.white),deskElement));                                            
        this.desk.push(new ChessCell(7,7,new Rook(FigureColor.white),deskElement));
        this.addDivElement("8","gripDeskColumn",deskElement);
        for (let i in symbolsNumber){
            this.addDivElement(symbolsNumber[i],"gripDeskRow",deskElement)
        }
    }
    canMovePositions = [];


    _currentPlayer = FigureColor.white;
    get currentPlayer(){return this._currentPlayer}
    set currentPlayer(value){
        this._currentPlayer = value;
        this.clearClassInDesk(Defines.chessCellCanMove);
        this.setHoverForCells();
    }

    _selectedCell = undefined;

    clearClassInDesk(className){
        let elements = document.getElementsByClassName(className);
        while (elements.length){
            elements[0].classList.remove(className);    
        }
    }


    clearSelectedCell() {
        this.clearClassInDesk(Defines.cellSelected);
        this.clearClassInDesk(Defines.chessCellDestinationMark);
        this.clearClassInDesk(Defines.figureMustFight);
    }

    setSelectedCell(cellElement){
        cellElement.classList.add(Defines.cellSelected);
        let cm = this.getCellById(cellElement.id).canMoves;
        for (let canMove of cm){
            if (canMove.moveState == MoveState.fight){
                canMove.cell.canBeat = true;
            }
            canMove.cell.cellElement.classList.add(Defines.chessCellDestinationMark);
        }
    }

    clickToSameCell(cellElement){
        this.clearSelectedCell();
    }
    clickToCanMoveCell(cellElement){
        this.clearSelectedCell();
        this.setSelectedCell(cellElement);
    }
    clickToAnOtherCell(cellElement){
        if (!cellElement.classList.contains(Defines.chessCellDestinationMark))
            this.clearSelectedCell();
        else
            this.moveFigure(cellElement);
    }



    // return cell by id
    getCellById(id){
        let row = Number(id[4]);
        let column = Number(id[5]);
        return this.getCell(row,column);
    }
    clearCanMovePositions(){
        let el = document.getElementsByClassName(Defines.chessCellDestinationMark);
        while (el.length){
            el[0].classList.remove(Defines.chessCellDestinationMark);    
        }
    }
    removeFigure(cell){
        cell.figure = undefined;
    }

    
    // move selected figure to destination cell
    moveFigure(cellElement){
        let selectedElement = document.getElementsByClassName(Defines.cellSelected)[0];
        this.clearSelectedCell();
        let cell = this.getCellById(selectedElement.id);
        let targetCell = this.getCellById(cellElement.id);
        if (targetCell.figure != undefined) this.removeFigure(targetCell);
        targetCell.figure = cell.figure;
        cell.figure = undefined;
        if (this.currentPlayer == FigureColor.white)
            this.currentPlayer = FigureColor.black;
        else
            this.currentPlayer = FigureColor.white;

    }

    selectFigure(cellElement){
        // if exist selected figure
        let cell = getCellById(cellElement.id);
        if (cell == this.selectedItem)
        {
            // click to the same figure
            cellElement.classList.remove(Defines.cellSelected);
            this.clearCanMovePositions();    
        }else{
            // click to anathe figure or first figure
            if (this.selectedItem == undefined){
                // first click
                cellElement.classList.add(Defines.cellSelected);
                this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
                for (let cell of this.canMovePositions){
                    cell.getCellElement().classList.add(Defines.canMovePositions);
                }
            }else{

            }
             
            cellElement.classList.remove(Defines.cellSelected);
            cellElement.classList.add(Defines.cellSelected);    
        }
        


        cellElement.classList.add(Defines.cellSelected);
        this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
        for (let cell of this.canMovePositions){
            cell.getCellElement().classList
        }

    }
    addDivElement(html,className,owner){
        let gripDeskCell = document.createElement("div");
        gripDeskCell.innerHTML = html;
        gripDeskCell.classList.add(className);//<div class="gripDeskRow">a</div>
        owner.appendChild(gripDeskCell);    
    }
    getCell(row,column){
        return this.desk[row*8+column];
    }
 
    getMovePositions(cell){
        let result = [];
        if (cell.figure == undefined) return result;
        for (let i=0;i<8;i++){
            for (let j=0;j<8;j++){
                let r = cell.figure.checkMove(cell.row,cell.column,i,j);
                if (r==MoveState.can || r == MoveState.fight){
                    result.push( new CanMoveDestination(this.getCell(i,j),r));
                }
            }
        }
        return result;    
    }
    setHoverForCells(){
        for (let cell of this.desk){
            cell.canMoves = this.getMovePositions(cell);
            if (cell.canMoves.length > 0)
                cell.cellElement.classList.add(Defines.chessCellCanMove);
            else
            cell.cellElement.classList.remove(Defines.chessCellCanMove);
        }
    }

}


class PlayerDesk{
    constructor(deskId){
        let deskElement = document.getElementById(deskId);
        this.chessDesk = new ChessDesk(deskElement);
    }
}


function chessDeskCellClick(event){
    if (this.classList.contains(Defines.cellSelected)) // DOM
         globalThis.playerDesk.chessDesk.clickToSameCell(this);
    else{
         if (this.classList.contains(Defines.chessCellCanMove))
             globalThis.playerDesk.chessDesk.clickToCanMoveCell(this);
         else
             globalThis.playerDesk.chessDesk.clickToAnOtherCell(this);
    }
}

globalThis.playerDesk = new PlayerDesk("chessTable");
globalThis.playerDesk.chessDesk.currentPlayer = FigureColor.white;

