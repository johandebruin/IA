namespace I.A
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lbUrl = new System.Windows.Forms.ListBox();
            this.bUrl = new System.Windows.Forms.Button();
            this.bCampo1 = new System.Windows.Forms.Button();
            this.lbCampo1 = new System.Windows.Forms.ListBox();
            this.tbCampo1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bCampo2 = new System.Windows.Forms.Button();
            this.lbCampo2 = new System.Windows.Forms.ListBox();
            this.tbCampo2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bCampo3 = new System.Windows.Forms.Button();
            this.lbCampo3 = new System.Windows.Forms.ListBox();
            this.tbCampo3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bCampo4 = new System.Windows.Forms.Button();
            this.lbCampo4 = new System.Windows.Forms.ListBox();
            this.tbCampo4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bEntrenar = new System.Windows.Forms.Button();
            this.bCampo5 = new System.Windows.Forms.Button();
            this.lbCampo5 = new System.Windows.Forms.ListBox();
            this.tbCampo5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bEjec1 = new System.Windows.Forms.Button();
            this.bEjecTodos = new System.Windows.Forms.Button();
            this.tbFiltro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL\'s";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(16, 32);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(477, 22);
            this.tbUrl.TabIndex = 1;
            this.tbUrl.TextChanged += new System.EventHandler(this.tbUrl_TextChanged);
            this.tbUrl.Click += new System.EventHandler(this.tbUrl_Click);
            // 
            // lbUrl
            // 
            this.lbUrl.FormattingEnabled = true;
            this.lbUrl.ItemHeight = 16;
            this.lbUrl.Location = new System.Drawing.Point(16, 64);
            this.lbUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(613, 36);
            this.lbUrl.TabIndex = 2;
            this.lbUrl.SelectedIndexChanged += new System.EventHandler(this.lbUrl_SelectedIndexChanged);
            // 
            // bUrl
            // 
            this.bUrl.Location = new System.Drawing.Point(504, 32);
            this.bUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bUrl.Name = "bUrl";
            this.bUrl.Size = new System.Drawing.Size(127, 28);
            this.bUrl.TabIndex = 3;
            this.bUrl.Text = "AñadirURL";
            this.bUrl.UseVisualStyleBackColor = true;
            this.bUrl.Click += new System.EventHandler(this.bUrl_Click);
            // 
            // bCampo1
            // 
            this.bCampo1.Location = new System.Drawing.Point(504, 133);
            this.bCampo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCampo1.Name = "bCampo1";
            this.bCampo1.Size = new System.Drawing.Size(127, 28);
            this.bCampo1.TabIndex = 7;
            this.bCampo1.Text = "AñadirCampo1";
            this.bCampo1.UseVisualStyleBackColor = true;
            this.bCampo1.Click += new System.EventHandler(this.bCampo1_Click);
            // 
            // lbCampo1
            // 
            this.lbCampo1.FormattingEnabled = true;
            this.lbCampo1.ItemHeight = 16;
            this.lbCampo1.Location = new System.Drawing.Point(16, 165);
            this.lbCampo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbCampo1.Name = "lbCampo1";
            this.lbCampo1.Size = new System.Drawing.Size(613, 36);
            this.lbCampo1.TabIndex = 6;
            this.lbCampo1.SelectedIndexChanged += new System.EventHandler(this.lbCampo1_SelectedIndexChanged);
            // 
            // tbCampo1
            // 
            this.tbCampo1.Location = new System.Drawing.Point(16, 133);
            this.tbCampo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCampo1.Name = "tbCampo1";
            this.tbCampo1.Size = new System.Drawing.Size(477, 22);
            this.tbCampo1.TabIndex = 5;
            this.tbCampo1.Click += new System.EventHandler(this.tbCampo1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Campo1";
            // 
            // bCampo2
            // 
            this.bCampo2.Location = new System.Drawing.Point(504, 229);
            this.bCampo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCampo2.Name = "bCampo2";
            this.bCampo2.Size = new System.Drawing.Size(127, 28);
            this.bCampo2.TabIndex = 11;
            this.bCampo2.Text = "AñadirCampo2";
            this.bCampo2.UseVisualStyleBackColor = true;
            this.bCampo2.Click += new System.EventHandler(this.bCampo2_Click);
            // 
            // lbCampo2
            // 
            this.lbCampo2.FormattingEnabled = true;
            this.lbCampo2.ItemHeight = 16;
            this.lbCampo2.Location = new System.Drawing.Point(16, 261);
            this.lbCampo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbCampo2.Name = "lbCampo2";
            this.lbCampo2.Size = new System.Drawing.Size(613, 36);
            this.lbCampo2.TabIndex = 10;
            // 
            // tbCampo2
            // 
            this.tbCampo2.Location = new System.Drawing.Point(16, 229);
            this.tbCampo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCampo2.Name = "tbCampo2";
            this.tbCampo2.Size = new System.Drawing.Size(477, 22);
            this.tbCampo2.TabIndex = 9;
            this.tbCampo2.Click += new System.EventHandler(this.tbCampo2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Campo2";
            // 
            // bCampo3
            // 
            this.bCampo3.Location = new System.Drawing.Point(504, 326);
            this.bCampo3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCampo3.Name = "bCampo3";
            this.bCampo3.Size = new System.Drawing.Size(127, 28);
            this.bCampo3.TabIndex = 15;
            this.bCampo3.Text = "AñadirCampo3";
            this.bCampo3.UseVisualStyleBackColor = true;
            this.bCampo3.Click += new System.EventHandler(this.bCampo3_Click);
            // 
            // lbCampo3
            // 
            this.lbCampo3.FormattingEnabled = true;
            this.lbCampo3.ItemHeight = 16;
            this.lbCampo3.Location = new System.Drawing.Point(16, 358);
            this.lbCampo3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbCampo3.Name = "lbCampo3";
            this.lbCampo3.Size = new System.Drawing.Size(613, 36);
            this.lbCampo3.TabIndex = 14;
            // 
            // tbCampo3
            // 
            this.tbCampo3.Location = new System.Drawing.Point(16, 326);
            this.tbCampo3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCampo3.Name = "tbCampo3";
            this.tbCampo3.Size = new System.Drawing.Size(477, 22);
            this.tbCampo3.TabIndex = 13;
            this.tbCampo3.Click += new System.EventHandler(this.tbCampo3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 305);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Campo3";
            // 
            // bCampo4
            // 
            this.bCampo4.Location = new System.Drawing.Point(504, 422);
            this.bCampo4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCampo4.Name = "bCampo4";
            this.bCampo4.Size = new System.Drawing.Size(127, 28);
            this.bCampo4.TabIndex = 19;
            this.bCampo4.Text = "AñadirCampo4";
            this.bCampo4.UseVisualStyleBackColor = true;
            this.bCampo4.Click += new System.EventHandler(this.bCampo4_Click);
            // 
            // lbCampo4
            // 
            this.lbCampo4.FormattingEnabled = true;
            this.lbCampo4.ItemHeight = 16;
            this.lbCampo4.Location = new System.Drawing.Point(16, 454);
            this.lbCampo4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbCampo4.Name = "lbCampo4";
            this.lbCampo4.Size = new System.Drawing.Size(613, 36);
            this.lbCampo4.TabIndex = 18;
            this.lbCampo4.SelectedIndexChanged += new System.EventHandler(this.lbCampo4_SelectedIndexChanged);
            // 
            // tbCampo4
            // 
            this.tbCampo4.Location = new System.Drawing.Point(16, 422);
            this.tbCampo4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCampo4.Name = "tbCampo4";
            this.tbCampo4.Size = new System.Drawing.Size(477, 22);
            this.tbCampo4.TabIndex = 17;
            this.tbCampo4.Click += new System.EventHandler(this.tbCampo4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 401);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Campo4";
            // 
            // bEntrenar
            // 
            this.bEntrenar.Location = new System.Drawing.Point(16, 613);
            this.bEntrenar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bEntrenar.Name = "bEntrenar";
            this.bEntrenar.Size = new System.Drawing.Size(100, 28);
            this.bEntrenar.TabIndex = 20;
            this.bEntrenar.Text = "Entrenar";
            this.bEntrenar.UseVisualStyleBackColor = true;
            this.bEntrenar.Click += new System.EventHandler(this.bEntrenar_Click);
            // 
            // bCampo5
            // 
            this.bCampo5.Location = new System.Drawing.Point(504, 522);
            this.bCampo5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCampo5.Name = "bCampo5";
            this.bCampo5.Size = new System.Drawing.Size(127, 28);
            this.bCampo5.TabIndex = 24;
            this.bCampo5.Text = "AñadirCampo4";
            this.bCampo5.UseVisualStyleBackColor = true;
            // 
            // lbCampo5
            // 
            this.lbCampo5.FormattingEnabled = true;
            this.lbCampo5.ItemHeight = 16;
            this.lbCampo5.Location = new System.Drawing.Point(16, 554);
            this.lbCampo5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbCampo5.Name = "lbCampo5";
            this.lbCampo5.Size = new System.Drawing.Size(613, 36);
            this.lbCampo5.TabIndex = 23;
            // 
            // tbCampo5
            // 
            this.tbCampo5.Location = new System.Drawing.Point(16, 522);
            this.tbCampo5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCampo5.Name = "tbCampo5";
            this.tbCampo5.Size = new System.Drawing.Size(477, 22);
            this.tbCampo5.TabIndex = 22;
            this.tbCampo5.Click += new System.EventHandler(this.tbCampo5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 501);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Campo5";
            // 
            // bEjec1
            // 
            this.bEjec1.Location = new System.Drawing.Point(124, 596);
            this.bEjec1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bEjec1.Name = "bEjec1";
            this.bEjec1.Size = new System.Drawing.Size(100, 28);
            this.bEjec1.TabIndex = 25;
            this.bEjec1.Text = "Ejec1";
            this.bEjec1.UseVisualStyleBackColor = true;
            this.bEjec1.Click += new System.EventHandler(this.bEjec1_Click);
            // 
            // bEjecTodos
            // 
            this.bEjecTodos.Location = new System.Drawing.Point(124, 626);
            this.bEjecTodos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bEjecTodos.Name = "bEjecTodos";
            this.bEjecTodos.Size = new System.Drawing.Size(100, 28);
            this.bEjecTodos.TabIndex = 26;
            this.bEjecTodos.Text = "EjecTodos";
            this.bEjecTodos.UseVisualStyleBackColor = true;
            this.bEjecTodos.Click += new System.EventHandler(this.bEjecTodos_Click);
            // 
            // tbFiltro
            // 
            this.tbFiltro.Location = new System.Drawing.Point(232, 613);
            this.tbFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(397, 22);
            this.tbFiltro.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 656);
            this.Controls.Add(this.tbFiltro);
            this.Controls.Add(this.bEjecTodos);
            this.Controls.Add(this.bEjec1);
            this.Controls.Add(this.bCampo5);
            this.Controls.Add(this.lbCampo5);
            this.Controls.Add(this.tbCampo5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bEntrenar);
            this.Controls.Add(this.bCampo4);
            this.Controls.Add(this.lbCampo4);
            this.Controls.Add(this.tbCampo4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bCampo3);
            this.Controls.Add(this.lbCampo3);
            this.Controls.Add(this.tbCampo3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bCampo2);
            this.Controls.Add(this.lbCampo2);
            this.Controls.Add(this.tbCampo2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bCampo1);
            this.Controls.Add(this.lbCampo1);
            this.Controls.Add(this.tbCampo1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bUrl);
            this.Controls.Add(this.lbUrl);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Inteligencia Artificial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.ListBox lbUrl;
        private System.Windows.Forms.Button bUrl;
        private System.Windows.Forms.Button bCampo1;
        private System.Windows.Forms.ListBox lbCampo1;
        private System.Windows.Forms.TextBox tbCampo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCampo2;
        private System.Windows.Forms.ListBox lbCampo2;
        private System.Windows.Forms.TextBox tbCampo2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bCampo3;
        private System.Windows.Forms.ListBox lbCampo3;
        private System.Windows.Forms.TextBox tbCampo3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bCampo4;
        private System.Windows.Forms.ListBox lbCampo4;
        private System.Windows.Forms.TextBox tbCampo4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bEntrenar;
        private System.Windows.Forms.Button bCampo5;
        private System.Windows.Forms.ListBox lbCampo5;
        private System.Windows.Forms.TextBox tbCampo5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bEjec1;
        private System.Windows.Forms.Button bEjecTodos;
        private System.Windows.Forms.TextBox tbFiltro;
    }
}

