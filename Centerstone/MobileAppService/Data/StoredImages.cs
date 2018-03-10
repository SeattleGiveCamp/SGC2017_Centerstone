using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centerstone.MobileAppService.Data
{
    public partial class StoredImages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public long ImageId { get; set; }
        public byte[] ImageData { get; set; }

        public Images Image { get; set; }
    }
}
