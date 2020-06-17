using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Input;

namespace resmonV2
{
    public partial class frmMain : Form
    {
        Process[] processes;
        Process selectedProc;
        List<int> selectedProcs = new List<int>();

        public frmMain()
        {
            InitializeComponent();
            //SuspendProcess(1032);
            //ResumeProcess(1032);
            //getPidByName("CAM.DES");
            tbx_pName.TextChanged += tbx_pName_TextChanged;
        }

        private void tbx_pName_TextChanged(object sender, EventArgs e)
        {
            getPidByName(tbx_pName.Text);
        }

        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        public void printProcess(Process[] processes)
        {
            lbx_matches.Items.Clear();
            foreach (var process in processes)
            {
                lbx_matches.Items.Add(process.ProcessName.ToString() + "(" + process.Id.ToString() + ")" + " responding: " + process.Responding.ToString());
            }
        }

        public void getPidByName(string pName)
        {
            lbx_matches.Items.Clear();
            processes = Process.GetProcessesByName(pName);
            lbl_debug.Text = processes.Length.ToString();
            printProcess(processes);
        }
        public static void SuspendProcess(int pid)
        {
            var process = Process.GetProcessById(pid); // throws exception if process does not exist

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                SuspendThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
        }

        public static void ResumeProcess(int pid)
        {
            var process = Process.GetProcessById(pid);

            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                var suspendCount = 0;
                do
                {
                    suspendCount = ResumeThread(pOpenThread);
                } while (suspendCount > 0);

                CloseHandle(pOpenThread);
            }
        }

        private void Btn_suspend_Click(object sender, EventArgs e)
        {
            if (processes.Length > 0 && tbx_pName.Enabled)
            {
                foreach (var process in processes)
                {
                    SuspendProcess(process.Id);
                }
                printProcess(processes);
            }
            else if (selectedProcs.Count > 0)
            {
                foreach (var proc in selectedProcs)
                {
                    Console.WriteLine("Suspending " + processes.ElementAt(proc).ProcessName + "(" + processes.ElementAt(proc).Id + ")");
                    SuspendProcess(processes.ElementAt(proc).Id);
                }
                selectedProcs.Clear();
                lbl_selectedProc.Text = "";
                updateProcesses();
            }
            else
            {
                lbl_debug.Text = "Suspending " + selectedProc.ProcessName;
                SuspendProcess(selectedProc.Id);
                lbl_debug.Text = "Suspended " + selectedProc.ProcessName;
                updateProcesses();
            }
        }

        private void Btn_resume_Click(object sender, EventArgs e)
        {
            //tbx_pName.Text = "BRUH";
            if (processes.Length > 0 && tbx_pName.Enabled)
            {
                foreach (var process in processes)
                {
                    ResumeProcess(process.Id);
                }
                printProcess(processes);
            }
            else if (selectedProcs.Count > 0)
            {
                foreach (var proc in selectedProcs)
                {
                    Console.WriteLine("Resuming " + processes.ElementAt(proc).ProcessName + "(" + processes.ElementAt(proc).Id + ")");
                    ResumeProcess(processes.ElementAt(proc).Id);
                }
                selectedProcs.Clear();
                lbl_selectedProc.Text = "";
                updateProcesses();
            }
            else
            {
                lbl_debug.Text = "Resuming " + selectedProc.ProcessName;
                ResumeProcess(selectedProc.Id);
                lbl_debug.Text = "Resumed " + selectedProc.ProcessName;
                updateProcesses();
            }
        }
        private void Btn_terminate_Click(object sender, EventArgs e)
        {
            //tbx_pName.Text = "BRUH";
            if (processes.Length > 0 && tbx_pName.Enabled)
            {
                foreach (var process in processes)
                {
                    process.Kill();
                    processes = processes.Where(proc => process.Responding != false).ToArray();
                    printProcess(processes);
                    lbl_debug.Text = processes.Length.ToString();
                }
            }
            else if(selectedProcs.Count > 0)
            {
                foreach(var proc in selectedProcs)
                {
                    Console.WriteLine("Terminating " + processes.ElementAt(proc).ProcessName + "(" + processes.ElementAt(proc).Id + ")");
                    processes.ElementAt(proc).Kill();
                }
                selectedProcs.Clear();
                lbl_selectedProc.Text = "";
                updateProcesses();
            }
            else
            {
                lbl_debug.Text = "Terminating " + selectedProc.ProcessName;
                selectedProc.Kill();
                lbl_debug.Text = "Terminated " + selectedProc.ProcessName;
                updateProcesses();
            }
        }

        private static Process[] sortProcesses(Process[] unSortedProcesses)
        {
            Process[] sortedProcesses = unSortedProcesses;
            Array.Sort(sortedProcesses, delegate (Process proc1, Process proc2) { return proc1.ProcessName.CompareTo(proc2.ProcessName); });
            return sortedProcesses;
        }
        private void updateProcesses()
        {
            processes = sortProcesses(Process.GetProcesses());
            printProcess(processes);
        }

        private void Cbx_showAll_CheckedChanged(object sender, EventArgs e)
        {
            Process[] clear = { };
            if (cbx_showAll.Checked)
            {
                tbx_pName.Enabled = false;
                lbx_matches.Enabled = true;
                lbx_matches.Focus();
                processes = clear;
                processes = sortProcesses(Process.GetProcesses());
                printProcess(processes);
                lbl_debug.Text = processes.Length.ToString();
            }
            else
            {
                tbx_pName.Enabled = true;
                lbx_matches.Enabled = false;
                processes = clear;
                printProcess(processes);
                lbl_debug.Text = processes.Length.ToString();
            }
        }

        private void Lbx_matches_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedProc = processes.ElementAt(lbx_matches.SelectedIndex);
            
            //lbl_debug.Text = selectedProc.Id.ToString();
            if(lbx_matches.SelectedItems.Count > 1)
            {
                lbl_selectedProc.Text = "";
                selectedProcs.Clear();
                foreach (var item in lbx_matches.SelectedItems)
                {
                    lbl_selectedProc.Text += " " + lbx_matches.Items.IndexOf(item).ToString();
                    //selectedProcs = processes.Where(proc => proc.Id == lbx_matches.Items.IndexOf(item)).ToArray();
                    selectedProcs.Add(lbx_matches.Items.IndexOf(item));
                    Console.WriteLine(lbx_matches.Items.IndexOf(item).ToString());
                }
                //processes = selectedProcs;
            }
            else if(lbx_matches.SelectedItems.Count > 0)
            {
                lbl_selectedProc.Text = processes.ElementAt(lbx_matches.SelectedIndex).Id.ToString();
                selectedProc = processes.ElementAt(lbx_matches.SelectedIndex);
            }
        }
    }
}
