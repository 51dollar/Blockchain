namespace Blockchain;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private Chain _chain = new Chain();

    private void button1_Click(object sender, EventArgs e)
    {
        listBox.Items.Clear();

        _chain.Add(textBox1.Text, "User");

        listBox.Items.AddRange(_chain.Blocks.ToArray());
    }

    private void Form1_Load(object sender, EventArgs e)
    {
            listBox.Items.AddRange(_chain.Blocks.ToArray());
    }
}