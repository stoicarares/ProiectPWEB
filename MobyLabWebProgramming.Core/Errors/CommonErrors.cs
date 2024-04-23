using System.Net;

namespace MobyLabWebProgramming.Core.Errors;

/// <summary>
/// Common error messages that may be reused in various places in the code.
/// </summary>
public static class CommonErrors
{
    public static ErrorMessage UserNotFound => new(HttpStatusCode.NotFound, "User doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage FileNotFound => new(HttpStatusCode.NotFound, "File not found on disk!", ErrorCodes.PhysicalFileNotFound);
    public static ErrorMessage TechnicalSupport => new(HttpStatusCode.InternalServerError, "An unknown error occurred, contact the technical support!", ErrorCodes.TechnicalError);
    public static ErrorMessage ProductNotFound => new(HttpStatusCode.NotFound, "Product not found!", ErrorCodes.ProductNotFound);
    public static ErrorMessage ReviewNotFound => new(HttpStatusCode.NotFound, "Review not found!", ErrorCodes.ReviewNotFound);
    public static ErrorMessage ShoppingCartNotFound => new(HttpStatusCode.InternalServerError, "Shopping cart not found!", ErrorCodes.ShoppingCartNotFound);
    public static ErrorMessage Unauthorized => new(HttpStatusCode.Unauthorized, "Unauthorized access!", ErrorCodes.Unauthorized);
    public static ErrorMessage AddressNotFound => new(HttpStatusCode.NotFound, "Address not found", ErrorCodes.AddressNotFound);
}
