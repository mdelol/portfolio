using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
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
                foreach (var text in body.Descendants<Text>())
                {
                    foreach (var key in keys)
                    {
                        if (!text.Text.Contains("#" + "{" + key + "}")) continue;
                        var textForReplace = "";
                        dictionary.TryGetValue(key,out textForReplace);
                        text.Text = text.Text.Replace("#" + "{" + key + "}", textForReplace);
                    }
                }
                doc.Close();
            }
        }
    }
}