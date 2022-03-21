namespace ElementLib
{
  public class Beverage : Good
  {
    public int Calories { get; set; }
    public double Alcohol { get; set; }
    public override void Accept(IVisitor visitor)
    {
      visitor.VisitBeverage(this);
    }

    public override string GetHtml() => $"<tr><td>{Name}</td><td>{PricePerUnit}€</td><td>{Weight}g</td><td{Alcohol:0.0}% Alc.</td></tr>";
  }
}
