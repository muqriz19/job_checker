using be.Models;

namespace be.Interfaces {
    public interface ICompanies {
        public ICollection<Company> GetHRAsiaWinnersCompany();
        public ICollection<TheCompany> GetTheCompanies();
    }
}