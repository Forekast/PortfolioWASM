using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace PortfolioWASM.Services
{
    public class ImageDirectory
    {
        // Image Directory Set-up
        public class Image
        {
            public required string Path { get; set; }
            public required string Name { get; set; }
            public required string? Description { get; set; }
            public required string? Alt { get; set; }
        }

        public class Gallery
		{
            public required string Name { get; set; }
            public required string? Description { get; set; }
            public required Image[] Images { get; set; }

            public string[] FilePaths(string PathPrefix)
            {
                return Images.Select(image => Path.Join(PathPrefix, image.Path)).ToArray();
            }
        }

        public class Collection
        {
            public required string Name { get; set; }
            public required Gallery[] Galleries { get; set; }

            public string[] GalleryList
            {
                get { return Galleries.Select(gallery => Name).ToArray(); }              
            }
        }

    }
}
