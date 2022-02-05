using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Campaign
    {
        public Campaign(int id, DateTime registrationDate, DateTime? confirmationDate)
        {
            Id = id;
            RegistrationDate = registrationDate;
            ConfirmationDate = confirmationDate;
        }

        public int Id { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime? ConfirmationDate { get; private set; }
        public bool Confirmed => ConfirmationDate.HasValue;
        public TimeSpan ConfirmationDelay
        {
            get
            {
                if (ConfirmationDate.HasValue)
                    return ConfirmationDate.Value - RegistrationDate;
                else
                    return DateTime.Today - RegistrationDate;
            }
        }

        public override string ToString()
        {
            var text = new StringBuilder();
            text.Append($"[{Id:d3} @{RegistrationDate:yyyy-MM-dd HH:mm}] ");
            if (ConfirmationDate.HasValue)
                text.Append($"Confirmed @{ConfirmationDate:yyyy-MM-dd HH:mm} (Delay: {ConfirmationDelay.TotalDays:N2} days)");
            else
                text.Append($"waiting for confirmation... (Delay: {ConfirmationDelay.TotalDays:N2} days)");
            return text.ToString();
        }
    }
}
