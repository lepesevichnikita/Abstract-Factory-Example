using System;

namespace AbstractFactoryExample
{
  abstract public class AbstractCat
  {
    public abstract void Mew();
  }

  public class WildCat: AbstractCat
  {
    public override void Mew() { Console.WriteLine("Wild mew"); }
    public override string ToString() { return "Hello, i'm wild cat"; }
  }

  public class HomeCat: AbstractCat
  {
    public override void Mew() { Console.WriteLine("Home mew"); }
  }

  public class DNAMCat: AbstractCat
  {
    public override void Mew() { Console.WriteLine("DNAM mew"); }
  }

  public abstract class AbstractDog
  {
    public abstract void Woof();
  }

  public class WildDog: AbstractDog
  {
    public override void Woof() { Console.WriteLine("Wild woof"); }
  }

  public class HomeDog: AbstractDog
  {
    public override void Woof() { Console.WriteLine("Home woof"); }
  }

  public class DNAMDog: AbstractDog
  {
    public override void Woof() { Console.WriteLine("DNAM woof"); }
  }

  public abstract class AbstractPig
  {
    public abstract void Oink();
  }

  public class WildPig: AbstractPig
  {
    public override void Oink() { Console.WriteLine("Wild oink"); }
  }

  public class HomePig: AbstractPig
  {
    public override void Oink() { Console.WriteLine("Home oink"); }
  }

  public class DNAMPig: AbstractPig
  {
    public override void Oink() { Console.WriteLine("DNAM oink"); }
  }

  public abstract class AbstractAnimalsFactory
  {
    public abstract AbstractCat CreateCat();
    public abstract AbstractDog CreateDog();
    public abstract AbstractPig CreatePig();
  }

  public class WildAnimalsFactory: AbstractAnimalsFactory
  {
    public override AbstractCat CreateCat() { return new WildCat(); }
    public override AbstractDog CreateDog() { return new WildDog(); }
    public override AbstractPig CreatePig() { return new WildPig(); }
  }

  public class HomeAnimalsFactory: AbstractAnimalsFactory 
  {
    public override AbstractCat CreateCat() { return new HomeCat(); }
    public override AbstractDog CreateDog() { return new HomeDog(); }
    public override AbstractPig CreatePig() { return new HomePig(); }
  }

  public class DNAMAnimalsFactory: AbstractAnimalsFactory 
  {
    public override AbstractCat CreateCat() { return new DNAMCat(); }
    public override AbstractDog CreateDog() { return new DNAMDog(); }
    public override AbstractPig CreatePig() { return new DNAMPig(); }
  }

  public class Farm
  {
    public Farm(AbstractAnimalsFactory factory)
    {
      _factory = factory;
    }

    public void CreateCatAndMew()
    {
      AbstractCat cat = _factory.CreateCat();
      cat.Mew();
    }

    public void CreateDogAndWoof()
    {
      AbstractDog dog = _factory.CreateDog();
      dog.Woof();
    }

    public void CreatePigAndOink()
    {
      AbstractPig pig = _factory.CreatePig();
      pig.Oink();
    }


    private AbstractAnimalsFactory _factory { get; set; }
  }

  class Program
  {
    static void Main(string[] args)
    {
      WildAnimalsFactory wildFactory = new WildAnimalsFactory();
      HomeAnimalsFactory homeFactory = new HomeAnimalsFactory();
      DNAMAnimalsFactory dnamFactory = new DNAMAnimalsFactory();

      Farm wildFarm = new Farm(wildFactory);
      Farm homeFarm = new Farm(homeFactory);
      Farm dnamFarm = new Farm(dnamFactory);

      wildFarm.CreateCatAndMew();
      wildFarm.CreateDogAndWoof();
      wildFarm.CreatePigAndOink();

      homeFarm.CreateCatAndMew();
      homeFarm.CreateDogAndWoof();
      homeFarm.CreatePigAndOink();

      dnamFarm.CreateCatAndMew();
      dnamFarm.CreateDogAndWoof();
      dnamFarm.CreatePigAndOink();

      Console.WriteLine(wildFactory.CreateCat());
    }
  }
}
