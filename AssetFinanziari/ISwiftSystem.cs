using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetFinanziari
{
    public interface ISwiftSystem
    {
        public string BICNumber { get; set; }
        public void CreateBICNumber();
    }
}