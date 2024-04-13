using Graphic3D.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic3D
{
    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            using (Window game = new Window())
            {
                game.Run();
            }
        }       
    }
}
