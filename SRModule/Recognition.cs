using System;
using static SRModule.Statistics;
using static SRModule.NeuralNets;
using System.Linq;

namespace SRModule
{
    public class Recognition
    {
       
        public static void PrintArray(double[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }



        public static int Recognize(double[] aInp, string type)
        {

            //        cNetFF NetFF = new NeuralNets().new cNetFF(".\\src\\NNT\\HandDigits.nnt");
            //        cNetFF NetFF = new NeuralNets().new cNetFF(".\\src\\NNT\\HandCharDigitSign.nnt");
            cNetFF NetFF;
            /* if (list)
             {
                 if (type.Equals("lpc")) NetFF = new cNetFF("..\\..\\database\\NN\\lpc_train_digits.nnt");
                 else NetFF = new cNetFF("..\\..\\database\\NN\\mfcc_train_digits.nnt");
             }
             else
             {
                 if (type.Equals("lpc")) NetFF = new cNetFF("..\\..\\database\\NN\\lpc_train_commands.nnt");
                 else NetFF = new cNetFF("..\\..\\database\\NN\\mfcc_train_commands.nnt");
             }*/

            
            string path = "..\\..\\database\\NN\\" + type+"_";
            int length = aInp.Length;
       
            
            switch (length)
            {
                case 546:
                    path += "sesna_checklist_short.nnt";
                    break;
                case 1300:
                    path += "sesna_checklist_long.nnt";
                    break;
                case 442:
                    path += "train_digits.nnt";
                    break;
                case 780:
                    path += "train_commands.nnt";
                    break;
               }
            NetFF = new cNetFF(path);
                 


                    //Random rand = new Random();
                    // double[] aInp = new double[NetFF.Nl[0]];
                    //for (int i = 0; i < aInp.length; i++) {
                    //    aInp[i] = -0.7;
                    //}

                    //NetFF.SetInput(aInp);
                    //NetFF.InitWeightsRandom(0.5);
                    //NetFF.Propogate(); 


                    // int[][] Pattern2D_norm = Service.NormalizeLinearPropor(Pattern2D,32,32);

                    //double[] Feature = FeatureExtraction.FeatureExtraction(Service.ConvertArray2DtoD(Pattern2D_norm) , NetFF.FeatureExtType);

                    NetFF.InputTransformation(aInp);


            NetFF.SetInput(aInp);
            NetFF.Propogate();

            //PrintArray(NetFF.Output);

            NetFF.AnalyzeOutput();

            if (!NetFF.IsRejected)
            {
                double maxValue = NetFF.Output.Max();
                int index = Array.IndexOf(NetFF.Output, maxValue);
                return index;
            }

            else return -1;


        }

    }
}
