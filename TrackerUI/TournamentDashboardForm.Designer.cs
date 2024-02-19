namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            headerLabel = new Label();
            createNewTournamentLink = new LinkLabel();
            loadExistingTournamentLabel = new Label();
            loadExistingTournamentDropdown = new ComboBox();
            loadTournamentButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.ForeColor = Color.FromArgb(0, 0, 192);
            headerLabel.Location = new Point(302, 35);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(385, 50);
            headerLabel.TabIndex = 42;
            headerLabel.Text = "Tournament Dashboard";
            // 
            // createNewTournamentLink
            // 
            createNewTournamentLink.AutoSize = true;
            createNewTournamentLink.Location = new Point(540, 128);
            createNewTournamentLink.Name = "createNewTournamentLink";
            createNewTournamentLink.Size = new Size(234, 30);
            createNewTournamentLink.TabIndex = 45;
            createNewTournamentLink.TabStop = true;
            createNewTournamentLink.Text = "Create new Tournament";
            // 
            // loadExistingTournamentLabel
            // 
            loadExistingTournamentLabel.AutoSize = true;
            loadExistingTournamentLabel.Font = new Font("Segoe UI Light", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadExistingTournamentLabel.ForeColor = Color.FromArgb(0, 0, 192);
            loadExistingTournamentLabel.Location = new Point(215, 121);
            loadExistingTournamentLabel.Name = "loadExistingTournamentLabel";
            loadExistingTournamentLabel.Size = new Size(303, 37);
            loadExistingTournamentLabel.TabIndex = 44;
            loadExistingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // loadExistingTournamentDropdown
            // 
            loadExistingTournamentDropdown.FormattingEnabled = true;
            loadExistingTournamentDropdown.Location = new Point(215, 161);
            loadExistingTournamentDropdown.Name = "loadExistingTournamentDropdown";
            loadExistingTournamentDropdown.Size = new Size(559, 38);
            loadExistingTournamentDropdown.TabIndex = 43;
            // 
            // loadTournamentButton
            // 
            loadTournamentButton.FlatAppearance.BorderColor = Color.Silver;
            loadTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            loadTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            loadTournamentButton.FlatStyle = FlatStyle.Flat;
            loadTournamentButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loadTournamentButton.ForeColor = Color.FromArgb(0, 0, 192);
            loadTournamentButton.Location = new Point(366, 223);
            loadTournamentButton.Name = "loadTournamentButton";
            loadTournamentButton.Size = new Size(256, 44);
            loadTournamentButton.TabIndex = 57;
            loadTournamentButton.Text = "Load Tournament";
            loadTournamentButton.UseVisualStyleBackColor = true;
            // 
            // TournamentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(989, 332);
            Controls.Add(loadTournamentButton);
            Controls.Add(createNewTournamentLink);
            Controls.Add(loadExistingTournamentLabel);
            Controls.Add(loadExistingTournamentDropdown);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 0, 192);
            Margin = new Padding(5, 6, 5, 6);
            Name = "TournamentDashboardForm";
            Text = "Tournament Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private LinkLabel createNewTournamentLink;
        private Label loadExistingTournamentLabel;
        private ComboBox loadExistingTournamentDropdown;
        private Button loadTournamentButton;
    }
}