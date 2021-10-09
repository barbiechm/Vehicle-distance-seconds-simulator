using System;

namespace vehicle_simulator
{
  class Car : Vehicle
  {
    public override void Drive()
      {
      Console.WriteLine("This vehicle is driven with hands and feets\n"+ 
      "Your steering wheel goes from left to right\nLand vehicle");
      }
  }
 class Airplane : Vehicle
 {
    public override void Drive()
     {
      Console.WriteLine("This vehicle is driven with hands and feets\n"+ 
      "Your steering wheel goes from left to right, then top.\nFlying vehicle");  
     }
 }

}