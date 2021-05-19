using Challenge_2.Repository; //note this is actually Chalenge_3.Repository
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3.ProgramUI
{
    public class BadgesUI
    {
        private BadgesRepo _repo = new BadgesRepo();

        public void Run()
        {
            Menu();
        }
    }
}
