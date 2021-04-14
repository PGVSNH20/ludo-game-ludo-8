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
Compares positions (X and Y coordinates)

* public bool Compare(Position position)

## Setup
Sets up all the pieces on the board

* public static Piece[] Pieces(Colors color)

Changes the console foreground color to the player color so you know which turn it is

* public static void StringColor(Colors playerColor)

## Program
Adds players, creates a new board and saves the changes to the database

* public static void StartGame()

Resumes the last game played

* public static void ResumeGame()

Loads a saved game from the database

* public static void LoadGame()

Renders the board and connects all other classes, handles user errors, keeps track of turns and other game logic 

* public static void RenderGame(Board game)

Prints the main menu

* public static string PrintMenu()

Lets you check the history for a specific game that has been saved in the database, you can see everything that happened in the game in a textlog and also how the board looked when the game ended and the remaining pieces coordinates and placement on the board

* public static void GameHistory()

#### Documentation for Ludolicious by Broman & Bjornsson 2021 ©
