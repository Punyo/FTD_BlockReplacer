using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace FTD_BlockReplacer
{
    public partial class Form1 : Form
    {
        private string[][] blockidsnew;
        private static readonly string initdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "From The Depths/Player Profiles");
        private readonly string backupdir = Path.Combine(Directory.GetCurrentDirectory(), backupfoldername);
        private static readonly string backupfoldername = "BPBackups";
        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists(backupdir))
            {
                Directory.CreateDirectory(backupdir);
            }
            blockidsnew = new string[6][] { BlockIDs.Woods, BlockIDs.Metals, BlockIDs.Alloys, BlockIDs.Stones, BlockIDs.Leads, BlockIDs.HAs };
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
            List<int> existblocksid = new List<int>();
            List<string> existblocksdata = new List<string>();
            string bp;
            string path;
            if (openFileDialog1.FileName != "openFileDialog1")
            {
                path = openFileDialog1.FileName;
            }
            else
            {
                path = BPPath.Text;
            }
            try
            {
                bp = File.ReadAllText(path);
                File.WriteAllText(Path.Combine(backupdir, $"[BACKUP]{openFileDialog1.SafeFileName}"), bp);
                JObject json = JObject.Parse(bp);
                JObject blueprint = (JObject)json["Blueprint"];
                JObject itemdic = (JObject)json["ItemDictionary"];
                JArray blocks = (JArray)blueprint["BlockIds"];
                for (int ia = 1; ia < blockidsnew[BeforeBlock.SelectedIndex].Length; ia = ia + 2)
                {
                    int index = bp.IndexOf(blockidsnew[BeforeBlock.SelectedIndex][ia]);
                    if (index != -1)
                    {
                        existblocksdata.Add(blockidsnew[BeforeBlock.SelectedIndex][ia]);
                        string id = bp.Substring(index - 9, 9);
                        existblocksid.Add(int.Parse(Regex.Replace(id, "[^0-9]", string.Empty)));
                    }
                }
                for (int i = 0; i < blockidsnew[BeforeBlock.SelectedIndex].Length; i++)
                {
                    for (int ia = 0; ia < existblocksdata.Count; ia++)
                    {
                        if (blockidsnew[BeforeBlock.SelectedIndex][i] == existblocksdata[ia])
                        {
                            blockidsnew[BeforeBlock.SelectedIndex][i - 1] = existblocksid[ia].ToString();
                        }
                    }
                }
                existblocksid.Clear();
                existblocksdata.Clear();
                for (int ia = 1; ia < blockidsnew[AfterBlock.SelectedIndex].Length; ia = ia + 2)
                {
                    int index = bp.IndexOf(blockidsnew[AfterBlock.SelectedIndex][ia]);
                    if (index != -1)
                    {
                        existblocksdata.Add(blockidsnew[AfterBlock.SelectedIndex][ia]);
                        string id = bp.Substring(index - 9, 9);
                        existblocksid.Add(int.Parse(Regex.Replace(id, "[^0-9]", string.Empty)));
                    }
                }
                for (int i = 0; i < blockidsnew[AfterBlock.SelectedIndex].Length; i++)
                {
                    for (int ia = 0; ia < existblocksdata.Count; ia++)
                    {
                        if (blockidsnew[AfterBlock.SelectedIndex][i] == existblocksdata[ia])
                        {
                            blockidsnew[AfterBlock.SelectedIndex][i - 1] = existblocksid[ia].ToString();
                        }
                    }
                }
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
                    //for (int b = 1; b < blockidsnew[BeforeBlock.SelectedIndex].Length; b = b + 2)
                    //{
                    //    if (!itemdic.Va)
                    //    {
                    //        //itemdic.Last.AddAfterSelf(new JProperty(blockidsnew[AfterBlock.SelectedIndex][ia], blockidsnew[AfterBlock.SelectedIndex][ia + 1]));
                    //    }
                    //}
                }
                for (int ia = 0; ia < blockidsnew[AfterBlock.SelectedIndex].Length; ia = ia + 2)
                {
                    if (!itemdic.ContainsKey(blockidsnew[AfterBlock.SelectedIndex][ia]))
                    {
                        itemdic.Last.AddAfterSelf(new JProperty(blockidsnew[AfterBlock.SelectedIndex][ia], blockidsnew[AfterBlock.SelectedIndex][ia + 1]));
                    }
                }
                for (int ia = 0; ia < blockidsnew[BeforeBlock.SelectedIndex].Length; ia = ia + 2)
                {
                    if (!itemdic.ContainsKey(blockidsnew[BeforeBlock.SelectedIndex][ia]))
                    {
                        itemdic.Last.AddBeforeSelf(new JProperty(blockidsnew[BeforeBlock.SelectedIndex][ia], blockidsnew[BeforeBlock.SelectedIndex][ia + 1]));

                    }
                }
                File.WriteAllText(path, json.ToString());
                MessageBox.Show("置き換え完了");
            }
            catch (Exception ex)
            {
                if (ex.GetType()==typeof(NotSupportedException))
                {
                    MessageBox.Show("形式が間違っています");
                }
                else if (ex.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show("ファイルが見つかりません");
                }
                else
                {
                    throw ex;
                }
            }
           
        }
    }
}
