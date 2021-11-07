﻿using ArdaPos.DataAccess;
using ArdaPos.DataAccess.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArdaPos
{
    public partial class Form1 : Form
    {
        DataContext db;
        int selectRowIndex = -1;
        public Form1()
        {
            InitializeComponent();
            db = CreateDbContext();
        }

        private void Masa_DragOver(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        private void Masa_DragDrop(object sender, DragEventArgs e)
        {
            Button masa = sender as Button;
            var values = e.Data.GetData(typeof(String)).ToString().Split(",");

            var itemCount = siparisListView.Items.Count;

            itemCount++;
            if (itemCount == 1)
            {
                ListViewItem item = new ListViewItem(
                  new[]
                  {
                     itemCount.ToString(),
                     masa.Text == "Masa 1" ? "Masa 1" : "Masa 2",
                     values[0],
                     values[1],
                     $"{DateTime.Now.ToString("HH:mm")}'de sipariş edildi."
                  });

                siparisListView.Items.Add(item);
            }
            else
            {
                var index = 0;
                foreach (var listItem in siparisListView.Items)
                {
                    var subItem = (listItem as ListViewItem).SubItems;

                    if (subItem[2].Text.Contains(values[0]) && subItem[1].Text == masa.Text)
                    {
                        var price = decimal.Parse(values[1]);
                        var subItemPrice = decimal.Parse(subItem[3].Text);
                        var total = price + subItemPrice;

                        subItem[3].Text = total.ToString();
                        subItem[2].Text = values[0] + " x " + total / price;
                        subItem[4].Text += ", " + $"{DateTime.Now.ToString("HH:mm")}'de tekrar sipariş verildi.";
                        break;
                    }
                    index++;
                    if (siparisListView.Items.Count == index)
                    {
                        ListViewItem item = new ListViewItem(new[] { itemCount.ToString(), masa.Text == "Masa 1" ? "Masa 1" : "Masa 2", values[0], values[1], $"{DateTime.Now.ToString("HH:mm")}'de sipariş edildi." });
                        siparisListView.Items.Add(item);
                    }
                }
            }
        }
        private void grdData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grdData.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        int id = (int)grdData.Rows[info.RowIndex].Cells["Id"].Value;
                        var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
                        var text = string.Join(",", product.Name, product.Price);

                        if (product != null)
                        {
                            grdData.DoDragDrop(text, DragDropEffects.Move);
                        }
                    }
                }
            }
        }
        private void TakeOwe(string text = "")
        {
            foreach (var item in siparisListView.Items)
            {
                var listViewItem = (item as ListViewItem);
                if (listViewItem.SubItems[1].Text.Contains(text) || text == "")
                {
                    siparisListView.Items.Remove(listViewItem);
                }
            }
        }
        private decimal Total(string text = "")
        {
            var total = 0m;
            foreach (var item in siparisListView.Items)
            {
                var subItem = (item as ListViewItem).SubItems;
                if (subItem[1].Text.Contains(text) || text == "")
                {
                    total += decimal.Parse(subItem[3].Text.ToString());
                }
            }
            return total;
        }
        private void CreateOrder(string text = "")
        {
            foreach (var item in siparisListView.Items)
            {
                var subItem = (item as ListViewItem).SubItems;
                if (subItem[1].Text.Contains(text) || text == "")
                {
                    db.Add(new Order
                    {
                        TableNo = subItem[1].Text.ToString(),
                        Orders = subItem[2].Text.ToString(),
                        Amount = decimal.Parse(subItem[3].Text.ToString()),
                        Description = subItem[4].Text.ToString(),
                    });
                }
                db.SaveChanges();
            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Bütün Siparişleri Temizlemek İstiyor musunuz ?", "Sipariş Temizle", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dialog == DialogResult.Yes)
            {
                CreateOrder();
                siparisListView.Items.Clear();
            }
        }
        public DataContext CreateDbContext()
        {
            var path = @Directory.GetCurrentDirectory() + "/../../../appsettings.json";
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(path).Build();
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("DbConStr");
            builder.UseSqlServer(connectionString);
            return new DataContext(builder.Options);
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            if (db.Products == null)
                SeedData.Initialize(db);

            var productList = await db.Products.ToListAsync();
            grdData.DataSource = productList;
            grdData.Columns["Id"].Visible = false;

            toolTip.SetToolTip(this.btnToplam, "Siparişlerin Toplamını Alır.");
            toolTip.SetToolTip(this.btnSummary, "Daha Önceki Siparişlerin Özetini Gösterir.");
            toolTip.SetToolTip(this.btnDetail, "Daha Önceki Siparişleri Detayıyla Gösterir.");
            toolTip.SetToolTip(this.btnTemizle, "Listedeki Siparişleri Temizler.");
            toolTip.SetToolTip(this.btnHesap1, "Masa 1'in Hesabını Alır.");
            toolTip.SetToolTip(this.btnHesap2, "Masa 2'nin Hesabını Alır.");
        }

        private void Hesap_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tableNo = button.Name == "btnHesap1" ? "Masa 1" : "Masa 2";

            var sum = Total(tableNo);
            if (sum == 0)
                return;

            var dialog = MessageBox.Show(tableNo + "'in hesabı: " + sum + " TL. \nÖdemek istiyor musunuz ?", "Hesap Ekstresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                CreateOrder(tableNo);
                TakeOwe(tableNo);
            }
        }

        private void btnToplam_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bugün Toplam Kazanç ; " + Total() + " TL", "Z Raporu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var indices = siparisListView.SelectedIndices;
            if (indices.Count != 0)
            {
                selectRowIndex = indices[0];
            }
            if (selectRowIndex != -1)
            {
                siparisListView.Items[selectRowIndex].Remove();
            }
        }
    }
}