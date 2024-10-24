namespace WinFormsSkPlayGround.Views;

partial class DecodingParametersView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        editFloatingPointSlider1 = new Controls.EditFloatingPointSlider();
        SuspendLayout();
        // 
        // editFloatingPointSlider1
        // 
        editFloatingPointSlider1.Location = new Point(44, 61);
        editFloatingPointSlider1.Name = "editFloatingPointSlider1";
        editFloatingPointSlider1.Size = new Size(397, 64);
        editFloatingPointSlider1.TabIndex = 0;
        editFloatingPointSlider1.Text = "editFloatingPointSlider1";
        // 
        // DecodingParametersView
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(editFloatingPointSlider1);
        Name = "DecodingParametersView";
        Size = new Size(620, 659);
        ResumeLayout(false);
    }

    #endregion

    private Controls.EditFloatingPointSlider editFloatingPointSlider1;
}
