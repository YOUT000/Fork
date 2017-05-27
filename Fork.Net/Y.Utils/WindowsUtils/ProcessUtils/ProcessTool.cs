﻿//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Y.Utils.WindowsUtils.ProcessUtils
{
    public static class ProcessTool
    {
        public static void StartProcess(string appFile)
        {
            try
            {
                if (File.Exists(appFile))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = appFile;
                    //p.StartInfo.Arguments = "";
                    p.StartInfo.UseShellExecute = true;
                    p.Start();
                    p.WaitForInputIdle(3000);
                }
            }
            catch (Exception ex) { }
        }
        public static bool CheckProcessExists(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            foreach (Process p in processes)
            {
                return true;
            }
            return false;
        }
        public static void KillProcess(string name)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (Process p in processes)
                {
                    p.Kill();
                    p.Close();
                }
            }
            catch (Exception e) { }
        }
        public static void KillCurrentProcess()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id == current.Id)
                {
                    process.Kill();
                }
            }
        }
    }
}