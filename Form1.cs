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
                MessageBox.Show("Número máximo de paneles excedido, debe estar entre 2 y 6.");
                return;
            }

            // tercer if para que los paramaetros de paneles sea minimo 2
            if (Convert.ToInt32(textBox2.Text) < 2)
            {
                MessageBox.Show("El número de paneles debe de estar entre 2 y 6.");
                return;
            }

            // Verificar que el num de experimentos sea mayor a uno
            if(Convert.ToInt32(textBox1.Text) <=0 )
            {
                MessageBox.Show("El número de experimentos debe de ser un número positivo y mayor a 0.");
                return;
            }

            if (Convert.ToInt32(textBox3.Text) == Convert.ToInt32(textBox4.Text))
            {
                MessageBox.Show("El límite inferior y superior deben de ser diferentes.");
                return;
            }

            if (Convert.ToInt32(textBox3.Text) < 0 || Convert.ToInt32(textBox4.Text) <0)
            {
                MessageBox.Show("Los límites deben de ser positivos");
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

            llenarGrid(matrix, col, rows, PanelSeleccionado);
            llenarGrid2(PanelSeleccionado, rows);
            llenarGrid3(estadisticos);

        }
        public void llenarGrid(double[,] matrix, int col, int rows, List<double> PanelSeleccionado)
        {
            dataGridView1.Columns.Clear();

            // Numero de columnas con lo llenado en el Forms
            dataGridView1.ColumnCount = col;

            //headers (Nombres de columna)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                dataGridView1.Columns[j].HeaderText = ($"Panel  #{j + 1}");
            }

            // Set header style
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0,51,102);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int index = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (PanelSeleccionado.Contains(Convert.ToDouble(cell.Value)))
                    {
                        cell.Style.BackColor = Color.FromArgb(153, 204, 255); ;
                        break;
                    }
                    index++;
                }
            }

            dataGridView1.CurrentCell = null;

            // agregar control al dataGrid
            this.Controls.Add(dataGridView1);
        }

        public void llenarGrid2(List<double> PanelSeleccionado, int rows)
        {
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.ColumnCount = 1;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns[0].HeaderText = "Seleccion";
            foreach (double item in PanelSeleccionado)
            {
                dataGridView2.Rows.Add(item);
            }
            dataGridView2.CurrentCell = null;

        }

        public void llenarGrid3(List<double> estadisticos)
        {
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


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

            dataGridView3.CurrentCell = null;

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
