﻿using Ecom.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository.Services
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider fileProvider;
        public ImageManagementService() { }

        public ImageManagementService(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            List<string> SaveImageSrc = new List<string>();
            var ImageDirectory = Path.Combine("wwwroot", "Images", src);
            if (Directory.Exists(ImageDirectory) is not true)
            {
                Directory.CreateDirectory(ImageDirectory);
            }
            foreach (var item in files)
            {
                if (item.Length > 0)
                {
                    var ImageName = item.FileName;
                    var ImageSrc = $"/Images/{src}/{ImageName}";
                    var root = Path.Combine(ImageDirectory, ImageName);

                    using (FileStream stream = new FileStream(root, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    SaveImageSrc.Add(ImageName);
                }
            } 
            return SaveImageSrc;

        }

        public void DeleteImageAsync(string src)
        {
            var info=fileProvider.GetFileInfo(src);
            var root=info.PhysicalPath;
            File.Delete(root);
        }
    }
}
