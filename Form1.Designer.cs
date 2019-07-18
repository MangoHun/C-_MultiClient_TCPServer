namespace MultiClient_TCP_Server
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendClient1 = new System.Windows.Forms.Button();
            this.btnSendClient2 = new System.Windows.Forms.Button();
            this.btnSendClient3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(10, 42);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(485, 325);
            this.txtLog.TabIndex = 0;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(52, 12);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(265, 21);
            this.txtSendMsg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Send";
            // 
            // btnSendClient1
            // 
            this.btnSendClient1.Location = new System.Drawing.Point(323, 9);
            this.btnSendClient1.Name = "btnSendClient1";
            this.btnSendClient1.Size = new System.Drawing.Size(55, 27);
            this.btnSendClient1.TabIndex = 4;
            this.btnSendClient1.Text = "Client1";
            this.btnSendClient1.UseVisualStyleBackColor = true;
            this.btnSendClient1.Click += new System.EventHandler(this.btnSendClient_Click);
            // 
            // btnSendClient2
            // 
            this.btnSendClient2.Location = new System.Drawing.Point(382, 9);
            this.btnSendClient2.Name = "btnSendClient2";
            this.btnSendClient2.Size = new System.Drawing.Size(55, 27);
            this.btnSendClient2.TabIndex = 5;
            this.btnSendClient2.Text = "Client2";
            this.btnSendClient2.UseVisualStyleBackColor = true;
            this.btnSendClient2.Click += new System.EventHandler(this.btnSendClient_Click);
            // 
            // btnSendClient3
            // 
            this.btnSendClient3.Location = new System.Drawing.Point(441, 9);
            this.btnSendClient3.Name = "btnSendClient3";
            this.btnSendClient3.Size = new System.Drawing.Size(55, 27);
            this.btnSendClient3.TabIndex = 6;
            this.btnSendClient3.Text = "Client3";
            this.btnSendClient3.UseVisualStyleBackColor = true;
            this.btnSendClient3.Click += new System.EventHandler(this.btnSendClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 383);
            this.Controls.Add(this.btnSendClient3);
            this.Controls.Add(this.btnSendClient2);
            this.Controls.Add(this.btnSendClient1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendClient1;
        private System.Windows.Forms.Button btnSendClient2;
        private System.Windows.Forms.Button btnSendClient3;
    }
}

