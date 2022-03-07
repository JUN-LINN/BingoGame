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
using System.Collections;


namespace server
{
    public partial class Form1 : Form
    {
        #region Global variables
        TcpListener server;             
        Hashtable HT = new Hashtable(); 
        Socket socketClient;            
        Thread Th_Svr, Th_Clt;          
        int[] Player = new int[2];
        int[] playername = new int[2];
        int Playerready = 0;
        bool[] BlockBtn = new bool[1024];
        int a,i;
        int[] btnnumber = new int[1024];
        string round1="1";
        string round2 = "2";
        string round3 = "3";
        #endregion

        #region Form 
        public Form1()
        {
            InitializeComponent();
        }  

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion

        #region Connect button
        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Th_Svr = new Thread(ServerSub);     	//Server thread
                Th_Svr.IsBackground = true;
                Th_Svr.Start();                     	//Server thread start

                log_LB.Items.Add("Server Socket Biuld Success！");
                log_LB.Update();
                connectBtn.Enabled = false;
                ip_TB.Enabled = false;
                port_TB.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ServerSub()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(ip_TB.Text), int.Parse(port_TB.Text));
            server = new TcpListener(EP);       //Create server TCP Listener
            server.Start(100);                  //Maximun accept number

            while (true)
            {
                socketClient = server.AcceptSocket();   //Accept Socket
                Th_Clt = new Thread(listen);            //Create Thread
                Th_Clt.IsBackground = true;             //Background Thread
                Th_Clt.Start();                         //Thread start
            }
        }

        private void listen()
        {
            Socket sck = socketClient;              //Save Socket
            Thread Th = Th_Clt;                     //Save Thread
            string id = null;
            
            while (true)
            {
                byte[] B = new byte[1023];          //var B
                try
                {
                    int inLen = sck.Receive(B);     //Put the message into inLen
                    string str = Encoding.Default.GetString(B, 0, inLen);
                    string[] Msg = str.Split(',');
                    //Use switch case determine message
                    switch (Msg[0])
                    {
                        case "login":
                            try
                            {
                                HT.Add(Msg[1], sck);
                                onlineList_LB.Items.Add(Msg[1]);
                                logLBAdd("Login", Msg[1]);
                                sendAll(str);
                                id = Msg[1];
                                if (playername[0] == 0 && playername[1] == 0)
                                {
                                    playername[0] = 1;
                                    sendAll("ID," + playername[0] + "," + "Player1" + ",");
                                }
                                else if (playername[0] == 1 && playername[1] == 0)
                                {
                                    playername[1] = 1;
                                    sendAll("ID," + playername[1] + "," + "Player2" + ",");
                                }
                            }
                            catch
                            {
                                sendTo("deny,", sck);
                            }
                            break;
                        case "change":
                            //MessageBox.Show("" + playername[0] + playername[1]);
                            if (playername[0] == 0 && playername[1] == 0)
                            {
                                Playerready += 1;
                                playername[0] = 1;
                            }
                            else if (playername[0] == 1 && playername[1] == 0)
                            {
                                Playerready += 1;
                                playername[1] = 1;
                            }
                            //MessageBox.Show("" + Playerready);
                            if (Playerready == 2)
                            {
                                if (round1== "Player1")
                                {
                                    sendAll("refresh,");
                                }
                                else
                                {
                                    sendAll("GameStart,");
                                }
                            }
                            break;
                        case "logout":
                            HT.Remove(Msg[1]);
                            onlineList_LB.Items.Remove(Msg[1]);
                            sendAll(str);
                            Th.Abort();
                            break;
                        case "PlayerReady":
                            Playerready += 1;
                            if (Playerready == 2)
                            {
                                sendAll("GameStart,");
                                
                            }
                            break;
                       case "BtnClick":
                            Playerready = 0;
                            playername[0] = 0;
                            playername[1] = 0;
                            while (true)
                            {
                                if(a==0)
                                    BlockBtn[a] = true;
                                else if(a!=0)
                                    BlockBtn[a] = true;
                                a += 1;
                                break;
                            }
                            while(true)
                            {
                                btnnumber[i] = int.Parse(Msg[2]);
                                i += 1;
                                break;
                            }
                            sendAll("BtnClick," + Msg[1] + "," + Msg[2] + "," + 
                                BlockBtn[0] + "," + btnnumber[0]+ ","+
                                BlockBtn[1] + "," +btnnumber[1] + "," + 
                                BlockBtn[2] + "," + btnnumber[2] + "," +
                                BlockBtn[3] + "," + btnnumber[3] + "," +
                                BlockBtn[4] + "," + btnnumber[4] + "," +
                                BlockBtn[5] + "," + btnnumber[5] + "," +
                                BlockBtn[6] + "," + btnnumber[6] + "," +
                                BlockBtn[7] + "," + btnnumber[7] + "," +
                                BlockBtn[8] + ","+ btnnumber[8] + "," +
                                BlockBtn[9] + "," + btnnumber[9] + "," +
                                BlockBtn[10] + "," + btnnumber[10] + "," +
                                BlockBtn[11] + "," + btnnumber[11] + "," +
                                BlockBtn[12] + "," + btnnumber[12] + "," +
                                BlockBtn[13] + "," + btnnumber[13] + "," +
                                BlockBtn[14] + "," + btnnumber[14] + "," +
                                BlockBtn[15] + "," + btnnumber[15]);
                            
                            break;
                        case "GameOver":
                            sendAll("GameOver," + Msg[2] + ",");
                            if (Msg[1] == "Player1")
                            {
                                while(true)
                                {
                                    if (round1 == "1")
                                    {
                                        round1 = "Player1";
                                        break;
                                    }
                                    if (round2 == "2")
                                    {
                                        round2 = "Player1";
                                        break;
                                    }
                                    if (round3 == "3")
                                    {
                                        round3 = "Player1";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                while (true)
                                {
                                    if (round1 == "1")
                                    {
                                        round1 = "Player2";
                                        break;
                                    }
                                    if (round2 == "2")
                                    {
                                        round2 = "Player2";
                                        break;
                                    }
                                    if (round3 == "3")
                                    {
                                        round3 = "Player2";
                                        break;
                                    }
                                }
                            }
                            if (round1 == round2 || round1 == round3 || round2 == round3)
                            {
                                sendAll("Allwin," + Msg[1] + "," + Msg[2] + ",");
                                //sendAll("Btnblock," );
                            }

                            Array.Clear(BlockBtn,0,16);
                            Array.Clear(btnnumber, 0, 16);

                            break;
                    }
                }
                catch
                {
                    logLBAdd("Crash", id);
                    sendAll("message," + id + "logout.");
                }
            }
        }
        #endregion

        #region Form Closed
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            breakConnection();
        }

        private void breakConnection()
        {
            try
            {
                Application.ExitThread();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        #endregion

        #region Send Event
        private void sendTo(string str, Socket sck)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            sck.Send(B, 0, B.Length, SocketFlags.None);
        }

        private void sendAll(string str)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            foreach (Socket s in HT.Values)
            {
                s.Send(B, 0, B.Length, SocketFlags.None);
            }
        }
        #endregion

        #region Form Event
        private void logLBAdd(string type, string ifo)
        {
            log_LB.Items.Add("[" + type + "] : " + ifo);
        }
        #endregion

    } // end class
} // end namespace server
