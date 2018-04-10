using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using System.Net;
using System.Net.Sockets;
using System.Threading ;
using System.Timers;
using TimersTimer = System.Timers.Timer;
using Unication.PPSLog;

namespace Dll_import_test
{
    public partial class Form1 : Form
    {
        [DllImport("dll_BaseTest.dll")]
        private static extern int getOne(IntPtr buf);

        [DllImport("dll_BaseTest.dll")]
        private static extern int add(int a,int b);

        [DllImport("dll_BaseTest.dll")]
        private static extern int getTwo(ref int buf);

        [DllImport("dll_BaseTest.dll")]
        private static extern int getArray(ref IntPtr buf);

        // 初始化接口
        [DllImport("libupgrade.dll")]
        static extern int WinUpgradeLibInit(IntPtr Image_buffer_pointer, ulong ImageLen);

        //燒錄接口
        [DllImport("libupgrade.dll")]
        static extern int burnImage();

        //上傳接口 
        [DllImport("libupgrade.dll")]
        static extern int upload_file(IntPtr buf, ref uint len_of_transfer, char[] abs_filename_in_target);

        /// <summary>
        /// 從本機端傳入檔案進pager端
        /// </summary>
        /// <param name="buf">要傳入pager的檔案內容</param>
        /// <param name="len_of_transfer">檔案內容長度</param>
        /// <param name="abs_filename_in_target">傳入Pager內時檔案的名稱</param>
        /// <returns></returns>
        [DllImport("libupgrade.dll")]
        static extern int download_file(char[] buf, uint len_of_transfer, char[] abs_filename_in_target);

        //在target執行命令的接口
        [DllImport("libupgrade.dll")]
        static extern int exec_file_in_tg(char[] filepath);

        //查詢target狀態的接口
        [DllImport("libupgrade.dll")]
        static  extern int progress_reply_status_get(ref byte index,ref byte percent,ref ushort status);

        //[DllImport("libupgrade.dll")]
        //static extern int open_debug_log();

        [DllImport("libupgrade.dll")]
        static extern int burnpartition(int parts_selected);


        private IPEndPoint ServerInfo;
        private Socket ClientSocket;
        private static byte[] RevInfo = new byte[10240];

        TimersTimer _TimersTimer = null;
        
        string m_path = "";
        ulong dl = 0;
        bool reRun = false;
        int runTimes = 0;
        enum Partition_index
        {
            ipl = 0,
            spl,
            linux,
            calibratition,
            rootfs,
            defpara,
            otapara,
            runpara,
            userdata,
            reserve,
            log,
            image,
        }
        enum Status_index
        {
            Preparing = 0,
            Flashing,
            Verifying,
            Executing,
            Finished,
            Transfer,
        }
        public Form1()
        {
            InitializeComponent();

            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
        }

        private void ThreadRun()
        {
            if (reRun == false)
            {
                _TimersTimer = new TimersTimer();
                this._TimersTimer.Interval = 1000;
                this._TimersTimer.Elapsed += new System.Timers.ElapsedEventHandler(_TimersTimer_Elapsed);

                //開啟檔案
                //string OpenFileName = @"D:\Desktop\UniUpgradeTools_v01p08\Gx_Image_MFG_V1.00-T08.bin";
                FileStream myFile = File.Open(m_path, FileMode.Open, FileAccess.ReadWrite);
                //引用myReader類別
                BinaryReader myReader = new BinaryReader(myFile);
                //取得檔案內容長度
                dl = System.Convert.ToUInt64(myFile.Length);

                byte[] ByteData = new byte[dl + 1];
                //讀取位元陣列
                ByteData = myReader.ReadBytes((int)dl);
                //byte array 轉char array
                //CharData = System.Text.Encoding.ASCII.GetString(ByteData).ToCharArray();

                //宣告指針
                IntPtr unmanagedPointer = Marshal.AllocHGlobal(ByteData.Length);
                //將array指向指針
                Marshal.Copy(ByteData, 0, unmanagedPointer, ByteData.Length);
                //釋放資源
                myReader.Close();
                myFile.Close();
                //初始化
                int r = WinUpgradeLibInit(unmanagedPointer, dl);
                Log.ErrorLog.WriteLog("WinUpgradeLibInit Result:" + Convert.ToString(r, 16));
            }
            /* upload test code
            char[] buf = new char[10240];
            int bufsize = Marshal.SizeOf(buf[0]) * buf.Length;
            IntPtr array = Marshal.AllocHGlobal(bufsize);
            Marshal.Copy(buf, 0, unmanagedPointer, buf.Length);

            int[] s = new int[1];
            int ssize = Marshal.SizeOf(s[0]) * s.Length;
            IntPtr psize = Marshal.AllocHGlobal(ssize);
            Marshal.Copy(s, 0, unmanagedPointer, s.Length);
            int retval = upload_file(array, ref sssss, A);
             * 
             * */
            this._TimersTimer.Start();

            int resultBurn = 0;
            if (ckb_partition.Checked)
            {
                int selectP = 0x01 * CvtCkbToInt(ckb_ipl) + 0x02 * CvtCkbToInt(ckb_spl) + 0x04 * CvtCkbToInt(ckb_linux) + 0x08 * CvtCkbToInt(ckb_calibration) + 0x10 * CvtCkbToInt(ckb_rootfs) + 0x20 * CvtCkbToInt(ckb_defpara) + 0x40 * CvtCkbToInt(ckb_otapara) + 0x80 * CvtCkbToInt(ckb_runpara) + 0x100 * CvtCkbToInt(ckb_userdata) + 0x200 * CvtCkbToInt(ckb_log);
                Log.ErrorLog.WriteLog("select part:" + selectP.ToString());
                
                if (selectP == 0)
                {
                    MessageBox.Show("Please Check Partition");
                    return;
                }
                
                resultBurn = burnpartition(selectP);
            }
            else
            {
                resultBurn = burnImage();
            }
            slt_downloadPrgoress(100, "Finish");
            this._TimersTimer.Stop();
            
            if (ckb_autoRun.Checked == true)
            {
                Log.ErrorLog.WriteLog("Program Result: " + Convert.ToString(resultBurn, 16));
                Thread.Sleep(3000);
                reRun = true;
                Log.ErrorLog.WriteLog("RunTime:[" + runTimes.ToString() + "]");
                runTimes++;
                ThreadRun();
            }
            else
            {
                MessageBox.Show("Program Result: " + Convert.ToString(resultBurn, 16));
                UpdateControl_en(btn_Download, true);
            }
        }
        private int CvtCkbToInt(CheckBox cb)
        {
            return Convert.ToInt32(cb.Checked);
        }
        private delegate void UpdateControlCallback(Control c, string str);
        private void UpdateControl_p(Control c, string str)
        {
            if (this.InvokeRequired == true)
            {
                UpdateControlCallback d = UpdateControl_p;
                this.Invoke(d, c, str);
            }
            else
            {
                c.Text = str;
            }
        }
        
        private delegate void UpdateControlCallbackE(Control c,bool b);
        private void UpdateControl_en(Control c,bool b)
        {
            if (this.InvokeRequired == true)
            {
                UpdateControlCallbackE d = UpdateControl_en;
                this.Invoke(d, c , b);
            }
            else
            {
                c.Enabled = b;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            btn_Download.Enabled = false;
            /*
            bool con = connect("10.10.0.12", 0x8001);

            if (con == false)
            {
                MessageBox.Show("Connect Socket Fail");
                //return;
            }
             * */
            Thread threadrun = new Thread(ThreadRun);
            threadrun.Start();
            threadrun.IsBackground = true;
        }

        public bool connect(string ip, int port)
        {
            RevInfo = new byte[10240];

            //定義一個IPV4，TCP模式的Socket
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //服務端IP和端口信息設定,這裡的IP可以是127.0.0.1，可以是本機局域網IP，也可以是本機網絡IP
            ServerInfo = new IPEndPoint(IPAddress.Parse(ip), port);

            bool rt = false;
            try
            {
                //客戶端連接服務端指定IP端口，Sockket
                ClientSocket.Connect(ServerInfo);
                //將用戶登錄信息發送至服務器，由此可以讓其他客戶端獲知
                //ClientSocket.Send(Encoding.Unicode.GetBytes("用戶： " + Environment.MachineName + " 進入系統！\n"));
                //開始從連接的Socket異步讀取數據。接收來自服務器，其他客戶端轉發來的信息
                //AsyncCallback引用在異步操作完成時調用的回調方法
                //ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), ClientSocket);
                rt = true;
            }
            catch
            {
                return rt;
            }

            return rt;
        }

        byte index = 0;
        byte percent = 0;
        ushort sta = 0;

        private void _TimersTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int r = progress_reply_status_get(ref index, ref percent, ref sta);
            string str = ((Partition_index)index).ToString() +" " +((Status_index)sta).ToString();
            Log.ErrorLog.WriteLog(Log.ErrorModule.Error_HANDLER, "index[" + index.ToString() + "],per:[" + percent.ToString() + "],sta:[" + sta.ToString() + "]");
            slt_downloadPrgoress(percent,str);
        }

        public delegate void DownloadProgress(int percent,string str);
        private void slt_downloadPrgoress(int percent,string str)
        {
            if (this.InvokeRequired)
            {
                DownloadProgress uu = new DownloadProgress(slt_downloadPrgoress);
                this.Invoke(uu, percent,str);
            }
            else
            {
                progressBar1.Value = percent;
                label1.Text = str + " " + percent + "% Processing...";
            }
        }
        private void btn_readBin_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //初始路徑
            openFile.InitialDirectory = System.Environment.CurrentDirectory;
            //選擇條件
            openFile.Filter = "Image | *.bin";
            //紀錄上次路徑
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                m_path = openFile.FileName.ToString();
                txb_path.Text = m_path;
            }

        }

    }
}
