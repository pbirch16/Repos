using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UsingBindignNavigator
{
    public partial class frmNavigateData : Form
    {
        public frmNavigateData()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // The xml to bind to.
            string xml = @"<US><states>"
                + @"<state><name>Washington</name><capital>Olympia</capital></state>"
                + @"<state><name>Oregon</name><capital>Salem</capital></state>"
                + @"<state><name>California</name><capital>Sacramento</capital></state>"
                + @"<state><name>Nevada</name><capital>Carson City</capital></state>"
                + @"</states></US>";

            // Convert the xml string to bytes and load into a memory stream.
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            MemoryStream stream = new MemoryStream(xmlBytes, false);

            // Create a DataSet and load the xml into it.
            DataSet set = new DataSet();
            set.ReadXml(stream);

            // Set the DataSource to the DataSet, and the DataMember
            // to state.
            bindingSource1.DataSource = set;
            bindingSource1.DataMember = "state";

            textBox1.DataBindings.Add("Text", bindingSource1, "name");
            textBox2.DataBindings.Add("Text", bindingSource1, "capital");

        }
    }
}
