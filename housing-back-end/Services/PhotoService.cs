﻿using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using housing_back_end.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace housing_back_end.Services;

public class PhotoService : IPhotoService
{
    private readonly Cloudinary cloudinary;
    public PhotoService(IConfiguration config)
    {
        Account account = new Account(
            config.GetSection("CloudinarySettings:CloudName").Value,
            config.GetSection("CloudinarySettings:ApiKey").Value,
            config.GetSection("CloudinarySettings:ApiSecret").Value);

        cloudinary = new Cloudinary(account);
    }

    public async Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);

        var result = await cloudinary.DestroyAsync(deleteParams);

        return result;

    }

    public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo)
    {
        var uploadResult = new ImageUploadResult();
        if(photo.Length > 0)
        {
            using var stream = photo.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(photo.FileName, stream),
                Transformation = new Transformation()
                    .Height(500).Width(800)
            };
            uploadResult = await cloudinary.UploadAsync(uploadParams);
        }
        return uploadResult;
    }
}