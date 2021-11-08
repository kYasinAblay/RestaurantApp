using ArdaPos.DataAccess;
using ArdaPos.DataAccess.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
                        subItem[4].Text += " " + $"{DateTime.Now.ToString("HH:mm")}'de tekrar sipariş verildi.";
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
            if (siparisListView.Items.Count > 0)
            {
                var dialog = MessageBox.Show("Bütün Siparişleri Temizlemek İstiyor musunuz ?", "Sipariş Temizle", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dialog == DialogResult.Yes)
                {
                    CreateOrder();
                    siparisListView.Items.Clear();
                }
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
            if (db.Products.Count() == 0)
                SeedData.Initialize(db);

            var productList = await db.Products.ToListAsync();
            grdData.DataSource = productList;
            grdData.Columns["Id"].Visible = false;

            toolTip.SetToolTip(this.btnToplam, "Siparişlerin Toplamını Alır.");
            toolTip.SetToolTip(this.btnSummary, "Daha Önceki Siparişlerin Özetini Gösterir.");
            toolTip.SetToolTip(this.btnDetail, "Daha Önceki Siparişleri Detayıyla Gösterir. (Excel)");
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

            var dialog = MessageBox.Show(tableNo + "'in hesabı: " + sum + " TL. \nHesabı kapatmak istiyor musunuz ?", "Hesap Ekstresi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                CreateOrder(tableNo);
                TakeOwe(tableNo);
            }
        }
        private void btnToplam_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sipariş Listesindeki Toplam Kazanç ; " + Total() + " TL", "Z Raporu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var index = 1;
            foreach (var item in siparisListView.Items)
            {
                var listItem = (item as ListViewItem).SubItems[0];
                listItem.Text = (index++).ToString();
            }
        }
        private void btnSummary_Click(object sender, EventArgs e)
        {
            string summary = "";
            string detail = "";
            var orderList = db.Orders.OrderBy(d => d.Orders).ToList();
            string[] seperate = new string[3];

            var index = 0;
            var total = 0m;
            var final = 0m;
            var price = 0m;
            bool first = true;
            foreach (var order in orderList)
            {
                if (first)
                {
                    seperate = order.Orders.Split("x");

                    if (seperate.Count() != 1)
                        price = order.Amount / decimal.Parse(seperate[1]);
                    else
                        price = order.Amount;
                    first = false;
                }
                if (orderList[index].Orders.Contains(seperate[0]))
                {
                    final += order.Amount;
                    total += order.Amount;
                    summary = seperate[0] + " x " + (total / price).ToString();
                    index++;
                }
                if ((orderList.Count() > index && !orderList[index].Orders.Contains(seperate[0])) || orderList.Count() == index)
                {
                    detail += summary + $" kez satıldı. Toplam : {total} TL\n\n";
                    total = 0;
                    first = true;
                }
            }
            string split = "________________________________________________\n";
            MessageBox.Show(" Sipariş Özeti : \n\n" + detail + split + " Kâr : " + final.ToString() + " TL", "Ne Kadar Satıldı ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDetail_Click(object sender, EventArgs e)
        {
            ExcelPackage excel = new ExcelPackage();

            // name of the sheet
            var workSheet = excel.Workbook.Worksheets.Add("Siparişler");

            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            for (int i = 1; i <= siparisListView.Columns.Count; i++)
            {
                workSheet.Cells[1, i].Value = siparisListView.Columns[i - 1].Text;
            }
            int recordIndex = 2;

            foreach (var order in db.Orders.OrderBy(x => x.Orders).ToList())
            {
                workSheet.Cells[recordIndex, 1].Value = order.Id;
                workSheet.Cells[recordIndex, 2].Value = order.TableNo;
                workSheet.Cells[recordIndex, 3].Value = order.Orders;
                workSheet.Cells[recordIndex, 4].Value = order.Amount;
                workSheet.Cells[recordIndex, 5].Value = order.Description;
                recordIndex++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();

            string p_strPath = "D:\\siparisler-restaurantapp.xlsx";

            if (File.Exists(p_strPath))
                File.Delete(p_strPath);

            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();

            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            excel.Dispose();

            MessageBox.Show("Bütün satışlar, Excel dosyası olarak kaydedildi.\n Dosya yolu: " + p_strPath, "Dosya Adresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
