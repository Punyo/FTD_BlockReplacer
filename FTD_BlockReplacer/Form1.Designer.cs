
namespace FTD_BlockReplacer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BPPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BeforeBlock = new System.Windows.Forms.ComboBox();
            this.AfterBlock = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.replace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BPPath
            // 
            this.BPPath.Location = new System.Drawing.Point(12, 83);
            this.BPPath.Name = "BPPath";
            this.BPPath.Size = new System.Drawing.Size(726, 22);
            this.BPPath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = ".....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "ブロックを置き換えるBPのパス";
            // 
            // BeforeBlock
            // 
            this.BeforeBlock.FormattingEnabled = true;
            this.BeforeBlock.Items.AddRange(new object[] {
            "木材(Wood)",
            "鉄(Metal)",
            "軽合金(Light-weight Alloy)",
            "石(Stone)",
            "鉛(Lead)",
            "ヘビーアーマー(Heavy Armour)",
            "ゴム(Rubber)"});
            this.BeforeBlock.Location = new System.Drawing.Point(12, 228);
            this.BeforeBlock.Name = "BeforeBlock";
            this.BeforeBlock.Size = new System.Drawing.Size(321, 23);
            this.BeforeBlock.TabIndex = 3;
            // 
            // AfterBlock
            // 
            this.AfterBlock.FormattingEnabled = true;
            this.AfterBlock.Items.AddRange(new object[] {
            "木材(Wood)",
            "鉄(Metal)",
            "軽合金(Light-weight Alloy)",
            "石(Stone)",
            "鉛(Lead)",
            "ヘビーアーマー(Heavy Armour)",
            "ゴム(Rubber)"});
            this.AfterBlock.Location = new System.Drawing.Point(467, 228);
            this.AfterBlock.Name = "AfterBlock";
            this.AfterBlock.Size = new System.Drawing.Size(321, 23);
            this.AfterBlock.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "置き換え前のブロック";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "置き換え後のブロック";
            // 
            // replace
            // 
            this.replace.Location = new System.Drawing.Point(12, 371);
            this.replace.Name = "replace";
            this.replace.Size = new System.Drawing.Size(776, 23);
            this.replace.TabIndex = 7;
            this.replace.Text = "置き換え";
            this.replace.UseVisualStyleBackColor = true;
            this.replace.Click += new System.EventHandler(this.replace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.replace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AfterBlock);
            this.Controls.Add(this.BeforeBlock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BPPath);
            this.Name = "Form1";
            this.Text = "FTD_BlockReplace(材質変換機)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox BPPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BeforeBlock;
        private System.Windows.Forms.ComboBox AfterBlock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button replace;
    }
}

