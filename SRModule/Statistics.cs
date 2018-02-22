using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRModule
{
    public class Statistics
    {

        public enum TDataTransformType
        {
            ShiftMeanCovar1, ShiftMeanValMaxCovar, ShiftMeanVal,
            ShiftMeanDeviation1, Mult2Sub1, ShiftMean, IncreaseRate, None,
            ShiftMeanMaxCovar
        };

        public class TDataStatistics
        {

            public double[,] DataCovarMatrix;

            public double[] DataCovar,
                              DataMaxDev,
                              DataMean;

            public double MaxCovarVal,
                              MeanVal,
                              MaxDevVal;

            public int DataCount;

            public TDataStatistics()
            {

            }

            public void DataTransformation(double[] aData, TDataTransformType TransformType)
            {

                //            double[] aOut = new double[aInp.length];

                for (int i = 0; i < aData.Length; i++)
                {
                    try
                    {
                        switch (TransformType)
                        {
                            case TDataTransformType.ShiftMeanCovar1:
                                if (DataCovar[i] > 0)
                                    aData[i] = (aData[i] - DataMean[i]) * Math.Sqrt(1 / DataCovar[i]);
                                else
                                    aData[i] = (aData[i] - DataMean[i]);
                                break;
                            case TDataTransformType.ShiftMeanValMaxCovar: aData[i] = (aData[i] - MeanVal) * Math.Sqrt(1 / MaxCovarVal); break;
                            case TDataTransformType.ShiftMeanMaxCovar: aData[i] = (aData[i] - DataMean[i]) * Math.Sqrt(1 / MaxCovarVal); break;
                            case TDataTransformType.ShiftMeanVal: aData[i] = (aData[i] - MeanVal); break;
                            case TDataTransformType.ShiftMeanDeviation1:
                                if (DataMaxDev[i] > 0)
                                    aData[i] = (aData[i] - DataMean[i]) / (DataMaxDev[i]);
                                else
                                    aData[i] = (aData[i] - DataMean[i]);
                                break;
                            case TDataTransformType.ShiftMean: aData[i] = (aData[i] - DataMean[i]); break;
                            case TDataTransformType.Mult2Sub1: aData[i] = (aData[i] * 2) - 1; break;
                            case TDataTransformType.IncreaseRate: break;
                            case TDataTransformType.None: break;
                            default: aData[i] = aData[i]; break;
                        }
                    }

                    catch { }
                }
                //            return aOut;

            }

        }
    }
}
