using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FTD_BlockReplacer
{
    public partial class Form1 : Form
    {
        private string[][] blockidsnew;
        private readonly string initdir;
        public Form1()
        {
            InitializeComponent();
            initdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "From The Depths/Player Profiles");
            blockidsnew = new string[3][] { BlockIDs.Woods, BlockIDs.Metals ,BlockIDs.Alloys};
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Blueprintファイル|*.blueprint";
            openFileDialog1.Title = "BP選択";
            if (Directory.Exists(initdir))
            {
                openFileDialog1.InitialDirectory = initdir;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BPPath.Text = openFileDialog1.FileName;
            }
        }

        private void replace_Click(object sender, EventArgs e)
        {
            string bp = File.ReadAllText(openFileDialog1.FileName);
            JObject json = JObject.Parse(bp);
            JObject blueprint = (JObject)json["Blueprint"];
            JObject itemdic = (JObject)json["ItemDictionary"];
            JArray blocks = (JArray)blueprint["BlockIds"];
            for (int i = 0; i < blocks.Count; i++)
            {
                int a = System.Convert.ToInt32(blocks[i].ToString());
                for (int ia = 0; ia < blockidsnew[BeforeBlock.SelectedIndex].Length; ia = ia + 2)
                {
                    if (a.ToString() == blockidsnew[BeforeBlock.SelectedIndex][ia])
                    {
                        blocks[i] = Convert.ToInt32(blockidsnew[AfterBlock.SelectedIndex][ia]);
                    }
                }
            }
            for (int ia = 0; ia < blockidsnew[AfterBlock.SelectedIndex].Length; ia = ia + 2)
            {
                if (!itemdic.ContainsKey(blockidsnew[AfterBlock.SelectedIndex][ia]))
                {
                    itemdic.Last.AddAfterSelf(new JProperty(blockidsnew[AfterBlock.SelectedIndex][ia], blockidsnew[AfterBlock.SelectedIndex][ia + 1]));
                }
            }
            File.WriteAllText(openFileDialog1.FileName, json.ToString());
        }

   
    }
}
