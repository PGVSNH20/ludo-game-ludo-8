using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{

    public class Piece
    {
        public int ID { get; set; }
        public Colors Color { get; set; }
        public int Moves { get; set; } = 0;
        public Position CurrentPosition { get; set; }
        public Position StartPosition { get; set; }
        public Position NestPosition { get; set; }
        public Position EnterFinalTrackPosition { get; set; }
        public Position EndPosition = new Position(5,5);
        public int MoveDirectionX { get; set; } = 0;
        public int MoveDirectionY { get; set; } = 0;

        public Piece(int pieceID, Colors color, Position start, Position nest, Position enter)
        {
            ID = pieceID;
            Color = color;
            CurrentPosition = nest;
            StartPosition = start;
            NestPosition = nest;
            EnterFinalTrackPosition = enter;
        }

        public void TrackMovement()
        {
            if (this.CurrentPosition.Compare(this.EndPosition))
            {
                this.MoveDirectionX = 0;
                this.MoveDirectionY = 0;
            }

            if (this.CurrentPosition.Compare(this.EnterFinalTrackPosition))
            {
                if(this.MoveDirectionX == 1)
                {
                    this.MoveDirectionX = 0;
                    this.MoveDirectionY = 1;
                }

                else if (this.MoveDirectionY == -1)
                {
                    this.MoveDirectionX = 1;
                    this.MoveDirectionY = 0;
                }

                else if (this.MoveDirectionX == -1)
                {
                    this.MoveDirectionX = 0;
                    this.MoveDirectionY = -1;
                }

                else if (this.MoveDirectionY == 1)
                {
                    this.MoveDirectionX = -1;
                    this.MoveDirectionY = 0;
                }
            }

            Position changeToRight1 = new Position(0, 4);
            Position changeToRight2 = new Position(6, 4);
            Position changeToRight3 = new Position(4, 0);

            if (this.CurrentPosition.Compare(changeToRight1) || this.CurrentPosition.Compare(changeToRight2) || this.CurrentPosition.Compare(changeToRight3))
            {
                this.MoveDirectionX = 1;
                this.MoveDirectionY = 0;
            }

            Position changeToUp1 = new Position(0, 6);
            Position changeToUp2 = new Position(4, 4);
            Position changeToUp3 = new Position(4, 10);

            if (this.CurrentPosition.Compare(changeToUp1) || this.CurrentPosition.Compare(changeToUp2) || this.CurrentPosition.Compare(changeToUp3))
            {
                this.MoveDirectionX = 0;
                this.MoveDirectionY = -1;
            }

            Position changeToLeft1 = new Position(4, 6);
            Position changeToLeft2 = new Position(10, 6);
            Position changeToLeft3 = new Position(6, 10);

            if (this.CurrentPosition.Compare(changeToLeft1) || this.CurrentPosition.Compare(changeToLeft2) || this.CurrentPosition.Compare(changeToLeft3))
            {
                this.MoveDirectionX = -1;
                this.MoveDirectionY = 0;
            }

            Position changeToDown1 = new Position(6, 0);
            Position changeToDown2 = new Position(10, 4);
            Position changeToDown3 = new Position(6, 6);

            if (this.CurrentPosition.Compare(changeToDown1) || this.CurrentPosition.Compare(changeToDown2) || this.CurrentPosition.Compare(changeToDown3))
            {
                this.MoveDirectionX = 0;
                this.MoveDirectionY = 1;
            }

            this.CurrentPosition.X = this.CurrentPosition.X + this.MoveDirectionX;
            this.CurrentPosition.Y = this.CurrentPosition.Y + this.MoveDirectionY;
        }
    }
}
