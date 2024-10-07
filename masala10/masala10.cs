using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using System.Linq;

namespace masala
{
    class myform : Form
    {
        Label Label;
        Button[] buttons;
        string misol;
        DataTable nat;
        public myform():base()
        {
            this.Size = new Size(250, 410);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.Black;
            this.Text = "Kalkulyator";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label = new Label();
            Label.SetBounds(5, 5, ClientSize.Width-10,70);
            Label.BackColor= Color.White;
            Label.Font = new Font("Areal", 20, FontStyle.Bold);
            Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Controls.Add(Label);

            buttons = new Button[19];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Text = i.ToString();
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].BackColor = Color.White;
                buttons[i].Font = new Font("Areal", 18, FontStyle.Bold);
                if (i == 0)
                {
                    buttons[i].SetBounds(5, Label.Bottom + 5, Label.Width / 4-2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }
                else if (i <= 3)
                {
                    buttons[i].SetBounds(buttons[i - 1].Right+2, Label.Bottom + 5, Label.Width / 4-2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }
                else if (i == 4)
                {
                    buttons[i].SetBounds(Label.Left, buttons[0].Bottom+2, Label.Width / 4 - 2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }

                else if (i <= 7)
                {
                    buttons[i].SetBounds(buttons[i - 1].Right+2, buttons[0].Bottom+2, Label.Width / 4-2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }
                else if (i == 8)
                {
                    buttons[i].SetBounds(Label.Left, buttons[4].Bottom+2, Label.Width / 4 - 2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }

                else if (i <=11)
                {
                    buttons[i].SetBounds(buttons[i - 1].Right+2, buttons[4].Bottom + 2, Label.Width / 4 - 2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }
                else if (i == 12)
                {
                    buttons[i].SetBounds(Label.Left, buttons[8].Bottom + 2, Label.Width / 4 - 2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }

                else if (i <= 15)
                {
                    buttons[i].SetBounds(buttons[i - 1].Right+2, buttons[8].Bottom + 2, Label.Width / 4-2, Label.Width / 4);
                    if (i == 15)
                    {
                        buttons[i].SetBounds(buttons[i - 1].Right+2, buttons[8].Bottom + 2, Label.Width / 4-2, Label.Width / 2+2);
                    }
                    this.Controls.Add(buttons[i]);
                }
                else if (i == 16)
                {
                    buttons[i].SetBounds(Label.Left, buttons[12].Bottom + 2, Label.Width / 4 - 2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }

                else if(i<=18)
                {
                    buttons[i].SetBounds(buttons[i - 1].Right+2, buttons[12].Bottom + 2, Label.Width / 4-2, Label.Width / 4);
                    this.Controls.Add(buttons[i]);
                }

                buttons[i].Click += natija;
            }
            buttons[0].Text = " C";
            buttons[1].Text = "/";
            buttons[2].Text = "*";
            buttons[3].Text = "<=";

            buttons[4].Text = "1";
            buttons[5].Text = "2";
            buttons[6].Text = "3";
            buttons[7].Text = "-";

            buttons[8].Text = "4";
            buttons[9].Text = "5";
            buttons[10].Text = "6";
            buttons[11].Text = "+";

            buttons[12].Text = "7";
            buttons[13].Text = "8";
            buttons[14].Text = "9";
            buttons[15].Text = "=";

            buttons[16].Text = "%";
            buttons[17].Text = "0";
            buttons[18].Text = ".";
           


        }
        void natija(object a, EventArgs b)
        {
            if (((Button)a).Text != "=")
            {
                misol += ((Button)a).Text;
                misol = misol.Replace(',', '.');
                if (misol.Contains('C'))
                {
                    misol = "";
                }
                else if (misol.Contains("<="))
                {
                    misol = misol.Remove(misol.Length-3);
                }
                Label.Text = misol;
            }
            else 
            {
                misol = misol.Replace(',', '.');
                nat = new DataTable();
                if (misol.Contains('%'))
                {
                    string[] foiz = misol.Split('%');
                    if (foiz[0] != "" && foiz[1] != "")
                    {
                        misol = (foiz[0] + "*" + foiz[1]) + "/" + 100;
                    }
                }
                misol = nat.Compute(misol, "").ToString();
                misol = misol.Replace(',', '.');
                int j = 0;
                

                if (misol.Contains('.'))
                {
                    string txt = misol.Substring(misol.IndexOf('.'));
                    for (int i = 0; i < txt.Length; i++)
                    {
                        if (txt[i] != '.' && txt[i] != '0')
                            j++;
                    }
                }
                if (j == 0)
                {
                    if (misol.Contains('.'))
                    { misol = misol.Remove(misol.IndexOf('.')); }

                    Label.Text = misol;
                }
                else
                    Label.Text = misol;
            }
        }
    }

    class main
    {
        [STAThread]

        static void Main()
        {
            Application.Run(new myform());
        }
    }
}