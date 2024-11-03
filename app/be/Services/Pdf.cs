using be.Interfaces;
using UglyToad.PdfPig;

namespace be.Services
{
    public class Pdf : IPdf
    {

        private string getPathOfFileName(string filename, string directoryPath)
        {

            Console.WriteLine(Path.Combine(Environment.CurrentDirectory, directoryPath, filename));

            return Path.Combine(Environment.CurrentDirectory, directoryPath, filename);
        }

        public IList<string> readPDF(string filename, string directoryPath, Func<PdfDocument, IList<string>> operation)
        {
            string pathOfFile = getPathOfFileName(filename, directoryPath);

            using (PdfDocument document = PdfDocument.Open(pathOfFile))
            {
                return operation(document);
            }
        }
    }
}