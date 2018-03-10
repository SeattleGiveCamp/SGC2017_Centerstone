using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Centerstone.MobileAppService.Data
{
    public partial class Images
    {
        public Images()
        {
            StoredImages = new HashSet<StoredImages>();
        }
        [Key]
        public long ImageId { get; set; }
        public string UniqueImageId { get; set; }
        public string ApplicantGuid { get; set; }
        public long ApplicationId { get; set; }
        public string FileName { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }

        public HifApplication Application { get; set; }
        public ICollection<StoredImages> StoredImages { get; set; }
    }
}
