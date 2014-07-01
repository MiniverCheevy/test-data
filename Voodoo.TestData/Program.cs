using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.IO;
namespace ADSpammer
{

    public class RND
    {
        protected static int _lastNum = System.DateTime.Now.Millisecond;
        protected static int _cnt = 0;
        public static int GetRandomInt(int minVal, int maxVal)
        {
            _cnt += 1;
            Random rnd = new Random(_lastNum + _cnt);
            int num = rnd.Next(minVal, maxVal);
            _lastNum = num + _cnt;
            return num;
        }
        public static double GetRandomDouble(int minVal, int maxVal)
        {
            _cnt += 1;
            Random rnd = new Random(_lastNum + _cnt);
            double num = rnd.Next(minVal, maxVal);
            num = num + rnd.NextDouble();
            _lastNum = Convert.ToInt32 (num + Convert.ToDouble(_cnt));
            return num;

        }
        public static string GetRandomText(int lenght)
        {
            Int32 startNum = 97;
            int endNum = 122;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int num = 0;
            for (int i = 0; i <= lenght - 1; i++)
            {
                num = GetRandomInt(startNum, endNum);
                char c = (char)num;
                sb.Append(c.ToString());
            }
            string ret = sb.ToString();
            return ret;
        }

        public static string GetRandomTextWithFunkySymbols(int lenght)
        {
            Int32 startNum = 32;
            int endNum = 126;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i <= lenght - 1; i++)
            {
                sb.Append(((char)(GetRandomInt(startNum, endNum))).ToString ());
            }
            return sb.ToString();
        }
    } 
    class Program
    {
        static DirectoryEntry parent = null;
        
        static string UserPassword="";
        static string department = "";
        static List<string> lastNames = new List<string>();
        static List<string> firstMale = new List<string>();
        static List<string> firstFemale = new List<string>();
        static List<string> usedNames = new List<string>();
        static bool failed = false;
        public static List<string> ReadFile(string mPath)
        {
            string strFilename = mPath;
            string strLine;
            string strFile;
            List<string> ret = new List<string>();
            strFile = System.IO.Path.GetFileNameWithoutExtension(strFilename);
            System.IO.StreamReader objStreamReader;
            objStreamReader = File.OpenText(strFilename);
            while (objStreamReader.Peek() != -1)
            {
                strLine = objStreamReader.ReadLine();
                ret.Add (strLine.Trim ());
            }
            objStreamReader.Close();
            return ret;
        } 
        static string GetDepartment()
        {
            int num = RND.GetRandomInt(10000, 99999);
            string txt = RND.GetRandomText(10);
            return string.Format("{0} {1}", num.ToString(), txt);
        }
        static string GetLastName()
        {
            int idx = 0;

            idx = RND.GetRandomInt(0, lastNames.Count - 1);
            return  lastNames[idx];
        }
        static string GetFirstName()
        {
            int num = RND.GetRandomInt(1, 2);
            int idx = 0;

            string first = "";
            if (num == 1)
            {
                idx = RND.GetRandomInt(0, firstMale.Count - 1);
                first = firstMale[idx];
            }
            else
            {
                idx = RND.GetRandomInt(0, firstFemale.Count - 1);
                first = firstFemale[idx];
            }

           


            return first;
        }

        static void Main(string[] args)
        {
            string path = System.Environment.CurrentDirectory;
            string getPath = String.Format(@"{0}\last.txt", path);
            lastNames = ReadFile(getPath);

            getPath = String.Format(@"{0}\male.txt", path);
            firstMale = ReadFile(getPath);

            getPath = String.Format(@"{0}\female.txt", path);
            firstFemale = ReadFile(getPath);


            string LDAPRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPRoot"].ToString();
        	
            UserPassword = System.Configuration.ConfigurationManager.AppSettings ["UserPassword"].ToString ();
             string NumberToBuild = System.Configuration.ConfigurationManager.AppSettings ["NumberToBuild"].ToString ();
            int num = int.Parse(NumberToBuild);
            department = GetDepartment();

            parent = new DirectoryEntry(
              LDAPRoot,
              null,
              null,
              AuthenticationTypes.Secure
              );

            for (int i = 1; i <= num; i++)
            {
                failed = false;
                CreatUser(i);
                if (failed)
                    Console.Write("x");
                else
                    Console.Write(".");

                if (i % 500 == 0)
                {
                    department = GetDepartment();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine(string.Format("Completed User {0}", i.ToString()));
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Done");
            Console.ReadKey();

		
        }
        static void CreatUser(int i)
        {
            string first = GetFirstName();
            string last = GetLastName();
            string userName="";
            string cn = "";

            while ( usedNames.Contains (string.Format ("{0}.(1)", first, last)))
            {
             first = GetFirstName();
             last = GetLastName();
            }

            usedNames.Add(string.Format("{0}.{1}", first, last));
            userName = string.Format("{0}.{1}", first, last);
            cn = string.Format("{0} {1}", first, last);

            userName = string.Format("{0}.{1}", first, last).ToLower();

            
            DirectoryEntry user =
              parent.Children.Add(string.Format ("CN={0}", cn), "user");

            using (user)
            {

                user.Properties["sAMAccountName"].Value = userName;
                //user.Properties["userPrincipalName"].Value = "shawn.doucet@litwareinc.com";
                user.Properties["mail"].Value = "shawn.doucet@sparkhound.com";
                user.Properties["displayName"].Value = cn;
                user.Properties["cn"].Value = cn;
                user.Properties["department"].Value = department;
                user.Properties["givenName"].Value = first;
                //user.Properties["company"].Value = "Some Company";
                user.Properties["telephoneNumber"].Value = "123-234-3456";
                user.Properties["sn"].Value = last;
                try
                {
                    user.CommitChanges();
                }
                catch {
                    failed = true;
                }



                
               


            }

        
        }
    }
}
