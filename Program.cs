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

            Console.Write("PDF Content:" + Environment.NewLine);
            Console.Write(output);
            Console.Write(Environment.NewLine + "--EOF--");
        }
    }
}
