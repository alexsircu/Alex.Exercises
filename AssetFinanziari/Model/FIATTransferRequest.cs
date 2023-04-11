using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetFinanziari.Model
{
    internal class FIATTransferRequest
    {
        string _assetName;
        decimal _amount;
        long _IBANfrom;
        long _IBANto;

        public string AssetName { get { return _assetName; } set { _assetName = value; } }
        public decimal Amount { get { return _amount; } set { _amount = value; } }
        public long IBANFrom { get { return _IBANfrom; } set { _IBANfrom = value; } }
        public long IBANTo { get { return _IBANto; } set { _IBANto = value; } }
    }
}
