namespace pdfToExcel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_seleccionarExcel = new System.Windows.Forms.Button();
            this.btn_seleccionarCarpeta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_seleccionarExcel
            // 
            this.btn_seleccionarExcel.Location = new System.Drawing.Point(152, 133);
            this.btn_seleccionarExcel.Name = "btn_seleccionarExcel";
            this.btn_seleccionarExcel.Size = new System.Drawing.Size(104, 45);
            this.btn_seleccionarExcel.TabIndex = 0;
            this.btn_seleccionarExcel.Text = "Seleccionar excel";
            this.btn_seleccionarExcel.UseVisualStyleBackColor = true;
            this.btn_seleccionarExcel.Click += new System.EventHandler(this.btn_seleccionarExcel_Click);
            // 
            // btn_seleccionarCarpeta
            // 
            this.btn_seleccionarCarpeta.Location = new System.Drawing.Point(139, 32);
            this.btn_seleccionarCarpeta.Name = "btn_seleccionarCarpeta";
            this.btn_seleccionarCarpeta.Size = new System.Drawing.Size(137, 60);
            this.btn_seleccionarCarpeta.TabIndex = 1;
            this.btn_seleccionarCarpeta.Text = "Seleccionar carpeta destino";
            this.btn_seleccionarCarpeta.UseVisualStyleBackColor = true;
            this.btn_seleccionarCarpeta.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(412, 239);
            this.Controls.Add(this.btn_seleccionarCarpeta);
            this.Controls.Add(this.btn_seleccionarExcel);
            this.Name = "Form1";
            this.Text = "Pdf to excel";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_seleccionarExcel;
        private System.Windows.Forms.Button btn_seleccionarCarpeta;
    }
}

