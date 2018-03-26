namespace Cinema.UI
{
    partial class FormAdmin
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
            this.movies = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.employees = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // movies
            // 
            this.movies.Location = new System.Drawing.Point(25, 99);
            this.movies.Name = "movies";
            this.movies.Size = new System.Drawing.Size(75, 23);
            this.movies.TabIndex = 0;
            this.movies.Text = "Movies";
            this.movies.UseVisualStyleBackColor = true;
            this.movies.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // employees
            // 
            this.employees.Location = new System.Drawing.Point(163, 99);
            this.employees.Name = "employees";
            this.employees.Size = new System.Drawing.Size(75, 23);
            this.employees.TabIndex = 2;
            this.employees.Text = "Employees";
            this.employees.UseVisualStyleBackColor = true;
            this.employees.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.employees);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.movies);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button movies;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button employees;
    }
}