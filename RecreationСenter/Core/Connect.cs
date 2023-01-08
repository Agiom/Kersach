using RecreationСenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecreationСenter.Core
{
    public static class Connect
    {
       public static RelaxBDEntities DB { get; set; }

        public static Frame MyFrame { get; set; }
    }
}
