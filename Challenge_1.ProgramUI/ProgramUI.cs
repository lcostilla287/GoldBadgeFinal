using Challenge_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1.ProgramUI
{
    public class ProgramUI
    {
        private MenuRepo _repo = new MenuRepo();

        public void Run()
        {
            Menu();
        }
    }
}
