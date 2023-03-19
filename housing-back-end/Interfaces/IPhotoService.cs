using CloudinaryDotNet.Actions;

namespace housing_back_end.Interfaces;

public interface IPhotoService
{
    Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);

    //will add onre more method for deleting the photo
    Task<DeletionResult> DeletePhotoAsync(string publicId);
}