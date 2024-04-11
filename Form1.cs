using MySql.Data.MySqlClient;

namespace minions
{
    public partial class Form1 : Form
    {
        string connectionString = "10.42.42.64; " + "port=3306;" + "user=PC1;"
            + "pasword=1111;" + "database=minions";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection dbMinions = new MySqlConnection(connectionString);
            dbMinions.Open();
            MessageBox.Show("Connection is now opened!");
            MySqlCommand query = new MySqlCommand("select * from towns", dbMinions);
            MySqlDataReader reader = query.ExecuteReader();
            List<ComboItem> items = new List<ComboItem>();
            while (reader.Read())
            {
                ComboItem item = new ComboItem();

                item.Id = 106;
                item.Name = "";

                items.Add(item);

            }
            reader.Close();

            comboBox1.DataSource = items;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            dbMinions.Clone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"106. Ti vuvede {textBox1.Text} s godini {textBox2.Text} s grad" +
            $"{comboBox1.Text} -- > {comboBox1.SelectedValue}");

            string insertSQL = "INSERT INTO minions.minions " + "(id,`name`,age,town_id) " +
            $"VALUES (106,@townName,@age,@townId)";

           //zapochva Insert query
           //query.Parameters.AddWithValue("@townName");
        }
    }
}
