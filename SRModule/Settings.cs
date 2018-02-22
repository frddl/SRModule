using System;
using System.Windows.Forms;

namespace SRModule
{
    public partial class Settings : Form
    {
        Algorithms algo;
        public Settings(Algorithms algo)
        {
            InitializeComponent();
            this.algo = algo;
            sample_rate.Text = algo.get_fs() + "";
            fstart.Text = algo.fstart + "";
            z1.Text = algo.z1 + "";
            Z.Text = algo.Z + "";
            inputBlocks.Text = algo.blocks + "";
            inputBeta.Text = algo.beta + "";
            inputL.Text = algo.L + "";
            LifterPar.Text = algo.LifterPar + "";
            scale.Text = algo.scale + "";
            N.Text = algo.frameLength + "";
            K.Text = algo.frameStep + "";
            LpcP.Text = algo.LpcP + "";
            liftLPC.Checked = algo.liftLPC; 
            liftMFCC.Checked = algo.liftMFCC; 
            msLPC.Checked = algo.msLPC; 
            msMFCC.Checked = algo.msMFCC;
            coefFIR.Text = algo.coefFIR + "";
        }

        // Taking new arguments if you pressed OK button
        private void ok_Click(object sender, EventArgs e)
        {
            int L, Sc, blocks;
            double beta;
            L = int.Parse(inputL.Text);
            Sc = int.Parse(inputSc.Text);
            beta = Double.Parse(inputBeta.Text);
            blocks = int.Parse(inputBlocks.Text);
            algo.L = L;
            algo.Sc = Sc;
            algo.blocks = blocks;
            algo.beta = beta;            
            int z1 = int.Parse(this.z1.Text);
            algo.set_z1(z1);
            int fstart = int.Parse(this.fstart.Text);
            algo.set_fstart(fstart);
            int Z = int.Parse(this.Z.Text);
            algo.set_Z(Z);
            int LifterPar = int.Parse(this.LifterPar.Text);
            algo.set_LifterPar(LifterPar);
            int scale = int.Parse(this.scale.Text);
            algo.set_scale(scale);
            int frameLength = int.Parse(N.Text);
            algo.set_frameLength(frameLength);
            int frameStep =int.Parse(K.Text);
            algo.set_frameStep(frameStep);
            int LpcP = int.Parse(this.LpcP.Text);
            algo.set_LpcP(LpcP);
            double FIR = double.Parse(coefFIR.Text);
            algo.coefFIR = FIR;
            algo.liftLPC = liftLPC.Checked;
            algo.liftMFCC = liftMFCC.Checked;
            algo.msLPC = msLPC.Checked;
            algo.msMFCC = msMFCC.Checked;
            Close();
        }

        // Ignoring all new arguments if you press Cancel button
        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
