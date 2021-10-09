using System;
using System.Timers;

namespace vehicle_simulator
{ 
    class Program
    {    
        static void Main(string[] args)
        {  
           double entradaD = 600;  //DEFAULT VALUES
           double entradaV = 120;
           Menu(); 
           Console.WriteLine("Enter the distance, then followed by the <ENTER>, the speed of the vehicle");
           Console.WriteLine("SPACEBAR for stop program and exit");
           try{
           entradaD = Convert.ToDouble(Console.ReadLine());
           entradaV = Convert.ToDouble(Console.ReadLine());
           }catch(FormatException)
           {
                 Console.WriteLine("Incorrect format. Default speed 120km/s and distance 600km");
           }
           Vehicle vehiculo = new Vehicle(); 
           vehiculo.Conversion(entradaD, entradaV);
           vehiculo.StartEngine(); 
        }
        //program Menu
        public static void Menu()
        {
           Car coche = new Car();
           Airplane avion = new Airplane();
           int choose = 1;
           Console.WriteLine("-----------VEHICLE SIMULATOR-----------");
           Console.WriteLine("Choose your vehicle: 1- Car 2- Airplane");
           try
           {
              choose= Convert.ToInt16(Console.ReadLine());
           }
           catch (FormatException)
           {             
               Console.WriteLine("You haven't entered a valid value, I will take default to option 1");
           }     
           switch(choose)
           {
               case 1:             
               coche.Drive();
               break;
               case 2:         
               avion.Drive();
               break;
           }         
        }
   }
    class Vehicle // Class father
    {  
        public static Timer aTmr = new Timer(1000);	
        public static int secondsCount = 0;     //counts seconds  
        public double kmCount = 0;
        double velocity = 0;
        double distance = 0;

        public virtual void Drive() //editable method( polymorphism)
        {
            Console.WriteLine("This vehicle is driven by default");
        }
        public void StartEngine() // timer method
        {         
          aTmr.Elapsed += Counts;
		  aTmr.Enabled = true;
		  aTmr.AutoReset = true;
	      aTmr.Start();
          Console.ReadKey();    
          StopEngine();
        } 
        public static void StopEngine()
        {  
          Console.WriteLine("Stop vehicle");
          aTmr.Stop();

        }
        public double Conversion(double distance, double velocity) 
        {              
           this.distance = distance;
           this.velocity = velocity  / 3600;
           
           return distance / velocity;
        }   
        public void Counts(object sender, ElapsedEventArgs e) //timer
    	{
		secondsCount++;  
        kmCount +=velocity; 
           do
           {
           Console.ForegroundColor = ConsoleColor.Yellow;  //change letters color
		   Console.WriteLine(secondsCount + " seconds " + kmCount + " x km");
           }while(Console.BackgroundColor != ConsoleColor.Black);          
        }
    }  
} 

 

