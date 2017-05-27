namespace MC2017
{
    partial class Value_Unit_GUI
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
            this.accessModifier = new System.Windows.Forms.ComboBox();
            this.checkStatic = new System.Windows.Forms.RadioButton();
            this.checkFinal = new System.Windows.Forms.RadioButton();
            this.type = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accessModifier
            // 
            this.accessModifier.FormattingEnabled = true;
            this.accessModifier.Location = new System.Drawing.Point(0, 0);
            this.accessModifier.Name = "accessModifier";
            this.accessModifier.Size = new System.Drawing.Size(81, 20);
            this.accessModifier.TabIndex = 0;
            // 
            // checkStatic
            // 
            this.checkStatic.AutoSize = true;
            this.checkStatic.Location = new System.Drawing.Point(3, 26);
            this.checkStatic.Name = "checkStatic";
            this.checkStatic.Size = new System.Drawing.Size(53, 16);
            this.checkStatic.TabIndex = 1;
            this.checkStatic.TabStop = true;
            this.checkStatic.Text = "static";
            this.checkStatic.UseVisualStyleBackColor = true;
            // 
            // checkFinal
            // 
            this.checkFinal.AutoSize = true;
            this.checkFinal.Location = new System.Drawing.Point(62, 26);
            this.checkFinal.Name = "checkFinal";
            this.checkFinal.Size = new System.Drawing.Size(46, 16);
            this.checkFinal.TabIndex = 2;
            this.checkFinal.TabStop = true;
            this.checkFinal.Text = "final";
            this.checkFinal.UseVisualStyleBackColor = true;
            // 
            // type
            // 
            this.type.Location = new System.Drawing.Point(87, 0);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(43, 21);
            this.type.TabIndex = 3;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(137, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(73, 21);
            this.name.TabIndex = 4;
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(169, 26);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(41, 19);
            this.create.TabIndex = 5;
            this.create.Text = "생성";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // Value_Unit_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.create);
            this.Controls.Add(this.name);
            this.Controls.Add(this.type);
            this.Controls.Add(this.checkFinal);
            this.Controls.Add(this.checkStatic);
            this.Controls.Add(this.accessModifier);
            this.Name = "Value_Unit_GUI";
            this.Size = new System.Drawing.Size(215, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox accessModifier;
        private System.Windows.Forms.RadioButton checkStatic;
        private System.Windows.Forms.RadioButton checkFinal;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button create;
    }
}
