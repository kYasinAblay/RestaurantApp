
namespace ArdaPos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnMasa = new System.Windows.Forms.Button();
            this.btnMasa2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHesap2 = new System.Windows.Forms.Button();
            this.btnHesap1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnToplam = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.siparisListView = new System.Windows.Forms.ListView();
            this.colNo = new System.Windows.Forms.ColumnHeader();
            this.colMasaNo = new System.Windows.Forms.ColumnHeader();
            this.colSip = new System.Windows.Forms.ColumnHeader();
            this.colTutar = new System.Windows.Forms.ColumnHeader();
            this.colAciklama = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMasa
            // 
            this.btnMasa.AllowDrop = true;
            this.btnMasa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMasa.Location = new System.Drawing.Point(3, 23);
            this.btnMasa.Name = "btnMasa";
            this.btnMasa.Size = new System.Drawing.Size(219, 339);
            this.btnMasa.TabIndex = 0;
            this.btnMasa.Text = "Masa 1";
            this.btnMasa.UseVisualStyleBackColor = true;
            this.btnMasa.DragDrop += new System.Windows.Forms.DragEventHandler(this.Masa_DragDrop);
            this.btnMasa.DragOver += new System.Windows.Forms.DragEventHandler(this.Masa_DragOver);
            // 
            // btnMasa2
            // 
            this.btnMasa2.AllowDrop = true;
            this.btnMasa2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMasa2.Location = new System.Drawing.Point(3, 362);
            this.btnMasa2.Name = "btnMasa2";
            this.btnMasa2.Size = new System.Drawing.Size(219, 339);
            this.btnMasa2.TabIndex = 0;
            this.btnMasa2.Text = "Masa 2";
            this.btnMasa2.UseVisualStyleBackColor = true;
            this.btnMasa2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Masa_DragDrop);
            this.btnMasa2.DragOver += new System.Windows.Forms.DragEventHandler(this.Masa_DragOver);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHesap2);
            this.groupBox1.Controls.Add(this.btnHesap1);
            this.groupBox1.Controls.Add(this.btnMasa);
            this.groupBox1.Controls.Add(this.btnMasa2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1122, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 704);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Müşteriler";
            // 
            // btnHesap2
            // 
            this.btnHesap2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHesap2.Location = new System.Drawing.Point(151, 635);
            this.btnHesap2.Name = "btnHesap2";
            this.btnHesap2.Size = new System.Drawing.Size(62, 57);
            this.btnHesap2.TabIndex = 2;
            this.btnHesap2.Text = "Hesap";
            this.btnHesap2.UseVisualStyleBackColor = true;
            this.btnHesap2.Click += new System.EventHandler(this.Hesap_Click);
            // 
            // btnHesap1
            // 
            this.btnHesap1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHesap1.Location = new System.Drawing.Point(151, 297);
            this.btnHesap1.Name = "btnHesap1";
            this.btnHesap1.Size = new System.Drawing.Size(62, 57);
            this.btnHesap1.TabIndex = 2;
            this.btnHesap1.Text = "Hesap";
            this.btnHesap1.UseVisualStyleBackColor = true;
            this.btnHesap1.Click += new System.EventHandler(this.Hesap_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.siparisListView);
            this.groupBox2.Controls.Add(this.grdData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1122, 704);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Menü";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btnDetail);
            this.groupBox3.Controls.Add(this.btnSummary);
            this.groupBox3.Controls.Add(this.btnToplam);
            this.groupBox3.Controls.Add(this.btnTemizle);
            this.groupBox3.Location = new System.Drawing.Point(937, 522);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 158);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kasa";
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(40)))), ((int)(((byte)(90)))));
            this.btnDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(3, 93);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(58, 62);
            this.btnDetail.TabIndex = 6;
            this.btnDetail.UseVisualStyleBackColor = false;
            // 
            // btnSummary
            // 
            this.btnSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(54)))), ((int)(((byte)(9)))));
            this.btnSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSummary.Image = ((System.Drawing.Image)(resources.GetObject("btnSummary.Image")));
            this.btnSummary.Location = new System.Drawing.Point(61, 93);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(58, 62);
            this.btnSummary.TabIndex = 5;
            this.btnSummary.UseVisualStyleBackColor = false;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnToplam
            // 
            this.btnToplam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnToplam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToplam.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnToplam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToplam.Image = ((System.Drawing.Image)(resources.GetObject("btnToplam.Image")));
            this.btnToplam.Location = new System.Drawing.Point(3, 23);
            this.btnToplam.Name = "btnToplam";
            this.btnToplam.Size = new System.Drawing.Size(116, 70);
            this.btnToplam.TabIndex = 2;
            this.btnToplam.UseVisualStyleBackColor = false;
            this.btnToplam.Click += new System.EventHandler(this.btnToplam_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnTemizle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Image = ((System.Drawing.Image)(resources.GetObject("btnTemizle.Image")));
            this.btnTemizle.Location = new System.Drawing.Point(119, 23);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(58, 132);
            this.btnTemizle.TabIndex = 2;
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // siparisListView
            // 
            this.siparisListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colMasaNo,
            this.colSip,
            this.colTutar,
            this.colAciklama});
            this.siparisListView.ContextMenuStrip = this.contextMenuStrip;
            this.siparisListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siparisListView.FullRowSelect = true;
            this.siparisListView.GridLines = true;
            this.siparisListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.siparisListView.HideSelection = false;
            this.siparisListView.Location = new System.Drawing.Point(3, 362);
            this.siparisListView.Name = "siparisListView";
            this.siparisListView.Size = new System.Drawing.Size(1116, 339);
            this.siparisListView.TabIndex = 1;
            this.siparisListView.UseCompatibleStateImageBehavior = false;
            this.siparisListView.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No.";
            this.colNo.Width = 100;
            // 
            // colMasaNo
            // 
            this.colMasaNo.Text = "Masa No.";
            this.colMasaNo.Width = 100;
            // 
            // colSip
            // 
            this.colSip.Text = "Siparişler";
            this.colSip.Width = 350;
            // 
            // colTutar
            // 
            this.colTutar.Text = "Tutar";
            this.colTutar.Width = 120;
            // 
            // colAciklama
            // 
            this.colAciklama.Text = "Açıklama";
            this.colAciklama.Width = 400;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(95, 28);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // grdData
            // 
            this.grdData.AllowDrop = true;
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdData.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdData.Location = new System.Drawing.Point(3, 23);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdData.RowHeadersWidth = 51;
            this.grdData.RowTemplate.Height = 29;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(1116, 339);
            this.grdData.TabIndex = 0;
            this.grdData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdData_MouseDown);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 704);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Restaurant";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMasa;
        private System.Windows.Forms.Button btnMasa2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.ListView siparisListView;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colMasaNo;
        private System.Windows.Forms.ColumnHeader colSip;
        private System.Windows.Forms.ColumnHeader colTutar;
        private System.Windows.Forms.ColumnHeader colAciklama;
        private System.Windows.Forms.Button btnToplam;
        private System.Windows.Forms.Button btnHesap2;
        private System.Windows.Forms.Button btnHesap1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}

