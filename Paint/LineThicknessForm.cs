using System;
using System.Windows.Forms;

namespace Paint
{
    public partial class LineThicknessForm : Form
    {
        public float SelectedLineWidth { get; private set; }

        public LineThicknessForm(float initialLineWidth)
        {
            InitializeComponent();
            numericUpDownLineWidth.Value = (decimal)initialLineWidth;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SelectedLineWidth = (float)numericUpDownLineWidth.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LineThicknessForm_Load(object sender, EventArgs e)
        {

        }

        private void LineThicknessForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
