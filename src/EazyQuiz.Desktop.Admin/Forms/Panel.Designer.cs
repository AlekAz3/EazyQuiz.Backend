namespace EazyQuiz.Desktop.Admin;

partial class Panel
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
            this.QuestionInput = new System.Windows.Forms.RichTextBox();
            this.IsFirstAnswerCorrect = new System.Windows.Forms.RadioButton();
            this.FirstAnswerInput = new System.Windows.Forms.RichTextBox();
            this.SecondAnswerInput = new System.Windows.Forms.RichTextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.ThirdAnswerInput = new System.Windows.Forms.RichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ForthAnswerInput = new System.Windows.Forms.RichTextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QuestionInput
            // 
            this.QuestionInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QuestionInput.Location = new System.Drawing.Point(49, 34);
            this.QuestionInput.Name = "QuestionInput";
            this.QuestionInput.Size = new System.Drawing.Size(394, 94);
            this.QuestionInput.TabIndex = 0;
            this.QuestionInput.Text = "";
            // 
            // IsFirstAnswerCorrect
            // 
            this.IsFirstAnswerCorrect.AutoSize = true;
            this.IsFirstAnswerCorrect.Location = new System.Drawing.Point(27, 182);
            this.IsFirstAnswerCorrect.Name = "IsFirstAnswerCorrect";
            this.IsFirstAnswerCorrect.Size = new System.Drawing.Size(14, 13);
            this.IsFirstAnswerCorrect.TabIndex = 1;
            this.IsFirstAnswerCorrect.TabStop = true;
            this.IsFirstAnswerCorrect.UseVisualStyleBackColor = true;
            // 
            // FirstAnswerInput
            // 
            this.FirstAnswerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FirstAnswerInput.Location = new System.Drawing.Point(49, 174);
            this.FirstAnswerInput.Name = "FirstAnswerInput";
            this.FirstAnswerInput.Size = new System.Drawing.Size(394, 48);
            this.FirstAnswerInput.TabIndex = 5;
            this.FirstAnswerInput.Text = "";
            // 
            // SecondAnswerInput
            // 
            this.SecondAnswerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SecondAnswerInput.Location = new System.Drawing.Point(49, 257);
            this.SecondAnswerInput.Name = "SecondAnswerInput";
            this.SecondAnswerInput.Size = new System.Drawing.Size(394, 48);
            this.SecondAnswerInput.TabIndex = 7;
            this.SecondAnswerInput.Text = "";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(27, 265);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(14, 13);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // ThirdAnswerInput
            // 
            this.ThirdAnswerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ThirdAnswerInput.Location = new System.Drawing.Point(47, 355);
            this.ThirdAnswerInput.Name = "ThirdAnswerInput";
            this.ThirdAnswerInput.Size = new System.Drawing.Size(394, 48);
            this.ThirdAnswerInput.TabIndex = 9;
            this.ThirdAnswerInput.Text = "";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(27, 374);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // ForthAnswerInput
            // 
            this.ForthAnswerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForthAnswerInput.Location = new System.Drawing.Point(47, 446);
            this.ForthAnswerInput.Name = "ForthAnswerInput";
            this.ForthAnswerInput.Size = new System.Drawing.Size(394, 48);
            this.ForthAnswerInput.TabIndex = 11;
            this.ForthAnswerInput.Text = "";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(27, 467);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Send
            // 
            this.Send.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Send.Location = new System.Drawing.Point(47, 528);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(394, 39);
            this.Send.TabIndex = 12;
            this.Send.Text = "ќтправить";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.SendQuestionToServer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(49, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "¬ведите вопрос";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(47, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "¬ведите первый ответ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(49, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "¬ведите второй ответ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(47, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "¬ведите третий ответ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(47, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "¬ведите четверный ответ";
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 604);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.ForthAnswerInput);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.ThirdAnswerInput);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.SecondAnswerInput);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.FirstAnswerInput);
            this.Controls.Add(this.IsFirstAnswerCorrect);
            this.Controls.Add(this.QuestionInput);
            this.Name = "Panel";
            this.Text = "Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private RichTextBox QuestionInput;
    private RadioButton IsFirstAnswerCorrect;
    private RichTextBox FirstAnswerInput;
    private RichTextBox SecondAnswerInput;
    private RadioButton radioButton4;
    private RichTextBox ThirdAnswerInput;
    private RadioButton radioButton1;
    private RichTextBox ForthAnswerInput;
    private RadioButton radioButton2;
    private Button Send;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
}
