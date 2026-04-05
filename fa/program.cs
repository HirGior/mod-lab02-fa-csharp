using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;

    public State()
    {
        Transitions = new Dictionary<char, State>();
    }
  }
  
  public class FA1
  {
    private State start = new State { Name = "staet" };
    private State one1 = new State { Name = "one1" };
    private State one0 = new State { Name = "one0" };
    private State accept = new State { Name = "accept", IsAcceptState = true };
    private State dead = new State { Name = "dead" };

    public FA1()
    {
      start.Transitions['0'] = one0;
      start.Transitions['1'] = one1;

      one1.Transitions['1'] = one1;
      one1.Transitions['0'] = accept;

      one0.Transitions['0'] = dead;
      one0.Transitions['1'] = accept;

      accept.Transitions['0'] = dead;
      accept.Transitions['1'] = accept;

      dead.Transitions['0'] = dead;
      dead.Transitions['1'] = dead;
    }
    
    public bool? Run(IEnumerable<char> s)
    {
      State current = start;
        foreach (var c in s)
        {
            current = current.Transitions[c];
        }
        return current.IsAcceptState;
    }
  }

  public class FA2
  {
    private State ee = new State { Name = "ee" };
    private State oe = new State { Name = "oe" };
    private State eo = new State { Name = "eo" };
    private State oo = new State { Name = "oo", IsAcceptState = true };

    public FA2()
    {
      ee.Transitions['0'] = oe;
      ee.Transitions['1'] = eo;

      oe.Transitions['0'] = ee;
      oe.Transitions['1'] = oo;

      eo.Transitions['0'] = oo;
      eo.Transitions['1'] = ee;

      oo.Transitions['0'] = eo;
      oo.Transitions['1'] = oe;
    }
    
    public bool? Run(IEnumerable<char> s)
    {
      State current = ee;
        foreach (var c in s)
        {
            current = current.Transitions[c];
        }
        return current.IsAcceptState;
    }
  }
  
  public class FA3
  {
    private State start = new State { Name = "start" };
    private State one = new State { Name = "one" };
    private State accept = new State { Name = "accept", IsAcceptState = true };

    public FA3()
    {
      start.Transitions['0'] = start;
      start.Transitions['1'] = one;

      one.Transitions['0'] = start;
      one.Transitions['1'] = accept;

      accept.Transitions['0'] = accept;
      accept.Transitions['1'] = accept;
    }
    
    public bool? Run(IEnumerable<char> s)
    {
      State current = start;
        foreach (var c in s)
        {
            current = current.Transitions[c];
        }
        return current.IsAcceptState;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
