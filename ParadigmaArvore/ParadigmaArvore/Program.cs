using ParadigmaArvore.Entities;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ParadigmaArvore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool validInput = false;
            List<int> numbers = new List<int>();

            while (!validInput)
            {
                Console.Write("Digite a sequencia de números separados por virgula: ");
                string? request = Console.ReadLine();

                if (request == null || !ValidRequest(request))
                {
                    Console.WriteLine("Entrada inválida!!");
                    Console.WriteLine();
                    continue;
                }

                numbers = request.Split(',')
                                   .Select(x => int.Parse(x.Trim())).ToList();

                HashSet<int> checkList = request.Split(',').Select(x => int.Parse(x.Trim())).ToHashSet<int>();

                if (numbers.Count() < checkList.Count())
                {
                    Console.WriteLine("Existem números duplicados na lista.");
                    Console.WriteLine();
                    continue;
                }

                if (numbers.Count() <= 2)
                {
                    Console.WriteLine("É necessário informar pelo menos TRÈS números.");
                    Console.WriteLine();
                    continue;
                }

                validInput = true;
            }
            

            Tree tree = BuildTree(numbers.ToArray());
            Console.WriteLine("Informações da árvore:");
            Console.WriteLine();
            Console.WriteLine($"Array de entrada: [{String.Join(", ", numbers)}]");
            Console.WriteLine();
            Console.WriteLine($"Raiz: {tree.RootValue}");
            Console.WriteLine();
            Console.WriteLine("Galhos a esquerda: " + string.Join(", ", tree.LeftBranches.Select(x => x.Value)));
            Console.WriteLine();
            Console.WriteLine("Galhos a direita: " + string.Join(", ", tree.RightBranches.Select(x => x.Value)));
            Console.WriteLine();

            PrintTree(tree);
            Console.WriteLine();

            Console.WriteLine("\nObjeto em formato JSON:");
            Console.WriteLine();
            string json = JsonSerializer.Serialize(tree, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static bool ValidRequest(string request)
        {
            string regex = @"^\s*\d+(\s*,\s*\d+)*\s*$";
            return Regex.IsMatch(request, regex);
        }

        static Tree BuildTree(int[] numbers)
        {
            int rootIndex = Array.IndexOf(numbers, numbers.Max());
            int rootValue = numbers[rootIndex];

            var tree = new Tree
            {
                RootValue = rootValue
            };

            int[] leftNumbers = numbers.Take(rootIndex).ToArray();
            int[] rightNumbers = numbers.Skip(rootIndex + 1).ToArray();

            tree.LeftBranches = leftNumbers.OrderByDescending(x => x).Select(x => new Branch { Value = x }).ToList();
            tree.RightBranches = rightNumbers.OrderByDescending(x => x).Select(x => new Branch { Value = x }).ToList();

            return tree;
        }

        static void PrintTree(Tree tree)
        {
            Console.WriteLine("\nÁrvore visual:");
            Console.WriteLine();

            var left = tree.LeftBranches ?? new List<Branch>();
            var right = tree.RightBranches ?? new List<Branch>();

            int depth = Math.Max(left.Count, right.Count);
            int nodeWidth = 3;
            int spacing = nodeWidth + 1;
            int center = 40;

            int totalRows = depth * 2 + 1;
            int totalCols = center * 2;
            string[,] canvas = new string[totalRows, totalCols];

            for (int i = 0; i < totalRows; i++)
                for (int j = 0; j < totalCols; j++)
                    canvas[i, j] = " ";

            WriteCentered(canvas, 0, center, tree.RootValue.ToString(), nodeWidth);

            int xLeft = center;
            for (int i = 0; i < left.Count; i++)
            {
                int level = (i + 1) * 2;
                xLeft -= spacing;

                canvas[level - 1, xLeft + nodeWidth / 2 + 1] = "/";
                WriteCentered(canvas, level, xLeft, left[i].Value.ToString(), nodeWidth);
            }

            int xRight = center;
            for (int i = 0; i < right.Count; i++)
            {
                int level = (i + 1) * 2;
                xRight += spacing;

                canvas[level - 1, xRight - nodeWidth / 2 - 1] = "\\";
                WriteCentered(canvas, level, xRight, right[i].Value.ToString(), nodeWidth);
            }

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalCols; j++)
                    Console.Write(canvas[i, j]);
                Console.WriteLine();
            }

            void WriteCentered(string[,] grid, int row, int col, string value, int width)
            {
                int offset = value.Length / 2;
                int start = col - offset;
                for (int i = 0; i < value.Length; i++)
                {
                    if (start + i >= 0 && start + i < grid.GetLength(1))
                        grid[row, start + i] = value[i].ToString();
                }
            }

        }
    }
}
