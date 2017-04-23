using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKChallenge
{
    class Methods
    {
        public List<double> searchContinuityAboveValue(List<double> data, int indexBegin, int indexEnd, double threshold, int winLength)
        {
            List<double> returnValue = new List<double>();
            
            
            for (int i = indexBegin; i <= indexEnd; i++)
            {
                if (data[i] > threshold)
                {
                    double holder = data[i];
                    if (returnValue.Contains(data.IndexOf(holder)))
                    {
                        returnValue.Add(data.IndexOf(holder, i, indexEnd));
                    }
                    else
                    {
                        returnValue.Add(data.IndexOf(holder));
                    }
              }
            }

            for (int j = 0; j < returnValue.Count(); j++)
            {
                if(returnValue[j] > indexEnd || returnValue[j] < indexBegin)
                {
                    double remover = returnValue[j];
                    returnValue.Remove(remover);
                }
            }
            int wlPlus = winLength + 1;
            if (returnValue.Count() > winLength)
            {
                returnValue.RemoveRange(wlPlus, returnValue.Count() - wlPlus);
                return returnValue;
            }
            else
            {
                return returnValue;
            }
        }

        public List<double> backSearchContinuityWithinRange(List<double> data, int indexBegin, int indexEnd, double thresholdLo, double thresholdHi, int winLength)
        {
            List<double> returnValue = new List<double>();

            for(int i = indexBegin; i > indexEnd; i--)
            {
                if (data[i] < thresholdHi && data[i] > thresholdLo)
                {
                    double holder = data[i];
                    if (returnValue.Contains(data.IndexOf(holder)))
                    {
                        returnValue.Add(data.IndexOf(holder, i, indexEnd));
                    }
                    else
                    {
                        returnValue.Add(data.IndexOf(holder));
                    }
                }
            }

            for (int j = 0; j < returnValue.Count(); j++)
            {
                if (returnValue[j] < indexEnd || returnValue[j] > indexBegin)
                {
                    double remover = returnValue[j];
                    returnValue.Remove(remover);
                }
            }
            int wlPlus = winLength + 1;
            if (returnValue.Count() > winLength)
            {
                returnValue.RemoveRange(wlPlus, returnValue.Count() - wlPlus);
                return returnValue;
            }
            else
            {
                return returnValue;
            }
        }

        public List<double> searchContinuityAboveValueTwoSignals(List<double> data1, List<double> data2, int indexBegin, int indexEnd, double threshold1, 
            double threshold2, int winLength)
        {
            List<double> returnValue = new List<double>();

            for (int i = indexBegin; i < indexEnd; i++)
            {
                if(data1[i] > threshold1 && data2[i] > threshold2)
                {
                    double holder = data1[i];
                    if (returnValue.Contains(data1.IndexOf(holder)))
                    {
                        returnValue.Add(data1.IndexOf(holder, i, indexEnd));
                    }
                    else
                    {
                        returnValue.Add(data1.IndexOf(holder));
                    }
                }
            }

            for (int j = 0; j < returnValue.Count(); j++)
            {
                if (returnValue[j] > indexEnd || returnValue[j] < indexBegin)
                {
                    double remover = returnValue[j];
                    returnValue.Remove(remover);
                }
            }
            int wlPlus = winLength + 1;
            if (returnValue.Count() > winLength)
            {
                returnValue.RemoveRange(wlPlus, returnValue.Count() - wlPlus);
                return returnValue;
            }
            else
            {
                return returnValue;
            }
        }

        public List<double> searchMultiContinuityWithinRange(List<double> data, int indexBegin, int indexEnd, double thresholdLo, double thresholdHi, int winLength)
        {
            List<double> returnValue = new List<double>();

            for (int i = indexBegin; i < indexEnd; i++)
            {
                if(data[i] > thresholdLo && data[i] < thresholdHi)
                {
                    double holder = data[i];
                    if (returnValue.Contains(data.IndexOf(holder)))
                    {
                        returnValue.Add(data.IndexOf(holder, i));
                    }
                    else
                    {
                        returnValue.Add(data.IndexOf(holder));
                    }

                }
            }
            for (int j = 0; j < returnValue.Count(); j++)
            {
                if (returnValue[j] > indexEnd || returnValue[j] < indexBegin)
                {
                    double remover = returnValue[j];
                    returnValue.Remove(remover);
                }
            }
           
            double sequence = 0;
            List<double> exclude = new List<double>();
            for (int i = 0; i<returnValue.Count(); i++)
            {
                
                if(returnValue[i] - (sequence + 1) == 0)
                {
                    sequence = returnValue[i];
                    exclude.Add(returnValue[i]);
                }
                else if(i>0)
                {
                    exclude.Remove(returnValue[i - 1]);
                }

                sequence = returnValue[i];
            }
            foreach (var value in exclude)
            {
                returnValue.Remove(value);
            }

            int wlPlus = winLength * 2;
            if (returnValue.Count() > winLength)
            {
                returnValue.RemoveRange(wlPlus, returnValue.Count() - wlPlus);
                return returnValue;
            }
            else
            {
                return returnValue;
            }

            
        }
    }
}
