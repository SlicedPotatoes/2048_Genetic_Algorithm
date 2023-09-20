using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace _2048_Génétic_Algorithm
{
    public class Individual
    {
        public List<float> gen {  get; set; }
        public List<TreeGrid> lastNodes;
        public int score { get; set; }
        public Individual(List<float> gen) {
            this.gen = gen;
        }
        public void simulate()
        {
            if(this.lastNodes == null)
            {
                this.lastNodes = new List<TreeGrid>();
                this.score = 0;
                Parallel.ForEach(GlobalVariable.SEEDS, (seed) =>
                {
                    TreeGrid lastNode = Simulate_2048.bestMove(seed.defaultGrid, seed.seed, this.gen);
                    this.lastNodes.Add(lastNode);
                    this.score += Simulate_2048.getScoreGrid(lastNode.grid);
                });
                this.score /= GlobalVariable.SEEDS.Length;
            }
        }
    }
    public class Genetic
    {
        private Random rand;
        public List<Individual> population;
        public int nGeneration;
        public Genetic()
        {
            
            population = new List<Individual>();
            rand = new Random();
            initPopulation();
        }
        public Genetic(List<Individual> p, int ngen)
        {
            this.population = p;
            this.nGeneration = ngen;
            rand = new Random();
            while (this.population.Count < GlobalVariable.POPULATION_SIZE)
            {
                this.population.Add(genRandomIndividual());
            }
            simulatePop();
        }
        private void initPopulation()
        {
            var date = DateTime.Now;
            nGeneration = 1;
            for (int i = 0; i < GlobalVariable.POPULATION_SIZE; i++)
            {
                this.population.Add(genRandomIndividual());
            }
            simulatePop();
            sort();
            var date2 = DateTime.Now;
            Debug.WriteLine(date2 - date);
        }
        private Individual genRandomIndividual() {
            List<float> gen = new List<float>();
            for(int i = 0; i < GlobalVariable.MIN_MAX_POIDS.GetLength(0); i++)
            {
                gen.Add(Utils.random(this.rand, GlobalVariable.MIN_MAX_POIDS[i, 0], GlobalVariable.MIN_MAX_POIDS[i, 1]));
            }
            return new Individual(gen);
        }
        private Individual crossOver(Individual i1, Individual i2)
        {
            List<float> gen = new List<float>();
            for (int i = 0; i < i1.gen.Count; i++)
            {
                if(rand.NextSingle() >= 0.5)
                {
                    gen.Add(i1.gen[i]);
                }
                else
                {
                    gen.Add(i2.gen[i]);
                }
            }
            return new Individual(gen);
        }
        private Individual mutate(Individual ind, int nbGen, int multiplicateur)
        {
            List<float> gen = Utils.DeepCopyList(ind.gen);
            for(int i = 0; i < nbGen; i++)
            {
                int genIndex = rand.Next(gen.Count);
                bool isNeg = rand.NextSingle() > 0.5;
                float mut = 0f;
                if (multiplicateur == 4)
                {
                    mut = Utils.random(rand, GlobalVariable.MIN_MAX_POIDS[genIndex, 0], GlobalVariable.MIN_MAX_POIDS[genIndex, 1]);
                    gen[genIndex] = mut;
                }
                else
                {
                    mut = (gen[genIndex] * GlobalVariable.MUTATION_RATIO * multiplicateur * (isNeg ? -1 : 1));
                    gen[genIndex] += mut;
                }
            }
            return new Individual(gen);
        }

        private void sort()
        {
            this.population.Sort((Individual a, Individual b) =>
            {
                return b.score - a.score;
            });
        }
        public void nextGen()
        {
            List<Individual> pop = new List<Individual>();
            pop.Add(this.population[0]);
            pop.Add(this.population[1]);
            pop.Add(this.population[2]);

            /*pop.Add(crossOver(this.population[0], this.population[1]));
            pop.Add(crossOver(this.population[0], this.population[2]));
            pop.Add(crossOver(this.population[1], this.population[2]));*/
            for (int i = 0; i < 4; i++)
            {
                pop.Add(mutate(this.population[0], 1, 1));
            }
            pop.Add(mutate(this.population[0], 2, 2));
            pop.Add(mutate(this.population[0], 2, 3));
            pop.Add(mutate(this.population[0], 2, 4));
            pop.Add(mutate(this.population[0], 3, 2));
            pop.Add(mutate(this.population[0], 4, 2));
            pop.Add(mutate(this.population[0], 5, 2));
            while (pop.Count != GlobalVariable.POPULATION_SIZE)
            {
                pop.Add(genRandomIndividual());
            }
            this.population = pop;
            simulatePop();
            nGeneration++;
            sort();
        }
        public void simulatePop()
        {
            Parallel.ForEach(this.population, (ind) =>
            {
                ind.simulate();
            });
        }
    }
}
