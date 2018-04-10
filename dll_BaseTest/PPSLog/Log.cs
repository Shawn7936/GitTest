/**************************************************************
 *Log.cs: 提供操作异常机制
 *Copyright (c) 2010 Uncication.com.cn
 *
 * 说明:
 * 1.提供当前操作的异常处理(Log)
 * 
 * Update Log:
 * 
 * ************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Unication.PPSLog
{
    /// <summary>
    /// Log文件
    /// </summary>
    public class Log
    {
        #region Construct

        /// <summary>
        /// 隐藏构造
        /// </summary>
        private Log(string filePath)
        {
            logFile = filePath;

            System.IO.Directory.CreateDirectory(errorlogpath);
            //writer = new StreamWriter(logFile, true);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 字符串写入
        /// </summary>
        private StreamWriter writer = null;

        private readonly object lockHelp = new object();

        /// <summary>
        /// 日志路径
        /// </summary>
        private string logFile = null;

        private string errorlogpath = Application.StartupPath + "\\ErrorLog";

        private static Log errorLog = null;
        /// <summary>
        /// 错误日志
        /// </summary>
        public static Log ErrorLog
        {
            get
            {
                if (errorLog == null)
                {
                    errorLog = new Log(Application.StartupPath + "\\ErrorLog\\ErrorLog.txt");
                }

                return errorLog;
            }
        }

        #endregion


        public enum ErrorModule
        {
            Error_All = 0,
            Error_AP,
            Error_HANDLER,
        }


        #region Log Interface

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="msg"></param>
        public void WriteLog(string msg)
        {
            lock (lockHelp)
            {
                try
                {
                    writer = new StreamWriter(logFile, true);
                    writer.WriteLine("-----------------------{0}-----------------------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine(msg);
                    writer.Flush();
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                        writer.Dispose();
                        writer = null;
                    }
                }
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="msg"></param>
        public void WriteLog(ErrorModule module, string msg)
        {
            lock (lockHelp)
            {
                try
                {
                    string file = ModulePath(module);
                    writer = new StreamWriter(file, true);
                    writer.WriteLine("-----------------------{0}-----------------------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine(msg);
                    writer.Flush();
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                        writer.Dispose();
                        writer = null;
                    }
                }
            }
        }

        private string ModulePath(ErrorModule module)
        {
            string str;
            switch (module)
            {
                case ErrorModule.Error_All:
                    {
                        str = errorlogpath + "\\AllError.txt";
                    }
                    break;
                case ErrorModule.Error_AP:
                    {
                        str = errorlogpath + "\\ApError.txt";
                    }
                    break;
                case ErrorModule.Error_HANDLER:
                    {
                        str = errorlogpath + "\\HandleError.txt";
                    }
                    break;
                default:
                    {
                        str = Application.StartupPath + "\\ErrorLog.txt";
                    }
                    break;
            }

            return str;
        }

        #endregion
    }

}
