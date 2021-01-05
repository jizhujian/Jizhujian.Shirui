
namespace Jizhujian.Shirui
{
  partial class MainForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Step1Button = new System.Windows.Forms.Button();
      this.Step2Button = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // Step1Button
      // 
      this.Step1Button.Location = new System.Drawing.Point(56, 60);
      this.Step1Button.Name = "Step1Button";
      this.Step1Button.Size = new System.Drawing.Size(301, 73);
      this.Step1Button.TabIndex = 0;
      this.Step1Button.Text = "第1步：分析考勤原始记录";
      this.Step1Button.UseVisualStyleBackColor = true;
      this.Step1Button.Click += new System.EventHandler(this.Step1Button_Click);
      // 
      // Step2Button
      // 
      this.Step2Button.Location = new System.Drawing.Point(56, 241);
      this.Step2Button.Name = "Step2Button";
      this.Step2Button.Size = new System.Drawing.Size(301, 73);
      this.Step2Button.TabIndex = 1;
      this.Step2Button.Text = "第2步：输出考勤数据";
      this.Step2Button.UseVisualStyleBackColor = true;
      this.Step2Button.Click += new System.EventHandler(this.Step2Button_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(407, 84);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(316, 24);
      this.label1.TabIndex = 2;
      this.label1.Text = "请检查、修正处理结果后再进行下一步";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(407, 265);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(208, 24);
      this.label2.TabIndex = 3;
      this.label2.Text = "调整扣除工时后汇总考勤";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.Step2Button);
      this.Controls.Add(this.Step1Button);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "世睿考勤";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button Step1Button;
    private System.Windows.Forms.Button Step2Button;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}

