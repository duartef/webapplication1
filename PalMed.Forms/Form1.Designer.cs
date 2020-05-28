namespace PalMed.Forms
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
            this.btEjecutar = new System.Windows.Forms.Button();
            this.txUltimaEjecucion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txProximaEjecucion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEstado = new System.Windows.Forms.Label();
            this.txUltimoError = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btEjecutar
            // 
            this.btEjecutar.Location = new System.Drawing.Point(651, 421);
            this.btEjecutar.Name = "btEjecutar";
            this.btEjecutar.Size = new System.Drawing.Size(163, 63);
            this.btEjecutar.TabIndex = 0;
            this.btEjecutar.Text = "Ejecutar";
            this.btEjecutar.UseVisualStyleBackColor = true;
            this.btEjecutar.Click += new System.EventHandler(this.btEjecutar_Click);
            // 
            // txUltimaEjecucion
            // 
            this.txUltimaEjecucion.Location = new System.Drawing.Point(277, 6);
            this.txUltimaEjecucion.Name = "txUltimaEjecucion";
            this.txUltimaEjecucion.Size = new System.Drawing.Size(537, 38);
            this.txUltimaEjecucion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Última Ejecución:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Próxima Ejecución:";
            // 
            // txProximaEjecucion
            // 
            this.txProximaEjecucion.Location = new System.Drawing.Point(277, 79);
            this.txProximaEjecucion.Name = "txProximaEjecucion";
            this.txProximaEjecucion.Size = new System.Drawing.Size(537, 38);
            this.txProximaEjecucion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado:";
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(271, 142);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(127, 32);
            this.lbEstado.TabIndex = 6;
            this.lbEstado.Text = "lbEstado";
            // 
            // txUltimoError
            // 
            this.txUltimoError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txUltimoError.Location = new System.Drawing.Point(277, 192);
            this.txUltimoError.Multiline = true;
            this.txUltimoError.Name = "txUltimoError";
            this.txUltimoError.Size = new System.Drawing.Size(537, 223);
            this.txUltimoError.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Último Error:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 496);
            this.Controls.Add(this.txUltimoError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txProximaEjecucion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txUltimaEjecucion);
            this.Controls.Add(this.btEjecutar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEjecutar;
        private System.Windows.Forms.TextBox txUltimaEjecucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txProximaEjecucion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.TextBox txUltimoError;
        private System.Windows.Forms.Label label4;
    }
}

