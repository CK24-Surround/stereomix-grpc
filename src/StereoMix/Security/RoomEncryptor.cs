﻿using Microsoft.AspNetCore.Identity;

namespace StereoMix.Security;

public interface IRoomEncryptor
{
    string HashPassword(string roomId, string password);

    PasswordVerificationResult VerifyHashedPassword(string roomId, string hashedPassword, string providedPassword);
}

public class RoomEncryptor : IRoomEncryptor
{
    private readonly PasswordHasher<string> _hasher = new();

    public string HashPassword(string roomId, string password)
    {
        return _hasher.HashPassword(roomId, roomId + password);
    }

    public PasswordVerificationResult VerifyHashedPassword(string roomId, string hashedPassword, string providedPassword)
    {
        return _hasher.VerifyHashedPassword(roomId, hashedPassword, roomId + providedPassword);
    }
}
