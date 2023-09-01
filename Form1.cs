namespace MonteCarloFinal_F
{
    using MonteCarloFinal_F.Algoritmos;
    using System.Data;
    using System.Runtime.Intrinsics.X86;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("Los números ingresados deben ser mayores a cero, NO pueden ser espacios en blanco.");
                return;
            }

            // segundo if para que los paramaetros de paneles sea maximo 5
            if (Convert.ToInt32(textBox2.Text) > 6)
            {
                MessageBox.Show("Número máximo de paneles excedido");
                return;
            }

            // tercer if para que los paramaetros de paneles sea minimo 2
            if (Convert.ToInt32(textBox2.Text) < 2)
            {
                MessageBox.Show("Número de paneles incompleto");
                return;
            }

            int rows = Convert.ToInt32(textBox1.Text);
            int col = Convert.ToInt32(textBox2.Text);
            double lim_inf = Convert.ToDouble(textBox3.Text);
            double lim_sup = Convert.ToDouble(textBox4.Text);


            // se genera la matriz con numeros random
            Montecarlo montecarlo = new Montecarlo();
            (double[,] matrix, string descripcion) = montecarlo.Matriz(rows, col, lim_inf, lim_sup);
            (List<double> PanelSeleccionado, string algo) = montecarlo.Seleccion(matrix, rows, col);
            (List<double> estadisticos, string cosas) = montecarlo.Calculos(PanelSeleccionado);

            llenarGrid(matrix, col, rows);
            llenarGrid2(PanelSeleccionado, rows);
            llenarGrid3(estadisticos);
        }
        public void llenarGrid(double[,] matrix, int col, int rows)
        {
            dataGridView1.Columns.Clear();

            // Numero de columnas con lo llenado en el Forms
            dataGridView1.ColumnCount = col;

            //headers (Nombres de columna)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                dataGridView1.Columns[j].HeaderText = ($"Panel  #{j + 1}");
            }

            // agregar filas a la matriz
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row.Cells[j].Value = matrix[i, j];
                }
                dataGridView1.Rows.Add(row);
                dataGridView1.Rows[i].HeaderCell.Value = i + 1;
            }

            // agregar control al dataGrid
            this.Controls.Add(dataGridView1);
        }

        public void llenarGrid2(List<double> PanelSeleccionado, int rows)
        {
            dataGridView2.ColumnCount = 1;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns[0].HeaderText = "Seleccion";
            foreach (double item in PanelSeleccionado)
            {
                dataGridView2.Rows.Add(item);
            }
        }

        public void llenarGrid3(List<double> estadisticos)
        {
            dataGridView3.ColumnCount = 3;
            dataGridView3.Rows.Clear();
            dataGridView3.Rows.Add(); // agregar solo una fila
            dataGridView3.Columns[0].HeaderText = "Promedio";
            dataGridView3.Columns[1].HeaderText = "Desviación Estándar";
            dataGridView3.Columns[2].HeaderText = "Varianza";

            for (int i = 0; i < estadisticos.Count; i++)
            {
                dataGridView3.Rows[0].Cells[i].Value = estadisticos[i];
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
