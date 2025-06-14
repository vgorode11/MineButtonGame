using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineButtonGame
{
    public partial class FormResult : Form
    {
        public FormResult(bool survived)
        {
            InitializeComponent();
            if (survived)
            {
                lblMessage.Text = "Вы прошли игру!";
            }
            else
            {
                lblMessage.Text = "Вы подорвались!";
            }

            lblScore.Text = $"Счёт: {GameManager.CurrentPlayer.Score}";
        }

        private void FormResult_Load(object sender, EventArgs e)
        {

        }

        private void btnToMenu_Click(object sender, EventArgs e)
        {
            FormMenu menuForm = new FormMenu();
            menuForm.Show();
            this.Hide();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
