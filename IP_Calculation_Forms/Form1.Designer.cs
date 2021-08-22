
namespace IP_Calculation_Forms {
    partial class Form {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.lbl_Results = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.lbl_Mask = new System.Windows.Forms.Label();
            this.comboBoxMasks = new System.Windows.Forms.ComboBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.groupBox_btns = new System.Windows.Forms.GroupBox();
            this.btn_Out = new System.Windows.Forms.Button();
            this.txt_IP = new System.Windows.Forms.MaskedTextBox();
            this.panel.SuspendLayout();
            this.groupBox_btns.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(0, 28);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(803, 31);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Calculadora de Rede IPv4";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IP.Location = new System.Drawing.Point(22, 109);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(24, 20);
            this.lbl_IP.TabIndex = 1;
            this.lbl_IP.Text = "IP:";
            // 
            // lbl_Results
            // 
            this.lbl_Results.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Results.Location = new System.Drawing.Point(419, 95);
            this.lbl_Results.Name = "lbl_Results";
            this.lbl_Results.Size = new System.Drawing.Size(348, 130);
            this.lbl_Results.TabIndex = 5;
            this.lbl_Results.Text = "IP da Rede:\r\nIP de Broadcast:\r\nNúmero de hosts válidos:\r\nPrimeiro IP válido:\r\nÚlt" +
    "imo IP válido:\r\nClasse da Rede:";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.SeaGreen;
            this.panel.Controls.Add(this.lbl_Title);
            this.panel.Location = new System.Drawing.Point(0, -10);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(806, 74);
            this.panel.TabIndex = 0;
            // 
            // lbl_Mask
            // 
            this.lbl_Mask.AutoSize = true;
            this.lbl_Mask.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mask.Location = new System.Drawing.Point(22, 178);
            this.lbl_Mask.Name = "lbl_Mask";
            this.lbl_Mask.Size = new System.Drawing.Size(158, 21);
            this.lbl_Mask.TabIndex = 3;
            this.lbl_Mask.Text = "Máscara de sub-rede:";
            // 
            // comboBoxMasks
            // 
            this.comboBoxMasks.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMasks.FormattingEnabled = true;
            this.comboBoxMasks.Location = new System.Drawing.Point(186, 173);
            this.comboBoxMasks.Name = "comboBoxMasks";
            this.comboBoxMasks.Size = new System.Drawing.Size(187, 26);
            this.comboBoxMasks.TabIndex = 4;
            this.comboBoxMasks.SelectedIndexChanged += new System.EventHandler(this.comboBoxMasks_SelectedIndexChanged);
            this.comboBoxMasks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxMasks_KeyDown);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.ForeColor = System.Drawing.Color.Black;
            this.btn_Clear.Location = new System.Drawing.Point(129, 29);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(204, 33);
            this.btn_Clear.TabIndex = 0;
            this.btn_Clear.Text = "Limpar";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // groupBox_btns
            // 
            this.groupBox_btns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.groupBox_btns.Controls.Add(this.btn_Out);
            this.groupBox_btns.Controls.Add(this.btn_Clear);
            this.groupBox_btns.ForeColor = System.Drawing.Color.White;
            this.groupBox_btns.Location = new System.Drawing.Point(26, 239);
            this.groupBox_btns.Name = "groupBox_btns";
            this.groupBox_btns.Size = new System.Drawing.Size(741, 80);
            this.groupBox_btns.TabIndex = 6;
            this.groupBox_btns.TabStop = false;
            // 
            // btn_Out
            // 
            this.btn_Out.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Bold);
            this.btn_Out.ForeColor = System.Drawing.Color.Black;
            this.btn_Out.Location = new System.Drawing.Point(408, 29);
            this.btn_Out.Name = "btn_Out";
            this.btn_Out.Size = new System.Drawing.Size(204, 33);
            this.btn_Out.TabIndex = 1;
            this.btn_Out.Text = "Sair";
            this.btn_Out.UseVisualStyleBackColor = true;
            this.btn_Out.Click += new System.EventHandler(this.btn_Out_Click);
            // 
            // txt_IP
            // 
            this.txt_IP.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.txt_IP.Location = new System.Drawing.Point(52, 109);
            this.txt_IP.Mask = "990.990.990.990";
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(321, 25);
            this.txt_IP.TabIndex = 2;
            this.txt_IP.Text = "192168  0  0";
            this.txt_IP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_IP_KeyDown);
            this.txt_IP.Leave += new System.EventHandler(this.txt_IP_Leave);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(800, 356);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.groupBox_btns);
            this.Controls.Add(this.comboBoxMasks);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lbl_Results);
            this.Controls.Add(this.lbl_Mask);
            this.Controls.Add(this.lbl_IP);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora IP";
            this.panel.ResumeLayout(false);
            this.groupBox_btns.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label lbl_Results;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lbl_Mask;
        private System.Windows.Forms.ComboBox comboBoxMasks;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.GroupBox groupBox_btns;
        private System.Windows.Forms.Button btn_Out;
        private System.Windows.Forms.MaskedTextBox txt_IP;
    }
}

