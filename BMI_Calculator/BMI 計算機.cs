using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtHeight_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeight.Focus(); // 焦點移至體重
                e.SuppressKeyPress = true;
            }
        }

        // 體重欄位：按 Enter 直接計算
        private void txtWeight_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCalculate.PerformClick(); // 模擬點擊計算按鈕
                e.SuppressKeyPress = true;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // --- 加入輸入驗證功能 ---
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);

            // 驗證身高輸入
            if (isHeightValid)
            {
                if (height <= 0)
                {
                    MessageBox.Show("身高必須大於零。", "身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的身高數值。", "身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 驗證體重輸入
            if (isWeightValid)
            {
                if (weight <= 0)
                {
                    MessageBox.Show("體重必須大於零。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的體重數值。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double h_m = height / 100;
            double bmi = Math.Round(weight / (h_m * h_m), 1);

            // 切換顯示狀態
            lblPrompt.Visible = false;
            lblResult.Visible = true;
            lblStatus.Visible = true;
            pbBodyImage.Visible = true;

            lblResult.Text = $"您的 BMI 是：{bmi}";

            if (bmi < 18.5)
            {
                lblStatus.Text = "體態分級：體重過輕";
                lblStatus.ForeColor = lblResult.ForeColor = Color.SteelBlue;
                pbBodyImage.Image = Properties.Resources.體重過輕;
            }
            else if (bmi < 24)
            {
                lblStatus.Text = "體態分級：健康體位";
                lblStatus.ForeColor = lblResult.ForeColor = Color.ForestGreen;
                pbBodyImage.Image = Properties.Resources.健康體位;
            }
            else if (bmi < 27)
            {
                lblStatus.Text = "體態分級：過重";
                // 這裡改成了較深、不刺眼的顏色
                lblStatus.ForeColor = lblResult.ForeColor = Color.DarkGoldenrod;
                pbBodyImage.Image = Properties.Resources.過重;
            }
            else if (bmi < 30)
            {
                lblStatus.Text = "體態分級：輕度肥胖";
                lblStatus.ForeColor = lblResult.ForeColor = Color.Orange;
                pbBodyImage.Image = Properties.Resources.輕度肥胖;
            }
            else if (bmi < 35)
            {
                lblStatus.Text = "體態分級：中度肥胖";
                lblStatus.ForeColor = lblResult.ForeColor = Color.OrangeRed;
                pbBodyImage.Image = Properties.Resources.中度肥胖;
            }
            else // bmi >= 35
            {
                lblStatus.Text = "體態分級：重度肥胖";
                lblStatus.ForeColor = lblResult.ForeColor = Color.Red;
                pbBodyImage.Image = Properties.Resources.重度肥胖;
            }
        }


        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblPrompt_Click(object sender, EventArgs e)
        {

        }

    }
}
