module("Snake.init");

test("When snake is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  equal(position, snake.position, "Position is set");
  equal(speed, snake.speed, "Speed is set");
  equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  ok(snake.pieces,"SnakePieces are created");
  equal(snake.pieces.length, 5,"Five SnakePieces are created");
  ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");
test("When object is Food, should grow", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);
  var size = snake.size;
  snake.consume(new snakeGame.Food());
  var actual = snake.size;
  var expected = size + 1;
  equal(actual, expected);
});

test("When object is SnakePiece, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.SnakePiece());
  ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.Obstacle());
  ok(isDead, "The snake is dead");
});


module("MovingGameObject.init(constructor)");
test("Testing costructor correct init", function () {
    var position = { x: 5, y: 7 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 42,
        direction = 0;

    var movingObject = new snakeGame.MovingGameObject(
        position,
        size,
        fcolor,
        scolor,
        speed,
        direction);

    equal(movingObject.position, position,"Checking position");
    equal(movingObject.size, size, "Checking size");
    equal(movingObject.fcolor, fcolor, "Checking fill-color");
    equal(movingObject.scolor, scolor, "Checking stroke-color");
    equal(movingObject.speed, speed, "Checking speed");
    equal(movingObject.direction, direction, "Checking direction");
});

module("MovingGameObject.move")
test("Move negative X (direction 0)", function () {
    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 0;

    var expectedPosition = { x: position.x - speed, y: position.y };

    var movingObject = new snakeGame.MovingGameObject(
        position,
        size,
        fcolor,
        scolor,
        speed,
        direction);

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

test("Move positive X (direction 2)", function () {
    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 2;

    var expectedPosition = { x: position.x + speed, y: position.y };

    var movingObject = new snakeGame.MovingGameObject(
        position,
        size,
        fcolor,
        scolor,
        speed,
        direction);

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

test("Move negative Y (direction 1)", function () {
    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 1;

    var expectedPosition = { x: position.x, y: position.y - speed};

    var movingObject = new snakeGame.MovingGameObject(
        position,
        size,
        fcolor,
        scolor,
        speed,
        direction);

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

test("Move positive Y (direction 3)", function () {
    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 3;

    var expectedPosition = { x: position.x, y: position.y + speed };

    var movingObject = new snakeGame.MovingGameObject(
        position,
        size,
        fcolor,
        scolor,
        speed,
        direction);

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

test("Move positive Y, speed 10", function () {
    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 10,
        direction = 3;

    var expectedPosition = { x: position.x, y: position.y + speed };

    var movingObject = new snakeGame.MovingGameObject(
        position,
        size,
        fcolor,
        scolor,
        speed,
        direction);

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

module("MovingGameObject.changeDirection");
test("Direction 0 change to 1", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 0;

    var newDirection = 1;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

test("Direction 0 change to 3", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 0;

    var newDirection = 3;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

test("Direction 0 change to 0 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 0;

    var newDirection = 0;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 0 change to 2 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 0;

    var newDirection = 2;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 1 change to 1 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 1;

    var newDirection = 1;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 1 change to 3 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 1;

    var newDirection = 3;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 1 change to 0", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 1;

    var newDirection = 0;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

test("Direction 1 change to 2", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 1;

    var newDirection = 2;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

test("Direction 2 change to 1", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 2;

    var newDirection = 1;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

test("Direction 2 change to 3", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 2;

    var newDirection = 3;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

test("Direction 2 change to 0 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 2;

    var newDirection = 0;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 2 change to 2 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 2;

    var newDirection = 2;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 3 change to 1 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 3;

    var newDirection = 1;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 3 change to 3 (no change)", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 3;

    var newDirection = 3;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, direction);
});

test("Direction 3 change to 0", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 3;

    var newDirection = 0;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

test("Direction 3 change to 2", function () {
    var position = { x: 0, y: 0 }, size = 5, fcolor = "#000000", scolor = "#000000", speed = 10, direction = 3;

    var newDirection = 2;

    var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(newDirection);

    equal(movingObject.direction, newDirection);
});

