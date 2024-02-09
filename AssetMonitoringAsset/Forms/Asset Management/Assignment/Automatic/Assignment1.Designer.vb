<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Assignment1
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.dgv = New System.Windows.Forms.DataGridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.TextBox2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.TextBox1)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(5, 5)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1018, 127)
        Me.PanelControl1.TabIndex = 19
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(17, 83)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(322, 25)
        Me.TextBox2.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Requestor :"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(17, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(322, 25)
        Me.TextBox1.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 17)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Request Number :"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.dgv)
        Me.PanelControl2.Location = New System.Drawing.Point(5, 138)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1018, 316)
        Me.PanelControl2.TabIndex = 20
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(2, 2)
        Me.dgv.Name = "dgv"
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv.Size = New System.Drawing.Size(1014, 312)
        Me.dgv.TabIndex = 1
        '
        'Assignment1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 504)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.ColorizeInactiveIcon = DevExpress.Utils.DefaultBoolean.[True]
        Me.IconOptions.ShowIcon = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Assignment1"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Allocation"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents dgv As DataGridView
End Class
