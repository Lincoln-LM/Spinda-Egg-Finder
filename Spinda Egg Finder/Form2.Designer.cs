namespace Spinda_Egg_Finder
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.PainterPIDBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PIDRadio = new System.Windows.Forms.RadioButton();
            this.SpotRadio = new System.Windows.Forms.RadioButton();
            this.SpindaPicture = new System.Windows.Forms.PictureBox();
            this.OverlayCheck = new System.Windows.Forms.CheckBox();
            this.Spot1X = new System.Windows.Forms.NumericUpDown();
            this.Spot1Y = new System.Windows.Forms.NumericUpDown();
            this.Spot2Y = new System.Windows.Forms.NumericUpDown();
            this.Spot2X = new System.Windows.Forms.NumericUpDown();
            this.Spot3Y = new System.Windows.Forms.NumericUpDown();
            this.Spot3X = new System.Windows.Forms.NumericUpDown();
            this.Spot4Y = new System.Windows.Forms.NumericUpDown();
            this.Spot4X = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpindaPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot3Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot4Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot4X)).BeginInit();
            this.SuspendLayout();
            // 
            // PainterPIDBox
            // 
            this.PainterPIDBox.Location = new System.Drawing.Point(57, 357);
            this.PainterPIDBox.Name = "PainterPIDBox";
            this.PainterPIDBox.Size = new System.Drawing.Size(100, 20);
            this.PainterPIDBox.TabIndex = 0;
            this.PainterPIDBox.TextChanged += new System.EventHandler(this.PIDUpdated);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PIDRadio
            // 
            this.PIDRadio.AutoSize = true;
            this.PIDRadio.Checked = true;
            this.PIDRadio.Location = new System.Drawing.Point(12, 357);
            this.PIDRadio.Name = "PIDRadio";
            this.PIDRadio.Size = new System.Drawing.Size(46, 17);
            this.PIDRadio.TabIndex = 2;
            this.PIDRadio.TabStop = true;
            this.PIDRadio.Text = "PID:";
            this.PIDRadio.UseVisualStyleBackColor = true;
            // 
            // SpotRadio
            // 
            this.SpotRadio.AutoSize = true;
            this.SpotRadio.Location = new System.Drawing.Point(308, 12);
            this.SpotRadio.Name = "SpotRadio";
            this.SpotRadio.Size = new System.Drawing.Size(14, 13);
            this.SpotRadio.TabIndex = 3;
            this.SpotRadio.UseVisualStyleBackColor = true;
            // 
            // SpindaPicture
            // 
            this.SpindaPicture.Location = new System.Drawing.Point(12, 12);
            this.SpindaPicture.Name = "SpindaPicture";
            this.SpindaPicture.Size = new System.Drawing.Size(260, 295);
            this.SpindaPicture.TabIndex = 4;
            this.SpindaPicture.TabStop = false;
            // 
            // OverlayCheck
            // 
            this.OverlayCheck.AutoSize = true;
            this.OverlayCheck.Location = new System.Drawing.Point(164, 359);
            this.OverlayCheck.Name = "OverlayCheck";
            this.OverlayCheck.Size = new System.Drawing.Size(62, 17);
            this.OverlayCheck.TabIndex = 5;
            this.OverlayCheck.Text = "Overlay";
            this.OverlayCheck.UseVisualStyleBackColor = true;
            // 
            // Spot1X
            // 
            this.Spot1X.Location = new System.Drawing.Point(328, 31);
            this.Spot1X.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot1X.Name = "Spot1X";
            this.Spot1X.Size = new System.Drawing.Size(39, 20);
            this.Spot1X.TabIndex = 6;
            this.Spot1X.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // Spot1Y
            // 
            this.Spot1Y.Location = new System.Drawing.Point(373, 31);
            this.Spot1Y.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot1Y.Name = "Spot1Y";
            this.Spot1Y.Size = new System.Drawing.Size(39, 20);
            this.Spot1Y.TabIndex = 7;
            this.Spot1Y.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // Spot2Y
            // 
            this.Spot2Y.Location = new System.Drawing.Point(373, 57);
            this.Spot2Y.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot2Y.Name = "Spot2Y";
            this.Spot2Y.Size = new System.Drawing.Size(39, 20);
            this.Spot2Y.TabIndex = 9;
            this.Spot2Y.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // Spot2X
            // 
            this.Spot2X.Location = new System.Drawing.Point(328, 57);
            this.Spot2X.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot2X.Name = "Spot2X";
            this.Spot2X.Size = new System.Drawing.Size(39, 20);
            this.Spot2X.TabIndex = 8;
            this.Spot2X.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // Spot3Y
            // 
            this.Spot3Y.Location = new System.Drawing.Point(373, 83);
            this.Spot3Y.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot3Y.Name = "Spot3Y";
            this.Spot3Y.Size = new System.Drawing.Size(39, 20);
            this.Spot3Y.TabIndex = 11;
            this.Spot3Y.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // Spot3X
            // 
            this.Spot3X.Location = new System.Drawing.Point(328, 83);
            this.Spot3X.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot3X.Name = "Spot3X";
            this.Spot3X.Size = new System.Drawing.Size(39, 20);
            this.Spot3X.TabIndex = 10;
            this.Spot3X.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // Spot4Y
            // 
            this.Spot4Y.Location = new System.Drawing.Point(373, 109);
            this.Spot4Y.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot4Y.Name = "Spot4Y";
            this.Spot4Y.Size = new System.Drawing.Size(39, 20);
            this.Spot4Y.TabIndex = 13;
            this.Spot4Y.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // Spot4X
            // 
            this.Spot4X.Location = new System.Drawing.Point(328, 109);
            this.Spot4X.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Spot4X.Name = "Spot4X";
            this.Spot4X.Size = new System.Drawing.Size(39, 20);
            this.Spot4X.TabIndex = 12;
            this.Spot4X.ValueChanged += new System.EventHandler(this.SpotUpdated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Spot1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Spot2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Spot3:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Spot4:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Spot4Y);
            this.Controls.Add(this.Spot4X);
            this.Controls.Add(this.Spot3Y);
            this.Controls.Add(this.Spot3X);
            this.Controls.Add(this.Spot2Y);
            this.Controls.Add(this.Spot2X);
            this.Controls.Add(this.Spot1Y);
            this.Controls.Add(this.Spot1X);
            this.Controls.Add(this.OverlayCheck);
            this.Controls.Add(this.SpindaPicture);
            this.Controls.Add(this.SpotRadio);
            this.Controls.Add(this.PIDRadio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PainterPIDBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Painter";
            ((System.ComponentModel.ISupportInitialize)(this.SpindaPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot3Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot4Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spot4X)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PainterPIDBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton PIDRadio;
        private System.Windows.Forms.RadioButton SpotRadio;
        private System.Windows.Forms.PictureBox SpindaPicture;
        private System.Windows.Forms.CheckBox OverlayCheck;
        private System.Windows.Forms.NumericUpDown Spot1X;
        private System.Windows.Forms.NumericUpDown Spot1Y;
        private System.Windows.Forms.NumericUpDown Spot2Y;
        private System.Windows.Forms.NumericUpDown Spot2X;
        private System.Windows.Forms.NumericUpDown Spot3Y;
        private System.Windows.Forms.NumericUpDown Spot3X;
        private System.Windows.Forms.NumericUpDown Spot4Y;
        private System.Windows.Forms.NumericUpDown Spot4X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}