namespace playfair
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
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_text_input = new System.Windows.Forms.RichTextBox();
            this.textBox_text_output = new System.Windows.Forms.RichTextBox();
            this.textBox_encrypted_table = new System.Windows.Forms.RichTextBox();
            this.button_text_Encrypt = new System.Windows.Forms.Button();
            this.button_text_filter = new System.Windows.Forms.Button();
            this.button_text_Decrypt = new System.Windows.Forms.Button();
            this.button_keyword = new System.Windows.Forms.Button();
            this.textBox_keyword_filtered = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_info = new System.Windows.Forms.Button();
            this.button_language_en = new System.Windows.Forms.Button();
            this.button_language_cz = new System.Windows.Forms.Button();
            this.button_keyword_change = new System.Windows.Forms.Button();
            this.label_language = new System.Windows.Forms.Label();
            this.button_language_cz_small = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_keyword
            // 
            this.textBox_keyword.Location = new System.Drawing.Point(54, 85);
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.Size = new System.Drawing.Size(270, 22);
            this.textBox_keyword.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(54, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Keyword:";
            // 
            // textBox_text_input
            // 
            this.textBox_text_input.Location = new System.Drawing.Point(54, 221);
            this.textBox_text_input.Name = "textBox_text_input";
            this.textBox_text_input.Size = new System.Drawing.Size(270, 159);
            this.textBox_text_input.TabIndex = 2;
            this.textBox_text_input.Text = "";
            // 
            // textBox_text_output
            // 
            this.textBox_text_output.Location = new System.Drawing.Point(448, 221);
            this.textBox_text_output.Name = "textBox_text_output";
            this.textBox_text_output.Size = new System.Drawing.Size(270, 159);
            this.textBox_text_output.TabIndex = 3;
            this.textBox_text_output.Text = "";
            // 
            // textBox_encrypted_table
            // 
            this.textBox_encrypted_table.Location = new System.Drawing.Point(399, 59);
            this.textBox_encrypted_table.Name = "textBox_encrypted_table";
            this.textBox_encrypted_table.Size = new System.Drawing.Size(137, 120);
            this.textBox_encrypted_table.TabIndex = 4;
            this.textBox_encrypted_table.Text = "";
            // 
            // button_text_Encrypt
            // 
            this.button_text_Encrypt.Location = new System.Drawing.Point(54, 386);
            this.button_text_Encrypt.Name = "button_text_Encrypt";
            this.button_text_Encrypt.Size = new System.Drawing.Size(85, 23);
            this.button_text_Encrypt.TabIndex = 5;
            this.button_text_Encrypt.Text = "Encrypt";
            this.button_text_Encrypt.UseVisualStyleBackColor = true;
            this.button_text_Encrypt.Click += new System.EventHandler(this.button_text_Encrypt_Click);
            // 
            // button_text_filter
            // 
            this.button_text_filter.Location = new System.Drawing.Point(145, 386);
            this.button_text_filter.Name = "button_text_filter";
            this.button_text_filter.Size = new System.Drawing.Size(88, 23);
            this.button_text_filter.TabIndex = 6;
            this.button_text_filter.Text = "Filter";
            this.button_text_filter.UseVisualStyleBackColor = true;
            this.button_text_filter.Click += new System.EventHandler(this.button_text_filter_Click);
            // 
            // button_text_Decrypt
            // 
            this.button_text_Decrypt.Location = new System.Drawing.Point(239, 386);
            this.button_text_Decrypt.Name = "button_text_Decrypt";
            this.button_text_Decrypt.Size = new System.Drawing.Size(85, 23);
            this.button_text_Decrypt.TabIndex = 7;
            this.button_text_Decrypt.Text = "Decrypt";
            this.button_text_Decrypt.UseVisualStyleBackColor = true;
            this.button_text_Decrypt.Click += new System.EventHandler(this.button_text_Decrypt_Click);
            // 
            // button_keyword
            // 
            this.button_keyword.Location = new System.Drawing.Point(119, 113);
            this.button_keyword.Name = "button_keyword";
            this.button_keyword.Size = new System.Drawing.Size(126, 31);
            this.button_keyword.TabIndex = 8;
            this.button_keyword.Text = "Use keyword";
            this.button_keyword.UseVisualStyleBackColor = true;
            this.button_keyword.Click += new System.EventHandler(this.button_keyword_Click);
            // 
            // textBox_keyword_filtered
            // 
            this.textBox_keyword_filtered.Location = new System.Drawing.Point(599, 89);
            this.textBox_keyword_filtered.Name = "textBox_keyword_filtered";
            this.textBox_keyword_filtered.Size = new System.Drawing.Size(132, 22);
            this.textBox_keyword_filtered.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(54, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Input text:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(448, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Output text:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(399, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Table:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(599, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Filtered keyword:";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(713, 415);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 14;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_info
            // 
            this.button_info.Location = new System.Drawing.Point(632, 415);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(75, 23);
            this.button_info.TabIndex = 15;
            this.button_info.Text = "Info";
            this.button_info.UseVisualStyleBackColor = true;
            this.button_info.Click += new System.EventHandler(this.button_info_Click);
            // 
            // button_language_en
            // 
            this.button_language_en.Location = new System.Drawing.Point(12, 15);
            this.button_language_en.Name = "button_language_en";
            this.button_language_en.Size = new System.Drawing.Size(41, 23);
            this.button_language_en.TabIndex = 16;
            this.button_language_en.Text = "EN";
            this.button_language_en.UseVisualStyleBackColor = true;
            this.button_language_en.Click += new System.EventHandler(this.button_language_en_Click);
            // 
            // button_language_cz
            // 
            this.button_language_cz.Location = new System.Drawing.Point(54, 15);
            this.button_language_cz.Name = "button_language_cz";
            this.button_language_cz.Size = new System.Drawing.Size(41, 23);
            this.button_language_cz.TabIndex = 17;
            this.button_language_cz.Text = "CZ";
            this.button_language_cz.UseVisualStyleBackColor = true;
            this.button_language_cz.Click += new System.EventHandler(this.button_language_cz_Click);
            // 
            // button_keyword_change
            // 
            this.button_keyword_change.Location = new System.Drawing.Point(109, 150);
            this.button_keyword_change.Name = "button_keyword_change";
            this.button_keyword_change.Size = new System.Drawing.Size(149, 29);
            this.button_keyword_change.TabIndex = 18;
            this.button_keyword_change.Text = "Change keyword";
            this.button_keyword_change.UseVisualStyleBackColor = true;
            this.button_keyword_change.Click += new System.EventHandler(this.button_keyword_change_Click);
            // 
            // label_language
            // 
            this.label_language.Location = new System.Drawing.Point(160, 15);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(287, 23);
            this.label_language.TabIndex = 19;
            this.label_language.Text = "Current language:";
            // 
            // button_language_cz_small
            // 
            this.button_language_cz_small.Location = new System.Drawing.Point(98, 15);
            this.button_language_cz_small.Name = "button_language_cz_small";
            this.button_language_cz_small.Size = new System.Drawing.Size(56, 23);
            this.button_language_cz_small.TabIndex = 20;
            this.button_language_cz_small.Text = "CZ(s)";
            this.button_language_cz_small.UseVisualStyleBackColor = true;
            this.button_language_cz_small.Click += new System.EventHandler(this.button_language_cz_small_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_language_cz_small);
            this.Controls.Add(this.label_language);
            this.Controls.Add(this.button_keyword_change);
            this.Controls.Add(this.button_language_cz);
            this.Controls.Add(this.button_language_en);
            this.Controls.Add(this.button_info);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_keyword_filtered);
            this.Controls.Add(this.button_keyword);
            this.Controls.Add(this.button_text_Decrypt);
            this.Controls.Add(this.button_text_filter);
            this.Controls.Add(this.button_text_Encrypt);
            this.Controls.Add(this.textBox_encrypted_table);
            this.Controls.Add(this.textBox_text_output);
            this.Controls.Add(this.textBox_text_input);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_keyword);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button_language_cz_small;

        private System.Windows.Forms.Label label_language;

        private System.Windows.Forms.Button button_language_en;
        private System.Windows.Forms.Button button_language_cz;
        private System.Windows.Forms.Button button_keyword_change;

        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_info;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button button_text_Encrypt;
        private System.Windows.Forms.Button button_text_filter;
        private System.Windows.Forms.Button button_text_Decrypt;
        private System.Windows.Forms.Button button_keyword;
        private System.Windows.Forms.TextBox textBox_keyword_filtered;

        private System.Windows.Forms.RichTextBox textBox_text_output;
        private System.Windows.Forms.RichTextBox textBox_encrypted_table;

        private System.Windows.Forms.RichTextBox textBox_text_input;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBox_keyword;

        #endregion
    }
}