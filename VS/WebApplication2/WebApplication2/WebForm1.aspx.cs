using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;



namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Dictionary = docfile("bla.txt");
            string[] tudien = Dictionary.Keys.ToArray();
            
            string[] tu_loai = tuloai("bla.txt");
            for (int n = 0; n < row; n++)
            {
                if (tudien[n] != null)
                {
                    //string tudienchuan = tudien[n].Substring(0, tudien[n].Length - 2);
                    string tudienchuan = tudien[n].Split('/')[0];

                    Response.Write(tudienchuan + " - " + tu_loai[n] + " : ");
                    Response.Write("<br />");
                }
            }
        }
        public static int row = 31285;
        public Dictionary<string, List<string>> docfile(string filename)
        {
            StreamReader sr = new StreamReader(Server.MapPath(filename));
            string all = sr.ReadToEnd();
            string[] str = all.Split('\n');
            List<string> tucungnghia = new List<string>();
            string[] tudien = new string[row];
            Dictionary<string, List<string>> Dic = new Dictionary<string, List<string>>();
            
            //string[] tudienchuan = new string[row];
            
            int i = 0;
            foreach (string item in str)
            {
                if (item != "")
                {
                    string[] temp = item.Split('\t');
                    foreach (string substr in temp)
                    {
                        
                            tudien[i] = substr;
                            //tudienchuan[i] = tudien[i].Substring(0, tudien[i].Length - 2);
                        
                        break;        
                    }
                    Dic.Add(tudien[i], tucungnghia);
                    i++;
                    tucungnghia.Clear();
                }
            }

            sr.Close();
            return Dic;
        }

        public string[] tuloai(string filename)
        {
            string[] tachtuloai = new string[row];
            StreamReader sr = new StreamReader(Server.MapPath(filename));
            string all = sr.ReadToEnd();
            string[] str = all.Split('\n');
            string[] tudien = new string[row];

            int i = 0;
            foreach (string item in str)
            {
                if (item != "")
                {
                    string[] temp = item.Split('\t');
                    foreach (string substr in temp)
                    {
                       
                            tudien[i] = substr;
                            break;
                            //tachtuloai[i] = tudien[i].Substring(tudien[i].Length - 2);
                            
                        
                    }
                    tachtuloai[i] = tudien[i].Split('/')[1];
                    if (tachtuloai[i].Equals("V")) tachtuloai[i] = String.Copy("Verb");
                    else if (tachtuloai[i].Equals("O")) tachtuloai[i] = String.Copy("Objective");
                    else if (tachtuloai[i].Equals("N")) tachtuloai[i] = String.Copy("Noun");
                    else if (tachtuloai[i].Equals("A")) tachtuloai[i] = String.Copy("Adjective");
                    else tachtuloai[i] = String.Copy("Unknown");
                    i++;
                }
            }
            return tachtuloai;
        }
    }

    
}