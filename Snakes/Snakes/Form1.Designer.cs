namespace Snakes
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.playBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playBut
            // 
            this.playBut.BackColor = System.Drawing.Color.Snow;
            this.playBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playBut.Location = new System.Drawing.Point(210, 197);
            this.playBut.Name = "playBut";
            this.playBut.Size = new System.Drawing.Size(224, 83);
            this.playBut.TabIndex = 0;
            this.playBut.Text = "Play the Game";
            this.playBut.UseVisualStyleBackColor = false;
            this.playBut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playBut_MouseClick);
            this.playBut.MouseLeave += new System.EventHandler(this.playBut_MouseLeave);
            this.playBut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playBut_MouseMove);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(673, 457);
            this.Controls.Add(this.playBut);
            this.Name = "MainMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBut;
    }
}

