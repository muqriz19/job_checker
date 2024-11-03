namespace be.Models;

public class Company {
    public string Name { get; set; } = string.Empty;
}

public class TheCompany : Company {
    public bool IsFeatured { get; set; } = false;
}