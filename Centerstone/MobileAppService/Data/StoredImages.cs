using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Data
{
    public partial class StoredImages
    {
        public long RowId { get; set; }
        public long ImageId { get; set; }
        public byte[] ImageData { get; set; }

        public Images Image { get; set; }
    }
}
