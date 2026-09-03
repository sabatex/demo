import { Figure } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";

export class King extends Figure {
    constructor(color) {
        super(color);
        this.figureOrder = 0;
    }
    showFigure(cellElement) {
        let draw = this.getDraw(cellElement);
        if (this.color == FigureColor.black) {
            draw.style = ('fill:none; fill-opacity:1; fill-rule:evenodd; stroke:#000000; stroke-width:1.5; stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            let p = draw.path("M 22.5,11.63 L 22.5,6");
            p.style("fill:none; stroke:#000000; stroke-linejoin:miter;");
            p = draw.path("M 22.5,25 C 22.5,25 27,17.5 25.5,14.5 C 25.5,14.5 24.5,12 22.5,12 C 20.5,12 19.5,14.5 19.5,14.5 C 18,17.5 22.5,25 22.5,25");
            p.style("fill:#000000;fill-opacity:1; stroke-linecap:butt; stroke-linejoin:miter;");
            p = draw.path("M 11.5,37 C 17,40.5 27,40.5 32.5,37 L 32.5,30 C 32.5,30 41.5,25.5 38.5,19.5 C 34.5,13 25,16 22.5,23.5 L 22.5,27 L 22.5,23.5 C 19,16 9.5,13 6.5,19.5 C 3.5,25.5 11.5,29.5 11.5,29.5 L 11.5,37 z ");
            p.style("fill:#000000; stroke:#000000;");
            p = draw.path("M 20,8 L 25,8");
            p.style("fill:none; stroke:#000000; stroke-linejoin:miter;");
            p = draw.path("M 32,29.5 C 32,29.5 40.5,25.5 38.03,19.85 C 34.15,14 25,18 22.5,24.5 L 22.51,26.6 L 22.5,24.5 C 20,18 9.906,14 6.997,19.85 C 4.5,25.5 11.85,28.85 11.85,28.85");
            p.style("fill:none; stroke:#ffffff;");
            p = draw.path("M 11.5,30 C 17,27 27,27 32.5,30 M 11.5,33.5 C 17,30.5 27,30.5 32.5,33.5 M 11.5,37 C 17,34 27,34 32.5,37");
            p.style("fill:none; stroke:#ffffff;");
        } else {
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
