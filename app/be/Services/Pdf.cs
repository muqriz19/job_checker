using be.Interfaces;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace be.Services
{
    public class Pdf : IPdf
    {
        public IList<string> readPdf()
        {
            using (PdfDocument document = PdfDocument.Open("/home/m/Projects/Workspace/Code/job_checker/app/be/Assets/Documents/glc-salary-financing_list.pdf"))
            {
                bool hasStarted = false;
                IList<string> texts = [];

                foreach (Page page in document.GetPages())
                {
                    string pageText = page.Text;

                    IList<Word> words = page.GetWords().ToList();

                    string finalText = "";

                    for (int i = 0; i < words.Count(); i++)
                    {
                        string theText = words[i].Text;
                        Console.WriteLine(words[i].Text);
                        bool isNumeric = Int32.TryParse(theText, out int result);


                        if (isNumeric && !hasStarted)
                        {
                            hasStarted = true;

                            continue;
                        }
                        else
                        {
                            if (!isNumeric && hasStarted)
                            {
                                finalText += theText + " ";
                            }
                            else if (isNumeric && hasStarted)
                            {
                                texts.Add(finalText);
                                finalText = "";
                                // end here
                                hasStarted = false;
                                continue;
                            }
                        }
                    }
                }
                return texts;
            }

        }
    }
}