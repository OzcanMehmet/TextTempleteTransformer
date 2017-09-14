using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTempleteTransformer.PackageTT
{
    [Serializable]
    public class StorageContainer
    {
        public string ListName { get; set; }
        public List<TTPackage> Package{get;set;} 
    }
}
