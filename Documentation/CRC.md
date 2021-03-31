## PROGRAM
#### RESPONSIBILITIES
* Responsible for gluing all classes together to a working game
* Responsible for menu
#### COLLABORATORS
* All other classes

## BOARD
#### RESPONSIBILITIES
* Knows how many players there are in the game
* Knows how many moves a player has taken
* Knows when to move pieces after dice is rolled
#### COLLABORATORS
* Player
* Piece
* Move
* Dice

## DICE
#### RESPONSIBILITIES
* Knows how many steps a piece can move by randomizing a number between 1-6
#### COLLABORATORS
* Move
* Piece

## PLAYER
#### RESPONSIBILITIES
* Know player ID
* Know name of player
* Know win/loss stats of player
#### COLLABORATORS
* Piece
* Move

## MOVE
#### RESPONSIBILITIES
* Knows how to react when the value of the dice is returned
* Knows which player to move
#### COLLABORATORS
* Dice
* Board
* Piece


## PIECE
#### RESPONSIBILITIES
* Knows the connection between pieces and players
* knows what piece is moved
#### COLLABORATORS
* Move
* Player
* Board
