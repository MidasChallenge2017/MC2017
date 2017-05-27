namespace MC2017
{
    partial class MethodUnit_GUI
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
            this.type = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.checkStatic = new System.Windows.Forms.RadioButton();
            this.checkAbstract = new System.Windows.Forms.RadioButton();
            this.create = new System.Windows.Forms.Button();
            this.param = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // accessModifier
            // 
            this.accessModifier.FormattingEnabled = true;
            this.accessModifier.Items.AddRange(new object[] {
            "public",
            "private",
            "protected"});
            this.accessModifier.Location = new System.Drawing.Point(0, 0);
            this.accessModifier.Name = "accessModifier";
            this.accessModifier.Size = new System.Drawing.Size(81, 20);
            this.accessModifier.TabIndex = 0;
            // 
            // type
            // 
            this.type.Location = new System.Drawing.Point(87, 0);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(43, 21);
            this.type.TabIndex = 4;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(137, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(73, 21);
            this.name.TabIndex = 5;
            // 
            // checkStatic
            // 
            this.checkStatic.AutoSize = true;
            this.checkStatic.Location = new System.Drawing.Point(3, 51);
            this.checkStatic.Name = "checkStatic";
            this.checkStatic.Size = new System.Drawing.Size(53, 16);
            this.checkStatic.TabIndex = 6;
            this.checkStatic.TabStop = true;
            this.checkStatic.Text = "static";
            this.checkStatic.UseVisualStyleBackColor = true;
            // 
            // checkAbstract
            // 
            this.checkAbstract.AutoSize = true;
            this.checkAbstract.Location = new System.Drawing.Point(62, 51);
            this.checkAbstract.Name = "checkAbstract";
            this.checkAbstract.Size = new System.Drawing.Size(68, 16);
            this.checkAbstract.TabIndex = 7;
            this.checkAbstract.TabStop = true;
            this.checkAbstract.Text = "abstract";
            this.checkAbstract.UseVisualStyleBackColor = true;
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(169, 48);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(41, 19);
            this.create.TabIndex = 8;
            this.create.Text = "생성";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // param
            // 
            this.param.Location = new System.Drawing.Point(0, 26);
            this.param.Name = "param";
            this.param.Size = new System.Drawing.Size(210, 21);
            this.param.TabIndex = 9;
            // 
            // MethodUnit_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.param);
            this.Controls.Add(this.create);
            this.Controls.Add(this.checkAbstract);
            this.Controls.Add(this.checkStatic);
            this.Controls.Add(this.name);
            this.Controls.Add(this.type);
            this.Controls.Add(this.accessModifier);
            this.Name = "MethodUnit_GUI";
            this.Size = new System.Drawing.Size(215, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox accessModifier;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.RadioButton checkStatic;
        private System.Windows.Forms.RadioButton checkAbstract;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.TextBox param;
    }
}
