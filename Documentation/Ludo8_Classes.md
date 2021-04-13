# Documentation for a Ludo game by group 8 (Marcus Broman and Frej Björnsson) 

## GameEngine
### Board
        public int ID { get; set; }
        public List<Move> Moves { get; set; }
        [NotMapped]
        public List<Player> Players { get; set; }
        public DateTime GameStarted { get; set; }
        public DateTime? GameEnded { get; set; }

### Dice
       public static int Value { get; set; }

### Move
        [NotMapped]
        public Player Player { get; set; }
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int PieceID { get; set; }
        public int DiceValue { get; set; }
        public int BoardID { get; set; }

###  Piece
        public int ID { get; set; }
        public Colors Color { get; set; }
        public int Moves { get; set; } = 0;
        public Position CurrentPosition { get; set; }
        public Position StartPosition { get; set; }
        public Position SixthPosition { get; set; }
        public Position NestPosition { get; set; }
        public Position EnterFinalTrackPosition { get; set; }
        public Position EndPosition = new Position(5, 5);
        public int MoveDirectionX { get; set; } = 0;
        public int MoveDirectionY { get; set; } = 0;

### Player
        public int ID { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }
        [NotMapped]
        public Piece[] Pieces { get; set; }
        public int BoardID { get; set; }
        public bool AI { get; set; }
        
### Position
        public int X { get; set; }
        public int Y { get; set; }
### Setup
        public static Piece[] Pieces(Colors color)
        
### Event
        public string Message { get; set; }
        public Colors Color { get; set; }

## LudoGame
### LudoDbContext : DbContext
        public DbSet<Board> Board { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Move> Move { get; set; }
        

        
### Program





#### Documentation for Ludolicious by Broman & Bjornsson 2021 ©

