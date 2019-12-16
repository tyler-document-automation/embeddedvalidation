using System.Windows.Forms;

namespace CefBrowserTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.txtIntellidactId = new System.Windows.Forms.TextBox();
            this.buttonSuspend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelUrl = new System.Windows.Forms.Label();
            this.labelNotice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.DocumentListBox = new System.Windows.Forms.ListBox();
            this.batchIDTextBox = new System.Windows.Forms.TextBox();
            this.retrieveBatchDocsButton = new System.Windows.Forms.Button();
            this.apiKeyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.indexingRadioButton = new System.Windows.Forms.RadioButton();
            this.redactionRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.closeBatchIndexingButton = new System.Windows.Forms.Button();
            this.closeBatchRedactionButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(343, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 811);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(80, 9);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(224, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(984, 5);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 21);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // txtIntellidactId
            // 
            this.txtIntellidactId.Location = new System.Drawing.Point(404, 9);
            this.txtIntellidactId.Name = "txtIntellidactId";
            this.txtIntellidactId.Size = new System.Drawing.Size(245, 20);
            this.txtIntellidactId.TabIndex = 3;
            this.txtIntellidactId.TextChanged += new System.EventHandler(this.txtIntellidactId_TextChanged);
            // 
            // buttonSuspend
            // 
            this.buttonSuspend.Enabled = false;
            this.buttonSuspend.Location = new System.Drawing.Point(1071, 4);
            this.buttonSuspend.Name = "buttonSuspend";
            this.buttonSuspend.Size = new System.Drawing.Size(75, 23);
            this.buttonSuspend.TabIndex = 4;
            this.buttonSuspend.Text = "Suspend";
            this.buttonSuspend.UseVisualStyleBackColor = true;
            this.buttonSuspend.Click += new System.EventHandler(this.buttonSuspend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Enabled = false;
            this.buttonClose.Location = new System.Drawing.Point(1159, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(23, 12);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(51, 13);
            this.labelUrl.TabIndex = 5;
            this.labelUrl.Text = "Enter Url:";
            // 
            // labelNotice
            // 
            this.labelNotice.AutoSize = true;
            this.labelNotice.Location = new System.Drawing.Point(339, 10);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(64, 13);
            this.labelNotice.TabIndex = 6;
            this.labelNotice.Text = "IntellidactId:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Response:";
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Location = new System.Drawing.Point(404, 36);
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.Size = new System.Drawing.Size(886, 20);
            this.textBoxResponse.TabIndex = 8;
            // 
            // DocumentListBox
            // 
            this.DocumentListBox.FormattingEnabled = true;
            this.DocumentListBox.Location = new System.Drawing.Point(23, 158);
            this.DocumentListBox.Name = "DocumentListBox";
            this.DocumentListBox.Size = new System.Drawing.Size(281, 615);
            this.DocumentListBox.TabIndex = 10;
            this.DocumentListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DocumentListBox_MouseDoubleClick);
            // 
            // batchIDTextBox
            // 
            this.batchIDTextBox.Location = new System.Drawing.Point(80, 37);
            this.batchIDTextBox.Name = "batchIDTextBox";
            this.batchIDTextBox.Size = new System.Drawing.Size(224, 20);
            this.batchIDTextBox.TabIndex = 11;
            this.batchIDTextBox.TextChanged += new System.EventHandler(this.batchIDTextBox_TextChanged);
            // 
            // retrieveBatchDocsButton
            // 
            this.retrieveBatchDocsButton.Location = new System.Drawing.Point(24, 106);
            this.retrieveBatchDocsButton.Name = "retrieveBatchDocsButton";
            this.retrieveBatchDocsButton.Size = new System.Drawing.Size(75, 21);
            this.retrieveBatchDocsButton.TabIndex = 12;
            this.retrieveBatchDocsButton.Text = "Open Batch";
            this.retrieveBatchDocsButton.UseVisualStyleBackColor = true;
            this.retrieveBatchDocsButton.Click += new System.EventHandler(this.retrieveBatchDocsButton_Click);
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Location = new System.Drawing.Point(80, 66);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.Size = new System.Drawing.Size(224, 20);
            this.apiKeyTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Api Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Batch ID: ";
            // 
            // indexingRadioButton
            // 
            this.indexingRadioButton.AutoSize = true;
            this.indexingRadioButton.Checked = true;
            this.indexingRadioButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.indexingRadioButton.Location = new System.Drawing.Point(690, 8);
            this.indexingRadioButton.Name = "indexingRadioButton";
            this.indexingRadioButton.Size = new System.Drawing.Size(114, 17);
            this.indexingRadioButton.TabIndex = 1;
            this.indexingRadioButton.TabStop = true;
            this.indexingRadioButton.Text = "Indexing Validation";
            this.indexingRadioButton.UseVisualStyleBackColor = true;
            this.indexingRadioButton.CheckedChanged += new System.EventHandler(this.indexingRadioButton_CheckedChanged);
            this.indexingRadioButton.Click += new System.EventHandler(this.indexingRadioButton_Clicked);
            // 
            // redactionRadioButton
            // 
            this.redactionRadioButton.AutoSize = true;
            this.redactionRadioButton.Location = new System.Drawing.Point(814, 8);
            this.redactionRadioButton.Name = "redactionRadioButton";
            this.redactionRadioButton.Size = new System.Drawing.Size(123, 17);
            this.redactionRadioButton.TabIndex = 2;
            this.redactionRadioButton.TabStop = true;
            this.redactionRadioButton.Text = "Redaction Validation";
            this.redactionRadioButton.UseVisualStyleBackColor = true;
            this.redactionRadioButton.CheckedChanged += new System.EventHandler(this.redactionRadioButton_CheckedChanged);
            this.redactionRadioButton.Click += new System.EventHandler(this.redactionRadioButton_Clicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Document List: (double click to load document)";
            // 
            // closeBatchIndexingButton
            // 
            this.closeBatchIndexingButton.Location = new System.Drawing.Point(23, 801);
            this.closeBatchIndexingButton.Name = "closeBatchIndexingButton";
            this.closeBatchIndexingButton.Size = new System.Drawing.Size(123, 21);
            this.closeBatchIndexingButton.TabIndex = 17;
            this.closeBatchIndexingButton.Text = "Close Batch (Indexing)";
            this.closeBatchIndexingButton.UseVisualStyleBackColor = true;
            this.closeBatchIndexingButton.Click += new System.EventHandler(this.closeBatchIndexingButton_Click);
            // 
            // closeBatchRedactionButton
            // 
            this.closeBatchRedactionButton.Location = new System.Drawing.Point(173, 801);
            this.closeBatchRedactionButton.Name = "closeBatchRedactionButton";
            this.closeBatchRedactionButton.Size = new System.Drawing.Size(131, 21);
            this.closeBatchRedactionButton.TabIndex = 18;
            this.closeBatchRedactionButton.Text = "Close Batch (Redaction)";
            this.closeBatchRedactionButton.UseVisualStyleBackColor = true;
            this.closeBatchRedactionButton.Click += new System.EventHandler(this.closeBatchRedactionButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 866);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(341, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Please make sure the user account is valid and user rights are granted.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 849);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(337, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Note: this tool uses logged on windows user for server authentication. ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 889);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.closeBatchRedactionButton);
            this.Controls.Add(this.closeBatchIndexingButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.redactionRadioButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.indexingRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.apiKeyTextBox);
            this.Controls.Add(this.txtIntellidactId);
            this.Controls.Add(this.retrieveBatchDocsButton);
            this.Controls.Add(this.batchIDTextBox);
            this.Controls.Add(this.DocumentListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxResponse);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelNotice);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.buttonSuspend);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox txtIntellidactId;
        private System.Windows.Forms.Button buttonSuspend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.Label labelNotice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.ListBox DocumentListBox;
        private System.Windows.Forms.TextBox batchIDTextBox;
        private System.Windows.Forms.Button retrieveBatchDocsButton;
        private System.Windows.Forms.TextBox apiKeyTextBox;
        private Label label2;
        private Label label4;
        private RadioButton indexingRadioButton;
        private RadioButton redactionRadioButton;
        private Label label5;
        private Button closeBatchIndexingButton;
        private Button closeBatchRedactionButton;
        private Label label6;
        private Label label7;
    }
}

