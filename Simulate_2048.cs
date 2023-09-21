using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace _2048_Génétic_Algorithm
{
    public class TreeGrid
    {
        public int[] grid;
        public long seed;
        public int score;
        public int depth;
        public StringBuilder path;
        public int margedCell;
        public int biggestCell;
        public float heuristique;
        public TreeGrid(int[] grid, long seed, int score, int depth, int margedCell, int biggestCell) {
            this.grid = grid;
            this.seed = seed;
            this.score = score;
            this.depth = depth;
            this.margedCell = margedCell;
            this.biggestCell = biggestCell;
            this.heuristique = 0;
        }
    }
    public class Simulate_2048
    {   
        private static (int[] _grid, int score, bool sameGrid, int margedCell, int biggestCell) move(int[] grid, char m)
        {
            bool sameGrid = true;
            int[] _grid = new int[grid.Length];
            Array.Copy(grid, _grid, grid.Length);
            int score = 0;
            int margedCell = 0;
            int biggestCell = 0;

            int indexStart = m == 'U' || m == 'L' ? 0 : GlobalVariable.BOARD_SIZE - 1;
            int indexEnd = m == 'U' || m == 'L' ? GlobalVariable.BOARD_SIZE - 1 : 0;
            int indexInc = m == 'U' || m == 'L' ? 1 : -1;
            for(int i = indexStart; i != indexEnd + indexInc; i += indexInc)
            {
                for(int j = indexStart; j != indexEnd + indexInc; j += indexInc)
                {
                    int index1 = m == 'U' || m == 'D' ? i : j;
                    int index2 = m == 'U' || m == 'D' ? j : i;
                    int end = indexEnd + indexInc;
                    int k = m == 'U' || m == 'D' ? index1 + indexInc : index2 + indexInc;
                    if (_grid[index1 * GlobalVariable.BOARD_SIZE + index2] == 0)
                    {
                        for(; k != end; k += indexInc)
                        {
                            int kIndex1 = m == 'U' || m == 'D' ? k : index1;
                            int kIndex2 = m == 'U' || m == 'D' ? index2 : k;
                            if (_grid[kIndex1 * GlobalVariable.BOARD_SIZE + kIndex2] != 0)
                            {
                                sameGrid = false;
                                _grid[index1 * GlobalVariable.BOARD_SIZE + index2] = _grid[kIndex1 * GlobalVariable.BOARD_SIZE + kIndex2];
                                _grid[kIndex1 * GlobalVariable.BOARD_SIZE + kIndex2] = 0;
                                break;
                            }
                        }
                    }
                    if (_grid[index1 * GlobalVariable.BOARD_SIZE + index2] != 0)
                    {
                        for (; k != end; k += indexInc)
                        {
                            int kIndex1 = m == 'U' || m == 'D' ? k : index1;
                            int kIndex2 = m == 'U' || m == 'D' ? index2 : k;
                            if (_grid[kIndex1 * GlobalVariable.BOARD_SIZE + kIndex2] == _grid[index1 * GlobalVariable.BOARD_SIZE + index2])
                            {
                                sameGrid = false;
                                int cellNumber = _grid[index1 * GlobalVariable.BOARD_SIZE + index2] * 2;
                                _grid[index1 * GlobalVariable.BOARD_SIZE + index2] = cellNumber;
                                _grid[kIndex1 * GlobalVariable.BOARD_SIZE + kIndex2] = 0;
                                score += cellNumber;
                                margedCell++;
                                break;
                            }
                            else if (_grid[kIndex1 * GlobalVariable.BOARD_SIZE + kIndex2] != 0)
                            {
                                break;
                            }
                        }
                    }
                    if (_grid[index1 * GlobalVariable.BOARD_SIZE + index2] > biggestCell)
                    {
                        biggestCell = _grid[index1 * GlobalVariable.BOARD_SIZE + index2];
                    }
                }
            }
            return (_grid, score, sameGrid, margedCell, biggestCell);
        }
        public static (int x, int y, int value, long seed) preshotSpawn(int[] grid, long seed) {
            List<int> freeCells = new List<int>();
            for(int _y = 0; _y < GlobalVariable.BOARD_SIZE; _y++)
            {
                for(int _x = 0; _x < GlobalVariable.BOARD_SIZE; _x++)
                {
                    if (grid[_x * GlobalVariable.BOARD_SIZE + _y] == 0)
                    {
                        freeCells.Add(_x + _y * GlobalVariable.BOARD_SIZE);
                    }
                }
            }
            if(freeCells.Count == 0)
            {
                return (-1, -1, 0, -1);
            }
            
            int spawnIndex = freeCells[(int) (seed % freeCells.Count)];
            int value = (seed & 0x10) == 0 ? 2 : 4;
            int x = Convert.ToInt32(Math.Floor((double)(spawnIndex % GlobalVariable.BOARD_SIZE)));
            int y = Convert.ToInt32(Math.Floor((double)(spawnIndex / GlobalVariable.BOARD_SIZE)));
            long _seed = (seed * seed) % 50515093;
            return (x, y, value, _seed);
        }
        private static float calculHeuristique(TreeGrid node, List<float> poids)
        {
            int[] grid = node.grid;
            int monotonie = calculMonotonie(grid);
            float score = node.score * poids[0];
            score += node.margedCell * poids[1];
            score += node.biggestCell * poids[3];
            score -= monotonie * poids[4];
            if (grid[0 * GlobalVariable.BOARD_SIZE + 0] == node.biggestCell || grid[0 * GlobalVariable.BOARD_SIZE + 3] == node.biggestCell || grid[3 * GlobalVariable.BOARD_SIZE + 0] == node.biggestCell || grid[3 * GlobalVariable.BOARD_SIZE + 3] == node.biggestCell)
            {
                score *= poids[2];
            }
            return score;
        }
        private static int calculMonotonie(int[] grid)
        {
            int monotonie = 0;
            for(int i = 0; i < GlobalVariable.BOARD_SIZE; i++)
            {
                int rowMonotonie = 0;
                for(int j = 0; j < GlobalVariable.BOARD_SIZE - 1; j++)
                {
                    int diff = Math.Abs(grid[i * GlobalVariable.BOARD_SIZE + j] - grid[i * GlobalVariable.BOARD_SIZE + j + 1]);
                    rowMonotonie += diff;
                }
                monotonie += rowMonotonie;
            }
            return monotonie;
        }
        public static TreeGrid bestMove(int[] grid, long seed, List<float> poids)
        {
            List<TreeGrid> nodes = new List<TreeGrid>();
            nodes.Add(new TreeGrid(grid, seed, 0, 0, 0, 0));
            while (true)
            {
                ConcurrentBag<TreeGrid> _nodes = new ConcurrentBag<TreeGrid>();
                Parallel.ForEach(nodes.Take(nodes.Count > GlobalVariable.BEAM_WIDTH ? GlobalVariable.BEAM_WIDTH : nodes.Count), node =>
                {
                    Parallel.ForEach(GlobalVariable.MOVE, (m) =>
                    {
                        (int[] _grid, int score, bool isSameGrid, int margedCell, int biggestCell) = move(node.grid, m);
                        if (!isSameGrid)
                        {
                            (int preshotX, int preshotY, int preshotValue, long preshotSeed) = preshotSpawn(_grid, node.seed);
                            if (preshotX != -1 && preshotY != -1)
                            {
                                _grid[preshotX * GlobalVariable.BOARD_SIZE + preshotY] = preshotValue;
                            }
                            TreeGrid child = new TreeGrid(_grid, preshotSeed, score, node.depth + 1, margedCell, biggestCell);
                            child.heuristique = calculHeuristique(child, poids);
                            _nodes.Add(child);
                        }
                    });
                });
                if (_nodes.Count == 0)
                {
                    break;
                }
                List<TreeGrid> sortedNodes = _nodes.ToList();
                sortedNodes.Sort((TreeGrid a, TreeGrid b) =>
                {
                    return Convert.ToInt32(b.heuristique - a.heuristique);
                });
                nodes = sortedNodes;
            }
            return nodes[0];
        }
        public static int getScoreGrid(int[] grid)
        {
            int score = 0;
            for(int i = 0; i < GlobalVariable.BOARD_SIZE; i++)
            {
                for (int j = 0; j < GlobalVariable.BOARD_SIZE; j++)
                {
                    score += grid[i * GlobalVariable.BOARD_SIZE + j];
                }
            }
            return score;
        }
    }
}
