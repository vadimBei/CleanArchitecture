using Utils.Enums;

namespace Utils.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message) 
            : base(message, ErrorStatusCode.NotFound)
        {
        }

        public NotFoundException(Type type, object entityId)
            : base($"Entity '{type.Name}' was not found with Id: {entityId}", ErrorStatusCode.NotFound)
        {
        }
    }
}
