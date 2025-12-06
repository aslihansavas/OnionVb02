namespace OnionVb02.ValidatorStructure.Exceptions;

// Kayıt bulunamadı hatası
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string entityName, int id) : base($"{entityName} bulunamadı. ID: {id}") { }
}

// İş kuralı hatası
public class BusinessException : Exception
{
    public BusinessException(string message) : base(message) { }
}

// Yetkilendirme hatası
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message = "Bu işlem için yetkiniz yok.") : base(message) { }
}

// Çakışma hatası (örn: zaten var)
public class ConflictException : Exception
{
    public ConflictException(string message) : base(message) { }
}

