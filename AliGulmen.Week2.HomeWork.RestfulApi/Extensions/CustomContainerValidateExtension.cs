using AliGulmen.Week2.HomeWork.RestfulApi.Entities;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Extensions
{
    public static class CustomContainerValidateExtension
    {
       
            // This extension method used for containers
            // When the container will be updated, changes should be validated
            // Take new container informations as a parameter and compare with the old and default one...
            public static void ValidateWith(this Container existingContainer, Container newContainer)
            {

            existingContainer.containerId = newContainer.containerId != default ? newContainer.containerId : existingContainer.containerId;
            existingContainer.productId = newContainer.productId != default ? newContainer.productId : existingContainer.productId;
            existingContainer.uomId = newContainer.uomId != default ? newContainer.uomId : existingContainer.uomId;
            existingContainer.quantity = newContainer.quantity != default ? newContainer.quantity : existingContainer.quantity;
            existingContainer.locationId = newContainer.locationId != default ? newContainer.locationId : existingContainer.locationId;
            existingContainer.weight = newContainer.weight != default ? newContainer.weight : existingContainer.weight;
            existingContainer.creationDate = newContainer.creationDate != default ? newContainer.creationDate : existingContainer.creationDate;
        }
        
    }
}
