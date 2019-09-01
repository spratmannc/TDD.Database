using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Database.Lib
{
    public class PhoneNumber
    {
        public PhoneNumber(string areaCode, string exchange, string number)
        {
            AreaCode = areaCode;
            Exchange = exchange;
            Number = number;
        }

        public PhoneNumber()
        {
        }

        [Key]
        public int PersonId { get; set; }
        public string AreaCode { get; set; }
        public string Exchange { get; set; }
        public string Number { get; set; }
    }

    public interface IPhoneNumberRepository
    {
        PhoneNumber Find(int personId);

        void Save(Person person, PhoneNumber number);
    }
}
