using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplication.Entities
{
    public partial class CreditsEntities
    {
        private static CreditsEntities _context;
        public static CreditsEntities GetContext()
        {
            if(_context is null) 
                _context = new CreditsEntities();
            return _context;
        }
    }
}
