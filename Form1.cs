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

        _chain.Add(textBox1.Text, "Admin");

        foreach (var block in _chain.Blocks)
        {
            listBox.Items.Add(block);
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (var block in _chain.Blocks)
        {
            listBox.Items.Add(block);
        }
    }
}