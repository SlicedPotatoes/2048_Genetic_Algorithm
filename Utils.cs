namespace _2048_Génétic_Algorithm
{
    public class Utils
    {
        public static (long seed, int[] grid) genDefaultGrid(long seed)
        {
            int[] DEFAULT_GRID = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            for (int i = 0; i < 2; i++)
            {
                (int x, int y, int v, long _seed) = Simulate_2048.preshotSpawn(DEFAULT_GRID, seed);
                DEFAULT_GRID[x * GlobalVariable.BOARD_SIZE + y] = v;
                seed = _seed;
            }
            return (seed, DEFAULT_GRID);
        }
        public static T[,] DeepCopyArray<T>(T[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            T[,] values = new T[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    values[i, j] = matrix[i, j];
                }
            }
            return values;
        }
        public static List<T> DeepCopyList<T>(List<T> matrix)
        {
            List<T> list = new List<T>();
            for(int i = 0; i < matrix.Count; i++)
            {
                list.Add(matrix[i]);
            }
            return list;
        }
        public static float random(Random rand, int min, int max)
        {
            return rand.NextSingle() * (max - min) + min;
        }
    }
}
