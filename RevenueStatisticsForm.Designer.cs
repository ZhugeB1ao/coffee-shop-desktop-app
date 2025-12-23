namespace CoffeeShop
{
    partial class RevenueStatisticsForm
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
            panel1 = new Panel();
            dataGridViewStatistic = new DataGridView();
            panel2 = new Panel();
            buttonStatistic = new Button();
            dateTimePickerTo = new DateTimePicker();
            dateTimePickerFrom = new DateTimePicker();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatistic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(chartRevenue);
            panel1.Controls.Add(dataGridViewStatistic);
            panel1.Location = new Point(3, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(1640, 603);
            panel1.TabIndex = 1;
            // 
            // dataGridViewStatistic
            // 
            dataGridViewStatistic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStatistic.Location = new Point(3, 3);
            dataGridViewStatistic.Name = "dataGridViewStatistic";
            dataGridViewStatistic.RowHeadersWidth = 82;
            dataGridViewStatistic.Size = new Size(750, 591);
            dataGridViewStatistic.TabIndex = 0;
            // 
            // chartRevenue
            // 
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartRevenue.Legends.Add(legend1);
            chartRevenue.Location = new Point(760, 3);
            chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Revenue";
            chartRevenue.Series.Add(series1);
            chartRevenue.Size = new Size(870, 591);
            chartRevenue.TabIndex = 1;
            chartRevenue.Text = "chartRevenue";
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonStatistic);
            panel2.Controls.Add(dateTimePickerTo);
            panel2.Controls.Add(dateTimePickerFrom);
            panel2.Location = new Point(6, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(750, 119);
            panel2.TabIndex = 2;
            // 
            // buttonStatistic
            // 
            buttonStatistic.Location = new Point(535, 9);
            buttonStatistic.Name = "buttonStatistic";
            buttonStatistic.Size = new Size(200, 99);
            buttonStatistic.TabIndex = 2;
            buttonStatistic.Text = "Statistic";
            buttonStatistic.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(9, 69);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(466, 39);
            dateTimePickerTo.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(9, 9);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(466, 39);
            dateTimePickerFrom.TabIndex = 0;
            // 
            // RevenueStatisticsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1648, 734);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "RevenueStatisticsForm";
            Text = "RevenueStatisticsForm";
            Load += RevenueStatisticsForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatistic).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private DataGridView dataGridViewStatistic;
        private Panel panel2;
        private Button buttonStatistic;
        private DateTimePicker dateTimePickerTo;
        private DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
    }
}