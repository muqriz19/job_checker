using be.Models;

namespace be.Interfaces {
    public interface ICompanies {
        public ICollection<Company> GetHRAsiaWinnersCompany(int year);
        public ICollection<TheCompany> GetTheCompanies(int givenYear);
    }
}