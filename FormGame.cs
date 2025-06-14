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
    public partial class FormGame : Form
    {
        private int fieldSize = 3;         
        private int bombCount = 1;         
        private List<BombButton> buttons;   
        private List<int> bombIndices;     
        private Random rand = new Random(); 
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            
            fieldSize = Math.Min(fieldSize, 6);
            bombCount = Math.Min(bombCount, 10);

            
            if (buttons != null)
            {
                foreach (var btn in buttons)
                    this.Controls.Remove(btn);
            }

            buttons = new List<BombButton>();
            bombIndices = new List<int>();

            int totalButtons = fieldSize * fieldSize;
            int btnSize = 40;
            int spacing = 5;
            int startX = 10;
            int startY = 60;

            while (bombIndices.Count < bombCount)
            {
                int index = rand.Next(totalButtons);
                if (!bombIndices.Contains(index))
                    bombIndices.Add(index);
            }

            for (int i = 0; i < totalButtons; i++)
            {
                BombButton btn = new BombButton();
                btn.Index = i;
                btn.Size = new Size(btnSize, btnSize);

                int row = i / fieldSize;
                int col = i % fieldSize;

                btn.Location = new Point(
                    startX + col * (btnSize + spacing),
                    startY + row * (btnSize + spacing)
                );

                btn.Click += BombButton_Click;
                this.Controls.Add(btn);
                buttons.Add(btn);
            }

            this.Text = $"Поле: {fieldSize}x{fieldSize}, Бомб: {bombCount}";


        }

        private void BombButton_Click(object sender, EventArgs e)
        {
            BombButton btn = sender as BombButton;

            if (bombIndices.Contains(btn.Index))
            {
                btn.BackColor = Color.Red;
                MessageBox.Show("💥 Вы подорвались!");

                FormResult resultForm = new FormResult(false);
                resultForm.ShowDialog(); 

                this.Close(); 
                return;
            }
            

            btn.BackColor = Color.LightGreen;
            btn.Enabled = false;
            GameManager.CurrentPlayer.Score += 1;


            if (fieldSize < 6)
            {
                fieldSize++;
                bombCount++;
                GenerateGrid();
            }
            else
            {

                MessageBox.Show("🎉 Поздравляем! Вы прошли игру!");
                FormResult resultForm = new FormResult(true);
                resultForm.ShowDialog();
                this.Close();
            }
        }
    }
}
