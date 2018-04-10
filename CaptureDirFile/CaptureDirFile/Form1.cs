using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CaptureDirFile
{
    public partial class Form1 : Form
    {
        uint CapFileSize = 1024*1024;

        FolderBrowserDialog m_sourcePath = new FolderBrowserDialog();
        FolderBrowserDialog m_destPath = new FolderBrowserDialog();
        FileInfo fInfo = null;
        
        public Form1()
        {
            InitializeComponent();
            //讀取config檔
            readConfig();

            //設定針測的檔案類型，如不指定可設定*.*
            FileSystemWatcher watch = new FileSystemWatcher(txt_srcPath.Text, "*.*");
            //開啟監聽
            watch.EnableRaisingEvents = true;
            //是否連子資料夾都要偵測
            watch.IncludeSubdirectories = true;
            //新增時觸發事件
            watch.Created += watch_Created;
        }

        void watch_Created(object sender, FileSystemEventArgs e)
        {
            //拿取source目錄檔案
            string[] files = System.IO.Directory.GetFiles(txt_srcPath.Text);

            // Copy the files and overwrite destination files if they already exist.
            foreach (string s in files)
            {
                fInfo = new FileInfo(s);
                //檔案大於指定大小則移動至指定目錄
                //if (fInfo.Length >= CapFileSize)
                //判斷檔案是否被開啟
                if (!FileIsInUse(fInfo))
                {
                    //把路徑抽掉只留檔名
                    string fileName = System.IO.Path.GetFileName(s);
                    //將檔名與目的目錄結合
                    string destFile = System.IO.Path.Combine(txt_destPath.Text, fileName);
                    System.IO.File.Move(s, destFile);
                }

            }

        }

        private void btn_source_Click(object sender, EventArgs e)
        {
            if (m_sourcePath.ShowDialog() == DialogResult.OK)
            {
                txt_srcPath.Text = m_sourcePath.SelectedPath;
            }
            else
            {
                return;
            }
            
        }

        private void btn_destination_Click(object sender, EventArgs e)
        {
            if (m_destPath.ShowDialog() == DialogResult.OK)
            {
                txt_destPath.Text = m_destPath.SelectedPath;
            }
            
        }

        private void readConfig()
        {
            string configPath = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            StreamReader file = new StreamReader(configPath);
            //讀取source Path
            string sourceP = file.ReadLine();
            string[] srcPList = sourceP.Split('=');
            txt_srcPath.Text = srcPList[1];
            //讀取 destination Path
            string dstP = file.ReadLine();
            string[] dstPList = dstP.Split('=');
            txt_destPath.Text = dstPList[1];
            //讀取 檔案大小
            string fileSize = file.ReadLine();
            string[] FileSizeList = fileSize.Split('=');
            CapFileSize = Convert.ToUInt32(FileSizeList[1]);

            //判斷source目錄是否存在
            if (!System.IO.Directory.Exists(txt_srcPath.Text))
            {
                //不存在則顯示提示視窗
                MessageBox.Show("Source path does not exist!");
                return;
            }

            //判斷destination目錄是否存在
            if (!System.IO.Directory.Exists(txt_destPath.Text))
            {
                //不存在則創建指定目錄
                System.IO.Directory.CreateDirectory(txt_destPath.Text);
            }
            
            file.Close();
        }


        bool FileIsInUse(FileInfo file)
        {
            {
                FileStream stream = null;
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (IOException)
                {
                    //如果文件被占用，即
                    //1.文件正在被另一程序写入
                    //2.或者正在被另一线程处理
                    //3.或者文件不存在
                    //此处会抛出异常，我们就利用这个异常来判断指定文件是否被占用
                    return true;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }

                //file is not locked
                return false;
            } 
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //判斷source目錄是否存在
            if (System.IO.Directory.Exists(txt_srcPath.Text))
            {
                //判斷destination目錄是否存在
                if (!System.IO.Directory.Exists(txt_destPath.Text))
                {
                    //不存在則創建指定目錄
                    System.IO.Directory.CreateDirectory(txt_destPath.Text);
                }

                //拿取source目錄檔案
                string[] files = System.IO.Directory.GetFiles(txt_srcPath.Text);
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    fInfo = new FileInfo(s);
                    //檔案大於指定大小則移動至指定目錄
                    //if (fInfo.Length >= CapFileSize)
                    //判斷檔案是否被開啟
                    if (!FileIsInUse(fInfo))
                    {
                        //把路徑抽掉只留檔名
                        string fileName = System.IO.Path.GetFileName(s);
                        //將檔名與目的目錄結合
                        string destFile = System.IO.Path.Combine(txt_destPath.Text, fileName);
                        System.IO.File.Move(s, destFile);
                    }
                }
            }
            
        }
    }

}
