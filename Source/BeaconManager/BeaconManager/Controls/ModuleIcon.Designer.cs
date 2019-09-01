namespace BeaconManager.Controls
{
    partial class ModuleIcon
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item_start = new System.Windows.Forms.ToolStripMenuItem();
            this.item_enable = new System.Windows.Forms.ToolStripMenuItem();
            this.___seperator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.item_properties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_start,
            this.item_enable,
            this.___seperator_1,
            this.item_properties});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(128, 76);
            // 
            // item_start
            // 
            this.item_start.Name = "item_start";
            this.item_start.Size = new System.Drawing.Size(127, 22);
            this.item_start.Text = "Start";
            this.item_start.Click += new System.EventHandler(this.Item_start_Click);
            // 
            // item_enable
            // 
            this.item_enable.Name = "item_enable";
            this.item_enable.Size = new System.Drawing.Size(127, 22);
            this.item_enable.Text = "Disable";
            this.item_enable.Click += new System.EventHandler(this.Item_enable_Click);
            // 
            // ___seperator_1
            // 
            this.___seperator_1.Name = "___seperator_1";
            this.___seperator_1.Size = new System.Drawing.Size(124, 6);
            // 
            // item_properties
            // 
            this.item_properties.Name = "item_properties";
            this.item_properties.Size = new System.Drawing.Size(127, 22);
            this.item_properties.Text = "Properties";
            this.item_properties.Click += new System.EventHandler(this.Item_properties_Click);
            // 
            // ModuleIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "ModuleIcon";
            this.Size = new System.Drawing.Size(15, 15);
            this.Load += new System.EventHandler(this.ModuleIcon_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ModuleIcon_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ModuleIcon_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ModuleIcon_MouseDoubleClick);
            this.MouseHover += new System.EventHandler(this.ModuleIcon_MouseHover);
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem item_start;
        private System.Windows.Forms.ToolStripMenuItem item_enable;
        private System.Windows.Forms.ToolStripSeparator ___seperator_1;
        private System.Windows.Forms.ToolStripMenuItem item_properties;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
