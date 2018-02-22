using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRModule
{
    public partial class Recognition_Form : Form
    {

         
        public Recognition_Form(string lpc, string mfcc, string micro)
        {
            InitializeComponent();
            mfcc_result.Text = mfcc;
            lpc_result.Text = lpc;
            ms_result.Text = micro;
        }

    }
}
