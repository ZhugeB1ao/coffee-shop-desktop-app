using CoffeeShop.BUS;
using CoffeeShop.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CoffeeShop
{
    /// <summary>
    /// Revenue Statistics Form: Displays revenue reports and charts over time.
    /// </summary>
    public partial class RevenueStatisticsForm : Form
    {
        private BillService billService = new BillService();

        public RevenueStatisticsForm()
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);
            
            // Register the Click event for the Statistic button if not done in the Designer.
            this.buttonStatistic.Click += buttonStatistic_Click;
        }

        private void RevenueStatisticsForm_Load(object sender, EventArgs e)
        {
            LoadDateTimePicker(); // Default to viewing the current month.
            LoadBillListByDate(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }

        // Set default date pickers from the start to the end of the current month.
        private void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dateTimePickerFrom.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePickerTo.Value = dateTimePickerFrom.Value.AddMonths(1).AddDays(-1);
        }

        // Load the list of bills from the database based on the date range.
        private void LoadBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            // Normalize time (From 00:00:00 on the start date to 23:59:59 on the end date).
            DateTime from = checkIn.Date;
            DateTime to = checkOut.Date.AddDays(1).AddTicks(-1);

            var bills = billService.GetBillListByDate(from, to).ToList();
            
            // Clear the existing grid to avoid column duplication.
            dataGridViewStatistic.AutoGenerateColumns = false;
            dataGridViewStatistic.DataSource = null;
            dataGridViewStatistic.Columns.Clear();

            // Manually create DataGridView columns (synced with SQL dynamic objects).
            dataGridViewStatistic.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TableName", HeaderText = "Table Name", Width = 150 });
            dataGridViewStatistic.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Total Price", Width = 150 });
            dataGridViewStatistic.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CheckIn", HeaderText = "Check In", Width = 250 });
            dataGridViewStatistic.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CheckOut", HeaderText = "Check Out", Width = 250 });

            dataGridViewStatistic.DataSource = bills;
            
            // Enable scrolling for large datasets.
            dataGridViewStatistic.ScrollBars = ScrollBars.Both;

            // Update the visual chart.
            UpdateChart(bills);
        }

        /// <summary>
        /// Renders a column chart for revenue.
        /// Data is grouped by date.
        /// </summary>
        private void UpdateChart(List<dynamic> bills)
        {
            chartRevenue.Series["Revenue"].Points.Clear();
            
            // Apply colors synced with the main interface.
            chartRevenue.BackColor = UIHelper.BackColor;
            chartRevenue.ChartAreas[0].BackColor = Color.White;
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.ForeColor = UIHelper.TextBodyColor;
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.ForeColor = UIHelper.TextBodyColor;
            chartRevenue.ChartAreas[0].AxisX.TitleForeColor = UIHelper.TextHeaderColor;
            chartRevenue.ChartAreas[0].AxisY.TitleForeColor = UIHelper.TextHeaderColor;
            chartRevenue.Legends[0].BackColor = UIHelper.BackColor;
            chartRevenue.Legends[0].ForeColor = UIHelper.TextBodyColor;

            // Group bill data by date to calculate daily revenue.
            var chartData = bills
                .GroupBy(b => ((DateTime)b.CheckOut).Date)
                .Select(g => new { Date = g.Key, TotalPrice = g.Sum(b => (double)b.TotalPrice) })
                .OrderBy(x => x.Date)
                .ToList();

            // Add data points to the chart.
            foreach (var item in chartData)
            {
                int pointIndex = chartRevenue.Series["Revenue"].Points.AddXY(item.Date.ToString("dd/MM"), item.TotalPrice);
                chartRevenue.Series["Revenue"].Points[pointIndex].Color = UIHelper.PrimaryColor;
            }

            // Customize axis title display.
            chartRevenue.ChartAreas[0].AxisX.Title = "Date";
            chartRevenue.ChartAreas[0].AxisY.Title = "Revenue (VND)";
            chartRevenue.Series["Revenue"].ChartType = SeriesChartType.Column;
            chartRevenue.Series["Revenue"]["PixelPointWidth"] = "30";
        }

        // Triggered when the user clicks the 'Statistic' button.
        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadBillListByDate(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }
    }
}
