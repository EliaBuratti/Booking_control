namespace Booking_control
{
    internal class Cinema
    {
        static void Main(string[] args)
        {
            int SeatCinema = 50;
            int GroupMaxBooking = 50;
            Bookings newBooking = new Bookings(SeatCinema, GroupMaxBooking);
            int num = 0;

            while (num != 5)
            {
                Console.WriteLine("Welcome in Experis Cinema!, What do you want to do?");

                Console.WriteLine("1 new Booking \n2 check seat are avaiable \n3 delete booking \n4 wiew booking \n5 exit");
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                } 
                catch (Exception ex) 
                {
                    Console.Write($"{ex.Message}\n");
                }
                

                switch (num)
                {
                    case 1:
                        Console.WriteLine("What is your name?");
                        string name = Console.ReadLine();

                        Console.WriteLine("How many seat do you want to booking?");
                        int SeatNum = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(newBooking.NewBooking(name, SeatNum));
                        break;

                    case 2:
                        Console.WriteLine("How many seat do you want to booking?");
                        SeatNum = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(newBooking.CheckSeats(SeatNum).message);
                        break;

                    case 3:
                        Console.WriteLine("What is your name?");
                        name = Console.ReadLine();

                        Console.WriteLine(newBooking.DeleteBooking(name));
                        break;

                    case 4:
                        Console.WriteLine(newBooking.SeeBooking());
                        break;
                }

            }

            Console.WriteLine("exit");
        }
    }
}