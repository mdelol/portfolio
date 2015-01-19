using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Navigation;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
namespace OutputDocuments
{
    public class Formatter
    {
        public static void ReplaceTextInDocument(Dictionary<string,string> dictionary,string pathToFile )
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(pathToFile,true))
            {
                var body = doc.MainDocumentPart.Document.Body;
                var keys = dictionary.Keys.ToList();

                var dict = new Dictionary<string, string>();
                foreach (var key in keys)
                {
                    var s = "#{" + key + "}";
                    dict.Add(s,key);
                }

                var newKeys = dict.Keys.ToList();
                foreach (var paragraph in body.Descendants<Paragraph>())
                {
                    foreach (var key in newKeys)
                    {
                        ReplaceTextInParagraph(paragraph,key,dictionary[dict[key]]);
                    }
                }
                doc.Close();
            }
        }

        public static void ReplaceTextInParagraph(Paragraph paragraph, string oldText, string newText)
        {
            var text = paragraph.InnerText;

            RunProperties runProperties = null;

            Run run;
            while ((run = paragraph.GetFirstChild<Run>()) != null)
            {
                if (runProperties == null)
                {
                    runProperties = run.GetFirstChild<RunProperties>();
                }

                run.Remove();
            }

            string str = string.IsNullOrEmpty(oldText) ? newText : text.Replace(oldText, newText);
            var substrs = str.Split('\n');
            for (int i = 0; i < substrs.Length; ++i)
            {
                run = new Run(new Text(substrs[i]));
                if (runProperties != null)
                {
                    run.RunProperties = (RunProperties)runProperties.CloneNode(true);
                }

                paragraph.Append(run);
                if (i < substrs.Length - 1)
                    paragraph.Append(new Break());
            }
        }
    }
}