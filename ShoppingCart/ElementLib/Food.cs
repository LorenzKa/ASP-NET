namespace ElementLib
{
  public class Food : Good
  {
    public int Calories { get; set; }
    public override void Accept(IVisitor visitor)
    {
      visitor.VisitFood(this);
    }

    public override string GetHtml() => $"<tr><td>{Name}</td><td>{PricePerUnit}€</td><td>{Weight}g</td><td{Calories} kcal</td></tr>";
  }
}
