using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Alphabetizer
{
    /// <summary>
    /// Summary description for the XML Alphabetizer.
    /// </summary>
    public class XMLAlphabetizer : System.Windows.Forms.Form
    {
        #region Private Members
        private System.Windows.Forms.TextBox txtSource;
        private Label lblSource;
        private System.Windows.Forms.Button btnGenerate;
        private String sourceDoc = "";
        private String resultDoc = "result.xml";
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnReset;
        private OpenFileDialog openFileDialog;
        private Button btnBrowse;
        private Label lblDepth;
        private NumericUpDown numericUpDown;
        private Label lblSort;
        private TextBox txtAttribute;
        private GroupBox grpOrder;
        private ComboBox comboBox1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion
        
        #region Constructor
        public XMLAlphabetizer()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        } 
        #endregion

        #region Dispose
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        } 
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblDepth = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblSort = new System.Windows.Forms.Label();
            this.txtAttribute = new System.Windows.Forms.TextBox();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.grpOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(79, 14);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(304, 20);
            this.txtSource.TabIndex = 1;
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(12, 18);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(84, 20);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source XML";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(389, 47);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(63, 20);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(13, 103);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(451, 276);
            this.txtResult.TabIndex = 10;
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Location = new System.Drawing.Point(389, 77);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 20);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "";
            this.openFileDialog.Filter = "XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog.InitialDirectory = ".";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(389, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(66, 20);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(12, 47);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(181, 13);
            this.lblDepth.TabIndex = 3;
            this.lblDepth.Text = "Minimum Tree Depth to Apply Sort At";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(199, 45);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown.TabIndex = 4;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(12, 77);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(114, 13);
            this.lblSort.TabIndex = 5;
            this.lblSort.Text = "Sort By Attribute Name";
            // 
            // txtAttribute
            // 
            this.txtAttribute.Location = new System.Drawing.Point(132, 74);
            this.txtAttribute.Name = "txtAttribute";
            this.txtAttribute.Size = new System.Drawing.Size(126, 20);
            this.txtAttribute.TabIndex = 6;
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.comboBox1);
            this.grpOrder.Location = new System.Drawing.Point(275, 40);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(108, 54);
            this.grpOrder.TabIndex = 7;
            this.grpOrder.TabStop = false;
            this.grpOrder.Text = "Sort Attributes";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Ascending",
            "Decending"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "None";
            // 
            // XMLAlphabetizer
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(476, 391);
            this.Controls.Add(this.grpOrder);
            this.Controls.Add(this.txtAttribute);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblSource);
            this.Name = "XMLAlphabetizer";
            this.Text = "XML Alphabetizer";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.grpOrder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new XMLAlphabetizer());
        }

        #region Public Method - RunSort
        /// <summary>
        /// Run the sorting routine for the XML document.
        /// </summary>
        /// <param name="sourceDoc"></param>
        /// <returns></returns>
        public XDocument RunSort(string sourceDoc, int level, string attribute, int sortAttributes)
        {
            XDocument doc = XDocument.Load(sourceDoc);

            //Add these two hard-coded values as options from within the UI so we can apply it to any XML file.
            XDocument sortedDoc = XmlSort.Sort(doc, level, attribute, sortAttributes);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(resultDoc, settings))
            {
                sortedDoc.WriteTo(writer);
            }
            return sortedDoc;
        } 
        #endregion

        
        #region Event Handler - btnGenerate_Click
        /// <summary>
        /// Click event for the btnGenerate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text.Trim()))
            {
                MessageBox.Show("Enter a filename!", "File Name Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtSource.Text.EndsWith(".xml"))
                sourceDoc = txtSource.Text + ".xml";
            else
                sourceDoc = txtSource.Text;

            try
            {
                txtResult.Clear();

                XDocument sortedDoc = RunSort(sourceDoc, (int)numericUpDown.Value, txtAttribute.Text, comboBox1.SelectedIndex);

                txtResult.Text = sortedDoc.ToString();
            }

            catch (FileNotFoundException filexc)
            {
                MessageBox.Show(string.Format("File Not Found: {0}", filexc), "File Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            catch (Exception exc)
            {
                MessageBox.Show(string.Format("Error: {0}", exc), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region Event Handler - btnReset_Click
        /// <summary>
        /// Click handler for the btnReset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, System.EventArgs e)
        {
            txtSource.Text = "";
            txtResult.Text = "";
            numericUpDown.Value = 0;
            txtAttribute.Text = "";
            comboBox1.SelectedIndex = 0;
            txtSource.Focus();
        } 
        #endregion

        #region Event Handler - btnBrowse_Click
        /// <summary>
        /// Click handler for the btnBrowse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = openFileDialog.FileName;
            }
        } 
        #endregion
    }
}
