using CodyMazeBot.StoreModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CodyMazeBot {
    public class MazeGenerator {

        public MazeGenerator(
            IConfiguration configuration
        ) {
            var confMaze = configuration.GetRequiredSection("Maze");
            LastMove = Convert.ToInt32(confMaze["LastMove"]);
        }

        public int LastMove { get; init; }

        public (GridCoordinate Target, string Code) GenerateInstructions(GridCoordinate start, int move, IDictionary<string, GridCell> grid) {
            return move switch {
                1 => GenerateMove1(start, grid),
                2 => GenerateMove2(start, grid),
                3 => GenerateMove1(start, grid),
                4 => GenerateMove4(start, grid),
                5 => GenerateMove5(start, grid),
                6 => GenerateMove6(start, grid),
                7 => GenerateMove7(start, grid),
                8 => GenerateMove8(start, grid),
                9 => GenerateMove9(start, grid),
                10 => GenerateMove10(start, grid),
                11 => GenerateMove11(start, grid),
                12 => GenerateMove12(start, grid),
                13 => GenerateMove13(start, grid),
                _ => throw new ArgumentException($"Cannot generate move number {move}")
            };
        }

        private (GridCoordinate Target, string Code) GenerateMove1(GridCoordinate start, IDictionary<string, GridCell> grid) {
            var target = start.Advance();
            if (!target.HasValue) {
                throw new ArgumentException($"Cannot generate move 1 from position {start}");
            }

            return (target.Value, Strings.CodeForward);
        }

        private (GridCoordinate Target, string Code) GenerateMove2(GridCoordinate start, IDictionary<string, GridCell> grid) {
            // TODO pick randomly
            if (start.TurnLeft().CanAdvance()) {
                return (start.TurnLeft(), Strings.CodeLeft);
            }
            else if (start.TurnRight().CanAdvance()) {
                return (start.TurnRight(), Strings.CodeRight);
            }
            else {
                throw new ArgumentException($"Cannot turn right nor left from position {start}");
            }
        }

        private (GridCoordinate Target, string Code) GenerateMove4(GridCoordinate start, IDictionary<string, GridCell> grid) {
            if (start.TurnLeft().CanAdvance(2)) {
                return (start.TurnLeft().Advance().Value, $"{Strings.CodeLeft}{Strings.CodeForward}");
            }
            else if (start.TurnRight().CanAdvance(2)) {
                return (start.TurnRight().Advance().Value, $"{Strings.CodeRight}{Strings.CodeForward}");
            }
            else {
                throw new ArgumentException($"Cannot turn right nor left from position {start}");
            }
        }

        private (GridCoordinate Target, string Code) GenerateMove5(GridCoordinate start, IDictionary<string, GridCell> grid) {
            if (!start.CanAdvance(2)) {
                throw new ArgumentException($"Cannot advance two positions from position {start}");
            }
            return (start.Advance().Value.Advance().Value, $"2{{{Strings.CodeForward}}}");
        }

        private (GridCoordinate Target, string Code) GenerateMove6(GridCoordinate start, IDictionary<string, GridCell> grid) {
            int leftAdvancements = start.TurnLeft().MaxAdvancements();
            int rightAdvancements = start.TurnRight().MaxAdvancements();
            if (leftAdvancements > rightAdvancements) {
                return (start.TurnLeft().Advance(leftAdvancements).Value, $"{Strings.CodeLeft}{leftAdvancements}{{{Strings.CodeForward}}}");
            }
            else {
                return (start.TurnRight().Advance(rightAdvancements).Value, $"{Strings.CodeRight}{rightAdvancements}{{{Strings.CodeForward}}}");
            }
        }

        private (GridCoordinate Target, string Code) GenerateMove7(GridCoordinate start, IDictionary<string, GridCell> grid) {
            GridCoordinate current = start;
            GridCoordinate? next;
            if (start.CanAdvanceLeft()) {
                for (int c = 0; c < 3; ++c) {
                    next = current.TurnLeft().Advance();
                    if (!next.HasValue) {
                        return (current, $"{c}{{{Strings.CodeLeft}{Strings.CodeForward}}}");
                    }
                    current = next.Value;
                }
                return (current, $"3{{{Strings.CodeLeft}{Strings.CodeForward}}}");
            }
            else {
                for (int c = 0; c < 3; ++c) {
                    next = current.TurnRight().Advance();
                    if (!next.HasValue) {
                        return (current, $"{c}{{{Strings.CodeRight}{Strings.CodeForward}}}");
                    }
                    current = next.Value;
                }
                return (current, $"3{{{Strings.CodeRight}{Strings.CodeForward}}}");
            }
        }

        private (GridCoordinate Target, string Code) GenerateMove8(GridCoordinate start, IDictionary<string, GridCell> grid) {
            bool hasStar = grid[start.CoordinateString.ToLowerInvariant()].HasStar;
            string starCondition = hasStar ? Strings.CodeStar : Strings.CodeNoStar;

            if (start.TurnLeft().CanAdvance()) {
                return (start.TurnLeft().Advance().Value, $"{Strings.CodeIf}({starCondition}){{{Strings.CodeLeft}{Strings.CodeForward}}}");
            }
            else if (start.TurnRight().CanAdvance()) {
                return (start.TurnRight().Advance().Value, $"{Strings.CodeIf}({starCondition}){{{Strings.CodeRight}{Strings.CodeForward}}}");
            }
            else {
                throw new ArgumentException($"Cannot turn right nor left from position {start}");
            }
        }

        private (GridCoordinate Target, string Code) GenerateMove9(GridCoordinate start, IDictionary<string, GridCell> grid) {
            bool hasStar = grid[start.CoordinateString.ToLowerInvariant()].HasStar;
            string starCondition = hasStar ? Strings.CodeNoStar : Strings.CodeStar; // inverse, do on else condition

            if (start.TurnLeft().CanAdvance()) {
                return (start.TurnLeft().Advance().Value, $"{Strings.CodeIf}({starCondition}){{{Strings.CodeRight}{Strings.CodeForward}}}{Strings.CodeElse}{{{Strings.CodeLeft}{Strings.CodeForward}}}");
            }
            else if (start.TurnRight().CanAdvance()) {
                return (start.TurnRight().Advance().Value, $"{Strings.CodeIf}({starCondition}){{{Strings.CodeLeft}{Strings.CodeForward}}}{Strings.CodeElse}{{{Strings.CodeRight}{Strings.CodeForward}}}");
            }
            else {
                throw new ArgumentException($"Cannot turn right nor left from position {start}");
            }
        }

        private (GridCoordinate Target, string Code) GenerateMove10(GridCoordinate start, IDictionary<string, GridCell> grid) {
            var rnd = new Random();
            GridCoordinate target = start;
            int count = rnd.Next(2, 5);

            for (int i = 0; i < count; ++i) {
                target = target.CrawlPreferRight();
            }

            return (target, $"{count}{{{Strings.CodeIf}({Strings.CodePathAhead}){{{Strings.CodeForward}}}{Strings.CodeElse}{{{Strings.CodeIf}({Strings.CodePathRight}){{{Strings.CodeRight}}}{Strings.CodeElse}{{{Strings.CodeLeft}}}}}}}");
        }

        private (GridCoordinate Target, string Code) GenerateMove11(GridCoordinate start, IDictionary<string, GridCell> grid) {
            var rnd = new Random();
            GridCoordinate target = start;
            int count = rnd.Next(3, 6);

            for (int i = 0; i < count; ++i) {
                target = target.CrawlPreferLeft();
            }

            return (target, $"{count}{{{Strings.CodeIf}({Strings.CodePathAhead}){{{Strings.CodeForward}}}{Strings.CodeElse}{{{Strings.CodeIf}({Strings.CodePathLeft}){{{Strings.CodeLeft}}}{Strings.CodeElse}{{{Strings.CodeRight}}}}}}}");
        }

        private (GridCoordinate Target, string Code) GenerateMove12(GridCoordinate start, IDictionary<string, GridCell> grid) {
            int maxAdvances = start.MaxAdvancements();
            return (start.Advance(maxAdvances).Value, $"{Strings.CodeWhile}({Strings.CodePathAhead}){{{Strings.CodeForward}}}");
        }

        private (GridCoordinate Target, string Code) GenerateMove13(GridCoordinate start, IDictionary<string, GridCell> grid) {
            while (!grid[start.CoordinateString.ToLowerInvariant()].HasStar) {
                start = start.CrawlPreferRight();
            }

            return (start, $"{Strings.CodeWhile}({Strings.CodeNoStar}){{{Strings.CodeIf}({Strings.CodePathAhead}){{{Strings.CodeForward}}}{Strings.CodeElse}{{{Strings.CodeIf}({Strings.CodePathRight}){{{Strings.CodeRight}}}{Strings.CodeElse}{{{Strings.CodeLeft}}}}}");
        }

    }
}
