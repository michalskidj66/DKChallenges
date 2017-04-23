using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DKChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> timeStamp = new List<double>();
            List<double> ax = new List<double>();
            List<double> ay = new List<double>();
            List<double> az = new List<double>();
            List<double> wx = new List<double>();
            List<double> wy = new List<double>();
            List<double> wz = new List<double>();

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();
            List<string> listD = new List<string>();
            List<string> listE = new List<string>();
            List<string> listF = new List<string>();
            List<string> listG = new List<string>();

            using (var fs = File.OpenRead(@"C:\Users\DJ\Desktop\latestSwing.csv"))
            {
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        listA.Add(values[0]);
                        listB.Add(values[1]);
                        listC.Add(values[2]);
                        listD.Add(values[3]);
                        listE.Add(values[4]);
                        listF.Add(values[5]);
                        listG.Add(values[6]);


                    }
                }
            }

            for (int i = 0; i < listA.Count; i++)
            {
                timeStamp.Add(Convert.ToDouble(listA[i]));
                ax.Add(Convert.ToDouble(listB[i]));
                ay.Add(Convert.ToDouble(listC[i]));
                az.Add(Convert.ToDouble(listD[i]));
                wx.Add(Convert.ToDouble(listE[i]));
                wy.Add(Convert.ToDouble(listF[i]));
                wz.Add(Convert.ToDouble(listG[i]));

            }

            List<List<double>> theData = new List<List<double>>();

            theData.Add(timeStamp);
            theData.Add(ax);
            theData.Add(ay);
            theData.Add(az);
            theData.Add(wx);
            theData.Add(wy);
            theData.Add(wz);

            Methods m = new Methods();
            List<double> scav = new List<double>();
           scav = m.searchContinuityAboveValue(ax, 83, 140, 0, 3);
           scav = m.backSearchContinuityWithinRange(ax, 1000, 23, 1, 1.453, 3);
            scav = m.searchContinuityAboveValueTwoSignals(ax, ay, 23, 1000, 1, 1, 3);
            scav = m.searchMultiContinuityWithinRange(ax, 23, 1000, 1, 1.453, 3); 
        }
            
        
       
    }
    
}
