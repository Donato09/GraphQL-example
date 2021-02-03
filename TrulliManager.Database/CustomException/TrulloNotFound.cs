using System;
using System.Collections.Generic;
using System.Text;

namespace TrulliManager.Database.CustomException
{
    public class TrulloNotFound : Exception
    {
        public int TrulloId { get; set; }
    }
}
