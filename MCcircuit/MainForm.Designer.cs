namespace MCcircuit
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TestButton = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.PrecentTextBox = new System.Windows.Forms.TextBox();
            this.PrecentLabel = new System.Windows.Forms.Label();
            this.PrecentButton = new System.Windows.Forms.Button();
            this.ScanButton = new System.Windows.Forms.Button();
            this.ScanChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScanChart)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestButton
            // 
            this.TestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestButton.Location = new System.Drawing.Point(436, 422);
            this.TestButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(201, 53);
            this.TestButton.TabIndex = 0;
            this.TestButton.Text = "Brute Force";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextBox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(21, 72);
            this.InputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(699, 25);
            this.InputTextBox.TabIndex = 1;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(27, 132);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(978, 274);
            this.outputTextBox.TabIndex = 2;
            // 
            // PrecentTextBox
            // 
            this.PrecentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrecentTextBox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecentTextBox.Location = new System.Drawing.Point(894, 72);
            this.PrecentTextBox.Name = "PrecentTextBox";
            this.PrecentTextBox.Size = new System.Drawing.Size(111, 25);
            this.PrecentTextBox.TabIndex = 3;
            // 
            // PrecentLabel
            // 
            this.PrecentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrecentLabel.AutoSize = true;
            this.PrecentLabel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecentLabel.Location = new System.Drawing.Point(804, 75);
            this.PrecentLabel.Name = "PrecentLabel";
            this.PrecentLabel.Size = new System.Drawing.Size(76, 17);
            this.PrecentLabel.TabIndex = 4;
            this.PrecentLabel.Text = "Precentage:";
            // 
            // PrecentButton
            // 
            this.PrecentButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PrecentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrecentButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecentButton.Location = new System.Drawing.Point(664, 422);
            this.PrecentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrecentButton.Name = "PrecentButton";
            this.PrecentButton.Size = new System.Drawing.Size(201, 53);
            this.PrecentButton.TabIndex = 5;
            this.PrecentButton.Text = "Precentage Test";
            this.PrecentButton.UseVisualStyleBackColor = true;
            this.PrecentButton.Click += new System.EventHandler(this.PrecentButton_Click);
            // 
            // ScanButton
            // 
            this.ScanButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ScanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScanButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanButton.Location = new System.Drawing.Point(207, 422);
            this.ScanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(201, 53);
            this.ScanButton.TabIndex = 6;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // ScanChart
            // 
            this.ScanChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            chartArea1.Name = "ChartArea1";
            this.ScanChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ScanChart.Legends.Add(legend1);
            this.ScanChart.Location = new System.Drawing.Point(448, 137);
            this.ScanChart.Name = "ScanChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ScanChart.Series.Add(series1);
            this.ScanChart.Size = new System.Drawing.Size(529, 263);
            this.ScanChart.TabIndex = 7;
            this.ScanChart.Text = "ScanChart";
            this.ScanChart.Visible = false;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.TopPanel.Controls.Add(this.exitButton);
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1026, 35);
            this.TopPanel.TabIndex = 8;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(986, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(34, 27);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 486);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.ScanChart);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.PrecentButton);
            this.Controls.Add(this.PrecentLabel);
            this.Controls.Add(this.PrecentTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.TestButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MC";
            ((System.ComponentModel.ISupportInitialize)(this.ScanChart)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox PrecentTextBox;
        private System.Windows.Forms.Label PrecentLabel;
        private System.Windows.Forms.Button PrecentButton;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart ScanChart;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button exitButton;
    }
}

