using be.Interfaces;
using UglyToad.PdfPig;

namespace be.Services
{
    public class Pdf : IPdf
    {

        private string getPathOfFileName(string filename)
        {
            return Path.GetFullPath(filename);
        }

        public IList<string> readPDF(string filename, Func<PdfDocument, IList<string>> operation)
        {
            string pathOfFile = getPathOfFileName(filename);

            using (PdfDocument document = PdfDocument.Open(pathOfFile))
            {
                return operation(document);
            }
        }
    }
}