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
using XMLSplitter.Properties;
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
            FolderBrowserDialog folder = new FolderBrowserDialog();
            string saveLocation = (string)Settings.Default["defaultSaveLocation"];
            
            folder.Description = "Please choose a folder to save your files.";
            folder.SelectedPath = saveLocation;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                saveLocation = folder.SelectedPath;
                Settings.Default["defaultSaveLocation"] = saveLocation;
                Properties.Settings.Default.Save();
                int index = 0;
                int elementCount = 0;
                int elementsPerFile = 700;
                XDocument xdoc = XDocument.Load(Properties.Settings.Default.xmlFilePath);
                xdoc.Descendants("MetersNotRead").Remove();
                xdoc.Descendants("MetersRead").Remove();
                xdoc.Descendants("ScheduleExecution").Remove();


                //counts number of elements in XML file, limits the size(number of elements) of the new split file to make it so it fits in 24 files.
                foreach (var element in xdoc.Root.Elements())
                {
                    elementCount++;
                    elementsPerFile = elementCount / 24;
                }

                // if file is small enough where it would just be one element per file than just put everything into one file. Also adding 20 elements per file in order to keep num of files to 24 (Temporary?).
                if (elementsPerFile <= 1)
                {
                    elementsPerFile = elementCount;
                }
                else {elementsPerFile = elementsPerFile + 20;}

                foreach (var batch in xdoc.Root.Elements().InSetsOf(elementsPerFile))
                {
                    var newDoc = new XDocument(
                         new XElement("AMRDEF", batch));

                    newDoc.Save($"{saveLocation}\\exportedFile_{++index}.xml");
                    //MessageBox.Show($"Saved at {saveLocation}\\exportedFile_{index}.xml");
                }
                
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
