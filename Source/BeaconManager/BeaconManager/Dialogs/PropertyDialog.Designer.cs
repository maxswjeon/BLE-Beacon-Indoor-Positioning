namespace BeaconManager.Dialogs
{
    partial class PropertyDialog
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
            this.label_info = new System.Windows.Forms.Label();
            this.label_uuid = new System.Windows.Forms.Label();
            this.label_ip = new System.Windows.Forms.Label();
            this.label_pos = new System.Windows.Forms.Label();
            this.label_pos_y = new System.Windows.Forms.Label();
            this.label_pos_x = new System.Windows.Forms.Label();
            this.text_x = new System.Windows.Forms.TextBox();
            this.text_y = new System.Windows.Forms.TextBox();
            this.button_enable = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_info.Location = new System.Drawing.Point(8, 9);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(38, 21);
            this.label_info.TabIndex = 15;
            this.label_info.Text = "Info";
            // 
            // label_uuid
            // 
            this.label_uuid.AutoSize = true;
            this.label_uuid.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_uuid.Location = new System.Drawing.Point(8, 51);
            this.label_uuid.Name = "label_uuid";
            this.label_uuid.Size = new System.Drawing.Size(54, 21);
            this.label_uuid.TabIndex = 14;
            this.label_uuid.Text = "UUID : ";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ip.Location = new System.Drawing.Point(8, 30);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(33, 21);
            this.label_ip.TabIndex = 13;
            this.label_ip.Text = "IP : ";
            // 
            // label_pos
            // 
            this.label_pos.AutoSize = true;
            this.label_pos.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pos.Location = new System.Drawing.Point(7, 95);
            this.label_pos.Name = "label_pos";
            this.label_pos.Size = new System.Drawing.Size(67, 21);
            this.label_pos.TabIndex = 18;
            this.label_pos.Text = "Position";
            // 
            // label_pos_y
            // 
            this.label_pos_y.AutoSize = true;
            this.label_pos_y.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pos_y.Location = new System.Drawing.Point(7, 137);
            this.label_pos_y.Name = "label_pos_y";
            this.label_pos_y.Size = new System.Drawing.Size(24, 21);
            this.label_pos_y.TabIndex = 17;
            this.label_pos_y.Text = "Y :";
            // 
            // label_pos_x
            // 
            this.label_pos_x.AutoSize = true;
            this.label_pos_x.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pos_x.Location = new System.Drawing.Point(8, 116);
            this.label_pos_x.Name = "label_pos_x";
            this.label_pos_x.Size = new System.Drawing.Size(25, 21);
            this.label_pos_x.TabIndex = 16;
            this.label_pos_x.Text = "X :";
            // 
            // text_x
            // 
            this.text_x.Location = new System.Drawing.Point(37, 118);
            this.text_x.Name = "text_x";
            this.text_x.Size = new System.Drawing.Size(235, 21);
            this.text_x.TabIndex = 19;
            this.text_x.TextChanged += new System.EventHandler(this.Text_x_TextChanged);
            this.text_x.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Text_x_KeyUp);
            // 
            // text_y
            // 
            this.text_y.Location = new System.Drawing.Point(37, 139);
            this.text_y.Name = "text_y";
            this.text_y.Size = new System.Drawing.Size(235, 21);
            this.text_y.TabIndex = 20;
            this.text_y.TextChanged += new System.EventHandler(this.Text_y_TextChanged);
            this.text_y.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Text_y_KeyUp);
            // 
            // button_enable
            // 
            this.button_enable.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_enable.Location = new System.Drawing.Point(12, 220);
            this.button_enable.Name = "button_enable";
            this.button_enable.Size = new System.Drawing.Size(260, 29);
            this.button_enable.TabIndex = 21;
            this.button_enable.Text = "Disable";
            this.button_enable.UseVisualStyleBackColor = true;
            this.button_enable.Click += new System.EventHandler(this.Button_enable_Click);
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_start.Location = new System.Drawing.Point(12, 185);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(260, 29);
            this.button_start.TabIndex = 22;
            this.button_start.Text = "Stop";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Button_start_Click);
            // 
            // label_status
            // 
            this.label_status.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_status.Location = new System.Drawing.Point(183, 9);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(89, 21);
            this.label_status.TabIndex = 25;
            this.label_status.Text = "Status";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PropertyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_enable);
            this.Controls.Add(this.text_y);
            this.Controls.Add(this.text_x);
            this.Controls.Add(this.label_pos);
            this.Controls.Add(this.label_pos_y);
            this.Controls.Add(this.label_pos_x);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label_uuid);
            this.Controls.Add(this.label_ip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyDialog";
            this.ShowInTaskbar = false;
            this.Text = "PropertyDialog";
            this.Load += new System.EventHandler(this.PropertyDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_uuid;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label_pos;
        private System.Windows.Forms.Label label_pos_y;
        private System.Windows.Forms.Label label_pos_x;
        private System.Windows.Forms.TextBox text_x;
        private System.Windows.Forms.TextBox text_y;
        private System.Windows.Forms.Button button_enable;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_status;
    }
}