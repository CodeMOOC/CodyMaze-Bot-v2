using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public static class MazeExtensions {

        public static bool IsOnGridBorder(this GridCoordinate coord) {
            return (coord.ColumnIndex == 0 ||
                    coord.ColumnIndex == GridCoordinate.GridSideSize ||
                    coord.RowIndex == 0 ||
                    coord.RowIndex == GridCoordinate.GridSideSize);
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

    }
}
