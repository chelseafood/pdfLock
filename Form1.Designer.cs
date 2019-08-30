using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace PDFPassword_WinForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.Replace);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        public void Replace(Object sender,
                           EventArgs e)
        {
            //Path to where you want the file to output
            string outputFilePath = "C:/Users/eu725cj/Documents/test123.pdf";
            //Path to where the pdf you want to modify is
            string inputFilePath = "C:/Users/eu725cj/Documents/input1.pdf";

            try
            {
                using (Stream inputPdfStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                //using (Stream outputPdfStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (Stream outputPdfStream2 = new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                   
                    string password = "pass@123";
                    //Opens our outputted file for reading
                    var reader2 = new PdfReader(inputPdfStream);

                    //Encrypts the outputted PDF to make it not allow Copy or Pasting
                    PdfEncryptor.Encrypt(
                        reader2,
                        outputPdfStream2,
                        true,
                        null,
                        password,
                        PdfWriter.ALLOW_SCREENREADERS
                    );
                    //Creates the outputted final file
                    reader2.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        
        #endregion

        private System.Windows.Forms.Button button1;
    }
}

