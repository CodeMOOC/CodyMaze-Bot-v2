using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public struct GridCoordinate {

        public const int GridSideSize = 5;

        public GridCoordinate(int columnIndex, int rowIndex) {
            if(columnIndex < 0 || columnIndex >= GridSideSize) {
                throw new ArgumentException("Column index out of range", nameof(columnIndex));
            }
            if(rowIndex < 0 || rowIndex >= GridSideSize) {
                throw new ArgumentException("Row index out of range", nameof(rowIndex));
            }
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
            Direction = null;
        }

        public GridCoordinate(int columnIndex, int rowIndex, Direction? direction)
            : this(columnIndex, rowIndex) {
            Direction = direction;
        }

        public int ColumnIndex { get; init; }
        public int RowIndex { get; init; }
        public Direction? Direction { get; init; }

        public char Column {
            get {
                return ColumnIndex switch {
                    0 => 'A',
                    1 => 'B',
                    2 => 'C',
                    3 => 'D',
                    4 => 'E',
                    _ => 'X',
                };
            }
        }

        public char Row {
            get {
                return RowIndex switch {
                    0 => '1',
                    1 => '2',
                    2 => '3',
                    3 => '4',
                    4 => '5',
                    _ => 'X',
                };
            }
        }

        public char? DirectionChar {
            get {
                return Direction switch {
                    null => null,
                    CodyMazeBot.Direction.North => 'N',
                    CodyMazeBot.Direction.East => 'E',
                    CodyMazeBot.Direction.South => 'S',
                    CodyMazeBot.Direction.West => 'W',
                    _ => null
                };
            }
        }

        public override bool Equals(object obj) {
            if(!(obj is GridCoordinate)) {
                return false;
            }
            if(obj is string) {
                return Equals((string)obj);
            }

            var other = (GridCoordinate)obj;
            return (other.ColumnIndex == ColumnIndex &&
                    other.RowIndex == RowIndex &&
                    other.Direction == Direction);
        }

        public bool Equals(string s) {
            return ToString().Equals(s ?? string.Empty, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode() {
            return ColumnIndex * RowIndex;
        }

        public override string ToString() {
            return Direction.HasValue ?
                $"{Column}{Row}{DirectionChar.Value}" :
                $"{Column}{Row}";
        }

        public string CoordinateString {
            get {
                return $"{Column}{Row}";
            }
        }

        private static (int Col, int Row) ParseCoordinatesCouple(char c1, char c2) {
            int col = c1 switch {
                'a' => 0,
                'A' => 0,
                'b' => 1,
                'B' => 1,
                'c' => 2,
                'C' => 2,
                'd' => 3,
                'D' => 3,
                'e' => 4,
                'E' => 4,
                _ => -1
            };
            int row = c2 switch {
                '1' => 0,
                '2' => 1,
                '3' => 2,
                '4' => 3,
                '5' => 4,
                _ => -1
            };
            return (col, row);
        }

        private static Direction? ParseDirection(char c) {
            return c switch {
                'n' => CodyMazeBot.Direction.North,
                'N' => CodyMazeBot.Direction.North,
                'e' => CodyMazeBot.Direction.East,
                'E' => CodyMazeBot.Direction.East,
                's' => CodyMazeBot.Direction.South,
                'S' => CodyMazeBot.Direction.South,
                'w' => CodyMazeBot.Direction.West,
                'W' => CodyMazeBot.Direction.West,
                _ => null
            };
        }

        public static bool TryParse(string s, out GridCoordinate coordinate) {
            coordinate = default;

            if(string.IsNullOrEmpty(s)) {
                return false;
            }
            if(s.Length >= 2 || s.Length <= 3) {
                (var col, var row) = ParseCoordinatesCouple(s[0], s[1]);
                if(col < 0) {
                    return false;
                }
                if(row < 0) {
                    return false;
                }
                
                Direction? dir = null;
                if(s.Length == 3) {
                    dir = ParseDirection(s[2]);
                    if(dir == null) {
                        return false;
                    }
                }

                coordinate = new GridCoordinate(col, row, dir);
                return true;
            }
            else {
                return false;
            }
        }

    }
}
