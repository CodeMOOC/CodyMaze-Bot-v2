using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public static class MazeExtensions {

        public static bool IsOnGridBorder(this GridCoordinate coord) {
            return (coord.ColumnIndex == 0 ||
                    coord.ColumnIndex == GridCoordinate.GridSideSize - 1 ||
                    coord.RowIndex == 0 ||
                    coord.RowIndex == GridCoordinate.GridSideSize - 1);
        }

        public static Direction GetInitialDirection(this GridCoordinate coord) {
            if(coord.ColumnIndex == 0) {
                return Direction.East;
            }
            if(coord.ColumnIndex == GridCoordinate.GridSideSize - 1) {
                return Direction.West;
            }
            if(coord.RowIndex == 0) {
                return Direction.South;
            }
            if(coord.RowIndex == GridCoordinate.GridSideSize - 1) {
                return Direction.North;
            }
            throw new ArgumentException("Coordinate is not valid initial position", nameof(coord));
        }

        public static GridCoordinate? Advance(this GridCoordinate coord) {
            return coord.Direction switch {
                null => throw new ArgumentException("Cannot advance from coordinate without direction", nameof(coord)),
                Direction.North => (coord.RowIndex <= 0) ? null :
                    new GridCoordinate(coord.ColumnIndex, coord.RowIndex - 1, coord.Direction),
                Direction.East => (coord.ColumnIndex >= GridCoordinate.GridSideSize - 1) ? null :
                    new GridCoordinate(coord.ColumnIndex + 1, coord.RowIndex, coord.Direction),
                Direction.South => (coord.RowIndex >= GridCoordinate.GridSideSize - 1) ? null :
                    new GridCoordinate(coord.ColumnIndex, coord.RowIndex + 1, coord.Direction),
                Direction.West => (coord.ColumnIndex <= 0) ? null :
                    new GridCoordinate(coord.ColumnIndex - 1, coord.RowIndex, coord.Direction),
                _ => throw new ArgumentException("Invalid coordinate direction")
            };
        }

        public static GridCoordinate? Advance(this GridCoordinate coord, int moves) {
            GridCoordinate? current = coord;
            for(int i = 0; i < moves; ++i) {
                current = current.Value.Advance();
                if(!current.HasValue) {
                    return null;
                }
            }
            return current.Value;
        }

        public static GridCoordinate TurnRight(this GridCoordinate coord) {
            return coord.Direction switch {
                null => throw new ArgumentException("Cannot turn from coordinate without direction"),
                Direction.North => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.East),
                Direction.East => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.South),
                Direction.South => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.West),
                Direction.West => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.North),
                _ => throw new ArgumentException("Invalid coordinate direction")
            };
        }

        public static GridCoordinate TurnLeft(this GridCoordinate coord) {
            return coord.Direction switch {
                null => throw new ArgumentException("Cannot turn from coordinate without direction"),
                Direction.North => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.West),
                Direction.East => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.North),
                Direction.South => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.East),
                Direction.West => new GridCoordinate(coord.ColumnIndex, coord.RowIndex, Direction.South),
                _ => throw new ArgumentException("Invalid coordinate direction")
            };
        }

        public static bool CanAdvance(this GridCoordinate coord, int moves = 1) {
            GridCoordinate? current = coord;
            for(int i = 0; i < moves; ++i) {
                current = current.Value.Advance();
                if(!current.HasValue) {
                    return false;
                }
            }
            return true;
        }

        public static int MaxAdvancements(this GridCoordinate coord) {
            GridCoordinate? current = coord;
            int moves = 0;
            while(current.HasValue) {
                current = current.Value.Advance();
                moves++;
            }
            return moves - 1;
        }

        public static bool CanAdvanceLeft(this GridCoordinate coord) {
            return coord.TurnLeft().Advance().HasValue;
        }

        public static bool CanAdvanceRight(this GridCoordinate coord) {
            return coord.TurnRight().Advance().HasValue;
        }

        public static GridCoordinate CrawlPreferRight(this GridCoordinate coord) {
            if(coord.CanAdvance()) {
                return coord.Advance().Value;
            }
            else if(coord.TurnRight().CanAdvance()) {
                return coord.TurnRight();
            }
            else {
                return coord.TurnLeft();
            }
        }

        public static GridCoordinate CrawlPreferLeft(this GridCoordinate coord) {
            if (coord.CanAdvance()) {
                return coord.Advance().Value;
            }
            else if (coord.TurnLeft().CanAdvance()) {
                return coord.TurnLeft();
            }
            else {
                return coord.TurnRight();
            }
        }

    }
}
