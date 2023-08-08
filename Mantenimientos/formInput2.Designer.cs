namespace Mantenimientos
{
    partial class formInput2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMensaje1 = new System.Windows.Forms.Label();
            this.txtIngreso1 = new System.Windows.Forms.TextBox();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMensaje2 = new System.Windows.Forms.Label();
            this.txtIngreso2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMensaje2);
            this.groupBox1.Controls.Add(this.txtIngreso2);
            this.groupBox1.Controls.Add(this.lblMensaje1);
            this.groupBox1.Controls.Add(this.txtIngreso1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblMensaje1
            // 
            this.lblMensaje1.AutoSize = true;
            this.lblMensaje1.Location = new System.Drawing.Point(26, 27);
            this.lblMensaje1.Name = "lblMensaje1";
            this.lblMensaje1.Size = new System.Drawing.Size(35, 13);
            this.lblMensaje1.TabIndex = 1;
            this.lblMensaje1.Text = "label1";
            // 
            // txtIngreso1
            // 
            this.txtIngreso1.Location = new System.Drawing.Point(19, 52);
            this.txtIngreso1.Name = "txtIngreso1";
            this.txtIngreso1.Size = new System.Drawing.Size(331, 20);
            this.txtIngreso1.TabIndex = 0;
            // 
            // btnSalida
            // 
            this.btnSalida.Image = global::Mantenimientos.Properties.Resources.salida_bueno;
            this.btnSalida.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalida.Location = new System.Drawing.Point(502, 57);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(66, 58);
            this.btnSalida.TabIndex = 5;
            this.btnSalida.Text = "Salida";
            this.btnSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Mantenimientos.Properties.Resources.buscando;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(430, 57);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(66, 58);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMensaje2
            // 
            this.lblMensaje2.AutoSize = true;
            this.lblMensaje2.Location = new System.Drawing.Point(26, 90);
            this.lblMensaje2.Name = "lblMensaje2";
            this.lblMensaje2.Size = new System.Drawing.Size(35, 13);
            this.lblMensaje2.TabIndex = 3;
            this.lblMensaje2.Text = "label1";
            // 
            // txtIngreso2
            // 
            this.txtIngreso2.Location = new System.Drawing.Point(19, 115);
            this.txtIngreso2.Name = "txtIngreso2";
            this.txtIngreso2.Size = new System.Drawing.Size(331, 20);
            this.txtIngreso2.TabIndex = 2;
            // 
            // formInput2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 181);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "formInput2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formInput2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblMensaje1;
        private System.Windows.Forms.TextBox txtIngreso1;
        public System.Windows.Forms.Label lblMensaje2;
        private System.Windows.Forms.TextBox txtIngreso2;
    }
}