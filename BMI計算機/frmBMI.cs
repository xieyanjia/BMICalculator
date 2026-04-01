using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class frmBMI : Form
    {
        List<string> bmiHistory = new List<string>();

        public frmBMI()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);
            // 驗證身高輸入
            if (isHeightValid)
            {
                if (height <= 0)
                {
                    MessageBox.Show("身高必須大於零。", "身高值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的身高數值。", "身高值錯誤",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 驗證體重輸入
            if (isWeightValid)
            {
                if (weight <= 0)
                {
                    MessageBox.Show("體重必須大於零。", "體重值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的體重數值。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 將身高從公分轉換為公尺
            height = height / 100;
            // 計算BMI
            double bmi = weight / (height * height);

            string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
            Color[] colorList = { Color.Blue, Color.Green, Color.Orange, Color.DarkOrange, Color.Red, Color.Purple };

            string strResult = "";
            Color colorResult = Color.Black;
            int resultIndex = 0;
            if (bmi < 18.5)
            {
                resultIndex = 0;
            }
            else if (bmi < 24)
            {
                resultIndex = 1;
            }
            else if (bmi < 27)
            {
                resultIndex = 2;
            }
            else if (bmi < 30)
            {
                resultIndex = 3;
            }
            else if (bmi < 35)
            {
                resultIndex = 4;
            }
            else
            {
                resultIndex = 5;
            }
            strResult = strResultList[resultIndex];
            colorResult = colorList[resultIndex];
            lblResult.Text = $"{bmi:F2}({strResult})";
            lblResult.BackColor = colorResult;

            // ===== 歷史紀錄邏輯 =====
            // 建立紀錄字串 (注意 height * 100 轉回公分顯示)
            string record = $"{DateTime.Now:HH:mm:ss} | 身高:{height * 100:F0}cm 體重:{weight:F1}kg BMI:{bmi:F2} ({strResult})";

            // 加入清單
            bmiHistory.Add(record);

            // 限制最多保留 10 筆紀錄
            if (bmiHistory.Count > 10)
            {
                bmiHistory.RemoveAt(0);
            }

            // 更新畫面上的 ListBox 控制項 (名稱為 History_Record)
            History_Record.Items.Clear();
            History_Record.Items.AddRange(bmiHistory.ToArray());

        }

    }
}
