# CodyMaze bot

A Telegram bot that challenges you in an “Hour of Code”-style game, with coding-based challenges that must be solved by physically moving on a full-scale chessboard.

![CodyMaze cover](/docs/codymaze-cover.jpg?raw=true)

This version of the CodyMaze bot is a porting to C#/.NET of the [original bot](https://github.com/CodeMOOC/CodyMazeBot), re-architected to work within a Docker container.

## Introduction

In the context of the recent push for modern educational tools for teachers, which aim at bringing so-called “computational thinking” to the classroom and thus encourage young children to acquire basic logical and coding skills, several different programming-based games have been developed and proposed (for instance, the web-based [Hour of Code challenge](https://hourofcode.com) on Code.org).

The University of Urbino has developed several tools based on messaging bots, to deliver portable, affordable, and easy to use games to teach coding in larger classrooms.
The first of these initiatives is “[Code Hunting Games](http://codehunting.games)”, that allows users to create coding-based treasure hunts.

## The game

CodyMaze is a simple and portable “public square” game: it can be easily reproduced (using 9 sheets of paper and/or other objects) and installed in any larger open space, including classrooms or playgrounds.
The players are guided through a dynamically generated maze: the bot will send out instructions (in the form of code snippets) that the players must follow in order to reach their destination (thus executing the code).
If players successfully reach their destination and complete the maze, they will receive a completion certificate.

### The chessboard

The CodyMaze chessboard is a 5×5 grid, rows are numbered from&nbsp;1 to&nbsp;5, columns from&nbsp;A to&nbsp;D.
The chessboard is oriented, so that players can identify 4&nbsp;cardinal directions as shown in the following figure.

![CodyMaze chessboard](/docs/figure-chessboard.jpg?raw=true)

Each chessboard square is identified with a special QR&nbsp;Code, which allows the Telegram bot to determine in which square the player is currently located.
[QR&nbsp;Codes must be downloaded and printed](http://codemooc.org/wp-content/uploads/2017/09/CodyMaze-QRCodes.zip) on paper sheets.
The codes must be arranged as shown in the figure above.
To ensure that QR&nbsp;Codes do not move, they can be attached to carboard boxes, tin cans, or other objects.
The chessboard can optionally be drawn in chalk or using tape.

Some of the squares are marked by a “star icon”.&nbsp;⭐
Instructions of the CodyMaze bot, in the later part of the game, will include conditional operators that depend on whether a “star” is on the square currently occupied by the player or not.

### Player requirements

Each player will have to satisfy the following requirements in order to play:

* A smartphone with a camera and a Telegram client (registration to the messenger service is free),
* Mobile data connection or Wi-Fi,
* A QR&nbsp;Code scanner app (built in the native camera application on many popular mobile operating systems).

### How to play?

In order to start the game, you must move to one of the chessboard’s outer squares (that is, any square on the first or last row, or on the first or last column).
Scan in the QR&nbsp;Code you find there and follow the instructions provided by the bot.

At each step, the bot will **ask for your orientation** (in terms of the cardinal directions as indicated in the figure above) and will then provide you with an **instruction** to follow.
The command is composed of basic instructions such as `f` for “move one step forward”, `l` for “turn left”, and `r` for “turn right”.
Other, more complex, instructions such as `while`, `if`, and `else` will be used as the game progresses.
Instructions blocks (indicated by braces `{}`) can be repeated: for instance, `2{fr}` is equivalent to `frfr` and means that you will have to move forward and turn right twice.

After executing the instructions given by the bot and arriving on a new square (which in some cases can be the same square from which you started), you must **scan the square’s QR&nbsp;Code**.
The bot will confirm that you have reached the correct destination.
If—at any point—you fail to correctly follow the instructions, the bot will tell you so and will let you move back to a previous position.

The game is over after **13** correctly executed instructions.

## Source code and contributions

The Telegram bot is implemented in C# and makes use of a Cloud Firestore database.
The source is available under the *MIT license*. Pull requests welcome!&nbsp;🙏

### Thanks and acknowledgments

* Alessandro Bogliolo
* Brendan Paolini
* Lorenz Cuno Klopfenstein
* Saverio Delpriori
* Caba Veres
