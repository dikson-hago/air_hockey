using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hockey
{
    public partial class MenuForm : Form
    {
        Form1 main_form;

        public MenuForm(Form1 new_main_form)
        {
            InitializeComponent();
            this.TopMost = true;
         //   Cursor.Show();

            main_form = new_main_form;
        }

        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void new_game_button_Click(object sender, EventArgs e)
        {
            main_form._FREEZE_GAME = false;
            main_form._START_NEW_GAME = true;
            this.Close();
        }

        private void continue_button_Click(object sender, EventArgs e)
        {
            main_form._FREEZE_GAME = false;
            this.Close();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            main_form._CLOSE_GAME = true;
            this.Close();
        }
    }
}
