using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XMLSplitter
{

    public partial class XMLSplitter : Form
    {
        public XMLSplitter()
        {
            InitializeComponent();
        }

        


        private void openButton_Click(object sender, EventArgs e)
        {
            if (openXMLDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.xmlFilePath = openXMLDialog.FileName;
                Properties.Settings.Default.Save();
                filepathlbl.Text = ($"File Loaded : {Properties.Settings.Default.xmlFilePath} ");
            }
        }


        private void Split()
        {
            
            int index = 0;
            int size = 700;
            XDocument xdoc = XDocument.Load(Properties.Settings.Default.xmlFilePath);
            xdoc.Descendants("MetersNotRead").Remove();
            xdoc.Descendants("MetersRead").Remove();
            xdoc.Descendants("ScheduleExecution").Remove();


            foreach (var batch in xdoc.Root.Elements().InSetsOf(size))
            {
                var newDoc = new XDocument(
                     new XElement("AMRDEF", batch));

                newDoc.Save($"C:\\Users\\pthomson\\Desktop\\test_{++index}.xml");
            }
        }


        private void splitButton_Click(object sender, EventArgs e)
        {
            Split();

        }



        private void XMLSplitter_Load(object sender, EventArgs e)
        {
            filepathlbl.Text = ($"File loaded : {Properties.Settings.Default.xmlFilePath}");
        }
    }
    public static class IEnumerableExtensions
    {
        public static IEnumerable<List<T>> InSetsOf<T>(this IEnumerable<T> source, int max)
        {
            List<T> toReturn = new List<T>(max);
            foreach (var item in source)
            {
                toReturn.Add(item);
                if (toReturn.Count == max)
                {
                    yield return toReturn;
                    toReturn = new List<T>(max);
                }
            }
            if (toReturn.Any())
            {
                yield return toReturn;
            }
        }
    }
}
