//https://docs.microsoft.com/en-us/dotnet/csharp/delegate-class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public delegate void ShowValue();

namespace Delegates
{
    //public delegate int Comparison<in T>(T left, T right);

    //public delegate void Action();
    //public delegate void Action<in T>(T arg);
    //public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);

    class Program
    {
        //public Comparison<T> comparator;
        //private static int CompareLength(string left, string right) =>
        //    left.Length.CompareTo(right.Length);

        static void Main(string[] args)
        {
            //int result = comparator(left, right);
            // List<string> phrases = new List<string>() { "P2", "P1", "P3" };
            //phrases.Sort(CompareLength);
            //ActionType01();
            ActionType02();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void ActionType01()
        {
            Name testName = new Name("Peter");
            ShowValue showMethod = testName.DisplayToWindow;
            showMethod();
        }

        static void ActionType02()
        {
            Name testName = new Name("Cecilia");
            Action showMethod = testName.DisplayToWindow;
            showMethod();
        }
    }

    public class Name
    {
        private string instanceName;

        public Name(string name)
        {
            this.instanceName = name;
        }

        public void DisplayToConsole()
        {
            Console.WriteLine(this.instanceName);
        }

        public void DisplayToWindow()
        {
            MessageBox.Show(this.instanceName);
        }

        
    }
}
