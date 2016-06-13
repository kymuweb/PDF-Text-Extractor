using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDF_Text_Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfPath = "C:\\mypdf.pdf";
            PdfReader reader = new PdfReader(pdfPath);

            String output = null;
            for (int i = 1; i <= reader.NumberOfPages; i++)
                output = output + PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy());

            // NOTE: It seems that you will not be able to read it cell-by-cell because once the PDF is baked, it's no longer a table with cells, but vectors and text.
            // Other way of obtaining the data: (It could be handy for tables)
            // output = output + PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
            // Some links:
            //http://stackoverflow.com/questions/6956078/read-from-a-pdf-file-using-c-sharp
            //http://stackoverflow.com/questions/6956814/read-tables-from-a-pdf-file-using-c-sharp
            //http://stackoverflow.com/questions/32014589/how-to-read-data-from-table-structured-pdf-using-itextsharp

            Console.Write("PDF Content:" + Environment.NewLine);
            Console.Write(output);
            Console.Write(Environment.NewLine + "--EOF--");
        }
    }
}
