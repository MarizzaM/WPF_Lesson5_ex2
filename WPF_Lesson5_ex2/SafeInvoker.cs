using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Lesson5_ex2
{
    public class SafeInvoker
    {
        public static void SafeInvoke(Window window, Action uiWork)
        {
            // check the current hread.
            // if its UI thead then execute uiWork
            // if not, then summon dispatcher.invoke (uiWork)
            if (window.Dispatcher.CheckAccess()) // am I the UI thread?
            {
                uiWork.Invoke();
                return;
            }
            window.Dispatcher.BeginInvoke(uiWork); // calls the UI thread to draw!
        }

    }
}
