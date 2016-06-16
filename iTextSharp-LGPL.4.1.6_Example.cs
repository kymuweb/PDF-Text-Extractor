using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDF_Text_Extractor
{
    class iTextSharpLGPL416Example
    {
        static void Main(string[] args)
        {
            string pdfPath = "C:\\mypdf.pdf";
            PdfReader reader = new PdfReader(pdfPath);
            StringBuilder sb = new StringBuilder();

            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                var cpage = reader.GetPageN(page);
                var content = cpage.Get(PdfName.CONTENTS);
                var ir = (PRIndirectReference)content;
                var value = reader.GetPdfObject(ir.Number);
                if (value.IsStream())
                {
                    PRStream stream = (PRStream)value;
                    var streamBytes = PdfReader.GetStreamBytes(stream);
                    var tokenizer = new PRTokeniser(new RandomAccessFileOrArray(streamBytes));

                    try
                    {
                        while (tokenizer.NextToken())
                        {
                            if (tokenizer.TokenType == PRTokeniser.TK_STRING)
                            {
                                string str = tokenizer.StringValue;
                                sb.Append(str);
                            }
                        }
                    }
                    finally
                    {
                        tokenizer.Close();
                    }
                }
            }
            
            Console.Write("PDF Content:" + Environment.NewLine);
            Console.Write(sb.ToString());
            Console.Write(Environment.NewLine + "--EOF--");
        }
    }
}
