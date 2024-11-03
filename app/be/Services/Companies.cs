using be.Interfaces;
using be.Models;
using UglyToad.PdfPig.Content;

namespace be.Services
{
    public class Companies : ICompanies
    {
        private readonly IScraper _scraper;
        private readonly IPdf _pdf;


        public Companies(
            IScraper scrapper,
            IPdf pdf
        )
        {
            _scraper = scrapper;
            _pdf = pdf;
        }

        public ICollection<Company> GetHRAsiaWinnersCompany()
        {
            string url = "https://hr.asia/awards/malaysia-2023/";
            string query = "div.custom-winner .feature_box .feature_box_wrapper";

            ICollection<Company> companies = _scraper.GetItems<Company>(url, query, element =>
            {
                string name = element.InnerText.Trim();
                return new Company { Name = name };
            });

            return companies;
        }

        public IList<string> GetListOfGovLinkedCompanies()
        {
            return _pdf.readPDF("glc-salary-financing_list.pdf", document =>
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
            });
        }
    }
}