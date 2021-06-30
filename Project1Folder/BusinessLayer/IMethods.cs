using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibrary;

namespace BusinessLayer
{
    public interface IMethods
    {
        public void RegisterCustomer(Customers c);

        public void CreateAndSaveOrder(int i);

        public int FindProductIndex(int id);

    }

}
