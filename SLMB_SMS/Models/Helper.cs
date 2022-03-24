using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLMB_SMS.Models
{
    public static class Helper
    {
        public static string ConnectionString
        {
            get
            {
                return @"Data Source=DESKTOP-BSJERV7\YAKUBMUCK;Initial Catalog=slmb_db;Integrated Security=True";
            }
        }

        public static void Resize(ListView sender)
        {
            const double per = 100.00;
            double width = sender.Width;
            double count = sender.Columns.Count;

            for(int i = 0; i < sender.Columns.Count; i++)
            {
                ColumnHeader ch = sender.Columns[i];

                if (ch.Text.Contains("#"))
                {
                    count -= 1;
                    width -= 50;
                    ch.Width = 50;
                }
                else
                {
                    var percent = per / count;
                    ch.Width = Convert.ToInt32(percent / per * (width));
                }

            }
        }

        public static bool Connect
        {
            get
            {
                using(System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        return conn.State == System.Data.ConnectionState.Open;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static string PhotosPath { 
            get {
                return string.Format(@"{0}Resources\Avatar", Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("bin")));
            } 
        }

        public static Object Logged { get; set; }
        
        public enum Gender
        {
            Female,
            Male
        }
        
        public enum Colour
        {
            Blue,
            Green,
            Red,
            Yellow
        }
        
        public enum Action
        {
            Create,
            Update
        }
        
        public enum Status
        {
            Enabled,
            Disabled,
            Pending
        }

        public static MemoryStream PictureStream(string path)
        {
            using(FileStream fs = File.OpenRead(path))
            {
                byte[] byts = new byte[fs.Length];
                fs.Read(byts, 0, byts.Length);

                return new MemoryStream(byts, 0, byts.Length);
            }
        }

        public static DataTable ToDataTable(ListView lst)
        {
            DataTable dt = new DataTable();
            var columns = lst.Columns.Count;

            foreach(ColumnHeader ch in lst.Columns)
            {
                dt.Columns.Add(ch.Text);
            }

            foreach(ListViewItem item in lst.Items)
            {
                var cells = new object[columns];
                for(var i = 0; i < columns; i++)
                {
                    cells[i] = item.SubItems[i].Text;
                }

                dt.Rows.Add(cells);
            }

            return dt;
        }

        public static bool DoPrint(DataTable dt, string title)
        {
            PrintDocument doc = new PrintDocument();

            PrintDialog pd = new PrintDialog();
            pd.AllowPrintToFile = true;
            pd.AllowSomePages = true;

            var printing = pd.ShowDialog().Equals(DialogResult.OK);
            if(printing)
            {
                string exported = ToPDF(dt, title);

                try
                {
                    doc.DocumentName = exported;
                    doc.Print();
                    return true;
                }
                catch
                {
                    File.Delete(exported);
                    return false;
                }
            }

            return true;
        }

        private static string ToPDF(DataTable dt, string title)
        {
            string path = string.Format("{0}{1}.pdf", Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("bin")), DateTime.Now.Ticks);

            try
            {
                Document document = new Document(PageSize.A4.Rotate());
                
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                document.Open();
                document.AddHeader("Main", string.Format("SLMB Student Management System {0} Report", title));

                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLUE);
                Paragraph titlePH = new Paragraph(10f, new Chunk("Sierra Leone Muslim Brotherhood", titleFont));
                titlePH.Alignment = 1;
                titlePH.SpacingAfter = 20f;
                document.Add(titlePH);

                Font headFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.GRAY);
                Paragraph ph = new Paragraph(10f, new Chunk(title, headFont));
                ph.Alignment = 0;
                ph.SpacingAfter = 10f;
                document.Add(ph);

                Font rowsFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Font colsFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                float[] widths = new float[dt.Columns.Count];
                table.WidthPercentage = 100;

                foreach (DataColumn dc in dt.Columns)
                {
                    Phrase phrase = new Phrase(new Chunk(dc.ColumnName, colsFont));
                    PdfPCell cell = new PdfPCell(phrase);
                    cell.BackgroundColor = BaseColor.BLACK;
                    table.AddCell(cell);
                }

                foreach (DataRow r in dt.Rows)
                {
                    for (int h = 0; h < dt.Columns.Count; h++)
                    {
                        table.AddCell(new Phrase(r[h].ToString(), rowsFont));
                    }
                }

                document.Add(table);
                document.Close();


                return path;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static bool FieldsCompleted(Control ctrl)
        {
            foreach (Control got in ctrl.Controls)
            {
                if (got.GetType().Equals(new TextBox().GetType()))
                {
                    if (string.IsNullOrEmpty(got.Text))
                        return false;
                }
                else if (got.GetType().Equals(new ComboBox().GetType()))
                {
                    if (((ComboBox)got).SelectedIndex <= 0)
                        return false;
                }
                else if (got.GetType().Equals(new PictureBox().GetType()))
                {
                    if (((PictureBox)got).Image != null)
                        return false;
                }
            }
            return true;
        }

        public static void ShowMessage(Label lbl,string message, bool success = false)
        {
            lbl.Text = message;
            lbl.ForeColor = success ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            Timer timer = new Timer() { Interval = 4000 };
            timer.Start();
            timer.Tick += (object sender, EventArgs e) =>
            {
                lbl.ResetText();
                timer.Dispose();
            };
        }
        
        public static string Upload(int id, string path)
        {
            FileInfo fi = new FileInfo(path);
            string fileName = string.Format("{0}{1}", id, fi.Extension);
            string filePath = string.Format(@"{0}\{1}", PhotosPath, fileName);


            if (!filePath.Equals(path))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] fileBytes = File.ReadAllBytes(path);
                    fs.Write(fileBytes, 0, fileBytes.Length);
                }
            }

            return fileName;
        }
    }
}
