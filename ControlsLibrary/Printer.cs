using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLibrary
{
    public static class Printer
    {
        private static System.Drawing.Bitmap memImage { get; set; }
        public static DataTable ToDataTable(ListView lst)
        {
            DataTable dt = new DataTable();
            var columns = lst.Columns.Count;

            foreach (ColumnHeader ch in lst.Columns)
            {
                dt.Columns.Add(ch.Text);
            }

            foreach (ListViewItem item in lst.Items)
            {
                var cells = new object[columns];
                for (var i = 0; i < columns; i++)
                {
                    cells[i] = item.SubItems[i].Text;
                }

                dt.Rows.Add(cells);
            }

            return dt;
        }

        public static bool Print(ListView lv, string title)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Title = "Select export location", Filter = "PDF|*.PDF", DefaultExt = ".PDF" };

            if (sfd.ShowDialog().Equals(DialogResult.OK))
            {
                string path = string.IsNullOrEmpty(sfd.FileName) ? string.Empty : sfd.FileName;
                string file = ToPDF(ToDataTable(lv), title, path);
                return !string.IsNullOrEmpty(file);
            }

            return false;

        }

        public static void Print(Control ctrl, int reduced = 0, bool isA4 = true)
        {
            Capture(ctrl, reduced);
            PrintDocument pdoc = new PrintDocument();
            PaperSize ps = pdoc.PrinterSettings.PaperSizes.Cast<PaperSize>().FirstOrDefault(e => e.PaperName.Equals(isA4 ? "A4" : "A5"));
            pdoc.DefaultPageSettings.PaperSize = ps;
            pdoc.DefaultPageSettings.Landscape = true;
            pdoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
            pdoc.PrintPage += (object sender, PrintPageEventArgs e) =>
              {
                  e.Graphics.DrawImage(memImage, e.MarginBounds);
              };

            PrintDialog pd = new PrintDialog();
            pd.Document = pdoc;

            if (pd.ShowDialog().Equals(DialogResult.OK))
            {
                pdoc.Print();
            }
        }

        private static void Capture(Control ctrl,int reduced)
        {
            System.Drawing.Graphics grps = ctrl.CreateGraphics();
            System.Drawing.Size size = new System.Drawing.Size(ctrl.Width, ctrl.Height - reduced);
            memImage = new System.Drawing.Bitmap(size.Width, size.Height, grps);
            ctrl.DrawToBitmap(memImage, new System.Drawing.Rectangle(0, 0, ctrl.Width, ctrl.Height));
        }

        private static string ToPDF(DataTable dt, string title, string path="")
        {
            path = string.IsNullOrEmpty(path) ? string.Format("{0}temp/temp_{1}.pdf", Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("bin")), DateTime.Now.Ticks) : path;

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
    }
}
