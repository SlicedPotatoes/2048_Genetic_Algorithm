using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text.Json;

namespace _2048_Génétic_Algorithm
{
    public partial class Form1 : Form
    {
        private Genetic gen;
        private List<Label> labels;
        private int trainingTime;
        private int genTime;
        public Form1()
        {
            InitializeComponent();
            initGridLabel();
            this.trainingTime = 0;
            this.genTime = 0;
        }
        private void initGridLabel()
        {
            labels = new List<Label>();
            panelGrid.Controls.Clear();
            for (int i = 0; i < GlobalVariable.BOARD_SIZE; i++)
            {
                for (int j = 0; j < GlobalVariable.BOARD_SIZE; j++)
                {
                    Label l = new Label();
                    l.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    l.BorderStyle = BorderStyle.FixedSingle;
                    l.Margin = new Padding(0);
                    l.Size = new Size(75, 75);
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Font = new Font(new FontFamily("Segoe UI"), 15);
                    if ((i + j) % 2 == 0)
                    {
                        l.BackColor = Color.DarkGray;
                    }
                    else
                    {
                        l.BackColor = Color.Gray;
                    }
                    l.Text = "0";
                    labels.Add(l);
                    panelGrid.Controls.Add(l, i, j);
                }
            }
        }
        private void showPop()
        {
            labelGeneration.Text = gen.nGeneration.ToString();
            listView1.Items.Clear();
            for (int i = 0; i < gen.population.Count; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                for (int j = 0; j < gen.population[i].gen.Count; j++)
                {
                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, gen.population[i].gen[j].ToString());
                    item.SubItems.Add(subItem);
                }
                ListViewItem.ListViewSubItem score = new ListViewItem.ListViewSubItem(item, gen.population[i].score.ToString());
                item.SubItems.Add(score);
                listView1.Items.Add(item);
            }
        }

        async private void btnNextGen_Click(object sender, EventArgs e)
        {
            do
            {
                this.genTime = 0;
                timerStart.Start();
                Thread t = new Thread(() => { gen.nextGen(); });
                t.Start();
                await Task.Run(() => { t.Join(); });
                showPop();
                timerStart.Stop();
            } while (checkBox1.Checked);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.trainingTime = 0;
            timerStart.Start();
            gen = new Genetic();
            showPop();
            timerStart.Stop();
            if (checkBox1.Checked)
            {
                btnNextGen_Click(sender, e);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int index = listView1.SelectedIndices[0];
                List<TreeGrid> nodes = gen.population[index].lastNodes;
                selectSeed.Items.Clear();
                for (int i = 0; i < nodes.Count; i++)
                {
                    selectSeed.Items.Add(i);
                }
            }
        }

        private void selectSeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int indexIndividu = listView1.SelectedIndices[0];
                int indexSeed = selectSeed.SelectedIndex;
                TreeGrid node = gen.population[indexIndividu].lastNodes[indexSeed];
                drawGrid(node.grid);
            }


        }
        private void drawGrid(int[] grid)
        {
            int indexLabel = 0;
            for (int i = 0; i < GlobalVariable.BOARD_SIZE; i++)
            {
                for (int j = 0; j < GlobalVariable.BOARD_SIZE; j++)
                {
                    labels[indexLabel].Text = grid[i * GlobalVariable.BOARD_SIZE + j].ToString();
                    indexLabel++;
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int index = listView1.SelectedIndices[0];
                string s = "[";
                for (int i = 0; i < gen.population[index].gen.Count; i++)
                {
                    s += gen.population[index].gen[i].ToString().Replace(',', '.') + ", ";
                }
                Clipboard.SetText(s);
            }

        }

        private string secondeInTimeString(int s)
        {
            int h = s / 3600;
            s %= 3600;
            int m = s / 60;
            s %= 60;
            return h.ToString().PadLeft(2, '0') + ':' + m.ToString().PadLeft(2, '0') + ':' + s.ToString().PadLeft(2, '0');
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            this.trainingTime++;
            this.genTime++;
            labelTrainingTime.Text = secondeInTimeString(this.trainingTime);
            labelGenTime.Text = secondeInTimeString(this.genTime);
        }

        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Choisissez l'emplacement et le nom du fichier";
            saveFileDialog.Filter = "Fichiers JSON (*.json)|*.json|Tous les fichiers (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var data = new
                    {
                        generation = gen.nGeneration,
                        data = new List<Individual>()
                    };
                    for (int i = 0; i < gen.population.Count; i++)
                    {
                        data.data.Add(gen.population[i]);
                    }
                    string json = JsonSerializer.Serialize(data);
                    string cheminDuFichier = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(cheminDuFichier))
                    {
                        sw.WriteLine(json);
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
            }
        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selectionner un fichier";
            ofd.Filter = "Fichiers JSON (*.json)|*.json|Tous les fichiers (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string cheminDuFichier = ofd.FileName;
                    using (StreamReader sr = new StreamReader(cheminDuFichier))
                    {
                        string json = sr.ReadToEnd();
                        JObject jObj = JObject.Parse(json);
                        var dataArray = jObj["data"];
                        int nGen = (int)jObj["generation"];
                        List<Individual> l = new List<Individual>();
                        foreach(var element in dataArray)
                        {
                            List<float> poids = new List<float>();
                            foreach (float f in element["gen"])
                            {
                                poids.Add(f);
                            }
                            int score = (int)element["score"];
                            Individual i = new Individual(poids);
                            i.score = score;
                            l.Add(i);
                        }
                        this.gen = new Genetic(l, nGen);
                        showPop();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
            }
        }
    }
}