namespace _2048_Génétic_Algorithm
{
    public class Seed
    {
        public long seed;
        public int[] defaultGrid;
        public Seed((long seed, int[] grid) tuple) {
            this.seed = tuple.seed;
            this.defaultGrid = tuple.grid;
        }
    }
    public class GlobalVariable
    {
        //Variable Global 2048_Simulation
        public static int BEAM_WIDTH = 30;
        public static char[] MOVE = { 'U', 'D', 'L', 'R' };
        public static int BOARD_SIZE = 4;

        public static Seed[] SEEDS = {
            new Seed(Utils.genDefaultGrid(290797)),
            new Seed(Utils.genDefaultGrid(10682358)),
            new Seed(Utils.genDefaultGrid(38333962)),
            new Seed(Utils.genDefaultGrid(47049887)),
            new Seed(Utils.genDefaultGrid(11205586)),
            new Seed(Utils.genDefaultGrid(15242016)),
            new Seed(Utils.genDefaultGrid(32019767)),
            new Seed(Utils.genDefaultGrid(46946765)),
            new Seed(Utils.genDefaultGrid(4424780)),
            new Seed(Utils.genDefaultGrid(2524322)),
            new Seed(Utils.genDefaultGrid(20797492)),
            new Seed(Utils.genDefaultGrid(28944706)),
            new Seed(Utils.genDefaultGrid(20969426)),
            new Seed(Utils.genDefaultGrid(20950077)),
            new Seed(Utils.genDefaultGrid(8601721)),
            new Seed(Utils.genDefaultGrid(44677966)),
            new Seed(Utils.genDefaultGrid(534357)),
            new Seed(Utils.genDefaultGrid(970088)),
            new Seed(Utils.genDefaultGrid(8078305)),
            new Seed(Utils.genDefaultGrid(5731756)),
            new Seed(Utils.genDefaultGrid(45283038)),
            new Seed(Utils.genDefaultGrid(17769313)),
            new Seed(Utils.genDefaultGrid(41900735)),
            new Seed(Utils.genDefaultGrid(32506342)),
            new Seed(Utils.genDefaultGrid(28758123)),
            new Seed(Utils.genDefaultGrid(25880068)),
            new Seed(Utils.genDefaultGrid(41359522)),
            new Seed(Utils.genDefaultGrid(704563)),
            new Seed(Utils.genDefaultGrid(29082488)),
            new Seed(Utils.genDefaultGrid(18470229))
        };

        //Variable Global Genetic
        public static int[,] MIN_MAX_POIDS = { { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 100 } };
        public static float MUTATION_RATIO = 0.15f;
        public static int POPULATION_SIZE = 25;
    }
}
