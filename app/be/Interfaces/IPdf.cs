using UglyToad.PdfPig;

namespace be.Interfaces
{
    public interface IPdf
    {
        public IList<string> readPDF(string filename, string directoryPath, Func<PdfDocument, IList<string>> operation);
    }
}