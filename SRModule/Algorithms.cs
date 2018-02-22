using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SRModule
{
    public class Algorithms
    {
        public Algorithms(float[] array = null)
        {
            liftMFCC = false;
            msMFCC = false;
            liftLPC = false;
            msLPC = false;
            L = 100;
            Sc = 1000;
            beta = 0.8;
            blocks = 5;
            z1 = 13;                    //  (*** Kepstrallarin sayi ***)
            fstart = 64;               //   (*** Ilkin faydali tezlik ***)
            Z = 24;                  //     (*** Mel filterindeki kanallarin sayi ***)
            LpcP = 12;
            LifterPar = 13;        //       (*** Guclendirme emsali ***)
            scale =7120;   //7120; 
            coefFIR = 0.97;
            if (array != null)
            {
                originalWavSamples = new double[array.Length];
                MainWindow.floatToDouble(array, originalWavSamples);
            }
            /*sosna_checkList_short.txt-7120
            sosna_checkList_long.txt-16400 */

        }
        public long midLen = 0;
        public long midCount = 0;
        public double[,] frameMatrix;
        public double[,] hammingFrameMatrix;
        public double[,] bin;
        public double[] energyOfFrames;
        public double[] originalWavSamples;
        public double[] PPsamples;
       // public double[] VADsamples;
        public double[] scalledSamples;
        public double[,] LifteringcepstralMFCC;
        public double[,] LifteringcepstralLPC;
        public double[,] fbank;
        public double[,] cepstralMFCC;
        public double[,] cepstral;
        public double[,] McepstralMFCC;
        public double[,] McepstralLPC;
        public double[,] Rc;
        public double[,] Qamma;
        public double[,] Q;
        public double[,] E;
        public double[,] TersNitq;
        public double[,] cepstralLPC;
        public double[,,] a2Lpc;
       // public Complex[][] hammingFrameMatrixComplex;
        public double[,] fourierMatrix;
        public double[] forGraph;

        public int frameLength;
        public int frameCount;
        public int frameStep;
        public int z1;                   //  (*** Kepstrallarin sayi ***)
        public int fstart;              //   (*** Ilkin faydali tezlik ***)
        public int fs;               //    (*** Diskretleme tezliyi ***)
        public int Z;                  //     (*** Mel filterindeki kanallarin sayi ***)
        public int LpcP;
        public int LifterPar;      //       (*** Guclendirme emsali ***)
        public int scale;
        public int L;
        public int Sc;
        public int blocks;
        public double beta;
        public bool liftMFCC;
        public bool msMFCC;
        public bool liftLPC;
        public bool msLPC;
        public double coefFIR;

        // Set and Get methods in order to work with public variables

        public double calibrateTw;
        public bool[] getVAD(double TW)
        {
            bool[] a = new bool[8];
            int step = L;
            double tw;
            if (TW == 0 || TW > 0.1) tw = 0.01;
            else tw = TW;
            int pt = 0;
            for (int i = step; i < PPsamples.Length; i += step)
            {
                Boolean vad = VAD(i, L, Sc, tw);
                a[pt++] = vad;
            }
            return a;
        }


        public int get_fs()
        {
            return fs;
        } 
        
        public double[,] gethamming()
        {
            return hammingFrameMatrix;
        }

        public double[,] getRc()
        {
            return Rc;
        }
        public void setSamples(int len)
        {
            originalWavSamples = new double[len];
        }

        public double[] getOriginalSamples()
        {
            return originalWavSamples;
        }

        public double[] getPPsamples()
        {
            return PPsamples;
        }

       /* public double[] getVADsamples()
        {
            return VADsamples;
        }*/

            public void set_z1(int x)
        {
            z1 = x;
        }

        public void set_Z(int x)
        {
            Z = x;
        }

        public void set_fstart(int x)
        {
            fstart = x;
        }

        public void set_fs(int x)
        {
            fs = x;
        }

        public void set_LpcP(int x)
        {
            LpcP = x;
        }

        public void set_LifterPar(int x)
        {
            LifterPar = x;
        }

        public void set_frameLength(int x)
        {
            frameLength = x;
        }

        public void set_frameStep(int x)
        {
            frameStep = x;
        }

        public void set_scale(int x)
        {
            scale = x;
        }

        public void defineStepAndLength()
        {
            if (fs == 16000) { frameLength = 512; frameStep = 160 ; }
            else if (fs == 11025) { frameLength = 256; frameStep = 110; }
            else { frameLength = 200 ; frameStep = 80; }
        }
      
        // Method for preprocessing the original Wav samples
        public void preProcessing()
        {
            PPsamples = new double[originalWavSamples.Length];
            PPsamples[0] = originalWavSamples[0];
            for (int i = 1; i < originalWavSamples.Length; i++)
            {
                PPsamples[i] = originalWavSamples[i] - coefFIR * originalWavSamples[i - 1];
            }
        }

        // Function to determine the energy of block of samples
        public double energyEstimate(int m, int L)
        {
            double Es = 0; ;
            for (int i = m - L; i < m; i++)
            {
                Es += PPsamples[i] * PPsamples[i];
            }
            return Es;
        }

        // Function to determine the power of block of samples
        public double powerEstimate(int m, int L)
        {
            double Ps = energyEstimate(m, L) / L;
            return Ps;
        }

        // Function the determine how many times graph of our wave crossed the zero
        public double zeroCrossingRate(int m, int L)
        {
            double Zs = 0;
            for (int i = m - L + 1; i < m; i++)
            {
            Zs += Math.Abs(sgn(PPsamples[i]) - sgn(PPsamples[i - 1])) / 2;
            }
            
            return (Zs / L);
        }

        // Sign function
        public int sgn(double n)
        {
            if (n>= 0) return 1;
            else return -1;
        }

        // Function to determine WS
        public double findWs(int m, int L, int Sc)
        {
            double Ps = powerEstimate(m, L);
            double Zs = zeroCrossingRate(m, L);
            double Ws = Ps * (1 - Zs) * Sc;
           // Console.WriteLine("[" + m + "]"+ "Ps - " + Ps + " Zs - " + Zs + " Ws = " + Ws);
            return Ws;
        }

        //Function to determine Tw
        public double findTw()
        {
            int m = (PPsamples.Length / L) * L;
           // Console.WriteLine("length = " + PPsamples.Length + " M = " + m);
            double mv = mean(m, L, Sc, blocks);
            double bv = variance(m, L, Sc, blocks, mv);
            double alfa = 0.2 * Math.Exp(-beta*Math.Log(bv)); // -0.8 variable 
          //  Console.WriteLine("bw" + bv);
          //  Console.WriteLine("mv" + mv);
            return mv + bv * alfa;
        }

        //Calculating mean Ws for the given number of blocks 
        public double mean(int m, int L, int Sc, int blocks)
        {
            double mean = 0;
            for (int i = m - L * (blocks - 1); i <= m; i += L)
            {
                mean += findWs(i, L, Sc);
              //  Console.WriteLine("print="+ mean);
            }
            return mean / blocks;
        }

        // Calculating variance for the givent number of blocks
        public double variance(int m, int L, int Sc, int blocks, double mv)
        {
            double variance = 0;
            for (int i = m - L * (blocks - 1); i <= m; i += L)
            {
                variance += (findWs(i, L, Sc) - mv) * (findWs(i, L, Sc) - mv);
            }
            return variance / (blocks - 1);
        }

        // Function to determine VAD
        public Boolean VAD(int m, int L, int Sc, double Tw )
        {
            double Ws = findWs(m, L, Sc);
            //  Console.WriteLine("Ws[" + m + "]" + Ws);
            if (Ws >= Tw) return true;
            else return false;
        }

        public void getTw(string name)
        {
            double Tw = findTw();
            if (Tw > 0.1) Tw = 0.03;
            string s = name.Split('\\')[name.Split('\\').Length - 1];
            using (StreamWriter salam = new StreamWriter("twler.txt", true))
            {
                salam.WriteLine(s + " - " + Tw);
            }
        }


        public List<double[]> cropWordsWithoutVAD(NAudio.Wave.WaveFormat audio, String path = "")
        {
            int notNoise = 0;
            StreamWriter w = new StreamWriter("Length.txt", true);
            int step = L;
            int cnt = 0;
            double Tw = findTw();
           // double Tw = 0.01;
            Console.WriteLine(Tw + " = Tw");
            if (Tw > 0.1) Tw = 0.03;
            string[] massiv = path.Split('\\');
            string fileName = massiv[massiv.Length - 1].Split('.')[0];
            List<int> list = new List<int>();
            List<double[]> words = new List<double[]>();
            int zeros = 0;
            for (int i = step; i < PPsamples.Length; i += step)
            {
                Boolean vad = VAD(i, L, Sc, Tw);
                //  Console.Write(vad + " ");
                list.Add(i - step);
                list.Add(i);

                if (vad)
                {
                    notNoise++;
                    zeros = 0;
                }
                else
                {
                    zeros++;
                }

                if (zeros > 35 && notNoise > 30)
                {
                    zeros = 0;
                    notNoise = 0;
                    cnt++;
                    double[] file = new double[list.Count / 2 * step];
                    int pos = 0;
                    // printIntArray(list.ToArray());
                    for (int j = 0; j < list.Count; j += 2)
                        for (int k = list[j]; k < list[j + 1]; k++)
                            file[pos++] = PPsamples[k];
                    words.Add(file);
                    w.WriteLine(file.Length);


                    if (!String.IsNullOrEmpty(path))
                    {
                        float[] file2 = new float[file.Length];
                        var s = path.Substring(0, path.Length - 4);
                        Directory.CreateDirectory(s);
                        Console.WriteLine("Created directory " + s);
                        MainWindow.doubleToFloat(file2, file);
                        MainWindow.createWav(file2, s + "/" + fileName + "-" + cnt, audio);
                        Console.WriteLine(cnt);
                    }
                    list.Clear();
                }

            

            }
            if (notNoise > 30)
            {
                cnt++;
                double[] file = new double[list.Count / 2 * step];
                int pos = 0;
                // printIntArray(list.ToArray());
                for (int j = 0; j < list.Count; j += 2)
                    for (int k = list[j]; k < list[j + 1]; k++)
                        file[pos++] = PPsamples[k];
                words.Add(file);
                w.WriteLine(file.Length);

                if (!String.IsNullOrEmpty(path))
                {
                    float[] file2 = new float[file.Length];
                    var s = path.Substring(0, path.Length - 4);
                    Directory.CreateDirectory(s);
                    Console.WriteLine("Created directory " + s);
                    MainWindow.doubleToFloat(file2, file);
                    MainWindow.createWav(file2, s + "/" + fileName + "-" + cnt, audio);
                    Console.WriteLine(cnt);
                }

            }

            List<Double> aw = new List<double>();
            foreach(var cw in words) {
                aw.AddRange(cw);
            }
            forGraph = aw.ToArray();
            w.Close();
            return words;
        }

        public List<double[]> cropWords(NAudio.Wave.WaveFormat audio, String path="") {
			StreamWriter w = new StreamWriter("Length.txt", true); 
            int step = L;
            int cnt = 0;
            double Tw = findTw();
           // double Tw = 0.01;
            Console.WriteLine(Tw +  "=Tw");
            if (Tw > 0.1) Tw = 0.03;
            string[] massiv = path.Split('\\');
            string fileName = massiv[massiv.Length - 1].Split('.')[0];
            List<int> list = new List<int>();
            List<double[]> words = new List<double[]>();
            int zeros = 0;
            for (int i = step; i < PPsamples.Length; i += step)
            {
                Boolean vad = VAD(i, L, Sc, Tw);
              //  Console.Write(vad + " ");
                if (vad)
                {
                    zeros = 0;
                    list.Add(i - step);
                    list.Add(i);
                }
                else zeros++;
                if (zeros > 35 && list.Count > 30)
                {
                    zeros = 0;
                    cnt++;
                    double[] file = new double[list.Count / 2 * step];
                    int pos = 0;
                   // printIntArray(list.ToArray());
                    for (int j = 0; j < list.Count; j += 2)
                        for (int k = list[j]; k < list[j + 1]; k++)
                            file[pos++] = PPsamples[k];
                    words.Add(file);
					w.WriteLine(file.Length);
                    

                    if (path.Length > 0)
                    {
                        float[] file2 = new float[file.Length];
                        var s = path.Substring(0, path.Length - 4);
                        Directory.CreateDirectory(s);
                        Console.WriteLine("Created directory " + s);
                        MainWindow.doubleToFloat(file2, file);
                        MainWindow.createWav(file2, s + "/" + fileName + "-" + cnt, audio);
                        Console.WriteLine(cnt);
                    }
                    list.Clear();
                }

            }
            if(list.Count > 30)
            {
                cnt++;
                double[] file = new double[list.Count / 2 * step];
                int pos = 0;
               // printIntArray(list.ToArray());
                for (int j = 0; j < list.Count; j += 2)
                    for (int k = list[j]; k < list[j + 1]; k++)
                        file[pos++] = PPsamples[k];
                words.Add(file);
				w.WriteLine(file.Length);
                
                if (path.Length > 0)
                {
                    float[] file2 = new float[file.Length];
                    var s = path.Substring(0, path.Length - 4);
                    Directory.CreateDirectory(s);
                    Console.WriteLine("Created directory " + s);
                    MainWindow.doubleToFloat(file2, file);
                    MainWindow.createWav(file2, s + "/" + fileName + "-" + cnt, audio);
                    Console.WriteLine(cnt);
                }

            }
			w.Close();

            List<Double> aw = new List<Double>();
            foreach (var cw in words)
            {
                aw.AddRange(cw);
            }
            forGraph = aw.ToArray();


            return words;
			
        }

        // Croping the parts of array that does not contain voice
      /*  public void cropArray()
        {
            int step = L;
            double Tw = findTw(L, Sc, blocks, beta);
          //  int cnt = 0;
           // Console.WriteLine("Tw = "+Tw);
           // string cropParts = "";
            List<int> list = new List<int>();
            for (int i = step; i < PPsamples.Length; i += step)
            {
                Boolean vad = VAD(i, L, Sc, Tw);                
                if (vad)
                {
                    list.Add(i - step);
                    list.Add(i);
            //        cropParts += (i - step) + " " + (i);
           //         if (i + step < PPsamples.Length) cropParts += " ";
           //         cnt++;
                  //  Console.WriteLine("cnt = " + cnt);
                }
            }
            // Console.WriteLine("last block - " + (PPsamples.Length - 1));
           // Console.Write(cropParts);
           // if (cropParts[cropParts.Length - 1] == ' ') cropParts = cropParts.Substring(0, cropParts.Length - 1);
            int[] ints = list.ToArray();
            VADsamples = new double[ints.Length/2*step];
            int pos = 0;
         
            for (int i = 0; i < ints.Length; i += 2)
            {
                //Console.WriteLine(ints[i] + " " + ints[i + 1] + "pos");
                for (int j = ints[i]; j < ints[i + 1]; j++)
                {
                    VADsamples[pos] = PPsamples[j];
                   // Console.WriteLine();
                    pos++;
                    // Console.WriteLine("[" + pos+ "]" + PPsamples[j]);
                }
            }
            //Console.WriteLine(VADsamples.Length);
            midLen += VADsamples.Length;
            midCount++;

        }*/

        // Scaling the given array to the length given using lagranj function
        public void scaling(double[] VADsamples)
        {
            double emsal = VADsamples.Length * 1.0 / scale;
            // Console.WriteLine(emsal + " " + VADsamples.Length);
            scalledSamples = new double[scale];
            double j = 0;
            int k;
            for (int i = 0; i < scale - 6; i++)
            {
                j = emsal * i;
                k = (int)j;
                if (k + 2 >= VADsamples.Length) continue;
                if (k == 0) scalledSamples[i] = VADsamples[i];
                else
                {
                    //  Console.WriteLine("k = " + k + " length = " + VADsamples.Length);
                    scalledSamples[i] = lagranj(k - 1, k, k + 1, k + 2,
                    VADsamples[k - 1], VADsamples[k], VADsamples[k + 1], VADsamples[k + 2], (double)j);
                }
            }
        }

        // Lagranj function itself
        public double lagranj(double a, double b, double c, double d,
            double y0, double y1, double y2, double y3, double x)
        {
            return (x - b) * (x - c) * (x - d) * y0 / ((a - b) *
                (a - c) * (a - d)) + (x - a) * (x - c) * (x - d) *
                y1 / ((b - a) * (b - c) * (b - d)) + (x - a) * (x - b) * (x - d) *
                y2 / ((c - a) * (c - b) * (c - d)) + (x - a) * (x - b) * (x - c) *
                y3 / ((d - a) * (d - b) * (d - c));
        }

        // Framing of scalled array
        public void framing()
        {
            int numberOfFrames = (int)((scalledSamples.Length - frameLength + frameStep) * 1.0 / frameStep);
            frameCount = numberOfFrames;
            frameMatrix = new double[frameLength, numberOfFrames];
            for (int r = 0; r < numberOfFrames; r++)
                for (int i = 0; i < frameLength; i++)
                {
            //        Console.WriteLine(i + " and " + r + " 1L =" + scalledSamples.Length + 
           //             " 2L" + frameMatrix.GetLength(0) + " " + frameMatrix.GetLength(1));
                    frameMatrix[i, r] = scalledSamples[r * frameStep + i];             
                }         
        }

        
        // Determination of energy after framing
        public void energyAfterFraming()
        {
            double s = 0;
            energyOfFrames = new double[frameMatrix.GetLength(1)];
            for (int j=0; j<frameMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < frameMatrix.GetLength(0); i++)
                    s += frameMatrix[i, j] * frameMatrix[i, j];
                energyOfFrames[j] = (double)Math.Log(s);
            }
        }
        // implementing hamming after framing
        public void hamming()
        {
           // hammingFrameMatrixComplex = new Complex[frameMatrix.GetLength(1)][]; 
            hammingFrameMatrix = new double[frameMatrix.GetLength(0), frameMatrix.GetLength(1)];
            for(int i = 0; i < frameMatrix.GetLength(1); i++)
            {
                //hammingFrameMatrixComplex[i] = new Complex[512];
            }
            for (int i = 0; i < frameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < frameMatrix.GetLength(1); j++)
                {
                    
                    hammingFrameMatrix[i, j] = frameMatrix[i, j] * (double)(.54 - 0.46 * Math.Cos(2.0 * Math.PI * (i - 1) /
                        frameMatrix.GetLength(0)));
                  //  hammingFrameMatrixComplex[j][i] = new Complex(hammingFrameMatrix[i, j], 0);
                    
                }
            }
           
           
        }
		/*
		 *  
        public void fastFourier()
        {
            for (int i = 0; i < hammingFrameMatrixComplex.Length; i++)
                FourierTransform.FFT(hammingFrameMatrixComplex[i], FourierTransform.Direction.Forward);
            fourierMatrix = new double[hammingFrameMatrixComplex[0].Length, hammingFrameMatrixComplex.Length];
            for (int i = 0; i < hammingFrameMatrixComplex.Length; i++)
                for (int j = 0; j < hammingFrameMatrixComplex[0].Length; j++)
                    fourierMatrix[j, i] = hammingFrameMatrixComplex[i][j].Re;
        }
		*/

		private struct complex
		{
			public double real, image;

			public complex(double real, double image)
			{
				this.real = real;
				this.image = image;
			}
		}

		private complex Add(complex a, complex b)
		{
			return new complex(a.real + b.real,a.image + b.image);
		}

		private complex Minus(complex a, complex b)
		{
			return new complex(a.real - b.real, a.image - b.image);
		}

		private complex Multiply(complex a, complex b)
		{
			return new complex(a.real * b.real - a.image * b.image, a.real * b.image + a.image * b.real);
		}
		private complex Divide(complex a, int b)
		{
			return new complex(a.real / b, a.image / b);
		}


		// Fast fourier transformantion
		void FFT(complex[] a, int n, bool inv = false)
        {
            int i;
            if (n == 1) return;

            complex[] a0 = new complex[n / 2];
            complex[] a1 = new complex[n / 2];
            double angle = 2 * Math.PI / n * (inv ? -1 : 1);
			complex temp;
			complex w = new complex(1, 0); 
			complex e = new complex(Math.Cos(angle), Math.Sin(angle));

            for (i = 0; i < n / 2; i++) {
                a0[i] = a[2 * i];
                a1[i] = a[2 * i + 1];
            }

            FFT(a0, n >> 1, inv);
            FFT(a1, n >> 1, inv);

            for (i = 0; i < n / 2; i++)
            {
                temp = Multiply(w,a1[i]);
                a[i] = Add(a0[i],temp);
                a[i + n / 2] = Minus(a0[i],temp);
                if (inv)
                {
                    a[i] = Divide(a[i],2);
                    a[i + n / 2] = Divide(a[i + n / 2], 2);
                }
                w = Multiply(w,e);
            }
        }



		public void furye()
		{
			//double s1, s2, r1, r2;
			bin = new double[frameMatrix.GetLength(0), frameMatrix.GetLength(1)];
			//r1 = 2 * Math.PI / frameMatrix.GetLength(0);
			//using (StreamWriter file =
			//new StreamWriter("WriteLines2.txt"))
			//{


			for (int j = 0; j < frameMatrix.GetLength(1); j++)
			{
				complex[] a = new complex[hammingFrameMatrix.GetLength(0)];
				for (int n = 0; n < frameMatrix.GetLength(0); n++)
				{
					a[n] = new complex(hammingFrameMatrix[n, j], 0);
				}
				int cnt = 1;
				while (cnt < frameMatrix.GetLength(0)) cnt <<= 1;
				FFT(a, cnt);
				for (int n = 0; n < frameMatrix.GetLength(0); n++)
				{
					var b = a[n];
					bin[n, j] = Math.Sqrt(b.real * b.real + b.image * b.image);
				}
				/*
				if (j == 0)
				{
					for (int n = 0; n < frameMatrix.GetLength(0); n++)
					{
						var b = a[n];
						file.WriteLine(Math.Sqrt(b.real * b.real + b.image * b.image) + " ");
					}
					file.WriteLine();
				}
				*/
			}
			/*
			// FT slow
			double s1, s2, r1, r2;
			r1 = 2 * Math.PI / frameMatrix.GetLength(0);
			for (int j = 0; j < frameMatrix.GetLength(1); j++)
			{
				for (int k = 0; k < frameMatrix.GetLength(0); k++)
				{
					s1 = 0; s2 = 0; r2 = r1 * k;
					for (int n = 0; n < frameMatrix.GetLength(0); n++)
					{
						s1 += hammingFrameMatrix[n, j] * Math.Cos(r2 * n);
						s2 += hammingFrameMatrix[n, j] * Math.Sin(r2 * n);
					}
					//file.Write(s1 + " " + s2 + " ");
					bin[k, j] = Math.Sqrt(s1 * s1 + s2 * s2);
					//if(j == 0)
					//file.WriteLine(bin[k, j] + " ");
				}
				//file.WriteLine();
			}
			/*  int l = 5;
			  *int nyy = l / 0;*/
		}


		// Mel and Inverse Mel functions
		public double Mel (double x)
        {
            return 2595 * Math.Log10(1 + (x / 700));
        }

        public double inverseMel (double x)
        {
            return 700 * ( Math.Pow(10, x / 2595)- 1);
        }
      
        public void melFiltering()
        {
            double[] fc = new double[Z - 1];
            int[] cbin = new int[Z + 1];
            for (int i=0; i<fc.Length; i++)
            {
                fc[i]= inverseMel(Mel(fstart*1.0) + (Mel(fs*1.0 / 2) - Mel(fstart*1.0)) * (i + 1) / Z);
                cbin[i + 1]=(int) Math.Round(fc[i] * frameLength / fs);
            }
            cbin[0]= (int)Math.Round(fstart * frameLength*1.0 / fs);
            cbin[Z]=frameLength / 2;
            // printIntArray(cbin);
          //  printDoubleArray(fc);
            fbank = new double[Z - 1, frameCount];
            double fb1, fb2;
            for (int j=0; j<frameCount; j++)
            {
                for (int k=1; k<Z; k++)
                {
                    fb1 = 0;
                    for(int i=cbin[k-1]; i<=cbin[k]; i++)
                        fb1 = fb1 + (i - cbin[k - 1] + 1) * bin[i - 1, j] / (cbin[k] - cbin[k - 1] + 1);
                    fb2 = 0;
                    for(int i = cbin[k] + 1; i<= cbin[k + 1]; i++)
                        fb2 = fb2 + (1 - (i - cbin[k])*1.0 / (cbin[k + 1] - cbin[k] + 1)) * bin[i - 1, j];
                    fbank[k - 1, j]= Math.Log(fb1 + fb2);
                }
            }
        }

        public void cepstarProcessing()
        {
            double ce;
            cepstral = new double[z1-1, frameCount];
            double[,] cepstral13 = new double[z1, frameCount];
            for (int k=0; k<frameCount; k++)
            {
                for (int i=1; i<=z1; i++)
                {
                    ce = 0;
                    for(int j=0; j<Z-1; j++)
                    {
                       // Console.WriteLine(fbank[j,k]);
                        ce+= fbank[j, k] * Math.Cos(Math.PI * (i - 1)*1.0 * ((j + 1) - 0.5) / (Z - 1));
                    }
                    cepstral13[i - 1, k] = ce;
                }
            }
            for (int j=0; j <frameCount; j++)
                for(int i=0;i<=z1-2;i++)
                    cepstral[i, j]= cepstral13[i + 1, j];
        }

        public void addingEnergy()
        {
            cepstralMFCC = new double[z1, frameCount];
            for (int j = 0; j < frameCount; j++)
                for (int i = 0; i <= z1 - 2;i++)
                    cepstralMFCC[i, j] = cepstral[i, j];
            for (int i = 0; i < frameCount; i++)
            {
                cepstralMFCC[z1 - 1, i] = energyOfFrames[i];
            }

        }

        public double[,] liftering(double[,] feature)
        {
            double mm;
            double[,] Lifteringcepstral = new double[z1, frameCount];
            for (int j = 0; j < frameCount; j++)
                for (int q = 0; q <= z1 - 1; q++)
                {
                    mm = (1.0 + (LifterPar - 1)*1.0 * (Math.Sin(Math.PI * q *1.0 / (LifterPar - 1))) / 2);                    
                
                        Lifteringcepstral[q, j] = feature[q, j] * mm;
                
                }
            return Lifteringcepstral;
        }

        public double[,] cepstralMeanSubstraction( double[,] feature)
        {
            double mm;
            double[,] cepstralMS = new double[z1, frameCount];           
            for (int j = 0; j < frameCount; j++)
            {
                for (int q = 0; q <= z1 - 1; q++)
                {
                    mm = 0;
                    for (int i = 0; i < frameCount; i++)
                        mm += feature[q, i];
                    cepstralMS[q, j] = feature[q, j] - mm / frameCount;
                }
            }
            return cepstralMS;
        }
        
        public void autoCorrelation()
        {
            Rc = new double[LpcP + 1, frameCount];
           
                for (int j = 0; j < frameCount; j++)
                {
                    for (int m = 0; m < LpcP + 1; m++)
                    {

                        Rc[m, j] = 0;
                        for (int n = 0; n < frameLength; n++)
                        {
                            if (n - m >= 0) Rc[m, j] = Rc[m, j]+ hammingFrameMatrix[n, j] * hammingFrameMatrix[n - m, j];
                        }
                    }
                }
            
        }

		public void levinson()
        {
            double sLpc2;
            Qamma = new double[LpcP, frameCount];
            Q = new double[LpcP + 1, frameCount];
            E = new double[LpcP + 1, frameCount];
            a2Lpc = new double[LpcP + 1, LpcP + 1, frameCount];
            

            for (int j = 0; j < frameCount; j++)
            {
                a2Lpc[0, 0, j] = 1;
                E[0, j] = Rc[0, j];
                Q[0, j] = 0;
            }
            for (int k = 0; k < frameCount; k++)
                for (int j = 0; j < LpcP; j++)
                {
                    sLpc2= 0;
                   for(int i=1; i<j+1; i++)
                            sLpc2= sLpc2 + a2Lpc[j, i, k] * Rc[j - i + 1, k];

                     Qamma[j, k]= Rc[j + 1, k] + sLpc2;
                    Q[j + 1, k]= -Qamma[j, k] / E[j, k];
                    for (int i = 1; i < j + 1; i++)
                        a2Lpc[j + 1, i, k]= a2Lpc[j, i, k] + Q[j + 1, k] * a2Lpc[j, j - i + 1, k];
                    a2Lpc[j + 1, j + 1, k]= Q[j + 1, k];
                    E[j + 1, k]= E[j, k] * (1 - (Math.Abs(Q[j + 1, k])* Math.Abs(Q[j + 1, k])));
                }
        }
        
        public void tersLpc()
        {
            TersNitq = new double[frameLength, frameCount];
            for (int i = 0; i < frameCount; i++)
                for (int j = 0; j < LpcP + 1; j++)
                    TersNitq[j, i] = hammingFrameMatrix[j, i];
            for (int i = 0; i < frameCount; i++)
                for (int j = LpcP + 1; j < frameLength; j++)
                {
                    TersNitq[j, i] = 0;
                    for(int r=1; r<LpcP+1; r++)
                        TersNitq[j, i]= TersNitq[j, i] + a2Lpc[LpcP, r, i] * hammingFrameMatrix[j - r, i];
                }
            double DeltaELpc2= 0;
            for (int r = 0; r < frameCount; r++)
                for (int j = 0; j < frameLength; j++)
                    DeltaELpc2 = DeltaELpc2 + (TersNitq[j, r] + hammingFrameMatrix[j, r]) *
                (TersNitq[j, r] + hammingFrameMatrix[j, r]);

        }
        
        public void cepstralLpc()
        {
            double sCeps;
            cepstralLPC = new double[LpcP + 1, frameCount];
            for (int r=0; r<frameCount; r++)
                    for (int k= 0; k<LpcP+1; k++)
                            a2Lpc[LpcP, k, r]= -a2Lpc[LpcP, k, r];

            for (int r = 0; r < frameCount; r++)
                for (int k = 0; k < 2; k++)
                    cepstralLPC[k, r]= a2Lpc[LpcP, k, r];

            for (int r = 0; r < frameCount; r++)
                for (int k = 0; k < LpcP + 1; k++)
                {
                    sCeps = 0;

                    for(int i= 1; i< k; i++) 
                            sCeps= sCeps + i * a2Lpc[LpcP, k - i, r] * cepstralLPC[i, r];


                       cepstralLPC[k, r]= a2Lpc[LpcP, k, r] + sCeps / k;
                }
            for (int i = 0; i < frameCount; i++)
            {
                cepstralLPC[0, i] = energyOfFrames[i];
            }

        }

        public double[,] MFCC()
        {
            //MainWindow.RunTheMethod("fastFourier", ()=> fastFourier());
            MainWindow.RunTheMethod("fourier", ()=>furye());
            MainWindow.RunTheMethod("melFiltering", ()=>melFiltering());
            MainWindow.RunTheMethod("cepstarProcessing", ()=>cepstarProcessing());
            MainWindow.RunTheMethod("addingEnergy", ()=>addingEnergy());
            double[,] feature;
            feature = cepstralMFCC;
            if (liftMFCC || msMFCC)
            {
                if (liftMFCC)
                {
                    if (msMFCC) feature = cepstralMeanSubstraction(liftering(cepstralMFCC));
                    else feature = liftering(cepstralMFCC);
                }
                else feature = cepstralMeanSubstraction(cepstralMFCC);
            }
           // Console.Write(liftMFCC + " " + msMFCC);
            return feature;
        }

        public double[,] LPC()
        {
            MainWindow.RunTheMethod("autoCorrelation", ()=>autoCorrelation());
            MainWindow.RunTheMethod("levinson", ()=>levinson());
            MainWindow.RunTheMethod("cepstralLpc", ()=>cepstralLpc());
            double[,] feature;
            feature = cepstralLPC;
            if (liftLPC || msLPC)
            {
                if (liftLPC)
                {
                    if (msLPC) feature = cepstralMeanSubstraction(liftering(cepstralLPC));
                    else feature = liftering(cepstralLPC);
                }
                else feature = cepstralMeanSubstraction(cepstralLPC);
            }
          //  Console.Write(liftLPC + " " + msLPC);
            return feature;
        }

        public void printIntArray(int[] array)
        {
            foreach (int var in array)
                Console.WriteLine(var);
        }

        public void printDoubleArray(double[] array)
        {
            foreach (double var in array)
                Console.WriteLine(var);
        }
    }
}
