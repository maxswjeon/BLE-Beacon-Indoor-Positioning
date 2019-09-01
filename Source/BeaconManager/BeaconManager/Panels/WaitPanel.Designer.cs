namespace BeaconManager.Panels
{
    partial class WaitPanel
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
            this.label_wait = new System.Windows.Forms.Label();
            this.progress_wait = new System.Windows.Forms.ProgressBar();
            this.label_count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_wait
            // 
            this.label_wait.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_wait.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_wait.Location = new System.Drawing.Point(203, 140);
            this.label_wait.Name = "label_wait";
            this.label_wait.Size = new System.Drawing.Size(137, 33);
            this.label_wait.TabIndex = 0;
            this.label_wait.Text = "Scanning...";
            this.label_wait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progress_wait
            // 
            this.progress_wait.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress_wait.Location = new System.Drawing.Point(71, 200);
            this.progress_wait.Name = "progress_wait";
            this.progress_wait.Size = new System.Drawing.Size(400, 23);
            this.progress_wait.TabIndex = 1;
            // 
            // label_count
            // 
            this.label_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_count.Location = new System.Drawing.Point(430, 226);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(41, 18);
            this.label_count.TabIndex = 2;
            this.label_count.Text = "0/254";
            // 
            // WaitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.progress_wait);
            this.Controls.Add(this.label_wait);
            this.Name = "WaitPanel";
            this.Size = new System.Drawing.Size(542, 368);
            this.Load += new System.EventHandler(this.WaitPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_wait;
        private System.Windows.Forms.ProgressBar progress_wait;
        private System.Windows.Forms.Label label_count;
    }
}
