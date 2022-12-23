using Memory;
using System.Diagnostics;

namespace chillyrewrite
{
    public partial class Form1 : Form
    {
        public Mem m;
        methods? methods;
        Entity localPlayer = new Entity();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            localPlayer = methods.ReadLocalPlayer();
            textBox1.Text = localPlayer.type;
            Debug.WriteLine("akjwhajwhd");
            Debug.WriteLine(localPlayer.type + "\n" + "\n");
        }
    }
}