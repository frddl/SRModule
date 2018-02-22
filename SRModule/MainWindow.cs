using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Threading.Tasks.Task;


namespace SRModule
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        Recognition recogn = new Recognition();
        Algorithms algo = new Algorithms();
        NAudio.Wave.AudioFileReader audio;
        String wavSaveName = null;
        String wavOpenName = null;
        String originalName = null;
        float[] originalWavSamples;
       // float[] PPsamples;
       // float[] VADsamples;
        public string[] ms_commands;
        NAudio.Wave.WaveIn sourceStream = null;
        NAudio.Wave.DirectSoundOut waveOut = null;
        NAudio.Wave.WaveFileWriter waveWriter = null;
        NAudio.Wave.WaveFileReader waveReader = null;
        DateTime start;
        long midLen = 0;
        int labelNumb = -1;
        string oldName = "";
        string checkList;
        string numbersList;
        string sosna_checkList;
        static bool completed;
        string[] list_scales = null;
        string lpcResult;
        string mfccResult;
        string MicroResult;
        ISampleProvider samples;
        Stream stream_ms;
        public NAudio.Wave.BufferedWaveProvider waveBuffer = null;


        public Algorithms GetAlgo()
        {
            return algo;
        }

        
        int microcnt = 0;
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            microcnt++;
            Console.WriteLine("Micro Result Text: " + microcnt+ " " +  e.Result.Text);
           
            if (e.Result.Confidence > 0.5) MicroResult += e.Result.Text + " ";
            else MicroResult +=  " --- ";
          
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            getInputs();
            ToolTip tool = new ToolTip();
            initializeTips();
            tool.SetToolTip(this.radio_digits, numbersList);
            tool.SetToolTip(this.radio_checklist, checkList);
            //tool.SetToolTip(this.radio_sosna_checklist, sosna_checkList);   

            
        }

        SpeechRecognitionEngine global;
        SpeechRecognitionEngine sre;
        static SpeechSynthesizer ss = new SpeechSynthesizer();

        public void initializeTips()
        {
            numbersList = File.ReadAllText("..\\..\\database\\Lists\\digitsList.txt");
            checkList = File.ReadAllText("..\\..\\database\\Lists\\checkList.txt");
            sosna_checkList = File.ReadAllText("..\\..\\database\\Lists\\checkList.txt");
            list_scales = File.ReadAllLines("..\\..\\database\\Lists\\list-scales.txt");

                 ms_commands = new string[] { "adjusted and locked","All switches"
                ,"alternate air door"
                ,"Aircraft Documents"
                ,"Battery plus Main bus"
                ,"Cabin doors"
                ,"Circuit Breakers"
                ,"Cockpit checklist completed"
                ,"Completed"
                ,"Flight Controls"
                ,"Fuel Quantity"
                ,"Fuel Selector"
                ,"Fuel Shutoff Valve"
                ,"Fuel Temperature"
                ,"preflight inspection"
                ,"Seats and Belts"
                ,"Shut - off cabin heat"
                ,"sufficient"
                ,"Weight and balance","0","1","2","3", "4" , "5", "6", "7", "8", "9","aboard","Checked",
                "Closed"
                ,"Cockpit"
                ,"Completed"
                ,"decimal"
                ,"in"
                ,"locked"
                ,"off"
                ,"On"
                ,"open"
                ,"Removed"
                ,"sufficient"
                ,"Towbar"  };

        }

        // Reading all the input devices available and putting them in the ComboBox (inputList)
        //putting to types of record format to the ComboBox (inputFormat)
        public void getInputs()
        {
            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
            }

            foreach (var source in sources)
            {
                inputList.Items.Add(source.ProductName);
            }

            inputList.SelectedIndex = 0;
            if (inputList.MaxLength > 1) inputList.SelectedIndex = 1;
            inputFormat.Items.Add("11025, 16 bit, mono");
            inputFormat.Items.Add("16000, 16 bit, mono");
            inputFormat.SelectedIndex = 1;
        }


        public void microsoft_recognition_from_file()
        {
            microResultLabel.Text = "";
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToWaveFile(originalName);

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);


            Choices numbers = new Choices();
            

            numbers.Add(ms_commands);


            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);


            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            global = sre;
            global.Recognize();
        }

        public void microsoft_recognition_from_stream()
        {
            microResultLabel.Text = "";
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);


            Choices numbers = new Choices();


            numbers.Add(ms_commands);


            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);


            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            global = sre;
            global.RecognizeAsync(RecognizeMode.Multiple);
        }
        // Method on button which initializes recording
        private void save_Click(object sender, EventArgs e)
        {
            initRecord(false);
        }

        // Method on button which starts recording
        private void record_Click(object sender, EventArgs e)
        {
            if (global != null) global.Dispose();
               
            recording_timer.Start();
            start = DateTime.Now;
            initRecord(false);
            
            sourceStream.StartRecording();

        }

        private void stream_record_Click(object sender, EventArgs e)
        {
            Recognition_Form form = new Recognition_Form(null,null,null);
            form.Show();
           
            this.microResultLabel = form.ms_result;
            this.mfcc_result = form.mfcc_result;
            this.lpc_result = form.lpc_result;
            if (global != null) global.Dispose();
            ///DisposeWave();
            recording_timer.Start();
            start = DateTime.Now;
            initRecord(true);
            
            sourceStream.StartRecording();
            microsoft_recognition_from_stream();
        }


        static public void RunTheMethod(String s,Action myMethodName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            myMethodName();
            sw.Stop();
            Console.WriteLine(s + " " + (sw.Elapsed.TotalMilliseconds) + " ms");

        }

        static public dynamic RunTheMethod2(String s, Func<object, object> myMethodName, object pass)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            object variable = myMethodName(pass);
            sw.Stop();
            Console.WriteLine(s + " " + (sw.Elapsed.TotalMilliseconds) + " ms");
            return variable;
        }

        // Method that initialized name, location and thread for 
        // wave file to which input stream is going to be recorded
        private void initRecord(bool stream)
        {
            //Console.WriteLine(inputName.Text);
            wavSaveName = inputName.Text + ".wav";
            int deviceNumber;
            if (inputList.SelectedItem == null) return;

            deviceNumber = inputList.SelectedIndex;

            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            int rate, bits = 16, chn = 1;
            if (inputFormat.SelectedIndex == 0) rate = 11025;
            else rate = 16000;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(rate, bits, chn);
            sourceStream.BufferMilliseconds=50;
            if (!stream)
            {
                sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(OnDataAvailable);
                waveWriter = new NAudio.Wave.WaveFileWriter(wavSaveName, sourceStream.WaveFormat);
            }
            else
            {
                algo.originalWavSamples = new double[800];
                sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(StreamDataAvailable);
                waveBuffer = new NAudio.Wave.BufferedWaveProvider(sourceStream.WaveFormat);
                samples = waveBuffer.ToSampleProvider();
                
            }
            
        }
        public List<float> testStream = new List<float>();
        int zeros = 0;
        // Functions which writes chunks of samples to the wav file
        private void OnDataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        private void StreamDataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            byte[] bytes = new byte[e.Buffer.Length]; //your local byte[]
            List<byte> bytelist = new List<byte>();
            bytelist.AddRange(bytes);
            stream_ms = new MemoryStream(bytelist.ToArray());


            waveBuffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
            waveBuffer.DiscardOnBufferOverflow = true;
            var bytesPerFrame = sourceStream.WaveFormat.BitsPerSample / 8
                      * sourceStream.WaveFormat.Channels;
            var bufferedFrames = waveBuffer.BufferedBytes / bytesPerFrame;

            var frames = new float[bufferedFrames];
            Console.WriteLine(bufferedFrames);
            samples.Read(frames, 0, bufferedFrames);
            
            floatToDouble(frames, algo.originalWavSamples);
            algo.preProcessing();
            bool[] vad = algo.getVAD(publicTw);
            for(int i = 0;i < 8;i++)
            {
               // if(vad[i])
                for(int j = i * 100; j < i * 100 + 100 && j < frames.Length;j++) testStream.Add(frames[j]);
                if (!vad[i])
                {
                    zeros++;
                    if(zeros == 24) // magical constant
                    {
                        float[] speech = testStream.ToArray();
                        var algo = new Algorithms(speech);
                       
                        double[] a = new double[speech.Length];
                      
                        testStream.Clear();
                        // insert async recognition here here
                        zeros = 0;
                        System.Threading.Tasks.Task.Run(() => 
                        {
                            algo.set_fs(16000);
                            algo.defineStepAndLength();
                            processWavFile(algo);
                          
                        });
                       
                    }
                }
                else
                {
                    zeros = 0;
                }
            }
            //foreach (var frame in frames)
             //   testStream.Add(frame);
       
        }


        // Method that stops recording
        private void stop_Click(object sender, EventArgs e)
        {
            Recognition_Form form = new Recognition_Form(null, null, null);
            form.Show();

            this.microResultLabel = form.ms_result;
            this.mfcc_result = form.mfcc_result;
            this.lpc_result = form.lpc_result;


            if (sourceStream != null)
                {
                    sourceStream.StopRecording();
                    sourceStream.Dispose();
                    sourceStream = null;
                }
                if (waveWriter != null)
                {
                    waveWriter.Dispose();
                    waveWriter = null;
                }
                openWav(wavSaveName);
                recording_timer.Stop();
                wavSaveName = null;
            System.Threading.Tasks.Task.Run(() =>
            {
                processWavFile(algo);

            });
           // processWavFile(algo);
            

            
        }

        // Method that open the file dialog to open the needed file
        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;
            openWav(open.FileName);
        }

        public void define_length(String path)
        {
            originalName = path;
            wavToFloatArray(path);
            string name = path.Split('\\')[path.Split('\\').Length - 1];
            using (StreamWriter r = new StreamWriter("..\\..\\database\\length_of_files.txt", true))
                r.WriteLine(name + " - " + originalWavSamples.Length);
            

        }
        private void openCuttedWav(String path)
        {
            originalName = path;
            wavToFloatArray(path);
            double[] word = new double[originalWavSamples.Length];
            floatToDouble(originalWavSamples, word);
            RunTheMethod("Scaling", () => algo.scaling(word));
            RunTheMethod("Framing", () => algo.framing());
            RunTheMethod("EnergyAfterFraming", () => algo.energyAfterFraming());
            RunTheMethod("Hamming", () => algo.hamming());
            double[,] mfcc = algo.MFCC();
            double[,] lpc = algo.LPC();            


            printArrayInFile(mfcc, "..\\..\\database\\features\\test_sosna_cheklist_short_mfcc", labelNumber);
            printArrayInFile(lpc, "..\\..\\database\\features\\test_sosna_checklist_short_lpc", labelNumber);
                        
     }
     // Opening wave file based on the path
         private void openWav(String path)
         {
            
             DisposeWave();            
             originalName = path;
             microsoft_recognition_from_file();
            
             wavToFloatArray(path);
             printArray(originalWavSamples, "filewriter");
             printArray(testStream.ToArray(), "streamwriter");
             floatToDouble(originalWavSamples, algo.getOriginalSamples());

             RunTheMethod("preprocessing",() => algo.preProcessing());
             algo.getTw(path);
             algo.cropWords(audio.WaveFormat);
            
            float[] afterPP = new float[algo.getPPsamples().Length];
            float[] afterVad = new float[algo.forGraph.Length];

            
            doubleToFloat(afterPP, algo.getPPsamples());
            doubleToFloat(afterVad, algo.forGraph);

            createWav(afterPP, "afterPP",audio.WaveFormat);
            createWav(afterVad, "afterVAD", audio.WaveFormat);
            System.Threading.Tasks.Task.Run(() =>
            {

                graphCreate(chart1, algo.getOriginalSamples());
                graphCreate(chart2, algo.getPPsamples());
                graphCreate(chart3, algo.forGraph);

            });



            /* PPsamples = new float[algo.getPPsamples().Length];
             VADsamples = new float[algo.getVADsamples().Length];

             doubleToFloat(PPsamples, algo.getPPsamples());
             doubleToFloat(VADsamples, algo.getVADsamples());*/

            // Console.WriteLine(originalName);

            /* createWav(PPsamples, "afterPP", audio.WaveFormat);
             createWav(VADsamples, "afterVAD", audio.WaveFormat);

                DisposeWave();*/

            }

        private void listCommands (object sender, EventArgs e)
        {
            
        }
        
        public void cutWavFile(String path)
        {
            DisposeWave();
            originalName = path;
            wavToFloatArray(path);
            floatToDouble(originalWavSamples, algo.getOriginalSamples());
            RunTheMethod("preprocessing", () => algo.preProcessing());
            List<double[]> words = algo.cropWordsWithoutVAD(audio.WaveFormat, path);

        }
        // Method that contain all the operation with feature extraction
        private void processWavFile(Algorithms samples)
        {
            
           
            RunTheMethod("preprocessing", () => samples.preProcessing());            
            List<double[]> words = samples.cropWords(null);
            //lpc_result.Text = "";
            //mfcc_result.Text = "";

            //algo.cropWords(audio.WaveFormat);
            // algo.cropArray();


            // RunTheMethod("graph", () => graphCreate(chart1, algo.getOriginalSamples()));
            //graphCreate(chart2, algo.getPPsamples());
            // graphCreate(chart3, algo.getVADsamples());

            //PPsamples = new float[algo.getPPsamples().Length];
            //VADsamples = new float[algo.getVADsamples().Length];

            // doubleToFloat(PPsamples, algo.getPPsamples());
            // doubleToFloat(VADsamples, algo.getVADsamples());

            //createWav(PPsamples, "afterPP", audio.WaveFormat);
            // createWav(VADsamples, "afterVAD", audio.WaveFormat);*/



            
            foreach (var word in words)
            {

           
            if (radio_digits.Checked) samples.scale = 5840;
                else if (radio_checklist.Checked) samples.scale = 10000;
                else if (word.Length < 10000) samples.scale = 7120;
                else samples.scale = 16400;

                RunTheMethod("Scaling", () => samples.scaling(word));
                RunTheMethod("Framing",() => samples.framing());
                RunTheMethod("EnergyAfterFraming", ()=> samples.energyAfterFraming());
                RunTheMethod("Hamming", ()=> samples.hamming());
                double[,] mfcc = samples.MFCC();
                double[,] lpc = samples.LPC();
                


                /*printArrayInFile(mfcc, "..\\..\\database\\test_cheklist_mfcc", originalName);
                printArrayInFile(lpc, "..\\..\\database\\test_checklist_lpc", originalName);*/
                double[] lpc2 = new double[lpc.GetLength(0) * lpc.GetLength(1)];
                double[] mfcc2 = new double[mfcc.GetLength(0) * mfcc.GetLength(1)];
                
                DoubleArrayToSingleArray(lpc, lpc2);
                DoubleArrayToSingleArray(mfcc, mfcc2);
                Console.WriteLine(mfcc2.Length + "");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int lpc_answer = Recognition.Recognize(lpc2, "lpc");
                int mfcc_answer = Recognition.Recognize(mfcc2, "mfcc");
                sw.Stop();
                Console.WriteLine("Recognition" + " " + (sw.Elapsed.TotalMilliseconds) + " ms");
                recognized(samples.scale,lpc_answer, mfcc_answer);
            }
            Console.WriteLine(mfccResult);
            Console.WriteLine(lpcResult);
            try
            {
                microResultLabel.Invoke((MethodInvoker)delegate
                {
                    microResultLabel.Text = MicroResult != "" ? MicroResult : microResultLabel.Text; ;
                });

                mfcc_result.Invoke((MethodInvoker)delegate
                {
                    mfcc_result.Text = mfccResult != "" ? mfccResult : mfcc_result.Text;
                });

                lpc_result.Invoke((MethodInvoker)delegate
                {
                    lpc_result.Text = lpcResult != "" ? lpcResult : lpc_result.Text;
                });
            }
            catch(Exception e)
            {

            }
            mfccResult = "";
            MicroResult = "";
            lpcResult = "";

        }
        

        public void recognized(int scale,int lpc, int mfcc)
        {
            string length = scale+"";
            string path = "..\\..\\database\\Lists\\";
           

            for (int i =0; i<list_scales.Length; i++)
            {
                if (list_scales[i].Contains(length))
                {
                    path += list_scales[i].Split('-')[0];
                   
                } 

            }
            Console.WriteLine(scale);
            Console.WriteLine(path);
            
            if (lpc == -1) lpcResult += " --- ";
            else lpcResult += File.ReadLines(path).Skip(lpc).First().Split('-')[0];
            if (mfcc == -1) mfccResult+= " --- ";
            else mfccResult += File.ReadLines(path).Skip(mfcc).First().Split('-')[0];
            
        }

        private String takeName(String path)
        {
            String name="";
            for (int i=path.Length-1; i>0; i--)
            {
                if (path[i] == '\\')
                {
                    name = path.Substring(i+1, path.Length - i-5);
                    break;
                }
            }
            return name;
        }

        public void sortTrain()
        {
            int i = 0;
            StreamReader read = new StreamReader("..\\..\\database\\test_digits_lpc.txt");
            StreamWriter write = new StreamWriter("..\\..\\database\\sorted_test_digits_lpc.txt");
            string str;
            while (i<10)
            {
              
                read.BaseStream.Position = 0;
                read.DiscardBufferedData();
              //  Console.WriteLine(read.Peek());
                while (read.Peek() > -1)
                {
                    str = read.ReadLine();
                    if (str[0] == 48 + i) write.WriteLine(str);
                }
                
                i++;

            }
            read.Close();
            write.Close();
        }

        //Mathod for creating graph from the double arrays
        public void graphCreate(System.Windows.Forms.DataVisualization.Charting.Chart chart, double[] samples)
        {
            chart.Invoke((MethodInvoker)delegate
            {

            chart.Series.Clear();
            chart.Series.Add("wave");
            chart.Visible = false;
            chart.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart.Series["wave"].ChartArea = "ChartArea1";
                for(int i = 0; i < samples.Length; i+= 10)
                {
                    chart.Series["wave"].Points.Add(samples[i]);

                }
                //foreach (double point in samples)
                //chart.Series["wave"].Points.Add(point);
                chart.Visible = true;
            });
        }

        // Method for creating float array from given wav file
        public void wavToFloatArray(string path)
        {
           
            audio = new NAudio.Wave.AudioFileReader(path);
            NAudio.Wave.WaveFormat waveFormat = audio.WaveFormat;
            midLen += audio.Length;

            algo.set_fs(waveFormat.SampleRate);
            algo.defineStepAndLength();
            originalWavSamples = new float[audio.Length / 4];
            algo.setSamples(originalWavSamples.Length);
            audio.Read(originalWavSamples, 0, originalWavSamples.Length);
            audio.Close();
        }

        // Method to create wav file from float array
        public static void createWav(float[] array, String name, NAudio.Wave.WaveFormat audio)
        {
            NAudio.Wave.WaveFormat waveFormat = audio;
           // Console.WriteLine(waveFormat.SampleRate + " " + waveFormat.BitsPerSample + " " + waveFormat.Channels);
            using (NAudio.Wave.WaveFileWriter writer = new NAudio.Wave.WaveFileWriter(name + ".wav", waveFormat))
            {
                writer.WriteSamples(array, 0, array.Length);
            }
        }

        // Method to play wav file the path of which is in the wavOpenName variable
        private void play()
        {
            try
            {
                initPlay();
                waveOut.Play();
            }
            catch
            {
                MessageBox.Show("Error accured!!!\n\nOpen file or record voice");
            }
        }

        // Maethod to initialize thread for opening the wav file
        public void initPlay()
        {
            
                DisposeWave();
                waveReader = new NAudio.Wave.WaveFileReader(wavOpenName);
                waveOut = new NAudio.Wave.DirectSoundOut();
                waveOut.Init(new NAudio.Wave.WaveChannel32(waveReader));
           
            
        }

        // Button that stops the wave file playing at the moment
        private void stop_play_Click(object sender, EventArgs e)
        {
            DisposeWave();
        }

        // Method needed to cleanup outputStream and waveOut file
        private void DisposeWave()
        {
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
            
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing) waveOut.Stop();
                waveOut.Dispose();
                waveOut.Stop();
                waveOut = null;
            }
            
            if (waveReader != null)
            {
                waveReader.Dispose();
                waveReader.Close();
                waveReader = null;
            }
        }

        // Play buttons each playing one of 3 versions of wav files (original, afterPP, afterVAD)
        private void play1_Click(object sender, EventArgs e)
        {
            wavOpenName = originalName;
            play();
        }

        private void play2_Click(object sender, EventArgs e)
        {
            wavOpenName = "afterPP.wav";
            play();
        }

        private void play3_Click(object sender, EventArgs e)
        {
            wavOpenName = "afterVAD.wav";
            play();
        }

        // Actions to be done on closing the form 
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeWave();
        }

        // Actions done on pressing Exit button
        private void exit_Click(object sender, EventArgs e)
        {
            stop_Click(sender, e);
            this.Close();
        }          

       // Different methods to work with arrays (printing, copying, converting etc.)
       
        public void printArray(double[,] array, String name)
        {
            using (StreamWriter file = new StreamWriter(name + ".txt"))
            {
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        file.WriteLine("[" + i + "]" + "[" + j + "]" + array[i, j]);

            }
        }

        public void printArray(float[] array, String name)
        {
            using (StreamWriter file = new StreamWriter(name + ".txt"))
            {
                for (int i = 0; i < array.Length; i++)
                   
                        file.WriteLine("[" + i + "]" +   array[i]);

            }
        }

        public void printArray(double[,,] array, String name)
        {
            using (StreamWriter file = new StreamWriter(name + ".txt"))
            {
                for (int i = 0; i < array.GetLength(1); i++)
                    for (int j = 0; j < array.GetLength(2); j++)
                        file.WriteLine("[" + i + "]" + "[" + j + "]" + array[12, i, j]);

            }
        }
        public int extractNumber(string number)
        {
            if (number.Contains("Bir")) return 1;
            if (number.Contains("Iki")) return 2;
            if (number.Contains("Uch")) return 3;
            if (number.Contains("Dord")) return 4;
            if (number.Contains("Besh")) return 5;
            if (number.Contains("Alti")) return 6;
            if (number.Contains("Yeddi")) return 7;
            if (number.Contains("Sekkiz")) return 8;
            if (number.Contains("Doqquz")) return 9;
            if (number.Contains("Sifir")) return 0;
            return 0;

        }

       /* public int labelChecklist(string name)
        {
            string[] s = name.Split('_');
            if (string.Compare(s[0], oldName) == 0) return labelNumb;
            else labelNumb++;
            oldName = s[0];
            return labelNumb;
            
        }*/

        public int labelNumber = 0;
        public void printArrayInFile(double[,] array, String name, int number)
        {
            using (StreamWriter file = new StreamWriter(name+".txt", true))
            {
                int numb = number;              
                file.Write(numb + "#");
                for (int i = 0; i < array.GetLength(1); i++)
                    for (int j = 0; j < array.GetLength(0); j++)
                        if (j==0 && i==0) file.Write((" " + array[j, i]).Replace(',', '.'));
                        else file.Write(("; " + array[j, i]).Replace(',', '.'));
                file.WriteLine();
            }
               
        }

        public void DoubleArrayToSingleArray(double[,] from, double[] to)
        {
            for (int i = 0; i < from.GetLength(1); i++)
                for (int j = 0; j < from.GetLength(0); j++)
                    to[j + i * from.GetLength(0)] = from[j, i];

        }
        public void printArrayInSingleFile(double[,] array, String name)
        {
            using (StreamWriter file = new StreamWriter(name + ".txt"))
            {
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        file.WriteLine(array[i, j]);
            }

        }


        public void printArrayColumn(double[,] array, String name)
        {
            using (StreamWriter file = new StreamWriter(name + ".txt"))
            {
                for (int i = 0; i < array.GetLength(1); i++)
                    for (int j = 0; j < array.GetLength(0); j++)
                        file.WriteLine("[" + j + "]" + "[" + i + "]" + array[j, i]);

            }
        }

        public void printArray(double[] array, string name)
        {
            using (StreamWriter file = new StreamWriter(name + ".txt"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    file.WriteLine(array[i]+"; ");
                }
            }
        }
        public void multiArrayToSingleArray(double[,] from, double[] to )
        {
            for (int j = 0; j < from.GetLength(0); j++)
                for (int i = 0; i < from.GetLength(1); i++)               
                    to[i*j + i] = from[i, j];

        }

        public void printArrayInFile(double[] array, string name)
        {
            using (StreamWriter file = new StreamWriter( name + ".txt"))
            {
                
                for (int i = 0; i < array.Length; i++)
                {
                    file.WriteLine(array[i]);
                }
            }
        }

        public static void floatToDouble(float[] samples, double[] array)
        {
            for (int i = 0; i < samples.Length; i++)
                array[i] = samples[i];
        }

        public static void doubleToFloat(float[] samples, double[] array)
        {
            for (int i = 0; i < samples.Length; i++)
                samples[i] = (float)array[i];
        }

        //open settings form
        private void button1_Click(object sender, EventArgs e)
        {
            Settings form = new Settings(algo);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)  // loop
        {
            string[] fileEntries = Directory.GetFiles("..\\..\\database\\Test-checklist");
            
            foreach (string fileName in fileEntries)
            {
                try
                {
                    openWav(fileName);
                    processWavFile(algo);
                }
                catch
                {
                 //   Console.WriteLine(fileName);
                }
            }
          //  Console.WriteLine("DONE!!!");
          //  Console.WriteLine(algo.midLen/algo.midCount);
            

        }

        private void extract_button_Click(object sender, EventArgs e)
        {
           // try
           // {
                RunTheMethod("Full time",  ()=> processWavFile(algo));
          //  }
          //  catch (Exception exp)
          //  {
          //      MessageBox.Show("Error accured!!!\n\nOpen file or record voice ");
           // }
        }

        /*  private void readNN_button_Click(object sender, EventArgs e)
          {
              recogn.enterNN();
          }

          private void extractTXT_button_Click(object sender, EventArgs e)
          {
              recogn.enterNN();
              double[] feature = new double[455];
              string tmp;
              OpenFileDialog open = new OpenFileDialog();
              if (open.ShowDialog() != DialogResult.OK) return;
              using (StreamReader file = new StreamReader(open.FileName))
              {
                 for(int i=0; i<455; i++)
                  {
                      tmp = file.ReadLine();
                      tmp = tmp.Replace(".", ",");
                      feature[i] = double.Parse(tmp);
                  }

              }
              Console.WriteLine( recogn.recognized(feature, 0.5, 0.5));

          }
          */
        public double timerCalibrate;
        private void recording_timer_Tick(object sender, EventArgs e)
        {
            string tmp = Math.Round((DateTime.Now - start).TotalMilliseconds / 1000, 2) + " seconds";
            tmp = tmp.Replace(',', ':');
            time_label.Text = tmp;
            timerCalibrate = (DateTime.Now - start).TotalMilliseconds / 1000;
        }

        private void button8_Click(object sender, EventArgs e) /// magic
        {
            /*OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() != DialogResult.OK) return;
            StreamWriter fileW = new StreamWriter("..\\..\\database\\train-mfcc+lift+ms.txt");
            string line;
            using (StreamReader fileR = new StreamReader(open.FileName))
            {
                line = fileR.ReadLine();
                fileW.WriteLine(line.Replace(',', '.'));
            }*/
            sortTrain();
        }

        private void extractTXT_button_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string[] fileEntries = Directory.GetFiles("..\\..\\database\\Test-checklist");
            using (StreamWriter write = new StreamWriter("commandList.txt"))
            {
                foreach (string fileName in fileEntries)
                {
                    string[] s = fileName.Split('\\');
                    string[] s2 = s[4].Split('_');

                    if (string.Compare(s2[0], oldName) == 0) ;
                    else
                    {
                        labelNumb++;
                        oldName = s2[0];
                        write.WriteLine(oldName + " - " + labelNumb);
                    }



            }
            }
        }
        int file_cnt=0;
        int file_sum=0;
        private void walk_and_define(String s)
        {

            var a = Directory.GetFiles(s);


            foreach (var folder in Directory.GetDirectories(s))
            {
                walk_and_define(folder);
                using (StreamWriter r = new StreamWriter("..\\..\\database\\length_of_files.txt", true))
                    r.WriteLine("Mean Length - " + file_sum / file_cnt);

            }

            foreach (var file in a)
            {
                try
                {
                    define_length(file);
                    file_cnt++;
                    file_sum += originalWavSamples.Length;
                }
                catch
                {
                    using (StreamWriter corrupted = new StreamWriter("corrupted.txt")) corrupted.WriteLine(file);
                }

            }


        }


        private void walk_and_extract(String s)
        {
            
		    var a = Directory.GetFiles(s);

           
            foreach (var folder in Directory.GetDirectories(s))
				{
                    using (StreamWriter w = new StreamWriter("..\\..\\database\\Lists\\sosna_checklist_long.txt", true)) w.WriteLine(folder.Split('\\')[folder.Split('\\').Length-1]+ " - " + labelNumber);
					walk_and_extract(folder);
                    labelNumber++;
				}
            bool t = false;
				foreach (var file in a)
				{
                    try
                    {
                        openCuttedWav(file);
                    }
                    catch
                    {
                    Console.WriteLine(file + " - this is the file");
                    }


				}
              

        }

        private void walk_and_cut(String s)
        {

            var a = Directory.GetFiles(s);


            foreach (var folder in Directory.GetDirectories(s))
            {
               walk_and_cut(folder);                
            }
          
            foreach (var file in a)
            {
                try
                {
                    cutWavFile(file);
                }
                catch
                {
                    using (StreamWriter corrupted = new StreamWriter("corrupted.txt")) corrupted.WriteLine(file);
                }

            }


        }

        private void walk_and_delete(String s)
        {
            foreach (var folder in Directory.GetDirectories(s))
            {
				walk_and_delete(folder);
                DeleteFilesInDirectory(folder);
            }
        }
        private void DeleteFilesInDirectory(String s)
        {

            foreach (var file in Directory.GetFiles(s))
            {
                if (!file.Contains('-')) File.Delete(file);
            }

        }

        private void Cut_Files(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    walk_and_cut(fbd.SelectedPath);
                    // string[] files = Directory.GetFiles(fbd.SelectedPath);

                    // System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
            

        }

		private void Delete_Files(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					walk_and_delete(fbd.SelectedPath);
					// string[] files = Directory.GetFiles(fbd.SelectedPath);

					// System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
				}
			}
		}

        private void ExtractFiles(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    walk_and_extract(fbd.SelectedPath);
                    // string[] files = Directory.GetFiles(fbd.SelectedPath);

                    // System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void open_command_list_Click(object sender, EventArgs e)
        {
            CommandsList form = new CommandsList(ms_commands);
            form.StartPosition = FormStartPosition.Manual;
            form.Left = 250;
            form.Top = 0;
            form.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                        walk_and_define(fbd.SelectedPath);
                    // string[] files = Directory.GetFiles(fbd.SelectedPath);

                    // System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {


            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
            
            recording_timer.Stop();
            
        }
        double publicTw=0;
        Boolean calibratePressed = false;
        private void calibrate_button_Click(object sender, EventArgs e)
        {
            if (!calibratePressed)
            {
                initRecord(false);
                recording_timer.Start();
                sourceStream.StartRecording();
                start = DateTime.Now;
                
            }
            else
            {
                recording_timer.Stop();
                sourceStream.StopRecording();
                DisposeWave();
                openWav(wavSaveName);
                publicTw = algo.findTw();
                Console.WriteLine(publicTw);
            }
            calibratePressed = !calibratePressed;
                

            

            
            

            
            

        }
    }
}
