# Ludo8 Methods

## Board
For printing the gameboard

* public void PrintLudoBoard()
* 
To move a piece

* public void MovePiece(Move move)

To check if a game has ended 

* public bool Ended(Player player)

## Dice
For rolling the dice and returning a random value between 1 and 6.

* public static int Roll() 

## Move

## Piece
To check if a piece can make a legal move

* public bool AbleToMakeMove()

To move out a piece from the nest

* public void MoveOut()

Compares current position of a piece with all other opponents pieces, if they're on the same spot a push is made on the opponents piece 

* public bool PushOpponent(List<Player> players)

 Tracks the movement of a piece and shows which direction the piece should move on the board

* public void TrackMovement()

## Player
Sets the player name, color and if its an AI or a real player 

* public Player(string name, Colors color, bool aiplayer)

Simulates the AIs thinking time

* public void Thinking()

## Position

## Setup

## LudoDbContext : DbContext

## Program


#### Documentation for Ludolicious by Broman & Bjornsson 2021 ©
