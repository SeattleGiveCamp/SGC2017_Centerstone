using System;
using System.IO;

namespace Centerstone.Models
{
    public class HifImage
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public byte[] byteImage { get; set; }
        public void Delete()
        {
            try
            {
                System.IO.File.Delete(Path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static HifImage FromPngStream(Stream stream)
        {
            var id = Guid.NewGuid();
            var fname = id.ToString("N") + ".png";
            var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fname);
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fs);
            }
            return new HifImage()
            {
                Id = id,
                Path = path,
            };
        }
        
    }
}
