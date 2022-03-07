using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tic
{
    public partial class Form1 : Form
    {
        #region //Client global variable//
        Socket socketClient;
        Thread listenThread;
        IPEndPoint EP;
        
        byte[] data = new byte[10024];
        bool IsConnect;
        string Player_1or2 = "";
        //bool[] btnok = new bool[16];
        int A;
        int p1totalLine = 0;//目前有幾條連線 
        int p2totalLine = 0;//目前有幾條連線 
        int p1win = 0;
        int p2win = 0;
        int p1lose = 0;
        int p2lose = 0;
        //string player1win = "勝";
        //string player1lose = "敗";
        //string player2win = "勝";
        //string player2lose = "敗";
        int doo=0;

        bool haveLine = false;//是否已達成3條連線
        #endregion

        #region //Form//
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            btnBlock();
            btn_restart.Enabled = false;
        }
        #endregion

        #region //Main Game//
        
        int [] btnum = new int [16];
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(Player_1or2 == "Player1")
            {
                button1.BackColor = Color.LemonChiffon;
            }
            else if(Player_1or2 == "Player2")
            {
                button1.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[0] + ",");
            btnBlock(); check();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button2.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button2.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[1] + ",");
            btnBlock(); check();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button3.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button3.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[2] + ",");
            btnBlock(); check();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button4.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button4.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[3] + ",");
            btnBlock(); check();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button5.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button5.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[4] + ",");
            btnBlock(); check();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button6.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button6.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[5] + ","); 
            btnBlock(); check();
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button7.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button7.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[6] + ","); 
            btnBlock(); check();
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button8.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button8.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[7] + ","); 
            btnBlock(); check();
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button9.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button9.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[8] + ","); 
            btnBlock(); check();
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button10.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button10.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[9] + ","); 
            btnBlock(); check();
        }
        private void button11_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button11.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button11.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[10] + ",");
            btnBlock(); check();
        }
        private void button12_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button12.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button12.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[11] + ","); 
            btnBlock();
            check();
        }
        private void button13_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button13.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button13.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[12] + ","); 
            btnBlock();
            check();
        }
        private void button14_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button14.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button14.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[13] + ",");
            btnBlock();
            check();
        }
        private void button15_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button15.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button15.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[14] + ",");
            btnBlock();
            check();
        }
        private void button16_Click_1(object sender, EventArgs e)
        {
            if (Player_1or2 == "Player1")
            {
                button16.BackColor = Color.LemonChiffon;
            }
            else if (Player_1or2 == "Player2")
            {
                button16.BackColor = Color.LightSteelBlue;
            }
            socketSend("BtnClick," + Player_1or2 + "," + btnum[15] + ",");
            btnBlock();
            check();
        }

        private void check()
        {
            if (button1.BackColor == Color.LemonChiffon && button2.BackColor == Color.LemonChiffon && button3.BackColor == Color.LemonChiffon && button4.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button1.BackColor == Color.LightSteelBlue && button2.BackColor == Color.LightSteelBlue && button3.BackColor == Color.LightSteelBlue && button4.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            if (button5.BackColor == Color.LemonChiffon && button6.BackColor == Color.LemonChiffon && button7.BackColor == Color.LemonChiffon && button8.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button5.BackColor == Color.LightSteelBlue && button6.BackColor == Color.LightSteelBlue && button7.BackColor == Color.LightSteelBlue && button8.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            if (button9.BackColor == Color.LemonChiffon && button10.BackColor == Color.LemonChiffon && button11.BackColor == Color.LemonChiffon && button12.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button9.BackColor == Color.LightSteelBlue && button10.BackColor == Color.LightSteelBlue && button11.BackColor == Color.LightSteelBlue && button12.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            if (button13.BackColor == Color.LemonChiffon && button14.BackColor == Color.LemonChiffon && button15.BackColor == Color.LemonChiffon && button16.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button13.BackColor == Color.LightSteelBlue && button14.BackColor == Color.LightSteelBlue && button15.BackColor == Color.LightSteelBlue && button16.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            //判斷直四公格  
            if (button1.BackColor == Color.LemonChiffon && button5.BackColor == Color.LemonChiffon && button9.BackColor == Color.LemonChiffon && button13.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button1.BackColor == Color.LightSteelBlue && button5.BackColor == Color.LightSteelBlue && button9.BackColor == Color.LightSteelBlue && button13.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            if (button2.BackColor == Color.LemonChiffon && button6.BackColor == Color.LemonChiffon && button10.BackColor == Color.LemonChiffon && button14.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button2.BackColor == Color.LightSteelBlue && button6.BackColor == Color.LightSteelBlue && button10.BackColor == Color.LightSteelBlue && button14.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            if (button3.BackColor == Color.LemonChiffon && button7.BackColor == Color.LemonChiffon && button11.BackColor == Color.LemonChiffon && button15.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button3.BackColor == Color.LightSteelBlue && button7.BackColor == Color.LightSteelBlue && button11.BackColor == Color.LightSteelBlue && button15.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            if (button4.BackColor == Color.LemonChiffon && button8.BackColor == Color.LemonChiffon && button12.BackColor == Color.LemonChiffon && button16.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button4.BackColor == Color.LightSteelBlue && button8.BackColor == Color.LightSteelBlue && button12.BackColor == Color.LightSteelBlue && button16.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            //判斷斜線\  
            if (button1.BackColor == Color.LemonChiffon && button6.BackColor == Color.LemonChiffon && button11.BackColor == Color.LemonChiffon && button16.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button1.BackColor == Color.LightSteelBlue && button6.BackColor == Color.LightSteelBlue && button11.BackColor == Color.LightSteelBlue && button16.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;
            }
            //判斷斜線/  
            if (button4.BackColor == Color.LemonChiffon && button7.BackColor == Color.LemonChiffon && button10.BackColor == Color.LemonChiffon && button13.BackColor == Color.LemonChiffon)
            {
                p1totalLine += 1;
            }
            if (button4.BackColor == Color.LightSteelBlue && button7.BackColor == Color.LightSteelBlue && button10.BackColor == Color.LightSteelBlue && button13.BackColor == Color.LightSteelBlue)
            {
                p2totalLine += 1;

            }

            //是否達成3連線  
            if (p1totalLine >= 3 && p2totalLine<3)
            {
                haveLine = true;
                MessageBox.Show(p1totalLine + "條線");
                if (doo >= 1)
                {
                    socketSend("GameOver," + "Player2,"+ nickname_TB.Text + "," );
                }
                else
                {
                    socketSend("GameOver," + "Player1," + nickname_TB.Text + ",");
                }
                p1win += 1;
                p2lose += 1;
                btnBlock();
                btn_restart.Enabled = true;
            }
            else if (p2totalLine >= 3 && p1totalLine<3)
            {
                haveLine = true;
                MessageBox.Show(p2totalLine + "條線");
                if (doo >= 1)
                {
                    socketSend("GameOver," + "Player1," + nickname_TB.Text + ",");
                }
                else
                {
                    socketSend("GameOver," + "Player2," + nickname_TB.Text + ",");
                }
                p2win += 1;
                p1lose += 1;
                btnBlock();
                btn_restart.Enabled = true;
            }
            else if (p1totalLine >= 3 && p2totalLine >= 3)
            {
                haveLine = true;
                MessageBox.Show(p1totalLine + "條線");
                socketSend("GameOver," + "T");
                btnBlock();
                btn_restart.Enabled = true;

            }
            else
            {
                p1totalLine = 0;
                p2totalLine = 0;
            }

            //if(p1lose==2 && p2win==2)
            //{
            //    tb_win.Text = "敗";
            //}
            //else
            //{
            //    tb_win.Text = "敗";
            //}
        }


        private void btnBlock()
        {
            button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; button4.Enabled = false;
            button5.Enabled = false; button6.Enabled = false; button7.Enabled = false; button8.Enabled = false;
            button9.Enabled = false; button10.Enabled = false; button11.Enabled = false; button12.Enabled = false;
            button13.Enabled = false; button14.Enabled = false; button15.Enabled = false; button16.Enabled = false; 
        }

        private void btnOpen()
        {
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = true; button6.Enabled = true; button7.Enabled = true; button8.Enabled = true; 
            button9.Enabled = true; button10.Enabled = true; button11.Enabled = true; button12.Enabled = true;
            button13.Enabled = true; button14.Enabled = true; button15.Enabled = true; button16.Enabled = true;
        }

        private void getRandom()
        {
            Random r = new Random();
            int[] num = new int[16];
            for (int i = 0; i <= 15; i++)
            {
                btnum[i] = i+1 ;
            }
            int temp;
            for (int i = 0; i <= 15; i++)
            {
                int R = r.Next(16);
                temp = btnum[i];
                btnum[i] = btnum[R];
                btnum[R] = temp;
            }
            button1.Text = btnum[0].ToString();
            button2.Text = btnum[1].ToString();
            button3.Text = btnum[2].ToString();
            button4.Text = btnum[3].ToString();
            button5.Text = btnum[4].ToString();
            button6.Text = btnum[5].ToString();
            button7.Text = btnum[6].ToString();
            button8.Text = btnum[7].ToString();
            button9.Text = btnum[8].ToString();
            button10.Text = btnum[9].ToString();
            button11.Text = btnum[10].ToString();
            button12.Text = btnum[11].ToString();
            button13.Text = btnum[12].ToString();
            button14.Text = btnum[13].ToString();
            button15.Text = btnum[14].ToString();
            button16.Text = btnum[15].ToString();
        }
        private void clicked()
        {
            for (int i = 0; i <= 15; i++)
            {
                if (btnum[i] == A)
                {
                    if (Player_1or2 == "Player1" && button1.Text == btnum[i].ToString())
                    {
                        button1.Enabled = false;
                        button1.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button1.Text == btnum[i].ToString())
                    {
                        button1.Enabled = false;
                        button1.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button2.Text == btnum[i].ToString())
                    {
                        button2.Enabled = false;
                        button2.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button2.Text == btnum[i].ToString())
                    {
                        button2.Enabled = false;
                        button2.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button3.Text == btnum[i].ToString())
                    {
                        button3.Enabled = false;
                        button3.BackColor = Color.LemonChiffon;
                    }
                    else if(Player_1or2 == "Player2" && button3.Text == btnum[i].ToString())
                    {
                        button3.Enabled = false;
                        button3.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button4.Text == btnum[i].ToString())
                    {
                        button4.Enabled = false;
                        button4.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button4.Text == btnum[i].ToString())
                    {
                        button4.Enabled = false;
                        button4.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && Player_1or2 == "Player1" && button5.Text == btnum[i].ToString())
                    {
                        button5.Enabled = false;
                        button5.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button5.Text == btnum[i].ToString())
                    {
                        button5.Enabled = false;
                        button5.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button6.Text == btnum[i].ToString())
                    {
                        button6.Enabled = false;
                        button6.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button6.Text == btnum[i].ToString())
                    {
                        button6.Enabled = false;
                        button6.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && Player_1or2 == "Player1" && button7.Text == btnum[i].ToString())
                    {
                        button7.Enabled = false;
                        button7.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button7.Text == btnum[i].ToString())
                    {
                        button7.Enabled = false;
                        button7.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && Player_1or2 == "Player1" && button8.Text == btnum[i].ToString())
                    {
                        button8.Enabled = false;
                        button8.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button8.Text == btnum[i].ToString())
                    {
                        button8.Enabled = false;
                        button8.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button9.Text == btnum[i].ToString())
                    {
                        button9.Enabled = false;
                        button9.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button9.Text == btnum[i].ToString())
                    {
                        button9.Enabled = false;
                        button9.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button10.Text == btnum[i].ToString())
                    {
                        button10.Enabled = false;
                        button10.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button10.Text == btnum[i].ToString())
                    {
                        button10.Enabled = false;
                        button10.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button11.Text == btnum[i].ToString())
                    {
                        button11.Enabled = false;
                        button11.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button11.Text == btnum[i].ToString())
                    {
                        button11.Enabled = false;
                        button11.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button12.Text == btnum[i].ToString())
                    {
                        button12.Enabled = false;
                        button12.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button12.Text == btnum[i].ToString())
                    {
                        button12.Enabled = false;
                        button12.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button13.Text == btnum[i].ToString())
                    {
                        button13.Enabled = false;
                        button13.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button13.Text == btnum[i].ToString())
                    {
                        button13.Enabled = false;
                        button13.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button14.Text == btnum[i].ToString())
                    {
                        button14.Enabled = false;
                        button14.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button14.Text == btnum[i].ToString())
                    {
                        button14.Enabled = false;
                        button14.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button15.Text == btnum[i].ToString())
                    {
                        button15.Enabled = false;
                        button15.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button15.Text == btnum[i].ToString())
                    {
                        button15.Enabled = false;
                        button15.BackColor = Color.LightSteelBlue;
                    }
                    if (Player_1or2 == "Player1" && button16.Text == btnum[i].ToString())
                    {
                        button16.Enabled = false;
                        button16.BackColor = Color.LemonChiffon;
                    }
                    else if (Player_1or2 == "Player2" && button16.Text == btnum[i].ToString())
                    {
                        button16.Enabled = false;
                        button16.BackColor = Color.LightSteelBlue;
                    }

                }
            }
        }
        #endregion

        #region //Client//
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (entry_Btn.Enabled == false)
            {
                socketSend("logout," + nickname_TB.Text + ",");
                socketClient.Close();
            }
        }

        private void entry_Btn_Click_1(object sender, EventArgs e)
        {
          
            try
            {
                if (serverIP_TB.Text != "" && port_TB.Text != "" && nickname_TB.Text != "")      //checking TB != ""
                {
                    socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    EP = new IPEndPoint(IPAddress.Parse(serverIP_TB.Text), int.Parse(port_TB.Text));
                    socketClient.Connect(EP);
                    listenThread = new Thread(socketReceive);
                    listenThread.IsBackground = true;
                    listenThread.Start();
                    IsConnect = true;
                    socketSend("login," + nickname_TB.Text + ",");
                    serverIP_TB.Enabled = false;
                    port_TB.Enabled = false;
                    nickname_TB.Enabled = false;
                    entry_Btn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please entry full info!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            getRandom();
        }


        public void socketReceive()
        {
            int recvLength = 0;
            try
            {
                do
                {
                    recvLength = socketClient.Receive(data);
                    if (recvLength > 0)
                    {
                        Receive(Encoding.Default.GetString(data).Trim());
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        } // end socketReceive
        
        public void Receive(string recvData) //Recive data
        {
            try
            {
                char token = ',';
                string[] pt = recvData.Split(token);        //Cut by ","

                switch (pt[0])      //Use the first data in array to determine info
                {
                    case "deny":
                        log_LB.Items.Add("[System] : Nickname duplicate, \n please re-entry.");
                        serverIP_TB.Enabled = true;
                        port_TB.Enabled = true;
                        nickname_TB.Enabled = true;
                        entry_Btn.Enabled = true;
                        break;

                    case "list":
                        onlineList_LB.Items.Clear();
                        for (int i = 1; i < pt.Length; i++)
                        {
                            onlineList_LB.Items.Add(pt[i]);
                        }
                        break;
                    case "ID":
                        if (Player_1or2 == "")
                        {
                            Player_1or2 = pt[2];
                            socketSend("PlayerReady,");
                        }
                        break;
                    case "GameStart":
                        MessageBox.Show("GameStart!");

                        MessageBox.Show(nickname_TB.Text);
                        if (Player_1or2 == "Player1")
                            btnOpen();
                        break;
                    case "refresh":
                        if (Player_1or2 == "Player1")
                            Player_1or2 = "Player2";
                        else if (Player_1or2 == "Player2")
                            Player_1or2 = "Player1";
                        //MessageBox.Show(Player_1or2);
                        MessageBox.Show("GameRestart!"+ nickname_TB.Text);
                        if (Player_1or2 == "Player1")
                        {
                            btnOpen();
                        }
                            
                        break;
                    case "BtnClick":
                        
                        if (Player_1or2 != pt[1])
                        {
                            btnOpen();
                            
                            if (pt[3] == "True")
                            {
                                A = int.Parse(pt[4]);
                                clicked();
                            } 
                            if (pt[5] == "True")
                            {
                                A = int.Parse(pt[6]);
                                clicked();
                            }
                            if (pt[7] == "True")
                            {
                                A = int.Parse(pt[8]);
                                clicked();
                            }
                            if (pt[9] == "True")
                            {
                                A = int.Parse(pt[10]);
                                clicked();
                            }
                            if (pt[11] == "True")
                            {
                                A = int.Parse(pt[12]);
                                clicked();
                            }
                            if (pt[13] == "True")
                            {
                                A = int.Parse(pt[14]);
                                clicked();
                            }
                            if (pt[15] == "True")
                            {
                                A = int.Parse(pt[16]);
                                clicked();
                            }
                            if (pt[17] == "True")
                            {
                                A = int.Parse(pt[18]);
                                clicked();
                            }
                            if (pt[19] == "True")
                            {
                                A = int.Parse(pt[20]);
                                clicked();
                            }
                            if (pt[21] == "True")
                            {
                                A = int.Parse(pt[22]); ;
                                clicked();
                            }
                            if (pt[23] == "True")
                            {
                                A = int.Parse(pt[24]);
                                clicked();
                            }
                            if (pt[25] == "True")
                            {
                                A = int.Parse(pt[26]);
                                clicked();
                            }
                            if (pt[27] == "True")
                            {
                                A = int.Parse(pt[28]);
                                clicked();
                            }
                            if (pt[29] == "True")
                            {
                                A = int.Parse(pt[30]);
                                clicked();
                            }
                            if (pt[31] == "True")
                            {
                                A = int.Parse(pt[32]);
                                clicked();
                            }
                            if (pt[33] == "True")
                            {
                                A = int.Parse(pt[34]);
                                clicked();
                            }

                            check();

                            if (pt[2] == "1")
                            {
                                A = 1;
                                clicked();
                            }
                            else if (pt[2] == "2")
                            {
                                A = 2;
                                clicked();
                            }
                            else if (pt[2] == "3")
                            {
                                A = 3;
                                clicked();
                            }
                            else if (pt[2] == "4")
                            {
                                A = 4;
                                clicked();
                            }
                            else if (pt[2] == "5")
                            {
                                A = 5;
                                clicked();
                            }
                            else if (pt[2] == "6")
                            {
                                A = 6;
                                clicked();
                            }
                            else if (pt[2] == "7")
                            {
                                A = 7;
                                clicked();
                            }
                            else if (pt[2] == "8")
                            {
                                A = 8;
                                clicked();
                            }
                            else if (pt[2] == "9")
                            {
                                A = 9;
                                clicked();
                            }
                            else if (pt[2] == "10")
                            {
                                A = 10;
                                clicked();
                            }
                            else if (pt[2] == "11")
                            {
                                A = 11;
                                clicked();
                            }
                            else if (pt[2] == "12")
                            {
                                A = 12;
                                clicked();
                            }
                            else if (pt[2] == "13")
                            {
                                A = 13;
                                clicked();
                            }
                            else if (pt[2] == "14")
                            {
                                A = 14;
                                clicked();
                            }
                            else if (pt[2] == "15")
                            {
                                A = 15;
                                clicked();
                            }
                            else if (pt[2] == "16")
                            {
                                A = 16;
                                clicked();
                            }
                        }
                        break;
                    case "GameOver":
                        btnBlock();
                        btn_restart.Enabled = true;
                        MessageBox.Show(pt[1]+" win!");

                        //if (pt[1] == "Player1")
                        //{
                        //    MessageBox.Show("Player1 win!");
                        //    //tb_win.Text = p1win.ToString();
                        //}
                        //else if (pt[1] == "Player2")
                        //{
                        //    MessageBox.Show("Player2 win!");
                        //    //tb_win.Text = p2win.ToString();
                        //}
                        //else if (pt[1] == "T")
                        //{
                        //    MessageBox.Show("Tie!");
                        //}

                        if (p1win == 2 && p2win <2)
                        {
                            //tb_win.Text = "勝";
                            btnBlock();
                            btn_restart.Enabled = false;
                            
                        }
                        else if (p2win == 2 && p1win <2)
                        {
                            //tb_win.Text = "勝";
                            btnBlock();
                            btn_restart.Enabled = false;
                        }

                        break;
                    case "Allwin":
                        MessageBox.Show(pt[1] + "Allwin");
                        tb_win.Text = pt[2];
                        break;
                        //case "Btnblock":
                        //    btnBlock();
                        //    break;


                } // end switch
                Array.Clear(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } // end try-catch
        } // end Receive

        public void socketSend(string sendData)
        {
            if (IsConnect)
            {
                try
                {
                    socketClient.Send(Encoding.Default.GetBytes(sendData));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                log_LB.Items.Add("Disconnect");
            }
        } // end socketSend

        #endregion

        private void btn_restart_Click(object sender, EventArgs e)
        {
            btnBlock();
            btn_restart.Enabled = true;
            p1totalLine = 0;
            p2totalLine = 0;
            haveLine = false;
            getRandom();

            button1.BackColor = default(Color); button2.BackColor = default(Color); button3.BackColor = default(Color); button4.BackColor = default(Color);
            button5.BackColor = default(Color); button6.BackColor = default(Color); button7.BackColor = default(Color); button8.BackColor = default(Color);
            button9.BackColor = default(Color); button10.BackColor = default(Color); button11.BackColor = default(Color); button12.BackColor = default(Color);
            button13.BackColor = default(Color); button14.BackColor = default(Color); button15.BackColor = default(Color); button16.BackColor = default(Color);
         
            socketSend("change," );
            btn_restart.Enabled = false;
            doo += 1;
        }


    }
}