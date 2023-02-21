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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.TokenLabel = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusLabel.Location = new System.Drawing.Point(88, 111);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(52, 21);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "label1";
            // 
            // TokenLabel
            // 
            this.TokenLabel.Location = new System.Drawing.Point(110, 226);
            this.TokenLabel.Name = "TokenLabel";
            this.TokenLabel.Size = new System.Drawing.Size(255, 133);
            this.TokenLabel.TabIndex = 1;
            this.TokenLabel.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TokenLabel);
            this.Controls.Add(this.StatusLabel);
            this.Name = "Panel";
            this.Text = "Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label StatusLabel;
    private RichTextBox TokenLabel;
    private Button button1;
}
