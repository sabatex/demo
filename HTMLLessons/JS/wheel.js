       
       // simple object 
       prompt("shdshfsjfds",);
       confirm("Ви згодні?");
       let simpleObject = {};
       let simpleNewObject = new Object();

       let wheel = {
           radius:5,
           get diameter() {return this.radius*2},
           set diameter(value) {this.radius = value/2}
       }
       function Wheel1(radius){
           var variable = 10;
           this.radius=radius;
           Object.defineProperty(this,"diameter",{
               get(){
                   return this.radius*2;
               },
               set(value){
                   this.radius = value/2;   
               }
           });
           function calcLenght(){
               return Math.PI * this.radius;
           }

       }


      wheel = new Wheel1(10);
      //let s = wheel.calcLenght(); 