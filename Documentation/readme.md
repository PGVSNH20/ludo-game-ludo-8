# Documentation
Documentation for Ludolicious by Broman & Bjornsson 2021 ©

## User stories

### [Added 2021-03-30]
* As a user I want to choose the amount (2-4) of players.
* As a user I want to choose a color (Red, Green, Blue or Yellow)
* As a user I want to choose my name in the game so that friends recognize me.
* As a user I want to see a record board after the game is done.
* As a user I want to pick up a game where it ended after exiting the console.
* As a user i want to see whose turn it is and where i am on the board when starting again.



## Classes

### Player
* PlayerID
* Name
* Wins
* Losses

### Piece
* PieceID
* Name (color)
* StartingPosition
*

### Dice
* Value

### Board
* NestID
* MainTrack
* FinalTrack
*

### Move
* MoveID
* Forward
* PlayerID
* Position
* DiceValue


## Methods
* RollDice() for rolling the dice and returning a random value between 1 and 6.
* Forward() for moving forward with a piece after calling for the value returned from rolling the dice
* Occupied() for checking if the position on the board is occupied
* FalconPunch() for punching the opponents piece of the board if landing on an occupied spot
