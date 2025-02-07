
using be.Models;

public class JobCheckerViewModel {
    public ICollection<TheCompany> ListOfCompines {get; set;}
    public int SelectedYear {get; set;}

    public JobCheckerViewModel() {
        ListOfCompines = [];
    }
}