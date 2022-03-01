using Contracts.ImagesManager;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.ImagesManager
{
    public class ImagesManager: IImagesManager
    {
        private readonly IOptions<AppDomainSettings> _domainSettings;

        public ImagesManager(IOptions<AppDomainSettings> domainSettings)
        {
            _domainSettings = domainSettings;
        }

        public string Url(string path)
        {
            var url = path != "" ? path.Contains("http") ? path : _domainSettings?.Value?.domain_images + path : "";
            return url;
        }
    }
}
