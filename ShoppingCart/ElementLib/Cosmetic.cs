namespace ElementLib
{
  public class Cosmetic : Good
  {
    public override void Accept(IVisitor visitor)
    {
      visitor.VisitCosmetic(this);
    }

    public override string GetHtml() => $"<tr><td>{Name}</td><td>{PricePerUnit}€</td><td>{Weight}g</td><td>&nbsp;</td></tr>";
  }
}
