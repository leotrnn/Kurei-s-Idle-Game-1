namespace IdleGameV1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnClick = new System.Windows.Forms.Button();
            this.lblCPS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(167, 553);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(37, 13);
            this.lblCounter.TabIndex = 1;
            this.lblCounter.Text = "aaaaa";
            // 
            // btnClick
            // 
            this.btnClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClick.Location = new System.Drawing.Point(12, 12);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(358, 358);
            this.btnClick.TabIndex = 2;
            this.btnClick.Text = "button1";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.UserClick);
            // 
            // lblCPS
            // 
            this.lblCPS.AutoSize = true;
            this.lblCPS.Location = new System.Drawing.Point(170, 399);
            this.lblCPS.Name = "lblCPS";
            this.lblCPS.Size = new System.Drawing.Size(35, 13);
            this.lblCPS.TabIndex = 4;
            this.lblCPS.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 575);
            this.Controls.Add(this.lblCPS);
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.lblCounter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kurei\'s idle Game 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.Label lblCPS;
    }
}

