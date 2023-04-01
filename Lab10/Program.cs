
using System.Numerics;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Granny {
    class Game {
        static void Main() {
            DisplaysGameMenu();
        }
        static void ReturnsMenuMenu() {
            while (true) {
                Console.WriteLine("\nPress ESC to return to the menu.");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();
                if (key.Key == ConsoleKey.Escape) {
                    DisplaysGameMenu();
                    break;
                }
            }
        }
        static void DisplaysGameMenu() {
            while (true) {
                Console.WriteLine("Welcome to the game «Granny»");
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("[S] Start the game");
                Console.WriteLine("[R] Rules");
                Console.WriteLine("[C] Author");
                Console.WriteLine("[E] Exit");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();
                if (key.Key == ConsoleKey.S) {
                    StartsGame();
                    break;
                }
                else if (key.Key == ConsoleKey.C) {
                    DisplaysAuthor();
                    break;
                }
                else if (key.Key == ConsoleKey.R) {
                    DisplaysRules();
                    break;
                }
                else if (key.Key == ConsoleKey.E) {
                    break;
                }
            }
        }
        static void DisplaysAuthor() {
            Console.WriteLine("Code author: Bohdan Overianov, IK-24");
            ReturnsMenuMenu();
        }
        static void DisplaysRules() {
            Console.WriteLine("Rules of the game:");
            Console.WriteLine("\n(1) You need to move the granny across the highway so that the granny does not get hit by a car.");
            Console.WriteLine("(2) Cars move in different directions and at different speeds, which increase with each level.");
            Console.WriteLine("(3) Use the keys [W] [A] [S] [D] to move the grandmother forward, left, back and right respectively.");
            Console.WriteLine("\nGood Luck!");
            ReturnsMenuMenu();
        }
        static void StartsGame() {
            int currentLevel = 3;
            int currentScore = 0;
            while (true) { 
                if (currentLevel == 1) {
                    Level1(ref currentLevel, ref currentScore);
                }
                else if (currentLevel == 2) {
                    Level2(ref currentLevel, ref currentScore);
                }
                else if (currentLevel == 3) {
                    Level3(ref currentLevel, ref currentScore);
                }
                else {
                    if(currentLevel == 0) {
                        string gameOverTitle = "Granny got hit by a car!";
                        EndsGame(currentScore, gameOverTitle);
                    }
                    else {
                        string gameOverTitle = "You completed the game!";
                        EndsGame(currentScore, gameOverTitle);
                    }
                    break;
                }
            }
        }
        static void CompletedLevel(ref int currentScore, ref int currentLevel) {
            currentScore = currentScore + (currentLevel * 50);
            currentLevel++;
            Console.WriteLine("\nLevel completed!");
            Thread.Sleep(2000);
        }
        static void Level1(ref int currentLevel, ref int currentScore) {
            
            char[,] map = new char[,] {

                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'} };

            int[,] carPosition = new int[7, 4];
            int[] playerPosition = new int[2];

            GeneratesObjects(ref carPosition, ref playerPosition, map, currentLevel);

            while (currentLevel == 1) {
                PerformsGameActions(playerPosition, carPosition, map, ref currentLevel, ref currentScore);
            }
        }
        static void Level2(ref int currentLevel, ref int currentScore) {

            char[,] map = new char[,] {

                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'} };

            int[,] carPosition = new int[9, 4];
            int[] playerPosition = new int[2];

            GeneratesObjects(ref carPosition, ref playerPosition, map, currentLevel);

            while (currentLevel == 2) {
                PerformsGameActions(playerPosition, carPosition, map, ref currentLevel, ref currentScore);
            }
        }
        static void Level3(ref int currentLevel, ref int currentScore) {

            char[,] map = new char[,] {

                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'}, };

            int[,] carPosition = new int[11, 4];
            int[] playerPosition = new int[2];

            GeneratesObjects(ref carPosition, ref playerPosition, map, currentLevel);

            while (currentLevel == 3) {
                PerformsGameActions(playerPosition, carPosition, map, ref currentLevel, ref currentScore);
            }
        }
        static void PerformsGameActions(int[] playerPosition, int[,] carPosition, char[,] map, ref int currentLevel, ref int currentScore) {
            Console.WriteLine("«Granny»");
            Console.WriteLine("Level: " + currentLevel);
            Console.WriteLine($"Score: {currentScore} points");
            DrawsMap(playerPosition, map, carPosition);
            MovesGranny(ref playerPosition, ref map, ref currentLevel, ref currentScore);
            MovesCars(playerPosition, map, ref carPosition, ref currentLevel);
            Console.Clear();
        }
        static void GeneratesObjects(ref int[,] carPosition, ref int[] playerPosition, char[,] map, int currentLevel) {
            Random rnd = new Random();
            playerPosition[0] = (map.GetLength(1) - 1) / 2;
            playerPosition[1] = map.GetLength(0) - 2;
            for (int i = 0; i < carPosition.GetLength(0); i++) {
                carPosition[i, 0] = rnd.Next(1, map.GetLength(1) - 2);
                carPosition[i, 1] = 2 + i * 2;
                carPosition[i, 2] = rnd.Next(1, currentLevel + 2);
                carPosition[i, 3] = rnd.Next(0, 2);
            }
        }
        static void MovesGranny(ref int[] playerPosition, ref char[,] map, ref int currentLevel, ref int currentScore) {
            if (playerPosition[1] == 1) {
                CompletedLevel(ref currentScore, ref currentLevel);
            }

            if (Console.KeyAvailable) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W) {
                    if (map[playerPosition[1] - 1, playerPosition[0]] != '-') {
                        playerPosition[1]--;
                    }
                }
                else if (key.Key == ConsoleKey.A) {
                    if (map[playerPosition[1], playerPosition[0] - 1] != '|') {
                        playerPosition[0]--;
                    }
                }
                else if (key.Key == ConsoleKey.S) {
                    if (map[playerPosition[1] + 1, playerPosition[0]] != '-') {
                        playerPosition[1]++;
                    }
                }
                else if (key.Key == ConsoleKey.D) {
                    if (map[playerPosition[1], playerPosition[0] + 1] != '|') {
                        playerPosition[0]++;
                    }
                }
            }
        }
        static void DrawsMap(int[] playerPosition, char[,] map, int[,] carPosition) {
            int i = 0;
            for (int y = 0; y < map.GetLength(0); y++) {
                for (int x = 0; x < map.GetLength(1); x++) {
                    if (x == playerPosition[0] && y == playerPosition[1]) {
                        Console.Write("G");
                    }
                    else if (i < carPosition.GetLength(0) && x == carPosition[i,0] && y == carPosition[i, 1]) {
                        if (carPosition[i, 3] == 0) { 
                            Console.Write(">");
                            i++;
                        }
                        else {
                            Console.Write("<");
                            i++;
                        }
                    }
                    else {
                        Console.Write(map[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }
        static void MovesCars(int[] playerPosition, char[,] map, ref int[,] carPosition, ref int currentLevel) {
            Thread.Sleep(600);
            for (int i = 0; i < carPosition.GetLength(0); i++) {
                for (int j = 0; j < carPosition[i, 2]+1; j++) { 
                    if (carPosition[i, 3] == 0) {
                        if (carPosition[i, 0] < map.GetLength(1) - 2) {
                            carPosition[i, 0]++;
                        }
                        else {
                            carPosition[i, 0] = 1;
                        }
                    }
                    else if (carPosition[i, 3] == 1) {
                        if (carPosition[i, 0] > 1) {
                            carPosition[i, 0]--;
                        }
                        else {
                            carPosition[i, 0] = map.GetLength(1) - 2;
                        }
                    }

                    if (carPosition[i, 0] == playerPosition[0] && carPosition[i, 1] == playerPosition[1]) {
                        currentLevel = 0;
                    }
                }
            }
        }
        static void EndsGame(int currentScore, string gameOverTitle) {
            Console.Clear();
            Console.WriteLine("«Granny»");
            Console.WriteLine(gameOverTitle);
            Console.WriteLine($"Your score: {currentScore} points");
            ReturnsMenuMenu();
        }
    }
}