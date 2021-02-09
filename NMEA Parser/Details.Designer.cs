
namespace NMEA_Parser
{
	partial class Details
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
			this.DetailedInfoGrid = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.DetailedInfoGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// DetailedInfoGrid
			// 
			this.DetailedInfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DetailedInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailedInfoGrid.Location = new System.Drawing.Point(0, 0);
			this.DetailedInfoGrid.Name = "DetailedInfoGrid";
			this.DetailedInfoGrid.RowTemplate.Height = 25;
			this.DetailedInfoGrid.Size = new System.Drawing.Size(800, 450);
			this.DetailedInfoGrid.TabIndex = 0;
			// 
			// Details
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.DetailedInfoGrid);
			this.Name = "Details";
			this.Text = "Details";
			this.Load += new System.EventHandler(this.Details_Load);
			((System.ComponentModel.ISupportInitialize)(this.DetailedInfoGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DetailedInfoGrid;
	}
}