using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncBlackDuck.Model.Objetos
{
    public class FlyoutItemPage
    {
        public FlyoutItemPage()
        {
            TargetType = typeof(FlyoutItemPage);
        }
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}