using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class Itextsharp_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnShow_OnClick(object sender, EventArgs e)
    {
        Rectangle rec = new Rectangle(PageSize.A4);
        rec.BackgroundColor = new Color(System.Drawing.Color.Cyan);
        Document pdfdoc=new Document(rec);


        PdfWriter.GetInstance(pdfdoc, Response.OutputStream);


        pdfdoc.Open();

        // Setting Document properties e.g.
        // 1. Title
        // 2. Subject
        // 3. Keywords
        // 4. Creator
        // 5. Author
        // 6. Header
        pdfdoc.AddTitle("Hello World example");
        pdfdoc.AddSubject("This is an Example 4 of Chapter 1 of Book 'iText in Action'");
        pdfdoc.AddKeywords("Metadata, iTextSharp 4, Chapter 1, Tutorial");
        pdfdoc.AddCreator("iTextSharp 4.x");
        pdfdoc.AddAuthor("Debopam Pal");
        pdfdoc.AddHeader("Nothing", "No Header");

        Paragraph para = new Paragraph("    As we already see the iTextSharp.text.Document's constructor takes iTextSharp.text.Paragraph's object during Document creation. So, after creating the Paragraph object and setting Alignment property, we can pass this object to iTextSharp.text.Document's constructor during Document ceration. Lets implement:");
        para.Alignment = Element.ALIGN_JUSTIFIED;
        pdfdoc.Add(para);

        para = new Paragraph("As we already see the iTextSharp.text.Document's constructor takes iTextSharp.text.Paragraph's object during Document creation. So, after creating the Paragraph object and setting Alignment property, we can pass this object to iTextSharp.text.Document's constructor during Document ceration. Lets implement:");
        para.Alignment = Element.ALIGN_LEFT;
        pdfdoc.Add(para);

        para = new Paragraph("As we already see the iTextSharp.text.Document's constructor takes iTextSharp.text.Paragraph's object during Document creation. So, after creating the Paragraph object and setting Alignment property, we can pass this object to iTextSharp.text.Document's constructor during Document ceration. Lets implement:");
        para.Alignment = Element.ALIGN_BASELINE;
        pdfdoc.Add(para);

        PdfPTable table = new PdfPTable(3);
        table.TotalWidth = 400f;
        //fix the absolute width of the table
        table.LockedWidth = true;

        //relative col widths in proportions - 1/3 and 2/3
        float[] widths = new float[] { 2f, 4f, 6f };
        table.SetWidths(widths);
        table.HorizontalAlignment = 0;
        //leave a gap before and after the table
        table.SpacingBefore = 20f;
        table.SpacingAfter = 30f;

        PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
        cell.Colspan = 3;
        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
        table.AddCell(cell);
        table.AddCell("Col 1 Row 1");
        table.AddCell("Col 2 Row 1");
        table.AddCell("Col 3 Row 1");
        table.AddCell("Col 1 Row 2");
        table.AddCell("Col 2 Row 2");
        table.AddCell("Col 3 Row 2");

        pdfdoc.Add(table);

        pdfdoc.Close();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=SampleItext.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfdoc);
        Response.End();


    }
}