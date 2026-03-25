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
        public frmBMI()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);

            //驗證身高輸入
            if(!isHeightValid)
            {
                MessageBox.Show("請輸入有效的身高數值");
                return;
            }
            //驗證體重輸入
            if(!isWeightValid)
            {   
                if(weight <= 0)
                {
                    MessageBox.Show("體重數值必須大於0");
                    return;
                }

            }
            height = height / 100; // Convert cm to m

            double bmi = weight / (height * height);
            
            string strResult = "";

            if (bmi < 18.5)
            {
                strResult = "體重過輕";
            }
            else if (bmi >= 18.5 && bmi < 24)
            {
                strResult = "正常範圍";
            }
            else if (bmi >= 24 && bmi < 27)
            {
                strResult = "過重";
            }
            else if (bmi >= 27 && bmi < 30)
            {
                strResult = "輕度肥胖";
            }
            else if (bmi >= 30 && bmi < 35)
            {
                strResult = "中度肥胖";
            }
            else
            {
                strResult = "重度肥胖";
            }

        }

    }
}
