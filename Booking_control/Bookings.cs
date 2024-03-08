namespace Booking_control
{
    internal class Bookings
    {
        private int SeatNumber;
        private int GroupMax;
        private int SeatAvaiable;
        private string[] SeatOccuped;


        public Bookings(int seatNumber, int groupMax)
        {
            SeatNumber = seatNumber;
            GroupMax = groupMax;
            SeatAvaiable = seatNumber;
            SeatOccuped = new string[seatNumber];
        }

        public string NewBooking(string NameBooking, int NumSeat)
        {
            if (CheckSeats(NumSeat).avaiable)
            {
                string seatBooked = "";
                for (int i = 0, j = NumSeat; i < SeatOccuped.Length; i++)
                {
                    if (SeatOccuped[i] == null && j > 0)
                    {
                        SeatOccuped[i] = NameBooking;
                        seatBooked += i + " ";
                        SeatAvaiable--;
                        j--;
                    }
                }
                SeatNumber -= NumSeat;
                return "Congrats! " + NameBooking + ". You're seat are booked!\nSeat number:" + seatBooked;
            }

            return CheckSeats(NumSeat).message;
        }

        public (int Seat, bool avaiable, string message) CheckSeats(int NumSeat)
        {
            string message = "Sorry, the seat: " + NumSeat + ". It's not avaiable." + "You must booking for maximum " + (GroupMax >= SeatAvaiable ? GroupMax : SeatAvaiable);

            if (NumSeat <= GroupMax && NumSeat <= SeatAvaiable)
            {
                SeatAvaiable = 0;

                foreach (var Seat in SeatOccuped)
                {
                    if (Seat == null)
                    {
                        SeatAvaiable++;
                    }
                }


                message = "Your seat: " + NumSeat + " are avaiable!";

                if (NumSeat < SeatAvaiable )
                {
                    message = "Sorry we don't have much seat for your booking, we have avaiable: " + SeatAvaiable;
                }

                return (SeatAvaiable, SeatAvaiable >= NumSeat, message);
            }

            message = (SeatAvaiable == 0 ? "Sorry, the cinema is Full." : message);

            return (SeatAvaiable, false, message);


        }

        public string DeleteBooking(string Name)
        {

            if (!SeatOccuped.Contains(Name))
            {
                return "Nothing to delete, this name: \"" + Name + "\" isn't matched with any booking.";
            }

            for (int i = 0; i <= SeatOccuped.Length - 1; i++)
            {
                if (SeatOccuped[i] == Name)
                {
                    SeatOccuped.SetValue(null, i);
                    SeatNumber++;
                    SeatAvaiable++;
                } 
            }

            return "Your Booking: " + Name + ", was deleted!";
        }  

        public string SeeBooking()
        {
            string mapOccupation = "";

            for (int i = 0; i < SeatOccuped.Length; i++)
            {
                mapOccupation += "\nSeat: " + i + "   name: " + (SeatOccuped[i] == null ? "Empty" : SeatOccuped[i]);
            }
            return mapOccupation;
        }
        
    }
}
