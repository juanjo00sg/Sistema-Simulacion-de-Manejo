class Car {
  constructor() {
    this.r1 = 100;
    this.r2 = 50;
    this.x = width / 4;
    this.y = height/4;
    this.vx = 5;
    this.vy = 5;
  }

  hits(cone) {
    let x1 = this.x + this.r1 * 0.5;
    let y1 = this.y + this.r2 * 0.5;
    let x2 = cone.x + cone.r * 0.5;
    let y2 = cone.y + cone.r * 0.5;
    return collideCircleCircle(x1, y1, this.r2, x2, y2, cone.r);
  }


  move(keyValue) {
    switch (keyValue) {
      case 1:
        this.x += -1 * this.vx;
        break;
      case 2:
        this.x += this.vx;
        break;
      case 3:
        this.y += (-1*this.vx);
        break;
      case 4:
        this.y += this.vx;
        break;
      default:
        break;
    }
    this.y=constrain(this.y,50,300)
    this.x=constrain(this.x,100,500)
  }

  show() {
    image(carImg, this.x, this.y, this.r1, this.r2);
    //fill(255, 50);
    //rect(CORNER);
    //rect(this.x, this.y, this.r1, this.r2);
  }
}
